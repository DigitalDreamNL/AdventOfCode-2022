namespace AdventOfCode2022.D14;

public class Map
{
    public SquareType[,] Squares { get; set; }

     public static Bounds DetermineBounds(List<List<Vector2>> rocklines)
     {
         var minX = int.MaxValue;
         var minY = int.MaxValue;
         var maxX = int.MinValue;
         var maxY = int.MinValue;

         rocklines.ToList().ForEach(rockline =>
         {
             rockline.ToList().ForEach(point =>
             {
                 minX = Math.Min(minX, point.X);
                 minY = Math.Min(minY, point.Y);
                 maxX = Math.Max(maxX, point.X);
                 maxY = Math.Max(maxY, point.Y);
             });
         });

         return new Bounds
         {
             Min = new Vector2(minX, minY),
             Max = new Vector2(maxX, maxY),
         };
     }
    
    public static Map From(List<List<Vector2>> paths)
    {
        var bounds = DetermineBounds(paths);

        var width = bounds.Max.X;
        var height = bounds.Max.Y;

        var squares = new SquareType[width+1, height+1];

        for (var x = 0; x <= width; x++)
        {
            for (var y = 0; y <= height; y++)
            {
                squares[x, y] = SquareType.Air;
            }
        }
        
        paths.ForEach(rockLine =>
         {
             for (var i = 0; i < rockLine.Count - 1; i++)
             {
                 var first = rockLine[i];
                 var second = rockLine[i + 1];

                 if (first.X == second.X)
                 {
                     var x = first.X;
                     var start = Math.Min(first.Y, second.Y);
                     var end = Math.Max(first.Y, second.Y);
                     for (var y = start; y <= end; y++)
                     {
                         squares[x,y] = SquareType.Rock;
                     }
                 }
                 else if (first.Y == second.Y)
                 {
                     var y = first.Y;
                     var start = Math.Min(first.X, second.X);
                     var end = Math.Max(first.X, second.X);
                     for (var x = start; x <= end; x++)
                     {
                         squares[x,y] = SquareType.Rock;
                     }
                 }
             }
         });
        

        return new Map
        {
            Squares = squares
        };
    }
}

public struct Bounds
{
    public Vector2 Min { get; set; }
    public Vector2 Max { get; set; }
}

public enum SquareType
{
    Air,
    Rock,
    Sand
}

public static class SquareTypeExtensions
{
    public static string ToIcon(this SquareType x)
    {
        return x switch
        {
            SquareType.Air => ".",
            SquareType.Rock => "█",
            SquareType.Sand => "o",
            _ => "?"
        };
    }

    public static SquareType ToSquareType(this char c)
    {
        return c switch
        {
            '.' => SquareType.Air,
            '█' => SquareType.Rock,
            'o' => SquareType.Sand,
            _ => throw new Exception()
        };
    }
}

public class Sand
{
    public Vector2 Position { get; set; }

    public Sand(int x, int y)
    {
        Position = new Vector2(x, y);
    }

    public void Fall(SquareType[,] map)
    {
        if (map[Position.X, Position.Y + 1] == SquareType.Air)
        {
            Position.Y += 1;
            return;
        }

        if (map[Position.X,Position.Y + 1] != SquareType.Air)
        {
            if (map[Position.X - 1,Position.Y + 1] == SquareType.Air)
            {
                Position.X -= 1;
                Position.Y += 1;
                return;
            }

            if (map[Position.X + 1,Position.Y + 1] == SquareType.Air)
            {
                Position.X += 1;
                Position.Y += 1;
                return;
            }
        }
    }
}