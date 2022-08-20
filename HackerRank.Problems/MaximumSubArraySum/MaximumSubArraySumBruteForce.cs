namespace HackerRank.Problems.MaximumSubArraySum;

/// <summary>
/// Time complexity ~ O(n^2)
/// Space complexity ~ O(n)
/// </summary>
public class MaximumSubArraySumBruteForce : IMaximumSubArraySum
{
    public int Compute(IReadOnlyList<int> arr)
    {
        var maxSubArray = MaxSubArray(arr);

        return maxSubArray;
    }

    private int MaxSubArray(IReadOnlyList<int> arr)
    {
        var sums = CalculateTrailingSums(arr);
        var max = MaxSumTryEveryPair(sums);
        return max;
    }

    private int MaxSumTryEveryPair(int[] sums)
    {
        var max = int.MinValue;
        for (var i = 0; i < sums.Length; i++)
        {
            for (var j = i + 1; j < sums.Length; j++)
            {
                var sum = sums[j] - sums[i];
                max = Math.Max(max, sum);
            }
        }

        return max;
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