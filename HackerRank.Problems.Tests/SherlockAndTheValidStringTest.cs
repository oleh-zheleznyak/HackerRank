using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HackerRank.Problems.Tests
{
    public class SherlockAndTheValidStringTest
    {
        [Theory]
        [InlineData("a", true)]
        [InlineData("aa", true)]
        [InlineData("ab", true)]
        [InlineData("abc", true)]
        [InlineData("aab", true)]
        [InlineData("aaa", true)]
        [InlineData("aaab", true)]
        [InlineData("abcc", true)]
        [InlineData("abbcc", true)]
        [InlineData("abbccc", false)]
        [InlineData("aabbbccc", false)]
        [InlineData("aabbc", true)]
        [InlineData("abccc", false)]
        [InlineData("aabbbcc", true)]
        [InlineData("abcdefghhgfedecba", true)]
        [InlineData("aabbccddeefghi", false)]
        [InlineData("aaabbbc", true)]
        [InlineData("ibfdgaeadiaefgbhbdghhhbgdfgeiccbiehhfcggchgghadhdhagfbahhddgghbdehidbibaeaagaeeigffcebfbaieggabcfbiiedcabfihchdfabifahcbhagccbdfifhghcadfiadeeaheeddddiecaicbgigccageicehfdhdgafaddhffadigfhhcaedcedecafeacbdacgfgfeeibgaiffdehigebhhehiaahfidibccdcdagifgaihacihadecgifihbebffebdfbchbgigeccahgihbcbcaggebaaafgfedbfgagfediddghdgbgehhhifhgcedechahidcbchebheihaadbbbiaiccededchdagfhccfdefigfibifabeiaccghcegfbcghaefifbachebaacbhbfgfddeceababbacgffbagidebeadfihaefefegbghgddbbgddeehgfbhafbccidebgehifafgbghafacgfdccgifdcbbbidfifhdaibgigebigaedeaaiadegfefbhacgddhchgcbgcaeaieiegiffchbgbebgbehbbfcebciiagacaiechdigbgbghefcahgbhfibhedaeeiffebdiabcifgccdefabccdghehfibfiifdaicfedagahhdcbhbicdgibgcedieihcichadgchgbdcdagaihebbabhibcihicadgadfcihdheefbhffiageddhgahaidfdhhdbgciiaciegchiiebfbcbhaeagccfhbfhaddagnfieihghfbaggiffbbfbecgaiiidccdceadbbdfgigibgcgchafccdchgifdeieicbaididhfcfdedbhaadedfageigfdehgcdaecaebebebfcieaecfagfdieaefdiedbcadchabhebgehiidfcgahcdhcdhgchhiiheffiifeegcfdgbdeffhgeghdfhbfbifgidcafbfcd", true)]
        public void IsValidTest(string value, bool expectedValidity)
        {
            var sut = new SherlockAndTheValidString();
            var actualValidity = sut.IsValid(value);
            Assert.Equal(expectedValidity, actualValidity);
        }
    }
}
