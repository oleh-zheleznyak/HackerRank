namespace HackerRank.Problems;
public class ReverseMatrixToMaximizeSum
{
    public int FindMaxSum(List<List<int>> matrix)
    {
        if (matrix == null) throw new ArgumentNullException(nameof(matrix));
        if (matrix.Count == 0) throw new ArgumentException("Matrix is empty", nameof(matrix));
        if (matrix.Count % 2 == 1) throw new ArgumentException("Matrix should have even number of rows and columns", nameof(matrix));

        var maxSum = FindMaxSumByExpandingRows(matrix);
        return maxSum;
    }

    private int FindMaxSumByExpandingRows(List<List<int>> matrix)
    {
        var sums = new int[] {
        FlipColumnsBySum(matrix),
        FlipRowsBySum(matrix),
        FlipColumnsBySum(matrix),
        FlipRowsBySum(matrix),
        };

        return sums.Max();
    }

    private int FlipColumnsBySum(List<List<int>> matrix)
    {
        for (var col = 0; col < matrix.Count; col++)
        {
            var (left, right) = SumColumn(matrix, col);
            if (left < right) InverseColumn(matrix, col);
        }
        return SumFirstQuadrant(matrix);
    }

    private int FlipRowsBySum(List<List<int>> matrix)
    {
        for (var row = 0; row < matrix.Count; row++)
        {
            var (left, right) = SumRow(matrix, row);
            if (left < right) InverseRow(matrix, row);
        }
        return SumFirstQuadrant(matrix);
    }

    private (int leftSum, int rightSum) SumRow(List<List<int>> matrix, int row)
    {
        var n = matrix.Count / 2;
        var (left, right) = (0, 0);
        for (var col = 0; col < n; col++)
        {
            left += matrix[row][col];
            right += matrix[row][n + col];
        }
        return (left, right);
    }

    private (int leftSum, int rightSum) SumColumn(List<List<int>> matrix, int column)
    {
        var n = matrix.Count / 2;
        var (top, bottom) = (0, 0);
        for (var row = 0; row < n; row++)
        {
            top += matrix[row][column];
            bottom += matrix[n + row][column];
        }
        return (top, bottom);
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
