using StrategyPattern.Domain.Entities;

namespace StrategyPattern.Application.Strategy
{
    public class VacationUpdateStrategy : DefaultUpdateStrategy
    {
        public override void Update(Allocation allocation)
        {
            allocation.DaysToExpiration -= 1;

            if (allocation.DaysToExpiration >= 0)
            {
                allocation.Availability = Math.Min(allocation.Availability + 0.1m, 20m);
            }
            else
            {
                allocation.Availability = Math.Max(allocation.Availability - 0.1m, 0m);
            }
        }
    }
}
