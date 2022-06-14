using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HackerRank.Problems.Tests;

public class CaesarCipherTests
{
    [Theory]
    [InlineData("middle-Outz",2,"okffng-Qwvb")]
    [InlineData("Always-Look-on-the-Bright-Side-of-Life",5,"Fqbfdx-Qttp-ts-ymj-Gwnlmy-Xnij-tk-Qnkj")]
    [InlineData("zero",0,"zero")]
    [InlineData("alphabet size",'z'-'a'+1,"alphabet size")]
    [InlineData("abc",'z'-'a'+2,"bcd")]
    public void EncryptTest(string input, int shift, string expectedResult)
    {
        var sut = new CaesarCipher();
        var actual = sut.Encrypt(input, shift);

        Assert.Equal(expectedResult, actual);
    }
}