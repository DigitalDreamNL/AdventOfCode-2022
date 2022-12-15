using AdventOfCode2022.D14;
using AdventOfCode2022.Helpers;

namespace AdventOfCode2022.D15;

public class D15E2 : D15, IPuzzle
{
    private const ulong XMultiplier = 4000000;
    private readonly string _inputFile;
    private readonly int _gridSize;

    public D15E2(string inputFile = "D15/src/input.txt", int gridSize = 4000000)
    {
        _inputFile = inputFile;
        _gridSize = gridSize;
    }
    
    public async Task<string> Solve()
    {
        var coordinates = await new AsyncPuzzleSolver()
            .Execute($"[white]Calculating position of beacon'[/]", Solver(), true);
        
        var solution = XMultiplier * (ulong)coordinates.X + (ulong)coordinates.Y;

        return solution.ToString();
    }
    
    private Func<Action<double>, Task<Vector2>> Solver() =>
        _ => CalculateCoordinates();

    private async Task<Vector2> CalculateCoordinates()
    {
        var positions = await ReadInput();

        Vector2? result = null;
        var count = 0;
        while (result == null)
        {
            Parallel.For(2500000, _gridSize, y =>
            {
                var allLimits = positions.Select(position => CalculateLimitsOnLine(position, y)).Where(x => x.Any())
                    .ToList();
                var x = 0;
                while (x <= _gridSize && result == null)
                {
                    var currentX = x;
                    var nextLimit = allLimits.Where(l => l[0] <= currentX).MaxBy(l => l[1]);
                    if (nextLimit![1] == x)
                        result = new Vector2(x + 1, y);

                    x = nextLimit[1];
                    // Console.Write($"{count} iterations");
                    // Console.SetCursorPosition(0, Console.CursorTop);

                    count++;
                }
            });
        }

        return result ?? throw new Exception("No beacon found");
    }

    private async Task<List<List<Vector2>>> ReadInput()
    {
        var positions = new List<List<Vector2>>();

        using var sr = new StreamReader(_inputFile);
        while (!sr.EndOfStream)
        {
            var line = await sr.ReadLineAsync();
            positions.Add(Parse(line!));
        }

        return positions;
    }
}