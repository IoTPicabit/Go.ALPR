using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Go.ALPR.Sri.Business
{
    public interface ILocalizacionService
    {
        Task<IPagedList<LocalizacionDto>> ObtenerListaPaginada(
            string Nombre,
            byte Tipo,
            string CIF,
            string NIMA,
            bool? Habilitado,
            int pageNumber = 1,
            int pageSize = 10);

        LocalizacionDto ObtenerPorNombre(string nombre);

        List<LocalizacionDto> ObtenerLista(bool soloHabilitados = false);

        bool Guardar(LocalizacionDto localizacion);

        bool Eliminar(LocalizacionDto localizacion);

        bool CreadoSiNoExiste(string nombre, byte tipo);
    }
}
