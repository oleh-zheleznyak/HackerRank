using Xunit;

namespace HackerRank.Problems.Tests;

public class MinHeap2Tests
{
    [Theory]
    [InlineData(new int[] {1}, 1)]
    [InlineData(new int[] {1,2}, 1)]
    [InlineData(new int[] {2,1}, 1)]
    [InlineData(new int[] {1,2,3}, 1)]
    [InlineData(new int[] {3,2,1}, 1)]
    [InlineData(new int[] {2,1,3}, 1)]
    public void PushPeekTests(int[] pushes, int expectedMin)
    {
        var minHeap = new MinHeap2<int>(new int[pushes.Length]);
        foreach (var i in pushes) minHeap.Push(i);
        Assert.Equal(expectedMin, minHeap.PeekMin());
    }
}