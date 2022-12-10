using AdventOfCode2022.D1;
using AdventOfCode2022.D10;
using AdventOfCode2022.D2;
using AdventOfCode2022.D3;
using AdventOfCode2022.D4;
using AdventOfCode2022.D5;
using AdventOfCode2022.D6;
using AdventOfCode2022.D7;
using AdventOfCode2022.D8;
using AdventOfCode2022.D9;

namespace AdventOfCode2022;

public static class PuzzleSelector
{
    public static async Task Execute()
    {
        Console.WriteLine("Please select a puzzle");

        var day = "";
        var part = "";
        IPuzzle? puzzle = null;

        while (puzzle == null)
        {
            Console.Write("Day? (1-10): ");
            day = Console.ReadLine();

            Console.Write("Part? (1-2): ");
            part = Console.ReadLine();

            puzzle = part switch
            {
                "1" => day switch
                {
                    "1" => new D1E1(),
                    "2" => new D2E1(),
                    "3" => new D3E1(),
                    "4" => new D4E1(),
                    "5" => new D5E1(),
                    "6" => new D6E1(),
                    "7" => new D7E1(),
                    "8" => new D8E1(),
                    "9" => new D9E1(),
                    "10" => new D10E1(),
                    _ => null
                },
                "2" => day switch
                {
                    "1" => new D1E2(),
                    "2" => new D2E2(),
                    "3" => new D3E2(),
                    "4" => new D4E2(),
                    "5" => new D5E2(),
                    "6" => new D6E2(),
                    "7" => new D7E2(),
                    "8" => new D8E2(),
                    "9" => new D9E2(),
                    "10" => new D10E2(),
                    _ => null
                },
                _ => null
            };

            if (puzzle == null)
                Console.Write("Invalid selection. Please try again.");
        }

        Console.WriteLine();
        var result = await puzzle.Execute();
        Printer.WriteResult(day!, part!, result);
        Console.WriteLine();
    }
}