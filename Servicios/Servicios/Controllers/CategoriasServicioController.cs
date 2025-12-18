using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Servicios.Data;
using Servicios.Models;

namespace Servicios.Controllers
{
    public class CategoriasServicioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriasServicioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CategoriasServicio
        public async Task<IActionResult> Index(string? buscar, bool mostrarInactivas = false, int pagina = 1, int tamPagina = 10)
        {
            var query = mostrarInactivas
                ? _context.CategoriasServicio.IgnoreQueryFilters().AsQueryable()
                : _context.CategoriasServicio.AsQueryable();

            if (!string.IsNullOrWhiteSpace(buscar))
            {
                var texto = buscar.Trim();
                query = query.Where(c => c.Nombre.Contains(texto) || (c.Descripcion ?? "").Contains(texto));
            }

            query = query.OrderBy(c => c.Nombre);

            var totalRegistros = await query.CountAsync();
            pagina = pagina <= 0 ? 1 : pagina;
            tamPagina = tamPagina <= 0 ? 10 : tamPagina;

            var categorias = await query
                .Skip((pagina - 1) * tamPagina)
                .Take(tamPagina)
                .AsNoTracking()
                .ToListAsync();

            ViewBag.Buscar = buscar;
            ViewBag.MostrarInactivas = mostrarInactivas;
            ViewBag.PaginaActual = pagina;
            ViewBag.TotalPaginas = (int)Math.Ceiling(totalRegistros / (double)tamPagina);
            ViewBag.TotalRegistros = totalRegistros;
            ViewBag.TamPagina = tamPagina;

            return View(categorias);
        }

        // GET: CategoriasServicio/Create
        public IActionResult Create()
        {
            return View(new CategoriaServicio());
        }

        // POST: CategoriasServicio/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoriaServicio categoria)
        {
            if (ModelState.IsValid)
            {
                categoria.Activo = true;
                _context.CategoriasServicio.Add(categoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }

        // GET: CategoriasServicio/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var categoria = await _context.CategoriasServicio
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (categoria == null) return NotFound();
            return View(categoria);
        }

        // POST: CategoriasServicio/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoriaServicio categoria)
        {
            if (id != categoria.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var original = await _context.CategoriasServicio
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (original == null) return NotFound();

                original.Nombre = categoria.Nombre;
                original.Descripcion = categoria.Descripcion;
                original.Activo = categoria.Activo;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { mostrarInactivas = true });
            }

            return View(categoria);
        }

        // POST: CategoriasServicio/Desactivar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Desactivar(int id, string? buscar, int pagina = 1, int tamPagina = 10)
        {
            var categoria = await _context.CategoriasServicio.FindAsync(id);
            if (categoria == null) return NotFound();

            categoria.Activo = false;
            await _context.SaveChangesAsync();

            // Para que NO desaparezca en la vista, volvemos mostrando inactivas
            return RedirectToAction(nameof(Index), new
            {
                buscar,
                mostrarInactivas = true,
                pagina,
                tamPagina
            });
        }

        // POST: CategoriasServicio/Activar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Activar(int id, string? buscar, int pagina = 1, int tamPagina = 10)
        {
            var categoria = await _context.CategoriasServicio
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (categoria == null) return NotFound();

            categoria.Activo = true;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), new
            {
                buscar,
                mostrarInactivas = true,
                pagina,
                tamPagina
            });
        }
    }
}
