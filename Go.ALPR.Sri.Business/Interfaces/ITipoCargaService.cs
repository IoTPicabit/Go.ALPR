using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Go.ALPR.Sri.Business
{
    public interface ITipoCargaService
    {

        Task<IPagedList<TipoCargaDto>> ObtenerListaPaginada(
            string Nombre,
            byte Tipo,
            string LER,
            string ADR,
            int pageNumber = 1,
            int pageSize = 10);

        List<TipoCargaDto> ObtenerLista();

        List<TipoCargaDto> ObtenerListaPadres(int id);

        Task<bool> Guardar(TipoCargaDto tipocarga);

        Task<bool> Eliminar(TipoCargaDto tipocarga);
    }
}
