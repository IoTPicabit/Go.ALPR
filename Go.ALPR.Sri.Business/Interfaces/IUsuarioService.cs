using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Go.ALPR.Sri.Business
{
    public interface IUsuarioService
    {
        List<UsuarioDto> ObtenerLista();

        Task<bool> Guardar(UsuarioDto usuario);

        Task<bool> Eliminar(UsuarioDto usuario);

        Task<bool> Reiniciar(UsuarioDto usuario);

        bool ExisteMismoLogin(string login, int idUsuario);
    }
}
