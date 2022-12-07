namespace AdventOfCode2022.D6;

public abstract class D6alt : IPuzzle
{
    protected abstract int MarkerLength { get; }

    private char[] _uniqueCharacters = Array.Empty<char>();
    private int _position;

    public Task<string> Execute()
    {
        using var sr = new StreamReader("D6/src/input.txt");
        return FindMarker(sr);
    }

    private Task<string> FindMarker(StreamReader sr)
    {
        while (!sr.EndOfStream)
        {
            var character = (char) sr.Read();
            StripPreviousOccurenceFromUniqueCharacters(character);
            AppendCharacterToUniqueCharacters(character);

            if (MarkerFound())
                return MarkerPosition();

            _position++;
        }

        throw new Exception("No marker found");
    }

    private void StripPreviousOccurenceFromUniqueCharacters(char currentCharacter)
    {
        var index = FindCharacterInUniqueCharacters(currentCharacter);
        if (CharacterExistsInUniqueCharacters(index))
            RemoveAllCharactersBeforeIndex(index);
    }

    private int FindCharacterInUniqueCharacters(char currentCharacter) =>
        Array.IndexOf(_uniqueCharacters, currentCharacter);

    private static bool CharacterExistsInUniqueCharacters(int index) => index != -1;

    private void RemoveAllCharactersBeforeIndex(int index) =>
        _uniqueCharacters = _uniqueCharacters.Skip(index + 1).ToArray();

    private void AppendCharacterToUniqueCharacters(char currentCharacter) =>
        _uniqueCharacters = _uniqueCharacters.Concat(new[] {currentCharacter}).ToArray();

    private bool MarkerFound() => _uniqueCharacters.Length == MarkerLength;

    private Task<string> MarkerPosition() => Task.FromResult((_position + 1).ToString());
}