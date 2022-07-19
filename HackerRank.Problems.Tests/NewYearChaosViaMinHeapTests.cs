using System.Collections.Generic;
using Xunit;

namespace HackerRank.Problems.Tests;

public class NewYearChaosViaMinHeapTests : NewYearChaosTestsBase
{
    [Theory]
    [MemberData(nameof(GetTestData))]
    public void CalculateNumberOfBribesTest(List<int> queue, int? expectedBribes)
    {
        var sut = new NewYearChaosViaMinHeap();
        var actual = sut.CalculateNumberOfBribes(queue);
        Assert.Equal(expectedBribes, actual);
    }
}
