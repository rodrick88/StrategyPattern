using StrategyPattern.Application.Interfaces;
using StrategyPattern.Domain.Entities;

namespace StrategyPattern.Application.Strategy;

public class HomeWorkUpdateStrategy : IUpdateStrategy
{
    public void Update(Allocation allocation)
    {
        allocation.DaysToExpiration -= 1;

        if (allocation.DaysToExpiration >= 0)
        {
            allocation.Availability = Math.Max(allocation.Availability - 0.1m, 0m);
        }
        else
        {
            allocation.Availability = 0m;
        }
    }
}
