using StrategyPattern.Application.Factory;
using StrategyPattern.Application.Interfaces;
using StrategyPattern.Domain.Entities;

namespace StrategyPattern.Application.Services
{
    public class UpdateAvailabilityService : IUpdateAvailability
    {
        private IList<Allocation> _allocations;

        public UpdateAvailabilityService(IList<Allocation> allocation)
        {
            _allocations = allocation;
        }

        public void UpdateAvailability()
        {
            foreach (var allocation in _allocations)
            {
                var strategy = UpdateStrategyFactory.GetStrategy(allocation);
                strategy.Update(allocation);
            }
        }
    }
}
