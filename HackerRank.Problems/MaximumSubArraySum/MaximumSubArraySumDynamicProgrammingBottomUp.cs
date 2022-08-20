namespace HackerRank.Problems.MaximumSubArraySum;

/// <summary>
/// Time complexity ~ O(n)
/// Space complexity ~ O(1)
/// </summary>
public class MaximumSubArraySumDynamicProgrammingBottomUp : IMaximumSubArraySum
{
    public int Compute(IReadOnlyList<int> arr)
    {
        var maxSubArray = MaxSubArrayViaLinearDp(arr);

        return maxSubArray;
    }

    private int MaxSubArrayViaLinearDp(IReadOnlyList<int> arr)
    {
        var minSum = 0; // init to zero to handle case of all positive numbers
        var maxSum = int.MinValue;
        var sum = 0;
        var max = arr[0];
        bool hasNonNegative = false;

        for (var i = 0; i < arr.Count; i++)
        {
            hasNonNegative |= (arr[i] >= 0);
            max = Math.Max(max, arr[i]);

            sum += arr[i];
            minSum = Math.Min(minSum, sum);
            var candidate = sum - minSum;

            maxSum = Math.Max(maxSum, candidate);
        }

        return hasNonNegative ? maxSum : max;
    }
}