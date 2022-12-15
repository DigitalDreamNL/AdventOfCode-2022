namespace AdventOfCode2022.D12.Models;

public class Heightmap
{
    public int[,] Map { get; private init; } = null!;
    public Coords Start { get; private set; }
    public Coords End { get; private init; }
    public int MaxClimbHeight { get; private init; }

    public void SetStart(int x, int y) => Start = new Coords(x, y);

    public static Heightmap FromLines(string[] lines, int maxClimbHeight = 0)
    {
        var maxX = lines.Length;
        var maxY = lines[0].Length;

        var map = new int[maxX, maxY];
        Coords start = default;
        Coords end = default;

        for (var x = 0; x < maxX; x++)
        {
            for (var y = 0; y < maxY; y++)
            {
                var value = lines[x][y];

                if (value == 83) // == S == Start
                {
                    start = new Coords(x, y);
                    map[x, y] = 0;
                    continue;
                }

                if (value == 69) // == E == End
                {
                    end = new Coords(x, y);
                    map[x, y] = 26;
                    continue;
                }

                map[x, y] = value - 96;
            }
        }

        return new Heightmap
        {
            Map = map,
            Start = start,
            End = end,
            MaxClimbHeight = maxClimbHeight
        };
    }
}