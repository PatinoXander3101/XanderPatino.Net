using System.Collections.Generic;

namespace Servicios.Models.ViewModels
{
    public class CategoriaServicioIndexVm
    {
        public List<CategoriaServicio> Categorias { get; set; } = new();

        public string? Buscar { get; set; }
        public bool MostrarInactivas { get; set; }

        public int PaginaActual { get; set; }
        public int TotalPaginas { get; set; }
        public int TotalRegistros { get; set; }
    }
}
