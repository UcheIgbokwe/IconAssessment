using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Domain.DTOs;
using Domain.LogisticsDetails.Dimensions;

namespace Application.Contracts.Infrastructure.Courier
{
    public interface IShipFaster
    {
        decimal ParcelGreaterThan10kgLessThanEqual30Kg(double weight);
        decimal ParcelLessThanEqual1700Cm(Dimension dimension);
    }
}