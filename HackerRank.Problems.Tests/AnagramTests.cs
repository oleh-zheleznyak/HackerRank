using HackerRank.Problems.Test4;
using Xunit;

namespace HackerRank.Problems.Tests
{
    public class AnagramTests
    {
        [Theory]
        [InlineData("aaabbb",3)]
        [InlineData("ab", 1)]
        [InlineData("abc", -1)]
        [InlineData("mnop", 2)]
        [InlineData("xyyx", 0)]
        [InlineData("xaxbbbxx", 1)]
        [InlineData("asdfjoieufoa", 3)]
        [InlineData("fdhlvosfpafhalll", 5)]
        [InlineData("mvdalvkiopaufl", 5)]
        public void EditDistanceTests(string input, int expectedEditDistance)
        {
            var sut = new Anagram();
            var actualDistance = sut.EditDistance(input);
            Assert.Equal(expectedEditDistance, actualDistance);
        }
    }
}
