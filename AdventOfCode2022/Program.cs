using AdventOfCode2022;

Printer.WriteIntro();

var solvePuzzles = true;
while (solvePuzzles)
{
    await PuzzleSelector.Execute();

    Console.WriteLine("Solve another puzzle? (Y/n)");
    solvePuzzles = Console.ReadLine()!.ToLower() != "n";
}
