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

            return FindIndexToRemoveGivenValidString(s);
        }

        private static int FindIndexToRemoveGivenValidString(string s)
        {
            // example -  a b c a
            // move from both ends
            //   if mismatch -> look one ahead (if possible) in both directions
            //   if at least one match proceed
            //   if more than one diff - return false
            //   if not possible to look ahead return true

            var start = 0;
            var end = s.Length - 1;
            var differenceFound = false;
            var candidateIndex = -1;

            while (start < end)
            {
                if (s[start] != s[end])
                {
                    if (differenceFound) return -1;
                    differenceFound = true;

                    if (start + 1 == end) return start; // abca -> aca
                    
                    if (s[start + 1] == s[end]) // abcca -> acca
                    {
                        candidateIndex = start;
                        start++;
                    }
                    else if (s[start] == s[end-1]) // accba -> acca
                    {
                        candidateIndex = end;
                        end--;
                    }
                }
                else
                {
                    start++;
                    end--;
                }
            }
            return candidateIndex;
        }
    }
}
