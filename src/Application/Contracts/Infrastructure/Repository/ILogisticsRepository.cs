using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.LogisticsDetails;

namespace Application.Contracts.Infrastructure.Repository
{
    public interface ILogisticsRepository
    {
        void CreateRecord(LogisticsDetail logisticsDetail);
    }
}