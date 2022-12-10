namespace AdventOfCode2022.D10;

public class D10E2 : D10, IPuzzle
{
    private const string LitPixel = "█";
    private const string DarkPixel = " ";
    private const int Delay = 10;

    private string _pixels = "";

    public async Task<string> Execute()
    {
        await ParseSignal();
        DrawPixelsOnScreen();
        return "[See output]";
    }

    private void DrawPixelsOnScreen()
    {
        _pixels.Chunk(40).ToList().ForEach(DrawLine);
        Console.WriteLine();
    }

    private static void DrawLine(IEnumerable<char> line)
    {
        line.ToList().ForEach(DrawPixelAndWait);
        Console.WriteLine();
    }

    private static void DrawPixelAndWait(char c)
    {
        Console.Write(c);
        Thread.Sleep(Delay);
    }

    protected override void CycleHandler() =>
        _pixels += DeterminePixel(Cycle, X);

    private static string DeterminePixel(int cycle, int spritePosition)
    {
        var pixelPosition = (cycle - 1) % 40;
        return (pixelPosition >= spritePosition - 1 && pixelPosition <= spritePosition + 1) ? LitPixel : DarkPixel;
    }
}