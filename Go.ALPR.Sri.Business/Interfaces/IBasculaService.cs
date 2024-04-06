using System;
using System.Threading.Tasks;

namespace Go.ALPR.Sri.Business
{
    public interface IBasculaService
    {
        bool ConfigurarPuerto();

        bool BasculaOffline();

        bool ModoContinuo();

        BasculaDto ObtenerPeso();

        int ObtenerPesoReal();

        int ComprobarPesoEstable();

        void ConfigurarControlValidezPeso(IProgress<int> progreso);

        void ResetLecturaBascula();
    }
}
