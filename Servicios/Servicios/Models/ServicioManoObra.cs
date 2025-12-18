using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Servicios.Models
{
    public class ServicioManoObra
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El código es obligatorio.")]
        [StringLength(20, ErrorMessage = "El código no puede superar los 20 caracteres.")]
        public string Codigo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre del servicio es obligatorio.")]
        [StringLength(120, ErrorMessage = "El nombre no puede superar los 120 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "La descripción no puede superar los 500 caracteres.")]
        public string? Descripcion { get; set; }

        // ✅ FK real
        [Display(Name = "Categoría")]
        [Required(ErrorMessage = "La categoría es obligatoria.")]
        public int CategoriaServicioId { get; set; }

        public CategoriaServicio? CategoriaServicio { get; set; }

        [Range(0.25, 100, ErrorMessage = "Las horas deben estar entre 0.25 y 100.")]
        public decimal Horas { get; set; }

        [Range(0, 1_000_000, ErrorMessage = "La tarifa por hora no es válida.")]
        public decimal TarifaHora { get; set; }

        [Range(0, 100, ErrorMessage = "El descuento debe estar entre 0 y 100%.")]
        public decimal DescuentoPorc { get; set; }

        [Range(0, 100, ErrorMessage = "El IVA debe estar entre 0 y 100%.")]
        public decimal IvaPorc { get; set; } = 19m;

        [Display(Name = "Es servicio de garantía")]
        public bool EsGarantia { get; set; }

        public bool Activo { get; set; } = true;

        // Auditoría
        [Display(Name = "Fecha de creación")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [Display(Name = "Fecha de actualización")]
        public DateTime? FechaActualizacion { get; set; }

        [StringLength(100)]
        public string? CreadoPor { get; set; }

        [StringLength(100)]
        public string? ActualizadoPor { get; set; }

        // Calculadas (no se guardan)
        [NotMapped]
        [Display(Name = "Valor base")]
        public decimal ValorBase => Horas * TarifaHora;

        [NotMapped]
        [Display(Name = "Subtotal (con descuento)")]
        public decimal SubTotal
        {
            get
            {
                var descuento = ValorBase * (DescuentoPorc / 100m);
                return ValorBase - descuento;
            }
        }

        [NotMapped]
        [Display(Name = "Valor IVA")]
        public decimal ValorIva => SubTotal * (IvaPorc / 100m);

        [NotMapped]
        [Display(Name = "Valor total con IVA")]
        public decimal ValorConIva => SubTotal + ValorIva;
    }
}
