using System.Collections.Generic;
using Xunit;

namespace HackerRank.Problems.Tests
{
    public class NewYearChaosTests
    {
        [Theory]
        [MemberData(nameof(GetTestData))]
        public void CalculateNumberOfBribesTest(List<int> queue, int? expectedBribes)
        {
            var sut = new NewYearChaos();
            var actual = sut.CalculateNumberOfBribes(queue);
            Assert.Equal(expectedBribes, actual);
        }

        public static IEnumerable<object[]> GetTestData()
        {
            yield return SampleTestCase0();
            yield return SampleTestCase0_TooChaotic();
            yield return SampleTestCase1();
            yield return SampleTestCase1_TooChaotic();
            yield return SampleTestCase2();
        }

        private static object[] SampleTestCase0()
        {
            return new object[] {
                new List<int>() { 2, 1, 5, 3, 4 },
                3
            };
        }

        private static object[] SampleTestCase0_TooChaotic()
        {
            return new object[] {
                new List<int>() { 2, 5, 1, 3, 4 },
                null
            };
        }

        private static object[] SampleTestCase1()
        {
            return new object[] {
                new List<int>() { 1, 2, 5, 3, 7, 8, 6, 4 },
                //                0  0  2  0  2  2  1  0
                7
            };
        }

        private static object[] SampleTestCase1_TooChaotic()
        {
            return new object[] {
                new List<int>() { 5, 1, 2, 3, 7, 8, 6, 4 },
                null
            };
        }

        private static object[] SampleTestCase2()
        {
            return new object[] {
                new List<int>() { 1, 2, 5, 3, 4, 7, 8, 6 },
                4
            };
        }
    }
}
