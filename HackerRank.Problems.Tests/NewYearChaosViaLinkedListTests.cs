using System.Collections.Generic;
using Xunit;

namespace HackerRank.Problems.Tests;

public class NewYearChaosViaLinkedListTests : NewYearChaosTestsBase
{
    [Theory]
    [MemberData(nameof(GetTestData))]
    public void CalculateNumberOfBribesTest(List<int> queue, int? expectedBribes)
    {
        var sut = new NewYearChaosViaLinkedList();
        var actual = sut.CalculateNumberOfBribes(queue);
        Assert.Equal(expectedBribes, actual);
    }
}
