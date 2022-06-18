using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void SuperDigitTest(string numberAsDirtyString, int timesToRepeat, int expectedSuperDigit)
        {
            var sut = new RecursiveDigitSum();
            var actual = sut.SuperDigit(numberAsDirtyString, timesToRepeat);
            Assert.Equal(expectedSuperDigit, actual);
        }
    }
}
