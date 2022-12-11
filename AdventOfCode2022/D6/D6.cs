namespace AdventOfCode2022.D6;

public abstract class D6 : IPuzzle
{
    protected abstract int MarkerLength { get; } 

    public async Task<string> Solve()
    {
        var data = await ReadInput();
        return FindMarker(data);
    }

    private static async Task<string> ReadInput() => await new StreamReader("D6/src/input.txt").ReadToEndAsync();

    private string FindMarker(string data)
    {
        for (var i = 0; i < data.Length; i++)
        {
            if (AllCharactersInMarkerLengthAreUnique(data, i))
                return (i + MarkerLength).ToString();
        }

        throw new Exception("No marker found");
    }

    private bool AllCharactersInMarkerLengthAreUnique(string data, int start)
    {
        var buffer = "";
        var uniqueCharacters = 0;
        while (uniqueCharacters < MarkerLength && !buffer.Contains(data[start + uniqueCharacters]))
        {
            buffer += data[start + uniqueCharacters];
            uniqueCharacters++;
        }

        return uniqueCharacters == MarkerLength;
    }
}