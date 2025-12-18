using System.Collections.Generic;

namespace Servicios.Models.ViewModels
{
    public class ServicioManoObraIndexVm
    {
        public List<ServicioManoObra> Servicios { get; set; } = new();

        public ServicioManoObraFiltroVm Filtro { get; set; } = new();

        public int PaginaActual { get; set; }
        public int TotalPaginas { get; set; }
        public int TotalRegistros { get; set; }
    }
}
