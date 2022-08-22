using Xunit;

namespace HackerRank.Problems.Tests;

public class LegoBlocksTests
{
    [Theory]
    [InlineData(2,2,3)]
    [InlineData(3,2,7)]
    [InlineData(2,3,9)]
    public void NumberOfCombinationsForWallTest(int height, int width, int expectedCombinations)
    {
        var sut = new LegoBlocks();
        var actualCombinations = sut.NumberOfCombinationsForWall(height, width);
        Assert.Equal(expectedCombinations,actualCombinations);
    }
}