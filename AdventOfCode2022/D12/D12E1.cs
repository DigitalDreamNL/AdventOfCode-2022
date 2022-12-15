using AdventOfCode2022.D12.Models;
using AdventOfCode2022.Helpers;

namespace AdventOfCode2022.D12;

public class D12E1 : D12, IPuzzle
{
    public async Task<string> Solve()
    {
        var heightmap = await ReadHeightmapFromInput();

        return (await new AsyncPuzzleSolver()
            .Execute($"[white]Finding shortest path to summit[/]", Solver(heightmap), true)).ToString();
    }
    
    private static Func<Action<double>, Task<int>> Solver(Heightmap heightmap) =>
        _ => Task.FromResult(CalculateSteps(heightmap));
}