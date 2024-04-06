using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Go.ALPR.Sri.Business
{
    public interface ITransporteService
    {
        Task<IPagedList<TransporteDto>> ObtenerListaPaginada(
            string Matricula,
            string Remolque,
            string Conductor,
            string Empresa,
            byte Tipo,
            string TipoCarga,
            int pageNumber = 1,
            int pageSize = 10);

        bool CheckTransporteExiste(string matricula);

        TransporteCompletoDto ObtenerTransporte(string matricula);

        bool Guardar(TransporteDto transporte);

        bool Eliminar(TransporteDto transporte);

        void Actualizar(string matricula, string conductor);

    }
}
