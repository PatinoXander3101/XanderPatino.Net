using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Servicios.Models
{
    public class CategoriaServicio
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(80, ErrorMessage = "El nombre no puede superar los 80 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "La descripción no puede superar los 200 caracteres.")]
        public string? Descripcion { get; set; }

        public bool Activo { get; set; } = true;

        // Auditoría
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime? FechaActualizacion { get; set; }

        [StringLength(100)]
        public string? CreadoPor { get; set; }

        [StringLength(100)]
        public string? ActualizadoPor { get; set; }

        // Navegación (opcional pero recomendado)
        public ICollection<ServicioManoObra> Servicios { get; set; } = new List<ServicioManoObra>();
    }
}
