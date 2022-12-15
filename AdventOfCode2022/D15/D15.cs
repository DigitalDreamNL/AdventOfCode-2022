using System.Text.RegularExpressions;
using AdventOfCode2022.D14;

namespace AdventOfCode2022.D15;

public class D15
{
    public static List<Vector2> Parse(string line)
    {
        const string regex = @"(-?\d+)";
        var matches = new Regex(regex).Matches(line);

        var sensor = new Vector2(matches[0].Value, matches[1].Value);
        var beacon = new Vector2(matches[2].Value, matches[3].Value);

        return new List<Vector2> {sensor, beacon};
    }

    public static int CalculateManhattanDistance(List<Vector2> positions)
    {
        var sensor = positions[0];
        var beacon = positions[1];

        return Math.Abs(sensor.X - beacon.X)
               + Math.Abs(sensor.Y - beacon.Y);
    }

    public static List<int> CalculateLimitsOnLine(List<Vector2> positions, int z)
    {
        var distance = CalculateManhattanDistance(positions);

        if (Math.Abs(z - positions[0].Y) > distance) return new List<int>();
        
        var distanceToLine = z <= positions[0].Y
            ? positions[0].Y - z
            : z - positions[0].Y;

        var remainingTravelDistance = distance - distanceToLine;

        var start = positions[0].X - remainingTravelDistance;
        var end = positions[0].X + remainingTravelDistance;
        
        return new List<int> { start, end };
    }
}