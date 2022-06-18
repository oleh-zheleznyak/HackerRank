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
            var result = SuperDigit(fullDigit);
            return (int)result;
        }

        private string CleanNumberString(string numberAsDirtyString, int timesToRepeat)
        {
            var normalizedString = numberAsDirtyString.Trim();
            var fullDigit = string.Concat(Enumerable.Repeat(normalizedString, timesToRepeat));
            return fullDigit;
        }

        private ulong SuperDigit(string x)
        {
            if (x.Length  == 1) return ulong.Parse(x);
            ulong sum = 0;
            foreach(var c in x)
            {
                byte digit = (byte)(c - '0');
                sum += digit;
            }
            return SuperDigit(sum);
        }

        private ulong SuperDigit(ulong x)
        {
            if (x< 10) return x;
            ulong sum = 0;
            while (x>0)
            {
                byte digit = (byte)(x % 10);
                sum += digit;
                x /= 10;
            }
            return SuperDigit(sum);
        }
    }
}
