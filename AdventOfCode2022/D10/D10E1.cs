namespace AdventOfCode2022.D10;

public class D10E1 : D10, IPuzzle
{
    private readonly int[] _relevantCycles = {20, 60, 100, 140, 180, 220};
    private int _result = 0;

    public async Task<string> Solve()
    {
        await ParseSignal();
        return _result.ToString();
    }

    protected override void CycleHandler() =>
        _result += CalculateIncrement(Cycle, X);

    private int CalculateIncrement(int cycle, int x) =>
        !_relevantCycles.Contains(cycle) ? 0 : cycle * x;
}