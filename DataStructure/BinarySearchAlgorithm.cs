using BenchmarkDotNet.Attributes;

public class BinarySearchAlgorithm
{
    public static int BinarySearchRecursive(int targetValue, params int[] inputArray)
    {
        int lowerBound = 0, upperBound = inputArray.Length - 1; // Adjusted upperBound to be inputArray.Length - 1
        return PerformBinarySearchRecursive(lowerBound, upperBound, targetValue, inputArray);
    }

    private static int PerformBinarySearchRecursive(int lowerBound, int upperBound, int targetValue, int[] inputArray)
    {
        if (lowerBound > upperBound) return -1; // Base case: target not found

        int midPoint = lowerBound + (upperBound - lowerBound) / 2;

        return inputArray[midPoint].CompareTo(targetValue) switch
        {
            0 => midPoint, // inputArray[midPoint] == targetValue

            // inputArray[midPoint] < targetValue
            < 0 => PerformBinarySearchRecursive(midPoint + 1, upperBound, targetValue, inputArray),

            // inputArray[midPoint] > targetValue
            > 0 => PerformBinarySearchRecursive(lowerBound, midPoint - 1, targetValue, inputArray)
        };
    }
    public static int BinarySearchIterative(int targetValue, params int[] sortedAray)
    {
        int min = 0, max = sortedAray.Length - 1;
        if (min > max) return -1;
        while (min <= max)
        {
            int mid = min + (max - min) / 2;
            if (sortedAray[mid] == targetValue) return mid;
            if (sortedAray[mid] < targetValue)
            {
                min = mid + 1;
            }
            else
            {
                max = mid - 1;
            }
        }
        return -1;
    }
}
