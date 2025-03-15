public static class DivideAndConqure
{
    public static int FindMax(params int[] numbers)

    {
        if (numbers.Length == 1)
            return numbers[0];

        if (numbers.Length == 2)
            return int.Max(numbers[0], numbers[1]);

        int pivotPoint = Math.Abs(numbers.Length / 2);

        int[] firstHalfArray = numbers.Take(pivotPoint).ToArray();
        int[] secondHalfArray = numbers.Skip(pivotPoint).Take(pivotPoint).ToArray();

        var firstHalfResult = FindMax(firstHalfArray);
        var secondHalfResult = FindMax(secondHalfArray);

        return int.Max(firstHalfResult, secondHalfResult);
    }
}