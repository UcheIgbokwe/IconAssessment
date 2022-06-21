using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.SeedWork;

namespace Domain.LogisticsDetails.Dimensions
{
    public class Dimension : ValueObject
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public double CalculatedDimension { get; set; }

        public Dimension(double width, double height, double depth)
        {
            CalculatedDimension = width * height * depth;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return CalculatedDimension;
        }
    }
}