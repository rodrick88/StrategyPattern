using StrategyPattern.Domain.Entities;

namespace StrategyPattern.Application.Interfaces;

public interface IUpdateStrategy
{
    void Update(Allocation allocation);
}
