namespace AdventOfCode2022.D9.Models;

public class Rope
{
    private List<Knot> Knots { get; } = new();
    private List<Position> TailPath { get; } = new();
    private Knot Head => Knots.First();
    private Knot Tail => Knots.Last();
    public int UniquePositionsVisitedByTail => TailPath.Select(c => $"{c.X}-{c.Y}").Distinct().Count();

    public Rope(int knots)
    {
        for (var i = 0; i < knots + 1; i++)
        {
            Knots.Add(new Knot(0, 0));
        }
        SaveTailPosition();
    }

    public void Move(string direction)
    {
        Head.Move(direction);
        MoveKnots();
        SaveTailPosition();
    }

    private void MoveKnots()
    {
        for (var i = 1; i < Knots.Count; i++)
            MoveKnot(i);
    }

    private void MoveKnot(int position) => Knots.ElementAt(position).Follow(Knots.ElementAt(position-1));

    private void SaveTailPosition() => TailPath.Add(Position.FromKnot(Tail));
}