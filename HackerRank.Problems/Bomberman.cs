namespace HackerRank.Problems.Test5;
    class Result
    {
        public static List<string> bomberMan(int n, List<string> grid) =>
            new BomberMan().Simulate(n, grid);
    }

    public readonly record struct Point(int row, int col);
    public class BomberMan
    {
        private static char Bomb = 'O';
        private static char Crater = '.';

        public List<string> Simulate(int n, List<string> grid)
        {
            if (n <= 0) throw new ArgumentException($"{nameof(n)}<=0", nameof(n));
            if (n == 1) return grid;
            if (n % 2 == 0) return Convert(FullyFilled(grid));

            var k = n % 4; // 1=initial-2=filled-3=shape1-4=filled-5=shape2-6=filled-shape1...
            if (k == 3) return Exploded(grid); // 3=snape1 - one explosion
            return Exploded(Exploded(grid));
        }

        private List<string> Exploded(List<string> grid)
        {
            var fullyFilled = FullyFilled(grid);
            var locations = GetBombLocations(grid).ToList(); // .ToList just for debugging
            var craters = GoBoomInsideGrid(locations, grid).ToList();
            PutCraters(fullyFilled, craters);
            return Convert(fullyFilled);
        }

        private List<string> Convert(List<char[]> grid) =>
          grid.Select(x => new string(x)).ToList();

        private void PutCraters(List<char[]> grid, IEnumerable<Point> craters)
        {
            foreach (var crater in craters)
                grid[crater.row][crater.col] = Crater;
        }

        private List<char[]> FullyFilled(List<string> grid)
        {
            var row = Enumerable.Repeat(Bomb, grid[0].Length);
            return Enumerable.Range(1, grid.Count).Select(x => row.ToArray()).ToList();
        }

        private IEnumerable<Point> GetBombLocations(List<string> grid)
        {
            for (var row = 0; row < grid.Count; row++)
                for (var col = 0; col < grid[row].Length; col++)
                    if (grid[row][col] == Bomb) yield return new Point(row, col);
        }

        private IEnumerable<Point> GoBoom(Point point)
        {
            yield return point;
            yield return new Point(point.row + 1, point.col);
            yield return new Point(point.row - 1, point.col);
            yield return new Point(point.row, point.col + 1);
            yield return new Point(point.row, point.col - 1);
        }

        private IEnumerable<Point> GoBoomInsideGrid(Point point, List<string> grid)
        {
            return GoBoom(point).Where(
                x => x.row < grid.Count &&
                x.row >= 0 &&
                x.col < grid[0].Length &&
                x.col >= 0
                );
        }

        private IEnumerable<Point> GoBoomInsideGrid(IEnumerable<Point> points, List<string> grid) =>
            points.SelectMany(x => GoBoomInsideGrid(x, grid));

    }