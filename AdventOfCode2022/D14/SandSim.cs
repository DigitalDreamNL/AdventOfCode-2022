using AdventOfCode2022.D14.Exceptions;

namespace AdventOfCode2022.D14;

public static class SandSim
{
    public static List<Vector2> ParsePath(string path)
    {
        return path.Split(" -> ")
            .Select(p => new Vector2(p.Split(",")[0], p.Split(",")[1])).ToList();
    }

    public static List<List<Vector2>> ParsePaths(List<string> paths)
    {
        return paths.Select(ParsePath).ToList();
    }
    
    public static async Task<string> Simulate(string inputFile, bool addInifiniteFloor)
    {
        var paths = new List<string>();

        using var sr = new StreamReader(inputFile);
        while (!sr.EndOfStream)
            paths.Add((await sr.ReadLineAsync())!);

        if (addInifiniteFloor)
            paths.Add("0,169 -> 800,169");

        var points = SandSim.ParsePaths(paths);
        var map = Map.From(points);

        //DrawMap(points, map);

        var counter = 0;

        try
        {
            while (true)
            {
                var sand = new Sand(500, 0);
                var currentMovement = true;
                while (currentMovement)
                {
                    var oldX = sand.Position.X;
                    var oldY = sand.Position.Y;
                    sand.Fall(map.Squares);

                    if (oldX != sand.Position.X || oldY != sand.Position.Y)
                        continue;

                    if (map.Squares[oldX, oldY] == SquareType.Sand)
                        throw new SandIsStuckException();

                    map.Squares[oldX, oldY] = SquareType.Sand;
                    currentMovement = false;
                }

                counter++;
            }
        }
        catch (IndexOutOfRangeException)
        {
            // Sand tried to move out of grid, which means it would fall down forever
            return counter.ToString();
        }
        catch (SandIsStuckException)
        {
            // Sand can no longer move
            return counter.ToString();
        }
    }
}