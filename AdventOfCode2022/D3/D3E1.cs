namespace AdventOfCode2022.D3;

public class D3E1 : D3, IPuzzle
{
    public async Task<string> Solve()
    {
        using var sr = new StreamReader("D3/src/input.txt");
        while (!sr.EndOfStream)
            HandleRucksack((await sr.ReadLineAsync())!);

        return SumOfPriorities.ToString();
    }

    private void HandleRucksack(string rucksack)
    {
        var compartments = SplitCompartments(rucksack);
        var item = FindItemThatExistsInBothCcompartments(compartments);
        var priority = CalculatePriority(item);
        SumOfPriorities += priority;
    }

    private static string[] SplitCompartments(string items)
    {
        return items.Insert(items.Length / 2, "|").Split('|');
    }

    private static char FindItemThatExistsInBothCcompartments(string[] stacks) 
        => stacks.First().First(c => stacks.Last().Contains(c));
}