namespace HackerRank.Problems;
public class FlipMatrixRowsToMaximizeSumBruteForce
{
    public int FindMaxSum(List<List<int>> matrix)
    {
        if (matrix == null) throw new ArgumentNullException(nameof(matrix));
        if (matrix.Count == 0) throw new ArgumentException("Matrix is empty", nameof(matrix));
        if (matrix.Count % 2 == 1) throw new ArgumentException("Matrix should have even number of rows and columns", nameof(matrix));

        var maxSum = FindMaxSumByExpandingRows(matrix,0);
        return maxSum;
    }

    private int FindMaxSumByExpandingRows(List<List<int>> matrix, int attempts)
    {
        var n = matrix.Count / 2;
        if (attempts >= 2 * n) return 0;

        var maxSum = 0;
        for (var i = 0; i < 4 * n; i++)
        {
            FlipRowOrColumn(matrix, i);

            var sum = SumFirstQuadrant(matrix);
            maxSum = Math.Max(sum, maxSum);

            var recursiveSum = FindMaxSumByExpandingRows(matrix, attempts + 1);
            maxSum = Math.Max(recursiveSum, maxSum);

            FlipRowOrColumn(matrix, i);
        }
        return maxSum;
    }

    private void FlipRowOrColumn(List<List<int>> matrix, int index)
    {
        var flipRows = index < matrix.Count;
        if (flipRows) InverseRow(matrix, index);
        else InverseColumn(matrix, index - matrix.Count);
    }

    private int SumFirstQuadrant(List<List<int>> matrix)
    {
        var n = matrix.Count / 2;
        var sum = 0;
        for (var i = 0; i < n; i++)
            for (var j = 0; j < n; j++)
                sum += matrix[i][j];
        return sum;
    }

    private void InverseRow(List<List<int>> matrix, int row)
    {
        var n = matrix.Count / 2;
        for (var i = 0; i < n; i++)
        {
            var temp = matrix[row][i];
            var index = matrix.Count - i - 1;
            matrix[row][i] = matrix[row][index];
            matrix[row][index] = temp;
        }
    }

    private void InverseColumn(List<List<int>> matrix, int column)
    {
        var n = matrix.Count / 2;
        for (var i = 0; i < n; i++)
        {
            var temp = matrix[i][column];
            var index = matrix.Count - i - 1;
            matrix[i][column] = matrix[index][column];
            matrix[index][column] = temp;
        }
    }
}
