using StrategyPattern.Application.Strategy;
using StrategyPattern.Domain.Entities;
using Xunit;

namespace StrategyPattern.Test;

public class RemoteWorkUpdateStrategyTests
{
    [Fact]
    public void Update_DecreasesAvailabilityByPointOne_WhenMoreThanTenDaysToExpiration()
    {
        // Arrange
        var allocation = new Allocation { Name = "RemoteWork", DaysToExpiration = 11, Availability = 5 };
        var strategy = new RemoteWorkUpdateStrategy();

        // Act
        strategy.Update(allocation);

        // Assert
        Assert.Equal(10, allocation.DaysToExpiration);
        Assert.Equal(4.9m, allocation.Availability);
    }

    [Fact]
    public void Update_DecreasesAvailabilityByPointTwo_WhenTenOrLessDaysToExpiration()
    {
        // Arrange
        var allocation = new Allocation { Name = "RemoteWork", DaysToExpiration = 10, Availability = 5 };
        var strategy = new RemoteWorkUpdateStrategy();

        // Act
        strategy.Update(allocation);

        // Assert
        Assert.Equal(9, allocation.DaysToExpiration);
        Assert.Equal(4.8m, allocation.Availability);
    }

    [Fact]
    public void Update_DecreasesAvailabilityByPointThree_WhenFiveOrLessDaysToExpiration()
    {
        // Arrange
        var allocation = new Allocation { Name = "RemoteWork", DaysToExpiration = 5, Availability = 5 };
        var strategy = new RemoteWorkUpdateStrategy();

        // Act
        strategy.Update(allocation);

        // Assert
        Assert.Equal(4, allocation.DaysToExpiration);
        Assert.Equal(4.7m, allocation.Availability);
    }

    [Fact]
    public void Update_SetsAvailabilityToZero_AfterExpiration()
    {
        // Arrange
        var allocation = new Allocation { Name = "RemoteWork", DaysToExpiration = 0, Availability = 5 };
        var strategy = new RemoteWorkUpdateStrategy();

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
        var allocation = new Allocation { Name = "RemoteWork", DaysToExpiration = 5, Availability = 0.2m };
        var strategy = new RemoteWorkUpdateStrategy();

        // Act
        strategy.Update(allocation);

        // Assert
        Assert.Equal(4, allocation.DaysToExpiration);
        Assert.Equal(0m, allocation.Availability);
    }
}
