namespace AdventOfCode2022.D14;

public class Vector2
{
    public int X { get; set; }
    public int Y { get; set; }

    public Vector2(string x, string y) : this (Convert.ToInt32(x), Convert.ToInt32(y))
    {
    }

    public Vector2(int x, int y)
    {
        X = x;
        Y = y;
    }
}