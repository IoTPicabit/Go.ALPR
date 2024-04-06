using System;
using System.Threading.Tasks;
using X.PagedList;

namespace Go.ALPR.Sri.Business
{
    public interface IControlAccesoFormBusiness
    {
        void Inicializar(); 

        Task<MainFormDto> NuevaEntrada(IProgress<string> progreso);

        Task<IPagedList<AccesoDto>> ObtenerListaAccesos(
            DateTime FechaInicio,
            DateTime FechaFin,
            string Matricula,
            int Acceso,
            int pageNumber = 1,
            int pageSize = 10
        );

    }
}
