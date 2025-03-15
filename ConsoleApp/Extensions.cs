public static class Extensions
{
    public static string NameInLowerCase(this string value)
    {
        return value.ToLower();
    }

    public static int Mean(this int value)
    {
        return value / 2;
    }

    public static void ExtensionMethods()
    {
        var nameInLowerCase = "ABDUL HAMEED".NameInLowerCase();
        System.Console.WriteLine(nameInLowerCase);
    }
}