using AdventOfCode2022.D11.Models;

namespace AdventOfCode2022.D11;

public static class MonkeyParser
{
    // Monkey n:,
    //   Starting items: 1,, 2, ..., n
    //   Operation: new = old <operator> n
    //   Test: divisible by n
    //     If true: throw to monkey n
    //     If false: throw to monkey n
    public static async Task<IMonkey> Parse(StreamReader sr, IMonkey monkey)
    {
        await sr.ReadLineAsync(); // Skip first Line
        
        var items = await DetermineStartingItems(sr);
        var operation = await DetermineOperation(sr);
        var testValue = await DetermineTestValue(sr);
        var trueMonkey = await DetermineTrueMonkeyTarget(sr);
        var falseMonkey = await DetermineFalseMonkeyTarget(sr);

        await sr.ReadLineAsync(); // Read empty line
        
        return monkey
            .WithItems(items)
            .WithOperation(operation)
            .WithTestValue(testValue)
            .WithTrueMonkeyTarget(trueMonkey)
            .WithFalseMonkeyTarget(falseMonkey);
    }

    private static async Task<List<ulong>> DetermineStartingItems(TextReader sr) =>
        (await sr.ReadLineAsync())![18..].Split(", ").ToList().ConvertAll(Convert.ToUInt64);

    private static async Task<string> DetermineOperation(TextReader sr) =>
        (await sr.ReadLineAsync())![19..];

    private static async Task<int> DetermineTestValue(TextReader sr) =>
        Convert.ToInt32((await sr.ReadLineAsync())![21..]);

    private static async Task<int> DetermineTrueMonkeyTarget(TextReader sr) =>
        Convert.ToInt32((await sr.ReadLineAsync())![29..]);

    private static async Task<int> DetermineFalseMonkeyTarget(TextReader sr) =>
        Convert.ToInt32((await sr.ReadLineAsync())![30..]);
}