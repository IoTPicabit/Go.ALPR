using System;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Go.ALPR.Sri.Business
{
    public interface IMainFormBusiness
    {
        void Inicializar();       

        List<LocalizacionDto> ObtenerListaLocalizaciones();

        List<EmpresaDto> ObtenerListaExpedidores();

        Task<MainFormDto> NuevaEntrada(IProgress<string> progreso);

        Task<MainFormDto> NuevaSalida(IProgress<string> progreso);

        int Guardar(MainFormDto datos);

        Task<bool> Eliminar(MainFormDto datos);

        MainFormDto IdentificacionManualTransporte(byte tipo, string matricula);

        bool ConfigurarBascula();

        bool BasculaOffline();

        bool BaculaEnModoContinuo();
        
        string ObtenerLecturaBascula(); //TODO: pruebas

        Task<byte[]> ObtenerAlbaran(int idOperacion);

        Task<byte[]> ObtenerCartaPorte(int idOperacion);

        Task<DataTable> ObtenerDatosAlbaran(int idOperacion);

        Task<Dictionary<string, string>> ObtenerListaEmails(int idOperacion);

        int ObtenerPesoReal();

        int ComprobarPesoEstable();

        void ControlValidezPeso(IProgress<int> peso);

        void ResetLecturaBascula();

    }
}
