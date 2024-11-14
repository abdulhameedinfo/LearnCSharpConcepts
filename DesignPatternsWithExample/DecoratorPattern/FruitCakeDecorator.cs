public class FruitCakeDecorator : CoffeeDecorator
{
    public FruitCakeDecorator(ICoffee coffee) : base(coffee)
    {
        _coffee = coffee;
    }
    public override string GetDescription() => _coffee.GetDescription() + " and serve with fruit cake.";
    public override double GetCost() => _coffee.GetCost() + 5;
}