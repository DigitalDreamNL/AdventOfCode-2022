namespace AdventOfCode2022.D7;

public class D7E2 : D7, IPuzzle
{
    private const int UpdateSize = 30000000;

    protected override string PuzzleQuery() =>
        Disk.Folders.Where(folder => folder.Size >= SpaceRequiredForUpdate)
            .OrderBy(folder => folder.Size)
            .First().Size.ToString();

    private int SpaceRequiredForUpdate => UpdateSize - Disk.EmptyDiskSize;
}