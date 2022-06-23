using HackerRank.Problems.Test2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HackerRank.Problems.Tests
{
    public class PalindromeIndexTests : PalindromeIndexTestsBase
    {
        protected override IPalindromeIndex CreateSystemUnderTest() => new PalindromeIndex();
    }
}
