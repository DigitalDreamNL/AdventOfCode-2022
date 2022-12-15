using AdventOfCode2022.Helpers;

namespace AdventOfCode2022.D15;

public class D15E1 : D15, IPuzzle
{
    private readonly string _inputFile;
    private readonly int _line;

    public D15E1(string inputFile = "D15/src/input.txt", int line = 2000000)
    {
        _inputFile = inputFile;
        _line = line;
    }
    
    public async Task<string> Solve()
    {
        var solution = await new AsyncPuzzleSolver()
            .Execute("[white]Calculating positions'[/]", Solver(), true);

        return solution.ToString();
    }
    
    private Func<Action<double>, Task<int>> Solver() =>
        _ => Calculate();
    
    public async Task<int> Calculate()
    {
        var allLimits = new List<List<int>>();
        
        using var sr = new StreamReader(_inputFile);
        while (!sr.EndOfStream)
        {
            var line = await sr.ReadLineAsync();
            var positions = Parse(line!);
            var limits = CalculateLimitsOnLine(positions, _line);
            
            if (limits.Count == 0)
                continue;
            
            allLimits.Add(limits);

            // Console.WriteLine($"Limits: {limits[0]}, {limits[1]}");
        }

        var minX = allLimits.Select(l => l[0]).Min();
        var maxX = allLimits.Select(l => l[1]).Max();
        
        // Console.WriteLine($"Min X: {minX}");
        // Console.WriteLine($"Max X: {maxX}");

        var coveredPositions = 0;
        for (var i = minX - 2; i < maxX + 2; i++)
        {
            if (allLimits.Any(l => l[0] <= i && l[1] >= i))
                coveredPositions++;
        }

        var solution = coveredPositions - 1;
        //Console.WriteLine($"Spots: {solution}");

        return solution;
    }
}