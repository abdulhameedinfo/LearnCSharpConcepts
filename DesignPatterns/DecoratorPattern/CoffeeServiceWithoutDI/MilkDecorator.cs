public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee) {}

    public override string GetDescription() => _coffee.GetDescription() + " with milk";
    public override double GetCost() => _coffee.GetCost() + 5;
}