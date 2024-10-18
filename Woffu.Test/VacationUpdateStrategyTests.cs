using StrategyPattern.Application.Strategy;
using StrategyPattern.Domain.Entities;

namespace StrategyPattern.Test;

public class VacationUpdateStrategyTests
{
    [Fact]
    public void Update_IncreasesAvailability_BeforeExpiration()
    {
        // Arrange
        var allocation = new Allocation { Name = "Vacation", DaysToExpiration = 5, Availability = 5 };
        var strategy = new VacationUpdateStrategy();

        // Act
        strategy.Update(allocation);

        // Assert
        Assert.Equal(4, allocation.DaysToExpiration);
        Assert.Equal(5.1m, allocation.Availability);
    }

    [Fact]
    public void Update_DecreasesAvailability_AfterExpiration()
    {
        // Arrange
        var allocation = new Allocation { Name = "Vacation", DaysToExpiration = 0, Availability = 5 };
        var strategy = new VacationUpdateStrategy();

        // Act
        strategy.Update(allocation);

        // Assert
        Assert.Equal(-1, allocation.DaysToExpiration);
        Assert.Equal(4.9m, allocation.Availability);
    }

    [Fact]
    public void Update_AvailabilityNeverNegative()
    {
        // Arrange
        var allocation = new Allocation { Name = "Vacation", DaysToExpiration = -1, Availability = 0.05m };
        var strategy = new VacationUpdateStrategy();

        // Act
        strategy.Update(allocation);

        // Assert
        Assert.Equal(-2, allocation.DaysToExpiration);
        Assert.Equal(0m, allocation.Availability);
    }

    [Fact]
    public void Update_AvailabilityNeverAboveTwenty()
    {
        // Arrange
        var allocation = new Allocation { Name = "Vacation", DaysToExpiration = 5, Availability = 20m };
        var strategy = new VacationUpdateStrategy();

        // Act
        strategy.Update(allocation);

        // Assert
        Assert.Equal(4, allocation.DaysToExpiration);
        Assert.Equal(20m, allocation.Availability);
    }
}
