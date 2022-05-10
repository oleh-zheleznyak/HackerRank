namespace HackerRank.Problems;
public class FlipMatrixRowsToMaximizeSum
{
    public int FindMaxSum(List<List<int>> matrix)
    {
        if (matrix == null) throw new ArgumentNullException(nameof(matrix));
        if (matrix.Count == 0) throw new ArgumentException("Matrix is empty", nameof(matrix));
        if (matrix.Count % 2 == 1) throw new ArgumentException("Matrix should have even number of rows and columns", nameof(matrix));

        var maxSum = FindMaxByChoosingMaxCell(matrix);
        return maxSum;
    }

    private int FindMaxByChoosingMaxCell(List<List<int>> matrix)
    {
        var sum = 0;
        var n = matrix.Count / 2;
        var quadruple = new int[4];

        for (int row = 0; row <n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                quadruple[0]=matrix[row][col];
                quadruple[1]=matrix[row][2*n-col-1];
                quadruple[2]=matrix[2*n-1-row][col];
                quadruple[3]=matrix[2*n-1-row][2*n-col-1];

                var max = quadruple.Max();
                sum += max;
            }
        }
        return sum;
    }
}
