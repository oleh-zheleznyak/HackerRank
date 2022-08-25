namespace HackerRank.Problems;

public class LegoBlocks
{
    private static readonly int[] BlockWidths = {1, 2, 3, 4};

    public int NumberOfCombinationsForWall(int height, int width)
    {
        var rowDecompositions = CalculateRowDecompositions(width);
        var result = NumberOfCombinationsForWall(height, width, rowDecompositions);
        return result;
    }

    private int[] CalculateRowDecompositions(int width)
    {
        var rowDecompCache = new int?[width + 1];
        var rowDecompositions = Enumerable.Range(0, width+1)
            .Select(x => NumberOfDecompositions(x, rowDecompCache))
            .ToArray();
        return rowDecompositions;
    }

    private int NumberOfCombinationsForWall(int height, int width, int[] rowDecompositionsCache)
    {
        var rowDecompositions = rowDecompositionsCache[width];
        var allDecomp = (int) Math.Pow(rowDecompositions, height);

        var allInvalidDecomp = 0;
        for (var i = 1; i < width; i++)
        {
            var solidWallPrefix = NumberOfCombinationsForWall(height, i, rowDecompositionsCache);
            // then there is a split in the wall at position between i and i+1
            var allWallDecompositions = rowDecompositionsCache[width - i];
            var anyWallSuffix = (int) Math.Pow(allWallDecompositions, height);
            allInvalidDecomp += solidWallPrefix * anyWallSuffix;
        }

        return allDecomp - allInvalidDecomp;
    }

    public int NumberOfDecompositions(int width, int?[] rowDecompCache)
    {
        if (width < 0) return 0;
        if (width == 0) return 1;
        if (rowDecompCache[width].HasValue) return rowDecompCache[width].Value;

        var total = 0;
        foreach (var brick in BlockWidths)
        {
            var diff = width - brick;
            if (diff >= 0)
            {
                total = total + NumberOfDecompositions(diff, rowDecompCache);
            }
            else break;
        }

        rowDecompCache[width] = total;
        return total;
    }
}