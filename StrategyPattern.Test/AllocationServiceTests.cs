using StrategyPattern.Application.Services;
using StrategyPattern.Domain.Entities;
using Xunit;


namespace StrategyPattern.Test;

public class AllocationServiceTests
{

    [Fact]
    public void UpdateAvailability_UpdatesAllAllocations()
    {
        // Arrange
        var allocations = new List<Allocation>
        {
            new Allocation { Name = "Vacation", DaysToExpiration = 5, Availability = 5 },
            new Allocation { Name = "HomeWork", DaysToExpiration = 5, Availability = 5 },
            new Allocation { Name = "Compensated RemoteWork", DaysToExpiration = 5, Availability = 5 },
            new Allocation { Name = "Sickness", DaysToExpiration = 0, Availability = 25 },
        };

        var allocationService = new UpdateAvailabilityService(allocations);

        // Act
        allocationService.UpdateAvailability();

        // Assert
        Assert.Equal(4, allocations[0].DaysToExpiration);
        Assert.Equal(5.1m, allocations[0].Availability);

        Assert.Equal(4, allocations[1].DaysToExpiration);
        Assert.Equal(4.9m, allocations[1].Availability);

        Assert.Equal(3, allocations[2].DaysToExpiration);
        Assert.Equal(4.4m, allocations[2].Availability); // Decreased by 0.3 * 2 times

        Assert.Equal(0, allocations[3].DaysToExpiration);
        Assert.Equal(25m, allocations[3].Availability);
    }
}