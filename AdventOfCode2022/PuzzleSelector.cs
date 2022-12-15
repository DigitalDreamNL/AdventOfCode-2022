using AdventOfCode2022.D1;
using AdventOfCode2022.D10;
using AdventOfCode2022.D11;
using AdventOfCode2022.D12;
using AdventOfCode2022.D13;
using AdventOfCode2022.D14;
using AdventOfCode2022.D15;
using AdventOfCode2022.D2;
using AdventOfCode2022.D3;
using AdventOfCode2022.D4;
using AdventOfCode2022.D5;
using AdventOfCode2022.D6;
using AdventOfCode2022.D7;
using AdventOfCode2022.D8;
using AdventOfCode2022.D9;
using AdventOfCode2022.Helpers;

namespace AdventOfCode2022;

public static class PuzzleSelector
{
    private const int NumberOfDays = 15;
    
    public static async Task Execute()
    {
        Console.WriteLine();

        var day = Ask.MultipleChoiceQuestion("Please select a [red]day[/]", GenerateDays(),
            "[grey](Move up and down to reveal more days)[/]");

        var part = Ask.MultipleChoiceQuestion("Please select a [red]part[/]", new List<string> {"Part 1", "Part 2"},
            "[grey](Move up and down to reveal more parts)[/]");

        IPuzzle puzzle = part switch
        {
            "Part 1" => day switch
            {
                "Day 1" => new D1E1(),
                "Day 2" => new D2E1(),
                "Day 3" => new D3E1(),
                "Day 4" => new D4E1(),
                "Day 5" => new D5E1(),
                "Day 6" => new D6E1(),
                "Day 7" => new D7E1(),
                "Day 8" => new D8E1(),
                "Day 9" => new D9E1(),
                "Day 10" => new D10E1(),
                "Day 11" => new D11E1(),
                "Day 12" => new D12E1(),
                "Day 13" => new D13E1(),
                "Day 14" => new D14E1(),
                "Day 15" => new D15E1(),
                _ => throw new Exception("Puzzle not found")
            },
            "Part 2" => day switch
            {
                "Day 1" => new D1E2(),
                "Day 2" => new D2E2(),
                "Day 3" => new D3E2(),
                "Day 4" => new D4E2(),
                "Day 5" => new D5E2(),
                "Day 6" => new D6E2(),
                "Day 7" => new D7E2(),
                "Day 8" => new D8E2(),
                "Day 9" => new D9E2(),
                "Day 10" => new D10E2(),
                "Day 11" => new D11E2(),
                "Day 12" => new D12E2(),
                "Day 13" => new D13E2(),
                "Day 14" => new D14E2(),
                "Day 15" => new D15E2(),
                _ => throw new Exception("Puzzle not found")
            },
            _ => throw new Exception("Puzzle not found")
        };

        var solution = await puzzle.Solve();

        Printer.WriteResult(day.Split(" ")[1]!, part.Split(" ")[1]!, solution);
        Console.WriteLine();
    }

    private static List<string> GenerateDays() =>
        Enumerable.Range(1, NumberOfDays).OrderByDescending(d => d).Select(d => $"Day {d}").ToList();
}