namespace AdventOfCode2022.D12.Models;

public readonly struct Coords
{
    public Coords(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; }
    public int Y { get; }

    public override string ToString() => $"({X},{Y})";
}