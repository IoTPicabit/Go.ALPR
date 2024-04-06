using System;
using System.Threading.Tasks;
using X.PagedList;

namespace Go.ALPR.Sri.Business
{
    public interface IAccesoService
    {
        Task<IPagedList<AccesoDto>> ObtenerListaPaginada(
            DateTime FechaInicio,
            DateTime FechaFin,
            string Matricula,
            int Acceso,
            int pageNumber = 1,
            int pageSize = 10
        );
    }
}
