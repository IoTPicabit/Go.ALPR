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
    public class LocalizacionService: ILocalizacionService
    {
        private readonly ILogger<LocalizacionService> _logger;
        private readonly SRIDbContext _dbContext;
        private readonly IMapper _mapper;

        public LocalizacionService(ILogger<LocalizacionService> logger, SRIDbContext dbContext, IMapper mapper)
        {
            _logger = logger;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IPagedList<LocalizacionDto>> ObtenerListaPaginada(
                                                        string Nombre,
                                                        byte Tipo,
                                                        string CIF,
                                                        string NIMA,
                                                        bool? Habilitado,
                                                        int pageNumber,
                                                        int pageSize)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            StaticPagedList<LocalizacionDto> result = null;

            try
            {
                result = await Task.Factory.StartNew(() =>
                {
                    var localizaciones = from l in _dbContext.Localizacions select l;

                    if (!String.IsNullOrEmpty(Nombre))
                    {
                        localizaciones = localizaciones.Where(l => l.Nombre.Equals(Nombre) || l.Nombre.Contains(Nombre));
                    }

                    if (Tipo != 0)
                    {
                        localizaciones = localizaciones.Where(l => l.IdTipoOperacion == Tipo);
                    }

                    if (!String.IsNullOrEmpty(CIF))
                    {
                        localizaciones = localizaciones.Where(l => l.Cif.Equals(CIF) || l.Cif.Contains(CIF));
                    }

                    if (!String.IsNullOrEmpty(NIMA))
                    {
                        localizaciones = localizaciones.Where(l => l.Nima.Equals(NIMA) || l.Nima.Contains(NIMA));
                    }

                    if (Habilitado != null)
                    {
                        localizaciones = localizaciones.Where(l => l.Habilitado == Habilitado);
                    }

                    localizaciones = localizaciones.Include(l => l.IdTipoOperacionNavigation);

                    localizaciones = localizaciones.OrderBy(l => l.Nombre).AsNoTracking();

                    var pagedLocalizaciones = localizaciones.ToPagedList(pageNumber, pageSize);

                    var localizacionesDto = _mapper.Map<IEnumerable<Localizacion>, IEnumerable<LocalizacionDto>>(pagedLocalizaciones.ToArray());

                    return new StaticPagedList<LocalizacionDto>(localizacionesDto, pagedLocalizaciones.GetMetaData());
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }

        public List<LocalizacionDto> ObtenerLista(bool soloHabilitados = false)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            List<LocalizacionDto> result = new List<LocalizacionDto>();
            try
            {
                var localizaciones = from l in _dbContext.Localizacions select l;

                if (soloHabilitados)
                {
                    localizaciones = localizaciones.Where(l => l.Habilitado == true);
                }

                localizaciones = localizaciones.Include(t => t.IdTipoOperacionNavigation);

                result = _mapper.Map<List<LocalizacionDto>>(localizaciones.AsNoTracking().ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }   
        
        public LocalizacionDto ObtenerPorNombre(string nombre)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            LocalizacionDto result = null;
            try
            {
                Localizacion entity = _dbContext.Localizacions.Where(e => e.Nombre == nombre).AsNoTracking().FirstOrDefault();
                
                if(entity != null)
                {
                    result = _mapper.Map<LocalizacionDto>(entity);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }

        public bool Guardar(LocalizacionDto localizacion)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            bool result = false;
            try
            {
                Localizacion entity; 

                if (localizacion.IdLocalizacion == 0)
                {   //Nuevo                   
                    entity = new Localizacion();               
                }
                else
                {   //Edición 
                    entity = _dbContext.Localizacions.Where(e => e.IdLocalizacion == localizacion.IdLocalizacion).FirstOrDefault();
                }

                entity.Nombre = localizacion.Nombre;
                entity.IdTipoOperacion = localizacion.IdTipoOperacion;
                entity.Cif = localizacion.Cif;
                entity.Direccion = localizacion.Direccion;
                entity.Nima = localizacion.Nima;
                entity.Habilitado = localizacion.Habilitado;

                if (localizacion.IdLocalizacion == 0)
                {   //Nuevo 
                    _dbContext.Localizacions.Add(entity);
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

        public bool Eliminar(LocalizacionDto localizacion)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            bool result = false;
            try
            {
                Localizacion entity = _dbContext.Localizacions.Where(o => o.IdLocalizacion == localizacion.IdLocalizacion).FirstOrDefault();

                _dbContext.Localizacions.Remove(entity);

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
        
        public bool CreadoSiNoExiste(string nombre, byte tipo)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");


            bool result = false;
            try
            {
                int cuenta = _dbContext.Localizacions.Count(l => l.Nombre.Equals(nombre) && l.IdTipoOperacion == tipo);
                if(cuenta == 0)
                {
                    Localizacion entity = new Localizacion();
                    entity.Nombre = nombre;
                    entity.IdTipoOperacion = tipo;

                    _dbContext.Localizacions.Add(entity);

                    int num = _dbContext.SaveChanges(true);

                    result = (num == 1);
                }

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
