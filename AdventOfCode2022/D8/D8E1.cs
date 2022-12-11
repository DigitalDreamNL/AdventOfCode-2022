namespace AdventOfCode2022.D8;

public class D8E1 : D8, IPuzzle
{
    public async Task<string> Solve()
    {
        await PopulateForest();
        return TreesVisibleInHorizontalLines().Concat(TreesVisibleInVerticalLines())
            .Distinct().Count().ToString();
    }

    private IEnumerable<string> TreesVisibleInHorizontalLines()
    {
        var visibleTrees = new List<string>();
        for (var row = 0; row < Trees.Count; row++)
        {
            visibleTrees.AddRange(TreesVisibleFromLeft(row));
            visibleTrees.AddRange(TreesVisibleFromRight(row));
        }
        return visibleTrees;
    }

    private IEnumerable<string> TreesVisibleFromLeft(int row)
    {
        var visibleTrees = new List<string>();
        var highestTree = 0;
        for (var col = 0; col < Trees[row].Count; col++)
        {
            var value = Trees[row][col];
            if (col == 0 || value > highestTree)
            {
                visibleTrees.Add(FormatCoordinates(row, col));
                highestTree = value;
            }
            if (highestTree == 9) break;
        }
        return visibleTrees;
    }

    private IEnumerable<string> TreesVisibleFromRight(int row)
    {
        var visibleTrees = new List<string>();
        var highestTree = 0;
        for (var col = Trees[row].Count - 1; col >= 0; col--)
        {
            var value = Trees[row][col];
            if (col == Trees[row].Count - 1 || value > highestTree)
            {
                visibleTrees.Add(FormatCoordinates(row, col));
                highestTree = value;
            }
            if (highestTree == 9) break;
        }
        return visibleTrees;
    }

    private IEnumerable<string> TreesVisibleInVerticalLines()
    {
        var visibleTrees = new List<string>();
        for (var col = 0; col < Trees[0].Count; col++)
        {
            visibleTrees.AddRange(TreesVisibleFromTop(col)); 
            visibleTrees.AddRange(TreesVisibleFromBottom(col));
        }
        return visibleTrees;
    }

    private IEnumerable<string> TreesVisibleFromTop(int col)
    {
        var visibleTrees = new List<string>();
        var highestTree = 0;
        for (var row = 0; row < Trees.Count; row++)
        {
            var value = Trees[row][col];
            if (row == 0 || value > highestTree)
            {
                visibleTrees.Add(FormatCoordinates(row, col));
                highestTree = value;
            }
            if (highestTree == 9) break;
        }
        return visibleTrees;
    }

    private IEnumerable<string> TreesVisibleFromBottom(int col)
    {
        var visibleTrees = new List<string>();
        var highestTree = 0;
        for (var row = Trees.Count - 1; row >= 0; row--)
        {
            var value = Trees[row][col];
            if (row == Trees.Count - 1 || value > highestTree)
            {
                visibleTrees.Add(FormatCoordinates(row, col));
                highestTree = value;
            }
            if (highestTree == 9) break;
        }
        return visibleTrees;
    }

    private static string FormatCoordinates(int x, int y) => $"{x}-{y}";
}