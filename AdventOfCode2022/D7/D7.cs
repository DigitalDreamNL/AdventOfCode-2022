using AdventOfCode2022.D7.Models;

namespace AdventOfCode2022.D7;

public abstract class D7 : IPuzzle
{
    private const string Input = "D7/src/input.txt";
    private const int DiskSpace = 70000000;
    protected abstract string PuzzleQuery();
    protected Disk Disk { get; private set; } = null!;

    public async Task<string> Solve()
    {
        await InitializeDisk();
        return PuzzleQuery();
    }

    private async Task InitializeDisk()
    {
        Disk = new Disk(DiskSpace);
        await ParseInput();
    }

    private async Task ParseInput()
    {
        using var sr = new StreamReader(Input);
        await sr.ReadLineAsync(); // Skip first line because disk is initialized with root folder
        while (!sr.EndOfStream)
            ParseLine((await sr.ReadLineAsync())!);
    }

    private void ParseLine(string line)
    {
        if (line.StartsWith("$ cd .."))
            Disk.MoveOneFolderUp();
        else if (line.StartsWith("$ cd "))
            Disk.MoveIntoFolder(line.Split(" ")[2]);
        else if (line.StartsWith("dir"))
            Disk.AddFolder(line.Split(" ")[1]);
        else if (char.IsDigit(line[0]))
            Disk.AddFile(line.Split(" ")[1], int.Parse(line.Split(" ")[0]));
    }
}