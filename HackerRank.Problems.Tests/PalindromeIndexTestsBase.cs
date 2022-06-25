using HackerRank.Problems.Test2;
using Xunit;

namespace HackerRank.Problems.Tests
{
    public abstract class PalindromeIndexTestsBase
    {
        [Theory]
        [InlineData("a", new[] { -1 })]
        [InlineData("aa", new[] { -1 })]
        [InlineData("aaab", new[] { 3 })]
        [InlineData("AB", new[] { 0, 1 })]
        [InlineData("abc", new[] { -1 })]
        [InlineData("aba", new[] { -1 })]
        [InlineData("Abb", new[] { 0 })]
        [InlineData("aBCa", new[] { 1, 2 })]
        [InlineData("aBcca", new[] { 1 })]
        [InlineData("hgygsvlfcwnswtuhmyaljkqlqjjqlqkjlaymhutwsnwcWflvsgygh", new[] { 44 })]
        [InlineData("cbabcB", new[] { 5 })]
        [InlineData("Bcbabc", new[] { 0 })]
        [InlineData("cbbcB", new[] { 4 })]
        [InlineData("CbcB", new[] { 0, 3 })]
        public void FindIndexToRemoveTests(string input, int[] allowedIndexes)
        {
            var sut = CreateSystemUnderTest();
            var actualIndex = sut.FindIndexToRemove(input.ToLower());
            Assert.Contains(actualIndex, allowedIndexes);
        }

        protected abstract IPalindromeIndex CreateSystemUnderTest();
    }
}