namespace HackerRank.Problems.Test2;

class Result
{
    public static int palindromeIndex(string s) =>
      new PalindromeIndex().FindIndexToRemove(s);

}

public class PalindromeIndex : IPalindromeIndex
{
    private enum SearchResult : byte
    {
        NotFound = 0,
        AlreadyPalindrome = 1,
        SpecificIndex = 2
    }

    private readonly record struct PalindromeSearch(SearchResult SearchResult, int Index)
    {
        public bool IsAPalindrome() => SearchResult == SearchResult.AlreadyPalindrome;
    };

    private static PalindromeSearch NotFound = new (SearchResult.NotFound, -1);
    private static PalindromeSearch AlreadyAPalindrome = new(SearchResult.AlreadyPalindrome, -1);
    private static PalindromeSearch AtIndex(int index) => new (SearchResult.SpecificIndex, index);

    public int FindIndexToRemove(string s)
    {
        if (s is null) throw new ArgumentNullException(nameof(s));
        if (string.IsNullOrWhiteSpace(s)) return -1;
        if (s.Length == 1) return -1;

        var result = FindIndexToRemove(s, 0, s.Length - 1, true);

        return result.Index;
    }

    private PalindromeSearch FindIndexToRemove(string s, int start, int end, bool noDifferencesYet)
    {
        while (start < end)
        {
            if (s[start] == s[end])
            {
                start++;
                end--;
            }
            else if (noDifferencesYet)
            {
                var withoutStart = FindIndexToRemove(s, start + 1, end, false);
                var withoutEnd = FindIndexToRemove(s, start, end - 1, false);

                if (withoutStart.IsAPalindrome()) return AtIndex(start);
                else if (withoutEnd.IsAPalindrome()) return AtIndex(end);
                else return NotFound;
            }
            else return NotFound;
        }
        return AlreadyAPalindrome;
    }
}
