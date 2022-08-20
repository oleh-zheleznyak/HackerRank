using HackerRank.Problems.MaximumSubArraySum;

namespace HackerRank.Problems.Tests.MaximumSubArraySum;

public class MaximumSubArraySumBruteForceTests : MaximumSubArraySumTestBase
{
    protected override IMaximumSubArraySum Implementation => new MaximumSubArraySumBruteForce();
}