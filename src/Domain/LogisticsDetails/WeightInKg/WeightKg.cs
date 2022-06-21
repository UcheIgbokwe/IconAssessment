using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.SeedWork;

namespace Domain.LogisticsDetails.WeightInKg
{
    public class WeightKg : ValueObject
    {
        public double Weight { get; set; }
        public WeightKg(double weight)
        {
            Weight = weight;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Weight;
        }
    }
}