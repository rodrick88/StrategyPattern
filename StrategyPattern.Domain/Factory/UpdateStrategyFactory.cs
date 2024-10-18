using StrategyPattern.Application.Interfaces;
using StrategyPattern.Application.Strategy;
using StrategyPattern.Domain.Entities;

namespace StrategyPattern.Application.Factory;

public static class UpdateStrategyFactory
{
    public static IUpdateStrategy GetStrategy(Allocation allocation)
    {
        string name = allocation.Name;

        bool isCompensated = name.Contains("Compensated");
        IUpdateStrategy baseStrategy;

        if (name.Contains("Sickness"))
        {
            baseStrategy = new SicknessUpdateStrategy();
        }
        else if (name.Contains("Vacation"))
        {
            baseStrategy = new VacationUpdateStrategy();
        }
        else if (name.Contains("HomeWork"))
        {
            baseStrategy = new HomeWorkUpdateStrategy();
        }
        else if (name.Contains("RemoteWork"))
        {
            baseStrategy = new RemoteWorkUpdateStrategy();
        }
        else
        {
            baseStrategy = new DefaultUpdateStrategy();
        }

        if (isCompensated && !(baseStrategy is SicknessUpdateStrategy))
        {
            return new CompensatedUpdateStrategy(baseStrategy);
        }

        return baseStrategy;
    }
}
