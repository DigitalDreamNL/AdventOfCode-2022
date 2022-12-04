namespace AdventOfCode2022.D2;

public class D2E1 : D2, IPuzzle
{
    protected override Dictionary<string, int> ScoringTable =>
        new()
        {
            {"A X", 4},
            {"A Y", 8},
            {"A Z", 3},
            {"B X", 1},
            {"B Y", 5},
            {"B Z", 9},
            {"C X", 7},
            {"C Y", 2},
            {"C Z", 6},
        };
}