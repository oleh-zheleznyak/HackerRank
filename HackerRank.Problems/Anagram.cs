namespace HackerRank.Problems.Test4;

class Result
{
    public static int anagram(string s) => new Anagram().EditDistance(s);
}
public class Anagram
{
    public int EditDistance(string s)
    {
        if (s is null) throw new ArgumentNullException(nameof(s));
        if (string.IsNullOrWhiteSpace(s)) throw new ArgumentException("null or whitespace", nameof(s));
        if (s.Length % 2 != 0) return -1;

        return EditDistanceSafe(s);
    }

    private int EditDistanceSafe(string s)
    {
        var half = s.Length / 2;
        var leftHalf = CharHistogram(s.Take(half));
        var rightHalf = s.Skip(half).ToList();

        var difference = 0;

        foreach (var c in rightHalf)
        {
            if (leftHalf.TryGetValue(c, out var count))
            {
                if (count > 1) leftHalf[c] = count - 1;
                else leftHalf.Remove(c);
            }
            else difference++;
        }

        return difference;
    }

    private IDictionary<char,int> CharHistogram(IEnumerable<char> chars)=> chars.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
}
