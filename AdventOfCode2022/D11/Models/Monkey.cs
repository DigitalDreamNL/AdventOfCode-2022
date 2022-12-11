namespace AdventOfCode2022.D11.Models;

public class Monkey : IMonkey
{
    private List<ulong> _items = new();
    public int TestValue { get; private set; }
    private int _trueMonkeyTarget;
    private int _falseMonkeyTarget;
    private bool _reduceWorryLevel;
    private string _operation = string.Empty;
    public ulong NumberOfItemsInspected { get; private set; }

    public IMonkey WithItems(List<ulong> items)
    {
        _items = items;
        return this;
    }

    public IMonkey WithOperation(string operation)
    {
        _operation = operation;
        return this;
    }

    public IMonkey WithTestValue(int value)
    {
        TestValue = value;
        return this;
    }

    public IMonkey WithTrueMonkeyTarget(int target)
    {
        _trueMonkeyTarget = target;
        return this;
    }

    public IMonkey WithFalseMonkeyTarget(int target)
    {
        _falseMonkeyTarget = target;
        return this;
    }

    public void EnableReduceWorryLevel()
    {
        _reduceWorryLevel = true;
    }

    public void PerformTurn(List<IMonkey> monkeys)
    {
        _items.ForEach(item =>
        {
            NumberOfItemsInspected++;
            var newItemValue = CalculateNewValue(monkeys, item);
            var nextMonkey = DetermineNextMonkey(newItemValue);
            ThrowItemAtMonkey(monkeys, nextMonkey, newItemValue);
        });
        _items = new List<ulong>();
    }

    private decimal CalculateNewValue(IEnumerable<IMonkey> monkeys, ulong old) =>
        _reduceWorryLevel
            ? Math.Floor(PerformOperation(old) / 3)
            : PerformOperation(old); // % monkeys.Select(m => m.TestValue).Aggregate(1, (acc, val) => acc * val);

    private decimal PerformOperation(ulong old)
    {
        var operation = _operation.Split(" ");
        var sign = operation[1];
        var number = operation[2] == "old" ? old : Convert.ToUInt64(operation[2]);

        return sign switch
        {
            "*" => old * number,
            "+" => old + number,
            _ => throw new Exception($"Invalid operation: {_operation}")
        };
    }

    private int DetermineNextMonkey(decimal newValue) =>
        newValue % TestValue == 0 ? _trueMonkeyTarget : _falseMonkeyTarget;

    private static void ThrowItemAtMonkey(IEnumerable<IMonkey> monkeys, int nextMonkey, decimal newValue) =>
        monkeys.ElementAt(nextMonkey).CatchItem((ulong) newValue);

    public void CatchItem(ulong item) => _items.Add(item);
}