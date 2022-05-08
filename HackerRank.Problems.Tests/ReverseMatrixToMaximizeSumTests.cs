using Xunit;
using System.Collections.Generic;

namespace HackerRank.Problems.Tests;

public class ReverseMatrixToMaximizeSumTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void FindMaxSumTest(List<List<int>> matrix, int expectedMaxSum)
    {
        var sut = new ReverseMatrixToMaximizeSum();
        var actual = sut.FindMaxSum(matrix);
        
        Assert.Equal(expectedMaxSum, actual);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return TwoByTwo();
        yield return FourByFour();
        yield return FourByFourTestCase0();
    }

    private static object[] TwoByTwo() =>
     new object[]
    {
         new List<List<int>> {
             new List<int> {1,2},
             new List<int> {3,4}
         },
         4
    };

    private static object[] FourByFour() =>
     new object[]
    {
         new List<List<int>> {
             new List<int> {1,2,3,4},
             new List<int> {5,6,7,8},
             new List<int> {9,10,11,12},
             new List<int> {13,14,15,16}
         },
         11+12+15+16
    };

    private static object[] FourByFourTestCase0() =>
     new object[]
    {
         new List<List<int>> {
             new List<int> {112,42,83,119},
             new List<int> {56,125,56,49},
             new List<int> {15,78,101,43},
             new List<int> {62,98,114,108}
         },
         414
    };

        private static object[] FourByFourTestCase1() =>
     new object[]
    {
         new List<List<int>> {
             new List<int> {114,108,83,119},
             new List<int> {101,125,56,78},
             new List<int> {56,43,15,49},
             new List<int> {62,98,112,42}
         },
         414
    };
}
// reverse row 3
// reverse row 2
// reverse cpol 0
// reverse row 0
// reverse row 3
// reverse col 3
// reverse row 0