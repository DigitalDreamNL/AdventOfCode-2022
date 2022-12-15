namespace AdventOfCode2022.D12.Models;

public class Node
{
    public int X { get; private init; }
    public int Y { get; private init; }
    public int MaxClimbValue { get; private init; }
    public Node? PreviousNode { get; private init; }
    public int Cost { get; private init; }
    public int Distance { get; private init; }
    public int? Score { get; private init; }
    public bool Done { get; set; }
    public bool IsTarget { get; private init; }

    public static Node CreateStartNode(Coords coords, int maxClimbValue)
    {
        return new Node
        {
            X = coords.X,
            Y = coords.Y,
            MaxClimbValue = maxClimbValue
        };
    }

    public static Node FromPreviousNode(Node node, int dX, int dY, Heightmap heightmap)
    {
        var x = node.X + dX;
        var y = node.Y + dY;
        var maxClimbValue = heightmap.Map[x, y] + heightmap.MaxClimbHeight;
        var distance = Math.Abs(x - heightmap.End.X) + Math.Abs(y - heightmap.End.Y);
        var cost = node.Cost + 1;
        var score = cost + distance;
        var isTarget = heightmap.End.X == x && heightmap.End.Y == y;

        return new Node
        {
            X = x,
            Y = y,
            PreviousNode = node,
            MaxClimbValue = maxClimbValue,
            Distance = distance,
            Cost = cost,
            Score = score,
            IsTarget = isTarget
        };
    }
}