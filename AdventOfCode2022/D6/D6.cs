namespace AdventOfCode2022.D6;

public abstract class D6
{
    protected abstract int SignalLength { get; } 

    public async Task<string> Execute() => await Execute(SignalLength);

    private async Task<string> Execute(int signalLength)
    {
        var data = await ReadInput();
        return FindSignal(data, signalLength);
    }

    private static async Task<string> ReadInput() => await new StreamReader("D6/src/input.txt").ReadToEndAsync();

    private static string FindSignal(string data, int signalLength)
    {
        for (var i = 0; i < data.Length; i++)
        {
            if (AllCharactersInSignalLengthAreUnique(data, i, signalLength))
                return (i + signalLength).ToString();
        }

        throw new Exception("No signal found");
    }

    private static bool AllCharactersInSignalLengthAreUnique(string data, int start, int signalLength)
    {
        var buffer = "";
        var uniqueCharacters = 0;
        while (uniqueCharacters < signalLength && !buffer.Contains(data[start + uniqueCharacters]))
        {
            buffer += data[start + uniqueCharacters];
            uniqueCharacters++;
        }

        return uniqueCharacters == signalLength;
    }
}