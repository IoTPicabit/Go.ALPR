using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;
using System.Data;

namespace Go.ALPR.Sri.Business
{
    public interface IOperacionService
    {
        Task<IPagedList<OperacionDto>> ObtenerListaPaginada(
            int Numero, 
            string Matricula,
            string Remolque,
            string Conductor,
            string Empresa,
            byte Tipo,
            DateTime FechaInicio,
            DateTime FechaFin,
            string TipoCarga,
            int pageNumber = 1, 
            int pageSize = 10);

        OperacionDto ObtenerEntradaPrevia(string matricula);

        int GuardarEntrada(OperacionDto datos, FotoDto fotos);

        int GuardarSalida(OperacionDto datos, FotoDto fotos);

        Task<byte[]> ObtenerAlbaran(int id);

        Task<byte[]> ObtenerCartaPorte(int id);

        FotosOperacionDto ObtenerFotosOperacion(int id);

        Task<Dictionary<string, string>> ObtenerListaEmails(int id);

        Task<DataTable> ObtenerDatosAlbaran(int id);        
    }
}
