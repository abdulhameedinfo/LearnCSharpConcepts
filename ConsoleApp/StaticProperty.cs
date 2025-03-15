public class ClassWithStaticProperties
{

    public ClassWithStaticProperties()
    {
        // Usage
        Console.WriteLine(StaticProperties.SharedValue); // Accessing static property directly through class name
        StaticProperties.SharedValue = 20;               // Modifying static property directly
        Console.WriteLine(StaticProperties.SharedValue);
    }
}

public class StaticProperties
{
    // Static property
    public static int SharedValue { get; set; } = 10;

    // Instance property
    public int InstanceValue { get; set; }
}
