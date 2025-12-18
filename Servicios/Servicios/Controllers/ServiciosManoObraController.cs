using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Servicios.Data;
using Servicios.Models;
using Servicios.Models.ViewModels;

namespace Servicios.Controllers
{
    public class ServiciosManoObraController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiciosManoObraController(ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================
        // INDEX
        // =========================
        public async Task<IActionResult> Index(ServicioManoObraFiltroVm filtro)
        {
            filtro ??= new ServicioManoObraFiltroVm();

            filtro.Pagina = filtro.Pagina <= 0 ? 1 : filtro.Pagina;
            filtro.TamPagina = filtro.TamPagina <= 0 ? 10 : filtro.TamPagina;
            filtro.Orden = string.IsNullOrWhiteSpace(filtro.Orden) ? "nombre" : filtro.Orden;

            // Si SoloActivos == false, hay que ignorar QueryFilters para ver inactivos
            IQueryable<ServicioManoObra> query =
                (filtro.SoloActivos == false)
                    ? _context.ServiciosManoObra.IgnoreQueryFilters()
                    : _context.ServiciosManoObra;

            query = query.Include(s => s.CategoriaServicio);

            if (!string.IsNullOrWhiteSpace(filtro.Buscar))
            {
                var txt = filtro.Buscar.Trim();
                query = query.Where(s => s.Nombre.Contains(txt) || (s.Codigo ?? "").Contains(txt));
            }

            if (filtro.CategoriaServicioId.HasValue && filtro.CategoriaServicioId.Value > 0)
            {
                query = query.Where(s => s.CategoriaServicioId == filtro.CategoriaServicioId.Value);
            }

            if (filtro.SoloGarantia == true)
            {
                query = query.Where(s => s.EsGarantia);
            }

            if (filtro.SoloActivos == true)
            {
                query = query.Where(s => s.Activo);
            }

            var orden = filtro.Orden.ToLowerInvariant();
            query = orden switch
            {
                "precioasc" => query.OrderBy(s => s.ValorConIva),
                "preciodesc" => query.OrderByDescending(s => s.ValorConIva),
                "horas" => query.OrderByDescending(s => s.Horas),
                _ => query.OrderBy(s => s.Nombre)
            };

            var totalRegistros = await query.CountAsync();

            var servicios = await query
                .Skip((filtro.Pagina - 1) * filtro.TamPagina)
                .Take(filtro.TamPagina)
                .AsNoTracking()
                .ToListAsync();

            // Categorías para el filtro del Index (ViewBag.CategoriasFiltro)
            ViewBag.CategoriasFiltro = await _context.CategoriasServicio
                .IgnoreQueryFilters()
                .OrderBy(c => c.Nombre)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Nombre,
                    Selected = filtro.CategoriaServicioId.HasValue && filtro.CategoriaServicioId.Value == c.Id
                })
                .ToListAsync();

            return View(new ServicioManoObraIndexVm
            {
                Servicios = servicios,
                Filtro = filtro,
                PaginaActual = filtro.Pagina,
                TotalRegistros = totalRegistros,
                TotalPaginas = (int)Math.Ceiling(totalRegistros / (double)filtro.TamPagina)
            });
        }

        // =========================
        // DETAILS
        // =========================
        public async Task<IActionResult> Details(int id)
        {
            var servicio = await _context.ServiciosManoObra
                .IgnoreQueryFilters()
                .Include(s => s.CategoriaServicio)
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);

            if (servicio == null) return NotFound();

            return View(servicio); // @model ServicioManoObra
        }

        // =========================
        // CREATE (GET)
        // =========================
        public async Task<IActionResult> Create()
        {
            await CargarCategorias(); // ✅ ViewBag.Categorias (para el partial)
            return View(new ServicioManoObraFormVm());
        }

        // =========================
        // CREATE (POST)
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServicioManoObraFormVm vm)
        {
            if (!ModelState.IsValid)
            {
                await CargarCategorias(); // ✅ importante para re-render
                return View(vm);
            }

            // Codigo es requerido en DB, si viene vacío generamos uno
            var codigo = string.IsNullOrWhiteSpace(vm.Codigo)
                ? await GenerarCodigoAsync()
                : vm.Codigo.Trim();

            var entity = new ServicioManoObra
            {
                Codigo = codigo,
                Nombre = vm.Nombre.Trim(),
                Descripcion = vm.Descripcion?.Trim(),
                CategoriaServicioId = vm.CategoriaServicioId,
                Horas = vm.Horas,
                TarifaHora = vm.TarifaHora,
                DescuentoPorc = vm.DescuentoPorc,
                IvaPorc = vm.IvaPorc,
                EsGarantia = vm.EsGarantia,
                Activo = vm.Activo,
                FechaCreacion = DateTime.Now
            };

            _context.ServiciosManoObra.Add(entity);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // =========================
        // EDIT (GET)
        // =========================
        public async Task<IActionResult> Edit(int id)
        {
            var servicio = await _context.ServiciosManoObra
                .IgnoreQueryFilters()
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);

            if (servicio == null) return NotFound();

            var vm = new ServicioManoObraFormVm
            {
                Id = servicio.Id,
                Codigo = servicio.Codigo,
                Nombre = servicio.Nombre,
                Descripcion = servicio.Descripcion,
                CategoriaServicioId = servicio.CategoriaServicioId,
                Horas = servicio.Horas,
                TarifaHora = servicio.TarifaHora,
                DescuentoPorc = servicio.DescuentoPorc,
                IvaPorc = servicio.IvaPorc,
                EsGarantia = servicio.EsGarantia,
                Activo = servicio.Activo
            };

            await CargarCategorias(); // ✅ ViewBag.Categorias para el partial
            return View(vm);
        }

        // =========================
        // EDIT (POST)
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ServicioManoObraFormVm vm)
        {
            if (id != vm.Id) return NotFound();

            if (!ModelState.IsValid)
            {
                await CargarCategorias(); // ✅ importante
                return View(vm);
            }

            var servicio = await _context.ServiciosManoObra
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(s => s.Id == id);

            if (servicio == null) return NotFound();

            if (!string.IsNullOrWhiteSpace(vm.Codigo))
                servicio.Codigo = vm.Codigo.Trim();

            servicio.Nombre = vm.Nombre.Trim();
            servicio.Descripcion = vm.Descripcion?.Trim();
            servicio.CategoriaServicioId = vm.CategoriaServicioId;
            servicio.Horas = vm.Horas;
            servicio.TarifaHora = vm.TarifaHora;
            servicio.DescuentoPorc = vm.DescuentoPorc;
            servicio.IvaPorc = vm.IvaPorc;
            servicio.EsGarantia = vm.EsGarantia;
            servicio.Activo = vm.Activo;
            servicio.FechaActualizacion = DateTime.Now;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // =========================
        // DESACTIVAR / ACTIVAR
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Desactivar(int id, ServicioManoObraFiltroVm filtro)
        {
            var servicio = await _context.ServiciosManoObra
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(s => s.Id == id);

            if (servicio == null) return NotFound();

            servicio.Activo = false;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), new
            {
                filtro.Buscar,
                filtro.CategoriaServicioId,
                filtro.SoloGarantia,
                filtro.SoloActivos,
                filtro.Orden,
                filtro.Pagina,
                filtro.TamPagina
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Activar(int id, ServicioManoObraFiltroVm filtro)
        {
            var servicio = await _context.ServiciosManoObra
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(s => s.Id == id);

            if (servicio == null) return NotFound();

            servicio.Activo = true;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), new
            {
                filtro.Buscar,
                filtro.CategoriaServicioId,
                filtro.SoloGarantia,
                filtro.SoloActivos,
                filtro.Orden,
                filtro.Pagina,
                filtro.TamPagina
            });
        }

        // =========================
        // HELPERS
        // =========================
        private async Task CargarCategorias()
        {
            // ✅ ESTE ES EL QUE TU PARTIAL ESPERA: ViewBag.Categorias
            ViewBag.Categorias = await _context.CategoriasServicio
                .IgnoreQueryFilters()
                .OrderBy(c => c.Nombre)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Nombre
                })
                .ToListAsync();
        }

        private async Task<string> GenerarCodigoAsync()
        {
            var ultimoId = await _context.ServiciosManoObra
                .IgnoreQueryFilters()
                .OrderByDescending(x => x.Id)
                .Select(x => x.Id)
                .FirstOrDefaultAsync();

            var next = ultimoId + 1;
            return $"MO-{next:000000}";
        }
    }
}
