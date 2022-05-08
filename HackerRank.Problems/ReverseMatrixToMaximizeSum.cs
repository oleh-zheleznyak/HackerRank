namespace HackerRank.Problems;
public class ReverseMatrixToMaximizeSum
{
    public int FindMaxSum(List<List<int>> matrix)
    {
        if (matrix is null) throw new ArgumentNullException(nameof(matrix));
        if (matrix.Count == 0) throw new ArgumentException("Matrix is empty", nameof(matrix));
        if (matrix.Count % 2 == 1) throw new ArgumentException("Matrix should have even number of rows and columns", nameof(matrix));

        var normal = FindMaxSumByExpandingRows(matrix, 0, false);
        var inverse = FindMaxSumByExpandingRows(matrix, 0, true);
        var maxSum = Math.Max(normal, inverse);
        return maxSum;
    }

    private int FindMaxSumByExpandingRows(List<List<int>> matrix, int row, bool inverse)
    {
        if (row == matrix.Count)
        {
            var normalCol = FindMaxSumByExpandingColumns(matrix, 0, false);
            var inversedCol = FindMaxSumByExpandingColumns(matrix, 0, true);
            var maxSumCol = Math.Max(normalCol, inversedCol);

            return maxSumCol;
        }

        if (inverse) InverseRow(matrix, row);

        var normal = FindMaxSumByExpandingRows(matrix, row + 1, false);
        var inversed = FindMaxSumByExpandingRows(matrix, row + 1, true);
        var maxSum = Math.Max(normal, inversed);

        if (inverse) InverseRow(matrix, row);

        return maxSum;
    }

    private int FindMaxSumByExpandingColumns(List<List<int>> matrix, int column, bool inverse)
    {
        if (column == matrix.Count)
        {
            return SumFirstQuadrant(matrix);
        }

        if (inverse) InverseColumn(matrix, column);

        var normal = FindMaxSumByExpandingColumns(matrix, column + 1, false);
        var inversed = FindMaxSumByExpandingColumns(matrix, column + 1, true);
        var maxSum = Math.Max(normal, inversed);

        if (inverse) InverseColumn(matrix, column);

        return maxSum;
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
