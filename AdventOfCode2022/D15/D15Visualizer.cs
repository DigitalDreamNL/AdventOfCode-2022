namespace AdventOfCode2022.D15;

public class D15Visualizer
{
    public async Task Execute()
    {
        using var sr = new StreamReader("D15/src/demo.txt");
        while (!sr.EndOfStream)
        {
            Console.ResetColor();
            var line = await sr.ReadLineAsync();
            Console.WriteLine();
            Console.WriteLine(line);
            var positions = D15.Parse(line!);
            Console.WriteLine();

            Console.Write("   ");
            for (var x = -5; x < 23; x++)
            {
                Console.Write(Math.Abs(x % 10));
            }
            Console.WriteLine();

            for (var y = 0; y < 25; y++)
            {
                Console.ResetColor();
                Console.Write($"{y:00} ");
                for (var x = -5; x < 23; x++)
                {
                    Console.BackgroundColor = x == 0 ? ConsoleColor.DarkGray : ConsoleColor.Black;
                    Console.ForegroundColor = x % 2 == 0 ? ConsoleColor.Green : ConsoleColor.DarkGray; 
                    
                    var symbol = y == 10 ? "-" : ".";
                    if (y == 10)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (positions[0].X == x && positions[0].Y == y)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        symbol = "S";
                    }
                    else if (positions[1].X == x && positions[1].Y == y)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        symbol = "B";
                    }

                    Console.Write(symbol);
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}