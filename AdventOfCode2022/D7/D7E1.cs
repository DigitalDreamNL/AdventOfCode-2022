namespace AdventOfCode2022.D7;

public class D7E1 : D7
{
    protected override string PuzzleQuery() =>
        Disk.Folders.Where(folder => folder.Size < 100000).Sum(folder => folder.Size).ToString();
}