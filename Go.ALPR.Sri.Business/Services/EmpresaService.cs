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
    public class EmpresaService: IEmpresaService
    {
        private readonly ILogger<EmpresaService> _logger;
        private readonly SRIDbContext _dbContext;
        private readonly IMapper _mapper;

        public EmpresaService(ILogger<EmpresaService> logger, SRIDbContext dbContext, IMapper mapper)
        {
            _logger = logger;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IPagedList<EmpresaDto>> ObtenerListaPaginada(
                                                        string Nombre,
                                                        string CIF,
                                                        string NIMA,
                                                        bool? Habilitado,
                                                        int pageNumber,
                                                        int pageSize)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            StaticPagedList<EmpresaDto> result = null;

            try
            {
                result = await Task.Factory.StartNew(() =>
                {
                    var empresas = from e in _dbContext.Empresas select e;

                    if (!String.IsNullOrEmpty(Nombre))
                    {
                        empresas = empresas.Where(e => e.Nombre.Equals(Nombre) || e.Nombre.Contains(Nombre));
                    }

                    if (!String.IsNullOrEmpty(CIF))
                    {
                        empresas = empresas.Where(e => e.Cif.Equals(CIF) || e.Cif.Contains(CIF));
                    }

                    if (!String.IsNullOrEmpty(NIMA))
                    {
                        empresas = empresas.Where(e => e.Nima.Equals(NIMA) || e.Nima.Contains(NIMA));
                    }

                    if(Habilitado != null)
                    {
                        empresas = empresas.Where(e => e.Habilitado == Habilitado);
                    }

                    empresas = empresas.OrderBy(e => e.Nombre).AsNoTracking();

                     var pagedEmpresas = empresas.ToPagedList(pageNumber, pageSize);

                    var empresasDto = _mapper.Map<IEnumerable<Empresa>, IEnumerable<EmpresaDto>>(pagedEmpresas.ToArray());

                    return new StaticPagedList<EmpresaDto>(empresasDto, pagedEmpresas.GetMetaData());
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }

        public List<EmpresaDto> ObtenerLista(bool soloHabilitados = false)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            List<EmpresaDto> result = new List<EmpresaDto>();
            try
            {
                var empresas = from e in _dbContext.Empresas select e;

                empresas = empresas.Where(e => e.Expedidor == false);

                if (soloHabilitados)
                {
                    empresas = empresas.Where(e => e.Habilitado == true);
                }

                result = _mapper.Map<List<EmpresaDto>>(empresas.ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }


        public List<EmpresaDto> ObtenerExpedidores()
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            List<EmpresaDto> result = new List<EmpresaDto>();
            try
            {
                var empresas = from e in _dbContext.Empresas select e;

                empresas = empresas.Where(e => e.Expedidor == true);               

                result = _mapper.Map<List<EmpresaDto>>(empresas.ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }


        public EmpresaDto ObtenerPorNombre(string nombre)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            EmpresaDto result = null;
            try
            {
                Empresa entity = _dbContext.Empresas.Where(e => e.Nombre == nombre).AsNoTracking().FirstOrDefault();

                if (entity != null)
                {
                    result = _mapper.Map<EmpresaDto>(entity);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }


        public bool Guardar(EmpresaDto empresa)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            bool result = false;
            try
            {
                Empresa entity;

                if (empresa.IdEmpresa == 0)
                {   //Nuevo
                    entity = new Empresa();                    
                }
                else
                {   //Edición
                    entity = _dbContext.Empresas.Where(u => u.IdEmpresa == empresa.IdEmpresa).FirstOrDefault();                                   
                }

                entity.Nombre = empresa.Nombre;
                entity.Cif = empresa.Cif;
                entity.Direccion = empresa.Direccion;
                entity.Nima = empresa.Nima;
                entity.Habilitado = empresa.Habilitado;        


                if (empresa.IdEmpresa == 0)
                {   //Nuevo
                    _dbContext.Empresas.Add(entity);
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

        public bool Eliminar(EmpresaDto empresa)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            bool result = false;
            try
            {
                Empresa entity = _dbContext.Empresas.Where(o => o.IdEmpresa == empresa.IdEmpresa).FirstOrDefault();

                _dbContext.Empresas.Remove(entity);

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
