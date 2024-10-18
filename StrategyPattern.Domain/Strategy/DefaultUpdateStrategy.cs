using StrategyPattern.Application.Interfaces;
using StrategyPattern.Domain.Entities;

namespace StrategyPattern.Application.Strategy;

public class DefaultUpdateStrategy : IUpdateStrategy
{
    public virtual void Update(Allocation allocation)
    {
        allocation.DaysToExpiration -= 1;

        if (allocation.DaysToExpiration >= 0)
        {
            allocation.Availability = Math.Min(allocation.Availability + 0.1m, 20m);
        }
        else
        {
            allocation.Availability = 0m;
        }
    }
}
