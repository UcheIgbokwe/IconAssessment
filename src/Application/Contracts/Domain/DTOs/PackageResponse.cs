using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Contracts.Domain.DTOs
{
    public class PackageResponse
    {
        public double DimensionValue { get; set; }
        public double Weight { get; set; }
        public decimal Price { get; set; }
    }
}