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
    public class TipoOperacionService: ITipoOperacionService
    {
        private readonly ILogger<TipoOperacionService> _logger;
        private readonly SRIDbContext _dbContext;
        private readonly IMapper _mapper;

        public TipoOperacionService(ILogger<TipoOperacionService> logger, SRIDbContext dbContext, IMapper mapper)
        {
            _logger = logger;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<TipoOperacionDto> ObtenerLista()
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            List<TipoOperacionDto> result = new List<TipoOperacionDto>();
            try
            {
                result = _mapper.Map<List<TipoOperacionDto>>(_dbContext.TipoOperacions.ToList());
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
