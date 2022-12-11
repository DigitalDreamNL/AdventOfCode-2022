using AdventOfCode2022.D8.Extensions;

namespace AdventOfCode2022.D8;

public class D8E2 : D8, IPuzzle
{
    private int NumberOfRows => Trees.Count;
    private int NumberOfColumns => Trees[0].Count;

    public async Task<string> Solve()
    {
        await PopulateForest();
        return FindHighestTreeValue().ToString();
    }

    private int FindHighestTreeValue()
    {
        var highestTreeValue = 0;
        for (var row = 0; row < NumberOfRows; row++)
        {
            for (var col = 0; col < NumberOfColumns; col++)
            {
                highestTreeValue = Math.Max(highestTreeValue, CalculateTreeValue(row, col));
            }
        }
        return highestTreeValue;
    }

    private int CalculateTreeValue(int row, int col)
    {
        return CalculateVisibleTreesTop(row, col) * CalculateVisibleTreesRight(row, col) *
               CalculateVisibleTreesBottom(row, col) * CalculateVisibleTreesLeft(row, col);
    }

    private int CalculateVisibleTreesTop(int row, int col)
    {
        var visibleTrees = 0;
        for (var i = row; i > 0; i--)
        {
            visibleTrees++;
            if (Trees[row][col].CannotSeePast(Trees[i - 1][col])) break;
        }
        return visibleTrees;
    }

    private int CalculateVisibleTreesRight(int row, int col)
    {
        var visibleTrees = 0;
        for (var i = col; i < NumberOfColumns - 1; i++)
        {
            visibleTrees++;
            if (Trees[row][col].CannotSeePast(Trees[row][i + 1])) break;
        }
        return visibleTrees;
    }

    private int CalculateVisibleTreesBottom(int row, int col)
    {
        var visibleTrees = 0;
        for (var i = row; i < NumberOfRows - 1; i++)
        {
            visibleTrees++;
            if (Trees[row][col].CannotSeePast(Trees[i + 1][col])) break;
        }
        return visibleTrees;
    }

    private int CalculateVisibleTreesLeft(int row, int col)
    {
        var visibleTrees = 0;
        for (var i = col; i > 0; i--)
        {
            visibleTrees++;
            if (Trees[row][col].CannotSeePast(Trees[row][i - 1])) break;
        }
        return visibleTrees;
    }
}