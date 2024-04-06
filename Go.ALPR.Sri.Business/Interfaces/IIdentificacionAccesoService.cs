using System;
using System.Threading.Tasks;

namespace Go.ALPR.Sri.Business
{
    public interface IIdentificacionAccesoService
    {
        Task<IdentificacionDto> ObtenerIdentificacion(byte tipo, IProgress<string> progreso);

        IdentificacionDto ObtenerIdentificacionVacia(byte tipo);

        Task<bool> RegistrarAcceso(string id, bool resultado);
    }
}
