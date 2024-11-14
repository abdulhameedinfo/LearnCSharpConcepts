public class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription() => _coffee.GetDescription() + " with sugur";
    public override double GetCost() => _coffee.GetCost() + 2;
}