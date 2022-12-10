namespace AdventOfCode2022.D10;

public abstract class D10
{
    protected int X = 1;
    protected int Cycle = 0;

    protected abstract void CycleHandler();

    protected async Task ParseSignal()
    {
        using var sr = new StreamReader("D10/src/input.txt");
        while (!sr.EndOfStream)
            await ParseLine(sr);
    }

    private async Task ParseLine(StreamReader sr)
    {
        var line = await sr.ReadLineAsync();
        HandleCycle();
        if (line == "noop") return;
        HandleCycle();
        X += int.Parse(line!.Split(" ")[1]);
    }

    private void HandleCycle()
    {
        Cycle++;
        CycleHandler();
    }
}