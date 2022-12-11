namespace AdventOfCode2022.D3;

public class D3E2 : D3, IPuzzle
{
    public async Task<string> Solve()
    {
        var groups = await DetermineGroups();
        groups.ToList().ForEach(HandleGroup);
        return SumOfPriorities.ToString();
    }

    private void HandleGroup(string[] groups)
    {
        var badge = FindBadge(groups);
        var priority = CalculatePriority(badge);
        SumOfPriorities += priority;
    }

    private static async Task<IEnumerable<string[]>> DetermineGroups()
        => (await File.ReadAllLinesAsync("D3/src/input.txt")).Chunk(3);

    private static char FindBadge(IReadOnlyCollection<string> rucksacks) 
        => string.Join("", rucksacks)
            .First(c => rucksacks.ElementAt(0).Contains(c)
                        && rucksacks.ElementAt(1).Contains(c)
                        && rucksacks.ElementAt(2).Contains(c));
}