using AdventOfCode2022.D12.Models;
using AdventOfCode2022.Helpers;

namespace AdventOfCode2022.D12;

public class D12E2 : D12, IPuzzle

{
    public async Task<string> Solve()
    {
        var heightmap = await ReadHeightmapFromInput();

        return (await DetermineLeastStepsFromAnyChar(heightmap, 'a')).ToString();
    }

    private async Task<int> DetermineLeastStepsFromAnyChar(Heightmap heightmap, char c)
    {
        return await new AsyncPuzzleSolver()
            .Execute($"[white]Finding shortest path to summit from any '{c}'[/]", Solver(heightmap, c), true);
    }

    private static Func<Action<double>, Task<int>> Solver(Heightmap heightmap, char c)
    {
        // Progress doesn't return correct value since improvement to use multiple threads
        return setProgress =>
        {
            var coords = FindAllNodesForCharacter(heightmap, c);

            var leastStepsFromAnyA = int.MaxValue;
            Parallel.For(0, coords.Count - 1, i =>
            {
                leastStepsFromAnyA =
                    UpdateLeastStepsFromAnyCharForNode(heightmap, coords, i, leastStepsFromAnyA, setProgress);
            });

            setProgress(100);

            return Task.FromResult(leastStepsFromAnyA);
        };
    }

    private static int UpdateLeastStepsFromAnyCharForNode(Heightmap heightmap, List<Coords> coords, int i,
        int leastStepsFromAnyA, Action<double> setProgress)
    {
        heightmap.SetStart(coords[i].X, coords[i].Y);
        try
        {
            leastStepsFromAnyA = Math.Min(leastStepsFromAnyA, CalculateSteps(heightmap));
        }
        catch
        {
            // No path can be found; ignore
        }

        setProgress((double) i / coords.Count * 100);
        return leastStepsFromAnyA;
    }

    private static List<Coords> FindAllNodesForCharacter(Heightmap heightmap, char c)
    {
        var coords = new List<Coords>();

        for (var x = 0; x < heightmap.Map.GetLength(0); x++)
        {
            for (var y = 0; y < heightmap.Map.GetLength(1); y++)
            {
                if (heightmap.Map[x, y] != c - 96) continue;

                coords.Add(new Coords(x, y));
            }
        }

        return coords;
    }
}