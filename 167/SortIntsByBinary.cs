using System;
using System.Linq;

/// <summary>
/// Given an integer array arr, sort the integers in arr in ascending order by the number of 1’s in their
/// binary representation and return the sorted array.
///
/// Examples:
/// $ sortBits([0,1,2,3,4,5,6,7,8])
/// $ [0,1,2,4,8,3,5,6,7]
/// </summary>
class SortIntsByBinary
{
    static void Main(string[] args)
    {
        Console.WriteLine(
		    $"[{ string.Join(",", SortBits(new int[]{0, 1, 2, 3, 4, 5, 6, 7, 8}))}]");
    }

    static int[] SortBits(int[] values)
    {
        if (values.Length == 0) return null;

        // This isn't "in-place" unfortunately, but best I can think of:
        // Convert int to base 2 string and order by occurences of '1'. Not in-place
        var sorted = values.OrderBy(v => Convert.ToString(v, toBase: 2)
            .Count(bv => bv == '1')).ToArray();

        return sorted;
    }
}
