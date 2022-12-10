namespace AdventOfCode2022;

public static class Printer
{
    public static void WriteIntro()
    {
        WriteGreen(@"     _       _                 _            __    ____          _      ");WriteRed(@"  ____   ___ ____  ____  ");
        WriteGreen(@"    / \   __| |_   _____ _ __ | |_    ___  / _|  / ___|___   __| | ___ ");WriteRed(@" |___ \ / _ \___ \|___ \ ");
        WriteGreen(@"   / _ \ / _` \ \ / / _ \ '_ \| __|  / _ \| |_  | |   / _ \ / _` |/ _ \");WriteRed(@"   __) | | | |__) | __) |");
        WriteGreen(@"  / ___ \ (_| |\ V /  __/ | | | |_  | (_) |  _| | |__| (_) | (_| |  __/");WriteRed(@"  / __/| |_| / __/ / __/ ");
        WriteGreen(@" /_/   \_\__,_| \_/ \___|_| |_|\__|  \___/|_|    \____\___/ \__,_|\___|");WriteRed(@" |_____|\___/_____|_____|");
        Console.ResetColor();
        Console.WriteLine();
    }

    private static void WriteGreen(string text)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(text);
    }

    private static void WriteRed(string text)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(text);
    }

    public static void WriteResult(string day, string part, string result)
    {
        WriteResultPart("Solution for day ", day);
        WriteResultPart(" part ", part);
        WriteResultPart(" is ", result);
        Console.WriteLine();
    }

    private static void WriteResultPart(string text, string value)
    {
        Console.Write(text);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(value);
        Console.ResetColor();
    }
}