using HackerRank.Problems.MaximumSubArraySum;
using Xunit;

namespace HackerRank.Problems.Tests.MaximumSubArraySum;

public abstract  class MaximumSubArraySumTestBase
{
    protected abstract IMaximumSubArraySum Implementation { get; }

    [Theory]
    [InlineData(new int[] {1}, 1)]
    [InlineData(new int[] {-1}, -1)]
    [InlineData(new int[] {1,2}, 3)]
    [InlineData(new int[] {-1,-2}, -1)]
    [InlineData(new int[] {-1,-2,-3}, -1)]
    [InlineData(new int[] {1,2,-3}, 3)]
    [InlineData(new int[] {-1,2,3}, 5)]
    [InlineData(new int[] {1,-2,3}, 3)]
    [InlineData(new int[] {3,-2,3,-4}, 4)]
    [InlineData(new int[] {3,-2,3,-4,-5,6,-2,6}, 10)]
    public void TestCalculate(int[] array, int expectedMaxSum)
    {
        var impl = Implementation;
        var actualMaxSum = impl.Compute(array);
        Assert.Equal(expectedMaxSum, actualMaxSum);
    }
}