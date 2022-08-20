using HackerRank.Problems.MaximumSubArraySum;

namespace HackerRank.Problems.Tests.MaximumSubArraySum;

public class MaximumSubArraySumDynamicProgrammingBottomUpTests : MaximumSubArraySumTestBase
{
    protected override IMaximumSubArraySum Implementation => new MaximumSubArraySumDynamicProgrammingBottomUp();
}