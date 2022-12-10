namespace AdventOfCode2022.D9.Models;

public class Knot : Position
{
    public Knot(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void Move(string direction)
    {
        _ = direction switch
        {
            "U" => Y -= 1,
            "D" => Y += 1,
            "R" => X += 1,
            "L" => X -= 1,
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }
    
    public void Follow(Position previousKnot)
    {
        if (IsNotTouching(previousKnot))
            MoveTowards(previousKnot);
    }

    private bool IsNotTouching(Position position) =>
        Math.Abs(X - position.X) > 1 || Math.Abs(Y - position.Y) > 1;

    private void MoveTowards(Position position)
    {
        X += (position.X == X) ? 0 : DetermineDirection(X, position.X);
        Y += (position.Y == Y) ? 0 : DetermineDirection(Y, position.Y);
    }

    private static int DetermineDirection(int own, int position) => position > own ? 1 : -1;
}