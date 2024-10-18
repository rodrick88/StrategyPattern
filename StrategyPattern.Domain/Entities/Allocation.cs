namespace StrategyPattern.Domain.Entities;

public class Allocation
{
    public string Name { get; set; }
    public int DaysToExpiration { get; set; }
    public decimal Availability { get; set; }
}
