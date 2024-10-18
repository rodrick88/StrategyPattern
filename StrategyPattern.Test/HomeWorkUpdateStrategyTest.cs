using StrategyPattern.Application.Strategy;
using StrategyPattern.Domain.Entities;
using Xunit;

namespace StrategyPattern.Test;

public class HomeWorkUpdateStrategyTests
{
    [Fact]
    public void Update_DecreasesAvailability_BeforeExpiration()
    {
        // Arrange
        var allocation = new Allocation { Name = "HomeWork", DaysToExpiration = 5, Availability = 5 };
        var strategy = new HomeWorkUpdateStrategy();

        // Act
        strategy.Update(allocation);

        // Assert
        Assert.Equal(4, allocation.DaysToExpiration);
        Assert.Equal(4.9m, allocation.Availability);
    }

    [Fact]
    public void Update_SetsAvailabilityToZero_AfterExpiration()
    {
        // Arrange
        var allocation = new Allocation { Name = "HomeWork", DaysToExpiration = 0, Availability = 5 };
        var strategy = new HomeWorkUpdateStrategy();

        // Act
        strategy.Update(allocation);

        // Assert
        Assert.Equal(-1, allocation.DaysToExpiration);
        Assert.Equal(0m, allocation.Availability);
    }

    [Fact]
    public void Update_AvailabilityNeverNegative()
    {
        // Arrange
        var allocation = new Allocation { Name = "HomeWork", DaysToExpiration = 5, Availability = 0.05m };
        var strategy = new HomeWorkUpdateStrategy();

        // Act
        strategy.Update(allocation);

        // Assert
        Assert.Equal(4, allocation.DaysToExpiration);
        Assert.Equal(0m, allocation.Availability);
    }
}
