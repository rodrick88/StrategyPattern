using StrategyPattern.Application.Strategy;
using StrategyPattern.Domain.Entities;

namespace StrategyPattern.Test;

public class DefaultUpdateStrategyTests
{
    [Fact]
    public void Update_IncreasesAvailability_BeforeExpiration()
    {
        // Arrange
        var allocation = new Allocation { Name = "FreeDisposal", DaysToExpiration = 5, Availability = 5 };
        var strategy = new DefaultUpdateStrategy();

        // Act
        strategy.Update(allocation);

        // Assert
        Assert.Equal(4, allocation.DaysToExpiration);
        Assert.Equal(5.1m, allocation.Availability);
    }

    [Fact]
    public void Update_SetsAvailabilityToZero_AfterExpiration()
    {
        // Arrange
        var allocation = new Allocation { Name = "FreeDisposal", DaysToExpiration = 0, Availability = 5 };
        var strategy = new DefaultUpdateStrategy();

        // Act
        strategy.Update(allocation);

        // Assert
        Assert.Equal(-1, allocation.DaysToExpiration);
        Assert.Equal(0m, allocation.Availability);
    }

    [Fact]
    public void Update_DoesNotIncreaseAvailabilityAboveTwenty()
    {
        // Arrange
        var allocation = new Allocation { Name = "FreeDisposal", DaysToExpiration = 5, Availability = 20 };
        var strategy = new DefaultUpdateStrategy();

        // Act
        strategy.Update(allocation);

        // Assert
        Assert.Equal(4, allocation.DaysToExpiration);
        Assert.Equal(20m, allocation.Availability);
    }
}


