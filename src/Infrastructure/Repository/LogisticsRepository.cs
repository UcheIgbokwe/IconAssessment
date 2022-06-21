using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Behaviours;
using Application.Contracts.Infrastructure.Repository;
using Domain.LogisticsDetails;
using Infrastructure.Persistence;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repository
{
    public class LogisticsRepository : GenericRepository<LogisticsDetail>, ILogisticsRepository
    {
        public LogisticsRepository(DataContext dbContext, ILogger logger) : base(dbContext, logger)
        {
        }

        public void CreateRecord(LogisticsDetail logisticsDetail)
        {
            try
            {
                /*Add record to in memory database*/
                Add(logisticsDetail);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in CreateRecord: {ex.Message}", ex.Message);
                throw new HandleDbException(ex.Message, ex);
            }
        }
    }
}