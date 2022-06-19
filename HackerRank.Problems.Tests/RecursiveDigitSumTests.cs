using Xunit;

namespace HackerRank.Problems.Tests
{
    public class RecursiveDigitSumTests
    {
        [Theory]
        [InlineData("1", 1, 1)]
        [InlineData("11", 1, 2)]
        [InlineData("1", 2, 2)]
        [InlineData(" 9875", 4, 8)]
        [InlineData("1000000", 100, 1)]
        [InlineData("999999999999999999999999", 100000, 9)]
        public void SuperDigitTest(string numberAsDirtyString, uint timesToRepeat, int expectedSuperDigit)
        {
            var sut = new RecursiveDigitSum();
            var actual = sut.SuperDigit(numberAsDirtyString, timesToRepeat);
            Assert.Equal(expectedSuperDigit, actual);
        }
    }
}
