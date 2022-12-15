namespace AdventOfCode2022.D13;

public class D13E1 : IPuzzle
{
    public async Task<string> Solve()
    {
        var index = 1;
        var sum = 0;

        using var sr = new StreamReader("D13/src/input.txt");
        while (!sr.EndOfStream)
        {
            var left = await sr.ReadLineAsync();
            var right = await sr.ReadLineAsync();

            var packetSorter = new PacketSorter();
            if (packetSorter.Compare(left!, right!) == true)
                sum += index;

            await sr.ReadLineAsync();
            index++;
        }

        return sum.ToString();
    }
}