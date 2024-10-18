using StrategyPattern.Application.Strategy;
using StrategyPattern.Domain.Entities;

namespace StrategyPattern.Test;

public class CompensatedUpdateStrategyTests
{
    [Fact]
    public void Update_AppliesBaseStrategyTwice_ForDefaultStrategy()
    {
        // Arrange
        var allocation = new Allocation { Name = "Compensated FreeDisposal", DaysToExpiration = 5, Availability = 5 };
        var baseStrategy = new DefaultUpdateStrategy();
        var strategy = new CompensatedUpdateStrategy(baseStrategy);

        // Act
        strategy.Update(allocation);

        // Assert
        Assert.Equal(3, allocation.DaysToExpiration);
        Assert.Equal(5.2m, allocation.Availability);
    }

    [Fact]
    public void Update_AppliesBaseStrategyTwice_ForVacationStrategy()
    {
        // Arrange
        var allocation = new Allocation { Name = "Compensated Vacation", DaysToExpiration = 10, Availability = 5 };
        var baseStrategy = new VacationUpdateStrategy();
        var strategy = new CompensatedUpdateStrategy(baseStrategy);

        // Act
        strategy.Update(allocation);

        // Assert
        Assert.Equal(8, allocation.DaysToExpiration);
        Assert.Equal(5.2m, allocation.Availability);
    }

    [Fact]
    public void Update_AppliesBaseStrategyTwice_AfterExpiration_ForVacation()
    {
        // Arrange
        var allocation = new Allocation { Name = "Compensated Vacation", DaysToExpiration = 0, Availability = 5 };
        var baseStrategy = new VacationUpdateStrategy();
        var strategy = new CompensatedUpdateStrategy(baseStrategy);

        // Act
        strategy.Update(allocation);

        // Assert
        Assert.Equal(-2, allocation.DaysToExpiration);
        Assert.Equal(4.8m, allocation.Availability);
    }

    [Fact]
    public void Update_DoesNotApplyToSickness()
    {
        // Arrange
        var allocation = new Allocation { Name = "Compensated Sickness", DaysToExpiration = 0, Availability = 25 };
        var baseStrategy = new SicknessUpdateStrategy();
        var strategy = new CompensatedUpdateStrategy(baseStrategy);

        // Act
        strategy.Update(allocation);

        // Assert
        Assert.Equal(0, allocation.DaysToExpiration);
        Assert.Equal(25m, allocation.Availability);
    }
}