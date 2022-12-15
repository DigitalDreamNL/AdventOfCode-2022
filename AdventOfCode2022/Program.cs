using AdventOfCode2022;
using AdventOfCode2022.Helpers;

var solvePuzzles = true;
while (solvePuzzles)
{
    Console.Clear();
    Printer.WriteIntro();
    Console.ResetColor();

    await PuzzleSelector.Execute();

    var solveMorePuzzles = Ask.MultipleChoiceQuestion("Solve another puzzle?", new List<string> { "Yes", "No" });
    solvePuzzles = solveMorePuzzles == "Yes";
}

Console.Clear();