using HackerRank.Problems.Test5;
using System.Collections.Generic;
using Xunit;

namespace HackerRank.Problems.Tests
{
    public class BomberManTests
    {
        [Theory]
        [MemberData(nameof(GetTestData))]
        public void SimulateTest(int numberOfSeconds, List<string> grid, List<string> expectedResult)
        {
            var sut = new BomberMan();
            var actual = sut.Simulate(numberOfSeconds, grid);
            Assert.Equal(expectedResult, actual);
        }

        public static IEnumerable<object[]> GetTestData()
        {
            yield return SampleTestCase0();
            yield return SampleTestCase1();
        }

        private static object[] SampleTestCase0()
        {
            return new object[] {
                3,
                new List<string>()
                {
                    ".......",
                    "...O...",
                    "....O..",
                    ".......",
                    "OO.....",
                    "OO....."
                },
                new List<string>()
                {
                    "OOO.OOO",
                    "OO...OO",
                    "OOO...O",
                    "..OO.OO",
                    "...OOOO",
                    "...OOOO"
                }

            };
        }

        private static object[] SampleTestCase1()
        {
            return new object[] {
                5,
                new List<string>()
                {
                    ".......",
                    "...O.O.",
                    "....O..",
                    "..O....",
                    "OO...OO",
                    "OO.O..."
                },
                new List<string>()
                {
                    ".......",
                    "...O.O.",
                    "...OO..",
                    "..OOOO.",
                    "OOOOOOO",
                    "OOOOOOO"
                }

            };
        }
    }
}
