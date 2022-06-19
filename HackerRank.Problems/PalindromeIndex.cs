using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.Test2
{
    class Result
    {
        public static int palindromeIndex(string s)=>
          new PalindromeIndex().FindIndexToRemove(s);

    }

    public class PalindromeIndex : IPalindromeIndex
    {
        public int FindIndexToRemove(string s)
        {
            if (s is null) throw new ArgumentNullException(nameof(s));
            if (string.IsNullOrWhiteSpace(s)) return -1;
            if (s.Length == 1) return -1;

            var editCount = 0;
            var diffIndex = -1;
            var start = 0;
            var end = s.Length - 1;
            while (start < end)
            {
                if (s[start] != s[end])
                {
                    editCount++;

                    if (s[start + 1] == s[end])
                    {
                        diffIndex = start;
                        start++;
                    }
                    else
                    {
                        diffIndex = end;
                        end++;
                    }


                    if (editCount > 1) return -1;
                }
                else
                {
                    start++;
                    end--;
                }
            }

            return diffIndex;
        }
    }
}
