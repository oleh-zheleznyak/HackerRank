namespace HackerRank.Problems.Test3;

class Result
{

    public static int getTotalX(List<int> a, List<int> b) => new BetweenTwoSets().GetTotalX(a, b);
}

public class BetweenTwoSets
{
    public int GetTotalX(List<int> a, List<int> b)
    {
        if (a is null) throw new ArgumentNullException(nameof(a));
        if (a.Count == 0) return 0;
        // TODO: same for b
        return CountTotalNumbersBetweenTwoSets(a, b);
    }

    public int CountTotalNumbersBetweenTwoSets(List<int> a, List<int> b)
    {
        var range_min = a.Max();
        var range_max = b.Min();
        var counter = 0;
        for (var i = range_min; i<=range_max; i++)
        {
            var isDividedByA = NumberIsEvenlyDividedByEveryElement(i, a);
            var dividesB = NumberEvenlyDividesEveryElement(i, b);
            if (isDividedByA && dividesB) counter++;
        }
        return counter;
    }

    private bool NumberIsEvenlyDividedByEveryElement(int number, List<int> elements)
    {
        for (int j = 0; j < elements.Count; j++)
        {
            var remainder = number % elements[j];
            if (remainder!=0) return false;
        }
        return true;
    }

    private bool NumberEvenlyDividesEveryElement(int number, List<int> elements)
    {
        for (int j = 0; j < elements.Count; j++)
        {
            var remainder = elements[j] % number;
            if (remainder != 0) return false;
        }
        return true;
    }
}
