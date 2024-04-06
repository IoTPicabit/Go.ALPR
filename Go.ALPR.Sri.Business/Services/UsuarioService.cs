using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

using Microsoft.EntityFrameworkCore;
using AutoMapper;

using Go.ALPR.Sri.Common;
using Go.ALPR.Sri.SqlServer;
using Go.ALPR.Sri.SqlServer.Entities;

namespace Go.ALPR.Sri.Business
{
    public class UsuarioService: IUsuarioService
    {
        private readonly ILogger<SeguridadService> _logger;
        private readonly SRIDbContext _dbContext;
        private readonly IMapper _mapper;

        public UsuarioService(ILogger<SeguridadService> logger, SRIDbContext dbContext,IMapper mapper)
        {
            _logger = logger;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<UsuarioDto> ObtenerLista()
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            List<UsuarioDto> result = new List<UsuarioDto>();
            try
            {
                result = _mapper.Map<List<UsuarioDto>>(_dbContext.Usuarios.Where(u => u.IdUsuario > 1).ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }

        public bool ExisteMismoLogin(string login, int idUsuario)
        {
            return _dbContext.Usuarios.Where(u => u.Login == login && u.IdUsuario != idUsuario).Count() > 0;
        }

        public async Task<bool> Guardar(UsuarioDto usuario)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            bool result = false;
            try
            {
                Usuario entity;

                if (usuario.IdUsuario == 0)
                {   //Nuevo
                    usuario.Clave = usuario.Login;
                    entity = _mapper.Map<Usuario>(usuario);
                    _dbContext.Usuarios.Add(entity);
                }
                else
                {   //Edición
                    entity = _dbContext.Usuarios.Where(u => u.IdUsuario == usuario.IdUsuario).FirstOrDefault();
                    entity.Nombre = usuario.Nombre;
                    entity.Login = usuario.Login;
                    entity.Tipo = usuario.Tipo; 
                    _dbContext.Entry(entity).State = EntityState.Modified;
                }

                int num = await _dbContext.SaveChangesAsync();

                result = (num == 1);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }

        public async Task<bool> Eliminar(UsuarioDto usuario)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            bool result = false;
            try
            {
                Usuario entity = _dbContext.Usuarios.Where(u => u.IdUsuario == usuario.IdUsuario).FirstOrDefault();

                _dbContext.Usuarios.Remove(entity);

                int num = await _dbContext.SaveChangesAsync();

                result = (num == 1);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }

        public async Task<bool> Reiniciar(UsuarioDto usuario)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            bool result = false;
            try
            {
                Usuario entity = _dbContext.Usuarios.Where(u => u.IdUsuario == usuario.IdUsuario).FirstOrDefault();

                int num = 1;
                if(entity.Clave != entity.Login)
                {
                    entity.Clave = entity.Login;
                    num = await _dbContext.SaveChangesAsync();
                }                               

                result = (num == 1);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }

    }
}
