namespace AdventOfCode2022.D2;

public class D2E1 : D2, IPuzzle
{
    private readonly Dictionary<string, int> _scoring = new()
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

    public async Task<string> Execute()
        => (await Execute(_scoring));
}