namespace AdventOfCode2022.D4;

public abstract class D4
{
    private int _overlappingAreasCount;
    protected abstract bool Comparator(int[] edges);

    public async Task<string> Execute()
    {
        using var sr = new StreamReader("D4/src/input.txt");
        while (!sr.EndOfStream)
            CheckForOverlap((await sr.ReadLineAsync())!);

        return _overlappingAreasCount.ToString();
    }

    private void CheckForOverlap(string line)
    {
        var edges = DetermineEdges(line);
        if (Comparator(edges)) _overlappingAreasCount++;
    }

    private static int[] DetermineEdges(string line)
    {
        var separators = new[] {",", "-"};
        var edges = line.Split(separators, StringSplitOptions.None); 
        return Array.ConvertAll(edges, int.Parse);
    }
}