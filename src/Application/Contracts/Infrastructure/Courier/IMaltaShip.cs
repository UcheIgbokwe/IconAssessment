using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Domain.DTOs;
using Domain.LogisticsDetails.Dimensions;

namespace Application.Contracts.Infrastructure.Courier
{
    public interface IMaltaShip
    {
        decimal ParcelGreaterThanEqual10kg(double weight);
        decimal ParcelGreaterThanEqual5000Cm(Dimension dimension);
    }
}