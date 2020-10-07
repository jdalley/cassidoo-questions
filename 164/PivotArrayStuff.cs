using System;

/// <summary>
/// Given an array that was once sorted in ascending order is rotated
/// at some pivot unknown to you beforehand (so [0,2,4,7,9] might
/// become [7,9,0,2,4], for example). Find the minimum value in
/// that array in O(n) or less.
/// </summary>
class PivotArrayStuff
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Lowest value in [7,9,0,2,4] is: { FindPivotValue(new int[] {7,9,0,2,4}) }");
        Console.WriteLine($"Lowest value in [2,3,7,-1,0] is: { FindPivotValue(new int[] {2,3,7,-1,0}) }");
        Console.WriteLine($"Lowest value in [-4,-2,3,5,7] is: { FindPivotValue(new int[] {-4,-2,3,5,7}) }");
        Console.WriteLine($"Lowest value in [5,7,-5,-3,1] is: { FindPivotValue(new int[] {5,7,-5,-3,1}) }");
        Console.WriteLine($"Lowest value in [0,2,4,6,8] is: { FindPivotValue(new int[] {0,2,4,6,8}) }");
    }

    static int FindPivotValue(int[] numbers)
    {
        if (numbers is null || numbers.Length == 0)
            throw new ArgumentException("numbers must not be null and contain at least one element.");

        int firstVal = numbers[0];

        // First value is the lowest, it was a ruse - it's been sorted all along!
        if (firstVal < numbers[numbers.Length - 1])
            return firstVal;

        // Otherwise we assume ascending numbers until a pivot:
        for (int i = 1; i < numbers.Length; i++) {
            // Reached pivot point, this value is the lowest.
            if (firstVal > numbers[i])
                return numbers[i];
        }

        // Some sentinel value which actually doesn't mean much since our array can have negative numbers.
        return -1;
    }
}
