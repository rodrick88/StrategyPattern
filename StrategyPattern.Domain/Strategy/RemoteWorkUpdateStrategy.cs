using StrategyPattern.Application.Interfaces;
using StrategyPattern.Domain.Entities;

namespace StrategyPattern.Application.Strategy
{
    public class RemoteWorkUpdateStrategy : IUpdateStrategy
    {
        public void Update(Allocation allocation)
        {
            allocation.DaysToExpiration -= 1;

            if (allocation.DaysToExpiration >= 0)
            {
                decimal decreaseAmount = 0.1m;

                if (allocation.DaysToExpiration < 5)
                {
                    decreaseAmount += 0.2m; // Total de 0.3m
                }
                else if (allocation.DaysToExpiration < 10)
                {
                    decreaseAmount += 0.1m; // Total de 0.2m
                }

                allocation.Availability = Math.Max(allocation.Availability - decreaseAmount, 0m);
            }
            else
            {
                allocation.Availability = 0m;
            }
        }
    }
}
