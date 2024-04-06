using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

using Microsoft.EntityFrameworkCore;

using Go.ALPR.Sri.Common;
using Go.ALPR.Sri.SqlServer;
using Go.ALPR.Sri.SqlServer.Entities;

namespace Go.ALPR.Sri.Business
{
    public class SeguridadService: ISeguridadService
    {
        private readonly ILogger<SeguridadService> _logger;
        private readonly SRIDbContext _dbContext;

        private UsuarioSesionDto _usuarioSesion;

        public SeguridadService(ILogger<SeguridadService> logger, SRIDbContext dbContext, UsuarioSesionDto usuarioSesion)
        {
            _logger = logger;
            _dbContext = dbContext;
            _usuarioSesion = usuarioSesion;
        }

        public async Task<bool> ComprobarLogin(string usuario, string clave)
        {
            _logger.LogTrace($"{this.TraceMethod(new { usuario })} - INICIO");

            bool result = false;
            try
            {
                var entity = await _dbContext.Usuarios.Where(e => e.Login.Equals(usuario) && (e.Clave.Equals(clave) || e.Clave == null)).FirstOrDefaultAsync<Usuario>();

                if(entity != null)
                {
                    result = true;
                    _usuarioSesion.IdUsuario = entity.IdUsuario;
                    _usuarioSesion.Nombre = entity.Nombre;
                    _usuarioSesion.Login = entity.Login;
                    _usuarioSesion.Tipo = entity.Tipo;
                }
               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { usuario }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { usuario })} - FIN");

            return result;
        }

        public async Task<bool> CambiarClave(int id, string clave)
        {
            _logger.LogTrace($"{this.TraceMethod(new { id })} - INICIO");

            bool result = false;
            try
            {
                var entity = await _dbContext.Usuarios.Where(e => e.IdUsuario == id).FirstOrDefaultAsync<Usuario>();

                if (entity != null)
                {
                    entity.Clave = clave;

                    _dbContext.Entry(entity).State = EntityState.Modified;

                    int num = await _dbContext.SaveChangesAsync();

                    result = (num == 1);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { id }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { id })} - FIN");

            return result;
        }

    }
}
