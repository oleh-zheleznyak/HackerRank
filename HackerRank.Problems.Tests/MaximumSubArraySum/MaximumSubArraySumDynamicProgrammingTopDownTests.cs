using HackerRank.Problems.MaximumSubArraySum;

namespace HackerRank.Problems.Tests.MaximumSubArraySum;

public class MaximumSubArraySumDynamicProgrammingTopDownTests : MaximumSubArraySumTestBase
{
    protected override IMaximumSubArraySum Implementation => new MaximumSubArraySumDynamicProgrammingTopDown();
}