using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HackerRank.Problems.Tests
{
    public class SimpleTextEditorTests
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void ExecuteOperationsTest(string[] operations, string expectedResult)
        {
            var operationFactory = new OperationFactory(operations);
            var editor = new SimpleTextEditor();
            var result = editor.ExecuteOperations(operationFactory);

            Assert.Equal(expectedResult, result);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return ShouldAppend();
            yield return ShouldDelete();
            yield return ShouldUndoAppend();
            yield return ShouldUndoDelete();
            yield return ShouldPassSampleTestCase0();
        }

        public static object[] ShouldAppend() => new object[]
        {

            new [] { "1", "1 abc" },
            "abc"
        };

        public static object[] ShouldDelete() => new object[]
        {

            new [] { "2", "1 abc", "2 1" },
            "ab"
        };


        public static object[] ShouldUndoAppend() => new object[]
        {
            new [] { "3", "1 a", "1 b", "4" },
            "a"
        };

        public static object[] ShouldUndoDelete() => new object[]
        {
            new [] { "3", "1 abc", "2 1", "4" },
            "abc"
        };

        public static object[] ShouldPassSampleTestCase0() => new object[]
        {
            new [] { "8", "1 abc", "3 3", "2 3", "1 xy", "3 2", "4", "4", "3 1" },
            "abc"
        };
    }
}
