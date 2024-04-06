using System.Threading.Tasks;

namespace Go.ALPR.Sri.Business
{
    public interface ISeguridadService
    {
        Task<bool> ComprobarLogin(string usuario, string clave);

        Task<bool> CambiarClave(int id, string clave);
    }
}
