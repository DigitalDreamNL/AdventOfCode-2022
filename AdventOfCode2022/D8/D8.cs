namespace AdventOfCode2022.D8;

public class D8
{
    protected readonly List<List<int>> Trees = new();

    protected async Task PopulateForest()
    {
        using var sr = new StreamReader("D8/src/input.txt");
        while (!sr.EndOfStream)
            Trees.Add((await sr.ReadLineAsync())!.Select(t => (int) char.GetNumericValue(t)).ToList());
    }
}