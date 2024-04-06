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
    public class TipoCargaService: ITipoCargaService
    {
        private readonly ILogger<TipoCargaService> _logger;
        private readonly SRIDbContext _dbContext;
        private readonly IMapper _mapper;

        public TipoCargaService(ILogger<TipoCargaService> logger, SRIDbContext dbContext, IMapper mapper)
        {
            _logger = logger;
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<IPagedList<TipoCargaDto>> ObtenerListaPaginada(
                                                        string Nombre,
                                                        byte Tipo,
                                                        string LER,
                                                        string ADR,
                                                        int pageNumber,
                                                        int pageSize)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            StaticPagedList<TipoCargaDto> result = null;

            try
            {
                result = await Task.Factory.StartNew(() =>
                {
                    var tiposcarga = from tc in _dbContext.TipoCargas select tc;

                    if (!String.IsNullOrEmpty(Nombre))
                    {
                        tiposcarga = tiposcarga.Where(tc => tc.Nombre.Equals(Nombre) || tc.Nombre.Contains(Nombre));
                    }

                    if (Tipo != 0)
                    {
                        tiposcarga = tiposcarga.Where(tc => tc.IdTipoOperacion == Tipo);
                    }

                    if (!String.IsNullOrEmpty(LER))
                    {
                        tiposcarga = tiposcarga.Where(tc => tc.CodigoLer.Equals(LER) || tc.CodigoLer.Contains(LER));
                    }

                    if (!String.IsNullOrEmpty(ADR))
                    {
                        tiposcarga = tiposcarga.Where(tc => tc.DenominacionAdr.Equals(ADR) || tc.DenominacionAdr.Contains(ADR));
                    }

                    tiposcarga = tiposcarga.Include(tc => tc.IdTipoOperacionNavigation);
                    tiposcarga = tiposcarga.Include(tc => tc.IdTipoCargaPadreNavigation);
                    tiposcarga = tiposcarga.Include(tc => tc.InverseIdTipoCargaPadreNavigation);
                    tiposcarga = tiposcarga.Include(tc => tc.IdEmpresaExpedicionNavigation);

                    tiposcarga = tiposcarga.OrderBy(tc => tc.Nombre).AsNoTracking();

                    var pagedTiposCarga = tiposcarga.ToPagedList(pageNumber, pageSize);

                    var tiposCargaDto = _mapper.Map<IEnumerable<TipoCarga>, IEnumerable<TipoCargaDto>>(pagedTiposCarga.ToArray());

                    return new StaticPagedList<TipoCargaDto>(tiposCargaDto, pagedTiposCarga.GetMetaData());
                });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }

        public List<TipoCargaDto> ObtenerLista()
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            List<TipoCargaDto> result = new List<TipoCargaDto>();
            try
            {
                var tiposcarga = from tc in _dbContext.TipoCargas select tc;
                tiposcarga = tiposcarga.Include(tc => tc.IdTipoOperacionNavigation);

                result = _mapper.Map<List<TipoCargaDto>>(tiposcarga.AsNoTracking().ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }

        
        public List<TipoCargaDto> ObtenerListaPadres(int id)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            List<TipoCargaDto> result = new List<TipoCargaDto>();
            try
            {
                result = _mapper.Map<List<TipoCargaDto>>(_dbContext.TipoCargas.Where(tc => tc.IdTipoCarga != id && tc.IdTipoCargaPadre == null).AsNoTracking().ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }

        public async Task<bool> Guardar(TipoCargaDto tipocarga)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            bool result = false;
            try
            {
                TipoCarga entity = _dbContext.TipoCargas.Where(u => u.IdTipoCarga == tipocarga.IdTipoCarga).FirstOrDefault();

                if(tipocarga.IdTipoCargaPadre == 0)
                {
                    tipocarga.IdTipoCargaPadre = null;
                }

                if(tipocarga.IdEmpresaExpedicion == 0)
                {
                    tipocarga.IdEmpresaExpedicion = null;
                }

                if (entity == null)
                {   //Nuevo
                    entity = new TipoCarga();
                    entity.Nombre = tipocarga.Nombre;
                    entity.CodigoLer = tipocarga.CodigoLer;
                    entity.DenominacionAdr = tipocarga.DenominacionAdr;
                    entity.IdTipoOperacion = tipocarga.IdTipoOperacion;
                    entity.IdTipoCargaPadre = tipocarga.IdTipoCargaPadre;
                    entity.IdEmpresaExpedicion = tipocarga.IdEmpresaExpedicion;

                    _dbContext.TipoCargas.Add(entity);
                }
                else
                {   //Edición                    
                    entity.Nombre = tipocarga.Nombre;
                    entity.CodigoLer = tipocarga.CodigoLer;
                    entity.DenominacionAdr = tipocarga.DenominacionAdr;
                    entity.IdTipoOperacion = tipocarga.IdTipoOperacion;
                    entity.IdTipoCargaPadre = tipocarga.IdTipoCargaPadre;
                    entity.IdEmpresaExpedicion = tipocarga.IdEmpresaExpedicion;

                    _dbContext.Entry(entity).State = EntityState.Modified;
                }

                int num = await _dbContext.SaveChangesAsync();

                result = (num != 0);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }

        public async Task<bool> Eliminar(TipoCargaDto tipocarga)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            bool result = false;
            try
            {
                TipoCarga entity = _dbContext.TipoCargas.Where(o => o.IdTipoCarga == tipocarga.IdTipoCarga).Include(tc => tc.InverseIdTipoCargaPadreNavigation).FirstOrDefault();

                //Establecemos a null la FK primero las cargas que dependen de la actual
                foreach(var subproducto in entity.InverseIdTipoCargaPadreNavigation)
                {
                    subproducto.IdTipoCargaPadre = null;
                }

                _dbContext.TipoCargas.Remove(entity);

                int num = await _dbContext.SaveChangesAsync();

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
