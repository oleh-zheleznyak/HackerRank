using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems
{

    class Result
    {
        public static int superDigit(string n, int k)
        {
            return new RecursiveDigitSum().SuperDigit(n, k);
        }
    }


    public class RecursiveDigitSum
    {
        public int SuperDigit(string numberAsDirtyString, int timesToRepeat)
        {
            var fullDigit = CleanNumberString(numberAsDirtyString, timesToRepeat);
            var result = (int)SuperDigit(fullDigit);
            return result;
        }

        private BigInteger CleanNumberString(string numberAsDirtyString, int timesToRepeat)
        {
            var normalizedString = numberAsDirtyString.Trim();
            var fullDigit = BigInteger.Parse(string.Concat(Enumerable.Repeat(normalizedString, timesToRepeat)));
            return fullDigit;
        }

        private long SuperDigit(BigInteger x)
        {
            if (x < 10) return (long)x;
            long sum = 0;
            while (x > 0)
            {
                long digit = (long)BigInteger.ModPow( x , 1, 10);
                sum += digit;
                x /= 10;
            }
            return SuperDigit(sum);
        }
    }
}
