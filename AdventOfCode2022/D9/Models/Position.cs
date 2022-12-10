namespace AdventOfCode2022.D9.Models;

public class Position
{
    public int X { get; protected set; }
    public int Y { get; protected set; }

    public static Position FromKnot(Knot knot) => new()
    {
        X = knot.X,
        Y = knot.Y
    };
}