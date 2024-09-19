using System.Reflection;

namespace Nemonuri.Snapshots.FastSerialization;

public class FastSerializableObjectSnapshotReader
{
    public string DirectoryPath {get;}
    public IReadOnlyList<Assembly> AssembliesForTypeResolving {get;}

    public FastSerializableObjectSnapshotReader
    (
        string directoryPath,
        Assembly[]? assembliesForTypeResolving = null
    )
    {
        DirectoryPath = directoryPath;
        AssembliesForTypeResolving = assembliesForTypeResolving ?? [];
    }

    public bool DirectoryExists => Directory.Exists(DirectoryPath);

    public IEnumerable<SnapshotFileInfo> EnumerateSnapshotFileInfos() =>
        Directory.EnumerateFiles(DirectoryPath)
            .Select(filePath => new SnapshotFileInfo(new FileInfo(filePath), AssembliesForTypeResolving));
}
