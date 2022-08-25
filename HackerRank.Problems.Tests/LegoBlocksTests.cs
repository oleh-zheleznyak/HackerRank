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