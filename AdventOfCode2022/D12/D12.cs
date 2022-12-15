using AdventOfCode2022.D12.Models;

namespace AdventOfCode2022.D12;

public class D12
{
    protected async Task<Heightmap> ReadHeightmapFromInput()
    {
        using var sr = new StreamReader("D12/src/input.txt");
        var lines = (await sr.ReadToEndAsync()).Split(Environment.NewLine);
        return Heightmap.FromLines(lines, 1);
    }

    protected static int CalculateSteps(Heightmap heightmap) =>
        new PathFinder(heightmap).DetermineShortestPath().Count;
}