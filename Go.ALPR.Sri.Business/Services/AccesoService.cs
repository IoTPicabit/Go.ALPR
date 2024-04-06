using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using Microsoft.EntityFrameworkCore;
using AutoMapper;

using Go.ALPR.Sri.Common;
using Go.ALPR.Sri.SqlServer;
using Go.ALPR.Sri.SqlServer.Entities;
using X.PagedList;

using Microsoft.Reporting.WinForms;

using System.IO;
using System.Data.SqlClient;

namespace Go.ALPR.Sri.Business
{
    public class AccesoService : IAccesoService
    {

        private readonly ILogger<OperacionService> _logger;
        private readonly SRIDbContext _dbContext;
        private readonly IMapper _mapper;

        public AccesoService(ILogger<OperacionService> logger, SRIDbContext dbContext, IMapper mapper)
        {
            _logger = logger;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IPagedList<AccesoDto>> ObtenerListaPaginada(
                                                        DateTime FechaInicio,
                                                        DateTime FechaFin,
                                                        string Matricula,
                                                        int Acceso,
                                                        int pageNumber = 1,
                                                        int pageSize = 10)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            StaticPagedList<AccesoDto> result = null;

            try
            {
                result = await Task.Factory.StartNew(() =>
                {
                    var accesos = from a in _dbContext.Accesos select a;
                                       
                    if (FechaInicio != DateTime.MinValue)
                    {
                        accesos = accesos.Where(a => a.Fecha >= FechaInicio.Date);
                    }
                    if (FechaFin != DateTime.MinValue)
                    {
                        accesos = accesos.Where(a => a.Fecha <= FechaFin.Date.AddHours(23).AddMinutes(59).AddSeconds(59));
                    }
                    if (!String.IsNullOrEmpty(Matricula))
                    {
                        accesos = accesos.Where(a => a.Matricula.Equals(Matricula) || a.Matricula.Contains(Matricula));
                    }
                    if(Acceso != int.MinValue)
                    {
                        accesos = accesos.Where(a => a.Resultado == (Acceso == 0 ? false : true));
                    }

                    accesos = accesos.OrderByDescending(a => a.Fecha).AsNoTracking();

                    var pagedAccesos = accesos.ToPagedList(pageNumber, pageSize);

                    var accesosDto = _mapper.Map<IEnumerable<Acceso>, IEnumerable<AccesoDto>>(pagedAccesos.ToArray());

                    return new StaticPagedList<AccesoDto>(accesosDto, pagedAccesos.GetMetaData());
                });
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