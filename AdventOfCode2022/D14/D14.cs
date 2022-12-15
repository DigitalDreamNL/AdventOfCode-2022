namespace AdventOfCode2022.D14;

public class D14
{
    protected static void DrawMap(List<List<Vector2>> points, Map map)
    {
        Console.Clear();

        var startX = Map.DetermineBounds(points).Min.X;
        var endX = map.Squares.GetLength(0);

        Console.Write("    ");
        for (var x = startX; x < endX; x++)
        {
            Console.Write(x % 10);
        }

        Console.WriteLine();

        for (var y = 0; y < map.Squares.GetLength(1); y++)
        {
            Console.Write($"{y:000} ");
            for (var x = startX; x < endX; x++)
            {
                Console.Write(map.Squares[x, y].ToIcon());
            }

            Console.WriteLine();
        }
    }
}