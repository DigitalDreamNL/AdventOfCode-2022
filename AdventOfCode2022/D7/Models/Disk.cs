namespace AdventOfCode2022.D7.Models;

public class Disk
{
    public int DiskSize { get; }
    public int EmptyDiskSize => DiskSize - Folders.First(folder => folder.Name == "/").Size;
    public List<Folder> Folders { get; } = new();
    public List<File> Files { get; } = new();
    public Folder ActiveFolder { get; private set; }

    public Disk(int diskSize)
    {
        DiskSize = diskSize;
        var root = Folder.Create(this, "/");
        Folders.Add(root);
        ActiveFolder = root;
    }

    public void MoveOneFolderUp() =>
        ActiveFolder = Folders.Single(f => f.Id == ActiveFolder.ParentId);

    public void MoveIntoFolder(string name) =>
        ActiveFolder = Folders.Single(f => f.ParentId == ActiveFolder.Id && f.Name == name);

    public void AddFolder(string name) =>
        Folders.Add(Folder.Create(this, name));

    public void AddFile(string name, int size) =>
        Files.Add(File.Create(this, name, size));
}