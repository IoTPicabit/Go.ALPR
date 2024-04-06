using System;
using System.Threading.Tasks;

namespace Go.ALPR.Sri.Business
{
    public interface IIdentificacionService
    {
        Task<IdentificacionDto> ObtenerIdentificacion(byte tipo, IProgress<string> progreso);

        IdentificacionDto ObtenerIdentificacionVacia(byte tipo);

        Task<bool> Eliminar(string id);

        Task CancelarIdentificacion();
    }
}
