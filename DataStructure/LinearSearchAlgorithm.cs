public class LinearSearchAlgorithm
{
    public  static void SimpleAlgorithm()
    {
        int[] numbers = [1, 10, 4, 5, 20, 30, 40, 2, 3, 0];

        int largestNumber = numbers[0];

        foreach (var number in numbers)
        {
            if (number > largestNumber)
                largestNumber = number;
        }
        System.Console.WriteLine(largestNumber);
    }
}