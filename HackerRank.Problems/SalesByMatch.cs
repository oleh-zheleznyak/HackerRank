namespace HackerRank.Problems;
public class SalesByMatch
{
    public int sockMerchant(int n, List<int> ar)
    {
        var socksCountArray = new int[101];

        for (var i = 0; i < ar.Count; i++)
            socksCountArray[ar[i]] = socksCountArray[ar[i]] + 1;

        var numberOfPairs = 0;
        for (var i = 0; i < socksCountArray.Length; i++)
                numberOfPairs = numberOfPairs + socksCountArray[i] / 2;

        return numberOfPairs;
    }
}