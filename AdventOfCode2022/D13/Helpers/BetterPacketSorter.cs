using System.Text.RegularExpressions;

namespace AdventOfCode2022.D13.Helpers;

// WIP Packet sorter
public class BetterPacketSorter
{
    public List<string> ChunksLeft { get; }
    public List<string> ChunksRight { get; }

    public BetterPacketSorter(string left, string right)
    {
        ChunksLeft = Parse(left);
        ChunksRight = Parse(right);
    }

    public static List<string> Parse(string input)
    {
        var pattern =  @",|\[|\]|\d+";
        var result = new Regex(pattern).Matches(input);

        return result.Select(r => r.Value).ToList();
    }

    public static List<string> NextChunk(List<string> chunk, int startPosition)
    {
        var endPosition = startPosition;
        var depth = 0;
        do
        {
            var v = chunk.ElementAt(endPosition);
            depth += v == "[" ? 1 : v == "]" ? -1 : 0;
            endPosition++;
        } while (depth > 0);

        return chunk.GetRange(startPosition, endPosition-1);
    }
}

