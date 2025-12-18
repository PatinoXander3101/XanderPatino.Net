using System.ComponentModel.DataAnnotations;

namespace Servicios.Models.ViewModels
{
    public class ServicioManoObraFormVm
    {
        public int Id { get; set; }

        [Display(Name = "Código")]
        public string? Codigo { get; set; } // Autogenerado

        [Required(ErrorMessage = "El nombre del servicio es obligatorio.")]
        [StringLength(120)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Descripcion { get; set; }

        [Display(Name = "Categoría")]
        [Required(ErrorMessage = "La categoría es obligatoria.")]
        public int CategoriaServicioId { get; set; }

        [Range(0.25, 100)]
        public decimal Horas { get; set; }

        [Display(Name = "Tarifa por hora")]
        [Range(0, 1_000_000)]
        public decimal TarifaHora { get; set; }

        [Display(Name = "Descuento (%)")]
        [Range(0, 100)]
        public decimal DescuentoPorc { get; set; }

        [Display(Name = "IVA (%)")]
        [Range(0, 100)]
        public decimal IvaPorc { get; set; } = 19m;

        [Display(Name = "Es garantía")]
        public bool EsGarantia { get; set; }

        public bool Activo { get; set; } = true;
    }
}
