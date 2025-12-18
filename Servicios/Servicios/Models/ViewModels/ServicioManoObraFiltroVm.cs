using System.ComponentModel.DataAnnotations;

namespace Servicios.Models.ViewModels
{
    public class ServicioManoObraFiltroVm
    {
        [Display(Name = "Buscar")]
        public string? Buscar { get; set; }

        [Display(Name = "Categoría")]
        public int? CategoriaServicioId { get; set; }

        [Display(Name = "Solo garantía")]
        public bool? SoloGarantia { get; set; }

        [Display(Name = "Solo activos")]
        public bool? SoloActivos { get; set; } = true;

        // nombre | precioAsc | precioDesc | horas
        public string Orden { get; set; } = "nombre";

        // Paginación
        public int Pagina { get; set; } = 1;
        public int TamPagina { get; set; } = 10;
    }
}
