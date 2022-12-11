using AdventOfCode2022.D11.Models;

namespace AdventOfCode2022.D11;

public abstract class D11 : IPuzzle
{
    protected abstract bool EnableReduceWorryLevel { get; }
    protected abstract int NumberOfRounds { get; }
    
    public async Task<string> Solve()
    {
        var monkeys = await InitializeMonkeys();

        if (EnableReduceWorryLevel)
            monkeys.ForEach(monkey => monkey.EnableReduceWorryLevel());

        for (var round = 0; round < NumberOfRounds; round++)
            monkeys.ForEach(monkey => monkey.PerformTurn(monkeys));

        var mostActiveMonkeys = monkeys.Select(monkey => monkey.NumberOfItemsInspected)
            .OrderByDescending(m => m)
            .Take(2).ToList();
        var result = mostActiveMonkeys.First() * mostActiveMonkeys.Last();

        return result.ToString();
    }

    private static async Task<List<IMonkey>> InitializeMonkeys()
    {
        var monkeys = new List<IMonkey>();
        using var sr = new StreamReader("D11/src/input.txt");
        while (!sr.EndOfStream)
            await AddMonkey(sr, monkeys);
        return monkeys;
    }

    private static async Task AddMonkey(StreamReader sr, List<IMonkey> monkeys) =>
        monkeys.Add(await MonkeyParser.Parse(sr, new Monkey()));
}