namespace AdventOfCode2022.D13;

public class D13E2 : IPuzzle
{
    public async Task<string> Solve()
    {
        var packets = await ReadInput();

        AddDividerPackets(packets);

        packets.Sort((a, b) => new PacketSorter().Compare(a, b) == true ? -1 : 1);

        var firstDividerIndex = packets.IndexOf("[[2]]") + 1;
        var secondDividerIndex = packets.IndexOf("[[6]]") + 1;
        
        return (firstDividerIndex * secondDividerIndex).ToString();
    }

    private static async Task<List<string>> ReadInput()
    {
        var packets = new List<string>();

        using var sr = new StreamReader("D13/src/input.txt");
        while (!sr.EndOfStream)
        {
            var line = await sr.ReadLineAsync();
            if (string.IsNullOrEmpty(line)) continue;

            packets.Add(line);
        }

        return packets;
    }

    private static void AddDividerPackets(List<string> packets)
    {
        packets.Add("[[2]]");
        packets.Add("[[6]]");
    }
}