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
using X.PagedList;

namespace Go.ALPR.Sri.Business
{
    public class ContactoService: IContactoService
    {
        private readonly ILogger<ContactoService> _logger;
        private readonly SRIDbContext _dbContext;
        private readonly IMapper _mapper;

        public ContactoService(ILogger<ContactoService> logger, SRIDbContext dbContext, IMapper mapper)
        {
            _logger = logger;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IPagedList<ContactoDto>> ObtenerListaPaginada(
                                                        string Nombre,
                                                        string Email,
                                                        bool? Habilitado,
                                                        int pageNumber,
                                                        int pageSize)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            StaticPagedList<ContactoDto> result = null;

            try
            {
                result = await Task.Factory.StartNew(() =>
                {
                    var contactos = from c in _dbContext.Contactos select c;

                    if (!String.IsNullOrEmpty(Nombre))
                    {
                        contactos = contactos.Where(c => c.Nombre.Equals(Nombre) || c.Nombre.Contains(Nombre));
                    }
                    
                    if (!String.IsNullOrEmpty(Email))
                    {
                        contactos = contactos.Where(c => c.Email.Equals(Email) || c.Email.Contains(Email));
                    }                    

                    if (Habilitado != null)
                    {
                        contactos = contactos.Where(c => c.Habilitado == Habilitado);
                    }

                    contactos = contactos
                                .Include(c => c.IdEmpresaNavigation)
                                .Include(c => c.IdTipoCargaNavigation);

                    contactos = contactos.OrderBy(c => c.Email).AsNoTracking();

                    var pagedContactos = contactos.ToPagedList(pageNumber, pageSize);

                    var contactosDto = _mapper.Map<IEnumerable<Contacto>, IEnumerable<ContactoDto>>(pagedContactos.ToArray());

                    return new StaticPagedList<ContactoDto>(contactosDto, pagedContactos.GetMetaData());
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }


        public bool Guardar(ContactoDto contacto)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            bool result = false;
            try
            {
                Contacto entity;

                if (contacto.IdContacto == 0)
                {   //Nuevo                   
                    entity = new Contacto();
                }
                else
                {   //Edición 
                    entity = _dbContext.Contactos.Where(c => c.IdContacto == contacto.IdContacto).FirstOrDefault();
                }

                entity.Email = contacto.Email;
                entity.Nombre = contacto.Nombre;
                entity.IdEmpresa = contacto.IdEmpresa;
                entity.IdTipoCarga = contacto.IdTipoCarga;                
                entity.Habilitado = contacto.Habilitado;

                if (contacto.IdContacto == 0)
                {   //Nuevo 
                    _dbContext.Contactos.Add(entity);
                }
                else
                {   //Edición

                    _dbContext.Entry(entity).State = EntityState.Modified;
                }

                int num = _dbContext.SaveChanges(true);

                result = (num != 0);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }

        public bool Eliminar(ContactoDto contacto)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            bool result = false;
            try
            {
                Contacto entity = _dbContext.Contactos.Where(c => c.IdContacto == contacto.IdContacto).FirstOrDefault();

                _dbContext.Contactos.Remove(entity);

                int num = _dbContext.SaveChanges(true);

                result = (num != 0);

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