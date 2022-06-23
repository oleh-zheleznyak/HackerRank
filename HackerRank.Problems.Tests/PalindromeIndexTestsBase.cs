using HackerRank.Problems.Test2;
using Xunit;

namespace HackerRank.Problems.Tests
{
    public abstract class PalindromeIndexTestsBase
    {
        [Theory]
        [InlineData("a", new[] { -1 })]
        [InlineData("aa", new[] { -1 })]
        [InlineData("ab", new[] { 0, 1 })]
        [InlineData("abc", new[] { -1 })]
        [InlineData("aba", new[] { -1 })]
        [InlineData("abb", new[] { 0 })]
        [InlineData("abca", new[] { 1, 2 })]
        [InlineData("abcca", new[] { 1 })]
        public void FindIndexToRemoveTests(string input, int[] allowedIndexes)
        {
            var sut = CreateSystemUnderTest();
            var actualIndex = sut.FindIndexToRemove(input);
            Assert.Contains(actualIndex, allowedIndexes);
        }

        protected abstract IPalindromeIndex CreateSystemUnderTest();
    }
}