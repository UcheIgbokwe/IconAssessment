using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Infrastructure.Repository;
using Infrastructure.Persistence;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dbContext;
        private readonly ILogger _logger;
        public ILogisticsRepository Logistics { get; set; }

        public UnitOfWork(DataContext dbContext, ILoggerFactory loggerFactory)
        {
            _dbContext = dbContext;
            _logger = loggerFactory.CreateLogger("logs");

            Logistics = new LogisticsRepository(_dbContext, _logger);
        }
        public async Task CompleteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}