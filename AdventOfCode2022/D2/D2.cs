namespace AdventOfCode2022.D2;

public abstract class D2
{
    protected abstract Dictionary<string, int> ScoringTable { get; }

    public async Task<string> Execute()
    {
        var score = 0;

        using var sr = new StreamReader("D2/src/input.txt");
        while (!sr.EndOfStream)
            score += GetScoreForResult((await sr.ReadLineAsync())!);

        return score.ToString();
    }

    private int GetScoreForResult(string result) => ScoringTable[result];
}