using StrategyPattern.Application.Interfaces;
using StrategyPattern.Domain.Entities;

namespace StrategyPattern.Application.Strategy;

public class SicknessUpdateStrategy : IUpdateStrategy
{
    public void Update(Allocation allocation)
    {
        // No se realiza ninguna acción; Sickness no cambia
    }
}
