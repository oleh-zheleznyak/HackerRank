using System.Collections.Generic;
using Xunit;

namespace HackerRank.Problems.Tests;

public class ReverseMatrixToMaximizeSumTests : FlipMatrixRowsToMaximizeSumTestBase
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void FindMaxSumTest(List<List<int>> matrix, int expectedMaxSum)
    {
        var sut = new FlipMatrixRowsToMaximizeSum();
        var actual = sut.FindMaxSum(matrix);

        Assert.Equal(expectedMaxSum, actual);
    }
}