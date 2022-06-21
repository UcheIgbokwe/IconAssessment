using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Domain.DTOs;
using Domain.LogisticsDetails.Dimensions;

namespace Application.Contracts.Infrastructure.Courier
{
    public interface ICargo4You
    {
        decimal ParcelLessThanEqual20Kg(double weight);
        decimal ParcelLessThanEqual2000Cm(Dimension dimension);
    }
}