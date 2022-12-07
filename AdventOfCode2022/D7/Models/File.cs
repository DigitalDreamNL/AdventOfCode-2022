namespace AdventOfCode2022.D7.Models;

public class File
{
    public Guid Id { get; private init; }
    public string Name { get; private init; } = string.Empty;
    public int Size { get; private init; }
    public Guid ParentId { get; private init; }

    public static File Create(Disk disk, string name, int size) => 
        new()
        {
            Id = Guid.NewGuid(),
            Name = name,
            Size = size,
            ParentId = disk.ActiveFolder.Id
        };
}