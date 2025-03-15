public static class DelegateUtilities
{
    // Pridicate to check if age is within a valid range
    public static Predicate<int> IsAgeWithinRange = (int age) => age > 18 && age < 72;


    // Action to log a message to the console
    public static Action<string> LogMessage = System.Console.WriteLine;


    // Func to combine first name and last name into a full name
    public static Func<string, string, string> GetFullName = (firstName, lastName) => $"{firstName} {lastName}";

}