using Domain.LogisticsDetails.Dimensions;
using Domain.LogisticsDetails.WeightInKg;
using Domain.SeedWork;
using Domain.Users;

namespace Domain.LogisticsDetails
{
    public class LogisticsDetail : IAggregateRoot
    {
        public int Id { get; set; }
        public WeightKg WeightKg { get; set; }
        public Dimension Dimension { get; set; }
        public virtual User User { get; set; }
    }
}