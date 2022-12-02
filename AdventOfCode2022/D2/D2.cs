namespace AdventOfCode2022.D2;

public class D2
{
    protected async Task<string> Execute(Dictionary<string, int> scoring)
    {
        var score = 0;
        using var sr = new StreamReader("D2/src/input.txt");
        while (!sr.EndOfStream)
            score += scoring[((await sr.ReadLineAsync())!)];

        return score.ToString();
    }
}