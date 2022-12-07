namespace AdventOfCode2022.D7.Models;

public class Folder
{
    private Disk _disk = null!;
    public Guid Id { get; private init; }
    public string Name { get; private init; } = string.Empty;
    public Guid ParentId { get; private init; }

    private int? _size;
    public int Size => _size ?? CalculateSize();

    public static Folder Create(Disk disk, string name) =>
        new()
        {
            _disk = disk,
            Name = name,
            ParentId = disk.ActiveFolder?.Id ?? Guid.Empty,
            Id = Guid.NewGuid()
        };

    private int CalculateSize()
    {
        _size = _disk.Files.Where(file => file.ParentId == Id).Select(file => file.Size)
            .Concat(_disk.Folders.Where(folder => folder.ParentId == Id).Select(folder => folder.Size))
            .Sum();
        return (int) _size;
    }
}