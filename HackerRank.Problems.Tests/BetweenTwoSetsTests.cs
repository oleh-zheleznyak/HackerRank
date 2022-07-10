using HackerRank.Problems.Test3;
using System.Linq;
using Xunit;

namespace HackerRank.Problems.Tests
{
    public class BetweenTwoSetsTests
    {
        [Theory]
        [InlineData(new int[] { 2, 4 }, new int[] { 16, 32, 96 }, 3)]
        public void GetTotalXTests(int[] a, int[] b, int expectedCount)
        {
            var sut = new BetweenTwoSets();
            var actualCount = sut.CountTotalNumbersBetweenTwoSets(a.ToList(), b.ToList());
            Assert.Equal(expectedCount, actualCount);
        }
    }
}
