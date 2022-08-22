namespace HackerRank.Problems;

public class LegoBlocks
{
    public static int[] BlockWidths = {1, 2, 3, 4};

    public int NumberOfCombinationsForWall(int height, int width)
    {
        var rowDecompCache = new int?[width+1];
        var result = NumberOfCombinationsForWall(height, width, rowDecompCache);
        return result;
    }

    public int NumberOfCombinationsForWall(int height, int width,int?[] rowDecompCache)
    {
        var rowDecompositions = NumberOfDecompositions(width, rowDecompCache);
        var wallDecompositions = (int)Math.Pow(rowDecompositions, height);

        var sum = 0;
        for (var i = 1; i < width; i++)
        {
            var invalidDecompositions = NumberOfCombinationsForWall(height, width - i, rowDecompCache);
            var multiplier = width-i >1 ?  2 : 1;
            sum = sum + invalidDecompositions * multiplier;
        }

        return wallDecompositions - sum;
    }
    
    private static int NumberOfDecompositions(int width, int?[] rowDecompCache)
    {
        if (width < 0) return 0;
        if (width==0) return 1;
        if (rowDecompCache[width].HasValue) return rowDecompCache[width].Value;
        
        var total = 0;
        foreach (var brick in BlockWidths)
        {
            var diff = width - brick;
            if (diff>=0)
            {
                total = total + NumberOfDecompositions(diff,rowDecompCache); 
            }
            else break;
        }

        rowDecompCache[width] = total;
        return total;
    }
}