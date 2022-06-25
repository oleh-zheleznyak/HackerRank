namespace HackerRank.Problems.Test2;

class Result
{
    public static int palindromeIndex(string s) =>
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
                if (differenceFound) return -1; //cbabcB
                differenceFound = true;

                if (start + 1 == end) return start; // abca -> aca

                var start_plusOne_eq_end = s[start + 1] == s[end];
                var start_eq_end_minusOne = s[start] == s[end - 1];

                if (start_plusOne_eq_end && start_eq_end_minusOne)
                {
                    // delete first - we are equal = babcB
                    if (s[start + 2] == s[end - 1])
                    {
                        candidateIndex = start;
                        start++;
                    }
                    else
                    {
                        candidateIndex = end;
                        end--;
                    }
                }
                else if (start_plusOne_eq_end) // abcca -> acca
                {
                    candidateIndex = start;
                    start++;
                }
                else if (start_eq_end_minusOne) // accba -> acca
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
