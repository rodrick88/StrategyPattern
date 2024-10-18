using StrategyPattern.Application.Interfaces;
using StrategyPattern.Domain.Entities;

namespace StrategyPattern.Application.Strategy;

public class CompensatedUpdateStrategy : IUpdateStrategy
{
    private readonly IUpdateStrategy _baseStrategy;

    public CompensatedUpdateStrategy(IUpdateStrategy baseStrategy)
    {
        _baseStrategy = baseStrategy;
    }

    public void Update(Allocation allocation)
    {
        // Aplicamos la estrategia base dos veces para duplicar el efecto
        _baseStrategy.Update(allocation);
        _baseStrategy.Update(allocation);
    }
}