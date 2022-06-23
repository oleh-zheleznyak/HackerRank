using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HackerRank.Problems.Tests
{
    public class PalindromeIndexBruteForceTests : PalindromeIndexTestsBase
    {
        protected override IPalindromeIndex CreateSystemUnderTest() => new PalindromeIndexBruteForce();
    }
}
