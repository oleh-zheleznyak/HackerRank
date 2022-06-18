namespace HackerRank.Problems;

class Result
{
    public static int superDigit(string n, int k)
    {
        return new RecursiveDigitSum().SuperDigit(n, k);
    }
}


public class RecursiveDigitSum
{
    public int SuperDigit(string numberAsDirtyString, uint timesToRepeat)
    {
        var normalizedString = numberAsDirtyString.Trim();
        var sum = CalculateInitialSum(normalizedString);
        var result = SuperDigit(sum * timesToRepeat);
        return (int)result;
    }

    private uint CalculateInitialSum(string x)
    {
        if (x.Length  == 1) return uint.Parse(x);
        uint sum = 0;
        foreach(var c in x)
        {
            byte digit = (byte)(c - '0');
            sum += digit;
        }
        return sum;
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
