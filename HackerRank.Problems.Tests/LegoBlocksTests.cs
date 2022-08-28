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