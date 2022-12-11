namespace AdventOfCode2022.D11.Models;

public interface IMonkey
{
    public IMonkey WithItems(List<ulong> items);
    public IMonkey WithOperation(string operation);
    public IMonkey WithTestValue(int value);
    public IMonkey WithTrueMonkeyTarget(int target);
    public IMonkey WithFalseMonkeyTarget(int target);
    public void EnableReduceWorryLevel();
    public void PerformTurn(List<IMonkey> monkeys);
    public void CatchItem(ulong item);
    public ulong NumberOfItemsInspected { get; }
    public int TestValue { get; }
}