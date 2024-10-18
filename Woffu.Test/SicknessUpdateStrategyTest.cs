using StrategyPattern.Application.Strategy;
using StrategyPattern.Domain.Entities;

namespace StrategyPattern.Test;

public class SicknessUpdateStrategyTests
{
    [Fact]
    public void Update_DoesNotChangeAvailabilityOrDaysToExpiration()
    {
        // Arrange
        var allocation = new Allocation { Name = "Sickness", DaysToExpiration = 0, Availability = 25 };
        var strategy = new SicknessUpdateStrategy();

        // Act
        strategy.Update(allocation);

        // Assert
        Assert.Equal(0, allocation.DaysToExpiration);
        Assert.Equal(25m, allocation.Availability);
    }
}
