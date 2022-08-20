namespace HackerRank.Problems.MaximumSubArraySum;

/// <summary>
/// Time complexity ~ O(n)
/// Space complexity ~ O(n)
/// </summary>
public class MaximumSubArraySumDynamicProgrammingTopDown : IMaximumSubArraySum
{
    public int Compute(IReadOnlyList<int> arr)
    {
        if (arr.Count == 0) return 0;
        if (arr.Count == 1) return arr[0];
        var max = int.MinValue;
        var sums = CalculateTrailingSums(arr);
        var minimums = CalculateTrailingSumsMin(sums);
        var cache = new int?[arr.Count+1];
        for (int i = 0; i <= arr.Count; i++)
        {
            var maxSumAtIndex = MaxSum(arr, i, sums, minimums, cache);
            max = Math.Max(max, maxSumAtIndex);
        }

        return max;
    }

    private int MaxSum(IReadOnlyList<int> arr, int index, int[] trailingSums, int[] trailingSumMin, int?[] cache)
    {
        if (index == 0) return 0;
        if (cache[index].HasValue) return cache[index].Value;
        var prev = MaxSum(arr, index - 1, trailingSums, trailingSumMin, cache);
        var subtract = trailingSums[index] == trailingSumMin[index] ? trailingSums[index] : 0;
        var current = prev + arr[index - 1] - subtract;

        cache[index] = current;
        return current;
    }

    private int[] CalculateTrailingSumsMin(int[] trailingSums)
    {
        var minimums = new int[trailingSums.Length];

        var min = trailingSums[0];
        for (int i = 0; i < trailingSums.Length; i++)
        {
            min = Math.Min(min, trailingSums[i]);
            minimums[i] = min;
        }
        
        return minimums;
    }
    
    private int[] CalculateTrailingSums(IReadOnlyList<int> arr)
    {
        var sums = new int[arr.Count + 1];
        sums[0] = 0;
        for (var i = 0; i < arr.Count; i++)
        {
            sums[i + 1] = sums[i] + arr[i];
        }

        return sums;
    }
}