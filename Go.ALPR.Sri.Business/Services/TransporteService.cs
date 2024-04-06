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
    public class TransporteService: ITransporteService
    {
        private readonly ILogger<TransporteService> _logger;
        private readonly SRIDbContext _dbContext;
        private readonly IMapper _mapper;

        public TransporteService(ILogger<TransporteService> logger, SRIDbContext dbContext, IMapper mapper)
        {
            _logger = logger;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IPagedList<TransporteDto>> ObtenerListaPaginada(
                                                        string Matricula,
                                                        string Remolque,
                                                        string Conductor,
                                                        string Empresa,
                                                        byte Tipo,
                                                        string TipoCarga,
                                                        int pageNumber,
                                                        int pageSize)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            StaticPagedList<TransporteDto> result = null;

            try
            {
                result = await Task.Factory.StartNew(() =>
                {
                    var transportes = from t in _dbContext.Transportes select t;

                    if (!String.IsNullOrEmpty(Matricula))
                    {
                        transportes = transportes.Where(t => t.Matricula.Equals(Matricula) || t.Matricula.Contains(Matricula));
                    }
                    if (!String.IsNullOrEmpty(Remolque))
                    {
                        transportes = transportes.Where(t => t.Remolque.Equals(Remolque) || t.Remolque.Contains(Remolque));
                    }
                    if (!String.IsNullOrEmpty(Conductor))
                    {
                        transportes = transportes.Where(t => t.Conductor.Contains(Conductor));
                    }
                    if (!String.IsNullOrEmpty(Empresa))
                    {
                        transportes = transportes.Where(t => t.IdEmpresaNavigation.Nombre.Contains(Empresa));
                    }
                    if (Tipo != 0)
                    {
                        transportes = transportes.Where(t => t.IdTipoOperacion == Tipo);
                    }                    
                    if (!String.IsNullOrEmpty(TipoCarga))
                    {
                        transportes = transportes.Where(t => t.IdTipoCargaNavigation.Nombre.Contains(TipoCarga));
                    }

                    transportes = transportes
                                .Include(t => t.IdTipoOperacionNavigation)
                                .Include(t => t.IdEmpresaNavigation)
                                .Include(t => t.IdTipoCargaNavigation);

                    transportes = transportes.OrderBy(t => t.Matricula).AsNoTracking();

                    var pagedTransportes = transportes.ToPagedList(pageNumber, pageSize);
                   
                    var transportesDto = _mapper.Map<IEnumerable<Transporte>, IEnumerable<TransporteDto>>(pagedTransportes.ToArray());

                    return new StaticPagedList<TransporteDto>(transportesDto, pagedTransportes.GetMetaData());
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }              
        
        public TransporteCompletoDto ObtenerTransporte(string matricula)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            TransporteCompletoDto result = null;
            try
            {
                var transporte = from t in _dbContext.Transportes select t;

                transporte = transporte.Where(t => t.Matricula == matricula);

                transporte = transporte.Include(t => t.IdTipoOperacionNavigation)
                                        .Include(t => t.IdEmpresaNavigation)
                                        .Include(t => t.IdTipoCargaNavigation)
                                        .Include(t => t.IdTipoCargaNavigation.IdEmpresaExpedicionNavigation)
                                        .Include(t => t.IdTipoCargaNavigation.InverseIdTipoCargaPadreNavigation);

                transporte = transporte.AsNoTracking();

                var entity = transporte.FirstOrDefault();

                result = _mapper.Map<TransporteCompletoDto>(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }

        public bool CheckTransporteExiste(string matricula)
        {

            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            bool result = false;
            try
            {
                var count = _dbContext.Transportes.Where(t => t.Matricula == matricula).Count();

                result = (count > 0);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;

        }

        public bool Guardar(TransporteDto transporte)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            bool result = false;
            try
            {
                Transporte entity = _dbContext.Transportes.Where(t => t.Matricula == transporte.Matricula).FirstOrDefault();

                if (entity == null)
                {   //Nuevo                    
                    entity = new Transporte();
                    entity.Matricula = transporte.Matricula;
                    entity.Remolque = transporte.Remolque;
                    entity.IdTipoOperacion = transporte.IdTipoOperacion;
                    entity.Conductor = transporte.Conductor;
                    entity.IdEmpresa = transporte.IdEmpresa;
                    entity.IdTipoCarga = transporte.IdTipoCarga;
                    _dbContext.Transportes.Add(entity);
                }
                else
                {   //Edición
                    entity.Remolque = transporte.Remolque;
                    entity.IdTipoOperacion = transporte.IdTipoOperacion;
                    entity.Conductor = transporte.Conductor;
                    entity.IdEmpresa = transporte.IdEmpresa;
                    entity.IdTipoCarga = transporte.IdTipoCarga;
                    _dbContext.Entry(entity).State = EntityState.Modified;
                }

                int num = _dbContext.SaveChanges(true);

                result = (num == 1);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }

        public bool Eliminar(TransporteDto transporte)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            bool result = false;
            try
            {
                Transporte entity = _dbContext.Transportes.Where(t => t.Matricula == transporte.Matricula).FirstOrDefault();

                _dbContext.Transportes.Remove(entity);

                int num = _dbContext.SaveChanges(true);

                result = (num == 1);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }
        
        public void Actualizar(string matricula, string conductor)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");
           
            try
            {
                Transporte entity = _dbContext.Transportes.Where(t => t.Matricula == matricula).FirstOrDefault();

                if(entity != null)
                {
                    entity.Conductor = conductor;
                    _dbContext.Entry(entity).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                }                

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");
        }
    }
}
