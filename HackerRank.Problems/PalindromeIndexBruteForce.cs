namespace HackerRank.Problems;

public class PalindromeIndexBruteForce : IPalindromeIndex
{
    public int FindIndexToRemove(string s)
    {
        if (s is null) throw new ArgumentNullException(nameof(s));
        if (string.IsNullOrWhiteSpace(s)) return -1;
        if (s.Length == 1) return -1;

        for (int i = -1; i < s.Length; i++)
            if (IsPalindromeWhenRemovingAtIndex(i, s)) return i;

        return -1;
    }

    private bool IsPalindromeWhenRemovingAtIndex(int i, string s)
    {
        var start = 0;
        var end = s.Length - 1;

        while (start < end)
        {
            if (start == i) start++;
            if (end == i) end--;

            if (s[start] != s[end]) return false;

            start++;
            end--;
        }
        return true;
    }
}
