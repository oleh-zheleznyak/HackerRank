using Xunit;

namespace HackerRank.Problems.Tests;

public class LegoBlocksTests
{
    [Theory]
    [InlineData(2, 2, 3)]
    [InlineData(3, 2, 7)]
    [InlineData(2, 3, 9)]
    [InlineData(2, 4, 27)]
    [InlineData(4, 4, 3375)]
    [InlineData(4, 5, 35714)]
    [InlineData(4, 6, 447902)]
    [InlineData(4, 7, 5562914)]
    [InlineData(5, 4, 29791)]
    [InlineData(6, 4, 250047)]
    [InlineData(7, 4, 2048383)]
    [InlineData(8,6,402844528)]
    [InlineData(7,3,16129)]
    [InlineData(3,8,328650)]
    [InlineData(3,7,57252)]
    [InlineData(8,10,634597424)]
    [InlineData(3,4,343)]
    [InlineData(10,3,1046529)]
    [InlineData(10,8,797528970)]
    [InlineData(2,10,3658)]
    [InlineData(9,5,908059021)]
    [InlineData(7,2,127)]
    [InlineData(5,8,225730660)]
    [InlineData(7,10,665164408)]
    [InlineData(5,6,16164270)]
    [InlineData(529,190,461438538)]
    [InlineData(873,909,84071244)]
    [InlineData(959,499,139909293)]
    [InlineData(37,809,280936480)]
    [InlineData(754,249,18141539)]
    [InlineData(304,334,572707190)]
    [InlineData(134,649,268703862)]
    [InlineData(891,755,798645255)]
    [InlineData(568,747,839582658)]
    [InlineData(369,530,442448653)]
    [InlineData(501,47,405763153)]
    [InlineData(789,798,476959008)]
    [InlineData(250,991,299759023)]
    [InlineData(304,34,893481715)]
    [InlineData(364,498,580495726)]
    [InlineData(254,893,207596656)]
    [InlineData(687,126,50346795)]
    [InlineData(153,997,5816159)]
    public void NumberOfCombinationsForWallTest(int height, int width, int expectedCombinations)
    {
        var sut = new LegoBlocks();
        var actualCombinations = sut.NumberOfCombinationsForWall(height, width);
        Assert.Equal(expectedCombinations, actualCombinations);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(3, 4)]
    [InlineData(4, 8)]
    public void NumberOfDecompositionsTest(int width, int expectedCombinations)
    {
        var sut = new LegoBlocks();
        var cache = new int?[width + 1];
        var actualCombinations = sut.NumberOfDecompositions(width, cache);
        Assert.Equal(expectedCombinations, actualCombinations);
    }
}