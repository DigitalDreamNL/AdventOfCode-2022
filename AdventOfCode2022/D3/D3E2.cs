namespace AdventOfCode2022.D3;

public class D3E2 : D3
{
    public async Task<string> Execute()
    {
        var groups = await DetermineGroups();
        groups.ForEach(HandleGroup);
        return SumOfPriorities.ToString();
    }

    private void HandleGroup(List<string> groups)
    {
        var badge = FindBadge(groups);
        var priority = CalculatePriority(badge);
        SumOfPriorities += priority;
    }

    private static async Task<List<List<string>>> DetermineGroups()
    {
        var counter = 0;
        var group = new List<string>();
        var groups = new List<List<string>>();

        using var sr = new StreamReader("D3/src/input.txt");
        while (!sr.EndOfStream)
        {
            group.Add((await sr.ReadLineAsync())!);
            counter++;

            if (counter % 3 != 0)
                continue;

            groups.Add(group);
            group = new List<string>();
        }
        return groups;
    }

    private static char FindBadge(IReadOnlyCollection<string> rucksacks) 
        => string.Join("", rucksacks)
            .First(c => rucksacks.ElementAt(0).Contains(c)
                        && rucksacks.ElementAt(1).Contains(c)
                        && rucksacks.ElementAt(2).Contains(c));
}