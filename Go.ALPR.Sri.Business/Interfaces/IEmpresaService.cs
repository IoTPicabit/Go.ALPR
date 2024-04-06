using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Go.ALPR.Sri.Business
{
    public interface IEmpresaService
    {

        Task<IPagedList<EmpresaDto>> ObtenerListaPaginada(
            string Nombre,
            string CIF,
            string NIMA,
            bool? Habilitado,
            int pageNumber = 1,
            int pageSize = 10);

        List<EmpresaDto> ObtenerLista(bool soloHabilitados = false);
        List<EmpresaDto> ObtenerExpedidores();

        EmpresaDto ObtenerPorNombre(string nombre);

        bool Guardar(EmpresaDto empresa);

        bool Eliminar(EmpresaDto empresa);
    }
}
