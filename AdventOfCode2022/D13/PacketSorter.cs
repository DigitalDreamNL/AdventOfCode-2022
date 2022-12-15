using System.Text;

namespace AdventOfCode2022.D13;

public class PacketSorter
{
    private string Left { get; set; } = null!;
    private string Right { get; set; } = null!;

    private readonly bool _debugEnabled = false;

    public bool? Compare(string left, string right, int depth = 0)
    {
        Left = left;
        Right = right;
        
        Debug($"- Compare {Left} vs {Right}", depth);

        Left = Left.RemoveCurrentSymbol();
        Right = Right.RemoveCurrentSymbol();

        while (Left.Length > 0 && Right.Length > 0)
        {
            var l = Left.SelectNextSymbol();
            var r = Right.SelectNextSymbol();

            if (l.IsChunkStart() && r.IsChunkStart())
            {
                var result = HandleTwoChunks(depth);

                if (result == null) continue;

                return result;
            }

            if (l.IsChunkStart() && r.IsDigit())
            {
                var result = HandleChunkAndDigit(depth, r);

                if (result == null) continue;

                return result;
            }

            if (l.IsDigit() && r.IsChunkStart())
            {
                var result = HandleDigitAndChunk(depth, l);

                if (result == null) continue;

                return result;
            }
            
            if (l.IsDigit() && r.IsDigit())
            {
                Debug($"- Compare {l} vs {r}", depth + 1);

                if (l.IsSmallerThan(r))
                {
                    Debug("- Left side is smaller, so inputs are in the right order", depth + 2);
                    return true;
                }

                if (l.IsLargerThan(r))
                {
                    Debug("- Right side is smaller, so inputs are not in the right order", depth + 2);
                    return false;
                }
            }

            Left = Left.RemoveCurrentSymbol();
            Right = Right.RemoveCurrentSymbol();
        }

        if (Left.Length < Right.Length)
        {
            Debug("- Left side ran out of items, so inputs are in the right order", depth + 1);
            return true;
        }

        if (Left.Length > Right.Length)
        {
            Debug("- Right side ran out of items, so inputs are not in the right order", depth + 1);
            return false;
        }
        
        return null;
    }

    private bool? HandleTwoChunks(int depth)
    {
        var chunkLeft = Left.SelectNextChunk();
        var chunkRight = Right.SelectNextChunk();

        var result = new PacketSorter().Compare(chunkLeft, chunkRight, depth + 1);

        Left = Left.Substring(chunkLeft.Length);
        Right = Right.Substring(chunkRight.Length);

        return result;
    }

    private bool? HandleChunkAndDigit(int depth, string r)
    {
        var chunkLeft = Left.SelectNextChunk();
        var chunkRight = $"[{r}]";

        Debug($"- Compare {chunkLeft} vs {r}", depth + 1);
        Debug($"- Mixed types; convert right to [{r}] and retry comparison", depth + 2);

        var result = new PacketSorter().Compare(chunkLeft, chunkRight, depth + 2);

        Left = Left.Substring(chunkLeft.Length);
        Right = Right.Substring(r.Length);
        return result;
    }

    private bool? HandleDigitAndChunk(int depth, string l)
    {
        var chunkRight = Right.SelectNextChunk();
        var chunkLeft = $"[{l}]";

        Debug($"- Compare {l} vs {chunkRight}", depth + 1);
        Debug($"- Mixed types; convert left to [{l}] and retry comparison", depth + 2);

        var result = new PacketSorter().Compare(chunkLeft, chunkRight, depth + 2);

        Left = Left.Substring(l.Length);
        Right = Right.Substring(chunkRight.Length);
        return result;
    }

    private void Debug(string text, int depth)
    {
        if (!_debugEnabled) return;

        var padding = new string(' ', depth * 2);
        Console.WriteLine($"{padding}{text}");
    }
}