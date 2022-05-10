using Xunit;
using System.Collections.Generic;

namespace HackerRank.Problems.Tests;

public class FlipMatrixRowsToMaximizeSumTestBase
{
    public static IEnumerable<object[]> TestData()
    {
        yield return TwoByTwo();
        yield return FourByFour();
        yield return FourByFourTestCase0();
        yield return FourByFourTestCase7();
        yield return FourByFourReversed();
        yield return FourByFourMixed();
    }

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

    private static object[] FourByFourMixed() =>
 new object[]
{
         new List<List<int>> {
             new List<int> {1,1,1,2},
             new List<int> {1,1,1,1},
             new List<int> {1,4,1,1},
             new List<int> {3,1,1,1}
         },
         3+4+1+1
};

    private static object[] FourByFourReversed() =>
     new object[]
    {
         new List<List<int>> {
             new List<int> {1,1,1,1},
             new List<int> {1,1,1,1},
             new List<int> {1,1,9,9},
             new List<int> {1,1,9,9}
         },
         36
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

    private static object[] FourByFourTestCase7() =>
 new object[]
{
         new List<List<int>> {
             new List<int> {107,54,128,15},
             new List<int> {12,75,110,138},
             new List<int> {100,96,34,85},
             new List<int> {75,15,28,112}
         },
         488
};

    private static object[] TwoByTwo() =>
     new object[]
    {
         new List<List<int>> {
             new List<int> {1,2},
             new List<int> {3,4}
         },
         4
    };
}
