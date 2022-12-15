using System.Text;

namespace AdventOfCode2022.D13;

public static class StringExtensions
{
    public static string SelectNextSymbol(this string self)
    {
        if (self.Length == 0)
            throw new Exception();

        var numberOfCharactersToReturn = 1;

        if (self.Length > 1 && self[0].ToString().IsDigit() && self[1].ToString().IsDigit())
            numberOfCharactersToReturn = 2;
        
        return self[..numberOfCharactersToReturn];
    }

    public static bool IsDigit(this string self) =>
        "0123456789".ToCharArray().Contains(self[0]);

    public static bool IsChunkStart(this string self) =>
        self[0] == '[';

    public static int ToInt(this string self) =>
        Convert.ToInt32(self);

    public static bool IsLargerThan(this string self, string other) =>
        self.ToInt() > other.ToInt();

    public static bool IsSmallerThan(this string self, string other) =>
        self.ToInt() < other.ToInt();

    public static string RemoveCurrentSymbol(this string self) =>
        self[self.SelectNextSymbol().Length..];

    public static string SelectNextChunk(this string self)
    {
        self = self[1..];
        var depth = 1;
        var chunk = new StringBuilder("[");
        while (self.Length > 0)
        {
            var symbol = self[0];
            chunk.Append(symbol);

            if (symbol == '[')
                depth++;
            else if (symbol == ']')
                depth--;

            if (depth == 0)
                return chunk.ToString();

            self = self[1..];
        }

        throw new Exception("No valid chunk found");
    }
}