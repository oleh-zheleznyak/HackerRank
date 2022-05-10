using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HackerRank.Problems.Tests;

public class SalesByMatchTests
{
    [Theory]
    [InlineData(new int[] {10, 20, 20, 10, 10, 30, 50, 10, 20}, 3)]
    public void FindMaxSumTest(int[] socks, int expectedPairCount)
    {
        var sut = new SalesByMatch();
        var actual = sut.sockMerchant(socks.Length, socks.ToList());

        Assert.Equal(expectedPairCount, actual);
    }
}