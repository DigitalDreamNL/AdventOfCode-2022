namespace AdventOfCode2022.D2;

public class D2E2 : D2
{
    protected override Dictionary<string, int> ScoringTable =>
        new()
        {
            {"A X", 3},
            {"A Y", 4},
            {"A Z", 8},
            {"B X", 1},
            {"B Y", 5},
            {"B Z", 9},
            {"C X", 2},
            {"C Y", 6},
            {"C Z", 7},
        };
}