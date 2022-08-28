namespace HackerRank.Problems;

public class LegoBlocks
{
    private static readonly int[] BlockWidths = {1, 2, 3, 4};
    private static readonly int Modulo = (int) Math.Pow(10, 9) + 7;
    private readonly Dictionary<(int, int), int> powerModuloCache = new();

    public int NumberOfCombinationsForWall(int height, int width)
    {
        if (height <= 0) throw new ArgumentException($"{nameof(height)} must be positive");
        if (width <= 0) throw new ArgumentException($"{nameof(width)} must be positive");
        if (width == 1) return 1;

        var cache = new int?[width + 1];
        var rowDecompositions = CalculateRowDecompositions(width);
        var result = NumberOfCombinationsForWall(height, width, rowDecompositions, cache);
        return result;
    }

    private int[] CalculateRowDecompositions(int width)
    {
        var rowDecompCache = new int?[width + 1];
        var rowDecompositions = Enumerable.Range(0, width + 1)
            .Select(x => NumberOfDecompositions(x, rowDecompCache))
            .ToArray();
        return rowDecompositions;
    }

    private int NumberOfCombinationsForWall(int height, int width, int[] rowDecompositionsCache, int?[] cache)
    {
        checked
        {
            if (cache[width].HasValue) return cache[width].Value;

            var rowDecompositions = rowDecompositionsCache[width];
            var allDecomp = PowModulo(rowDecompositions, height);

            double allInvalidDecomp = 0;
            for (var i = 1; i < width; i++)
            {
                var solidWallPrefix = NumberOfCombinationsForWall(height, i, rowDecompositionsCache, cache);
                // then there is a split in the wall at position between i and i+1
                var allWallDecompositions = rowDecompositionsCache[width - i];
                var anyWallSuffix = PowModulo(allWallDecompositions, height);
                allInvalidDecomp = (allInvalidDecomp + ((long)solidWallPrefix * anyWallSuffix) % Modulo) % Modulo;
            }

            var result = (int) (allDecomp - allInvalidDecomp + Modulo) % Modulo;
            cache[width] = result;
            return result;
        }
    }

    private int PowModulo(int baseNum, int power)
    {
        if (powerModuloCache.TryGetValue((baseNum, power), out var cachedValue))
            return cachedValue;
        
        var result = 1L;
        for (var i = 1; i <= power; i++)
        {
            result = result * baseNum % Modulo;
        }

        var computedValue = (int) (result + Modulo) % Modulo;
        powerModuloCache[(baseNum, power)] = computedValue;
        return computedValue;
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