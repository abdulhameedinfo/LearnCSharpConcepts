public class MorningCofee {
            public static void TakeCoffee()
        {
            // Start with a basic coffee
            ICoffee coffee = new BasicCoffee();
            Console.WriteLine($"{coffee.GetDescription()} costs ${coffee.GetCost()}");

            // Add Sugar to the coffee
            coffee = new Sugar(coffee);
            Console.WriteLine($"{coffee.GetDescription()} costs ${coffee.GetCost()}");

            // Add Milk to the coffee
            coffee = new Milk(coffee);
            Console.WriteLine($"{coffee.GetDescription()} costs ${coffee.GetCost()}");

            // Add Fruit Cake
            coffee = new FruitCake(coffee);
            System.Console.WriteLine($"{coffee.GetDescription()} costs ${coffee.GetCost()}");
        }

}