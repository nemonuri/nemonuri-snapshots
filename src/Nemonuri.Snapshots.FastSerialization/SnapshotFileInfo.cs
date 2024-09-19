using System.Reflection;

namespace Nemonuri.Snapshots.FastSerialization;

public class SnapshotFileInfo : IComparable<SnapshotFileInfo>
{
    private readonly static byte[] s_validFileHeader = 
    [
        ..BitConverter.GetBytes("!FastSerialization.1"u8.Length), 
        .."!FastSerialization.1"u8.ToArray()
    ];

    private readonly FileInfo _fileInfo;
    private readonly IReadOnlyList<Assembly> _assembliesForTypeResolving;

    internal SnapshotFileInfo(FileInfo fileInfo, IReadOnlyList<Assembly> assembliesForTypeResolving)
    {
        _fileInfo = fileInfo;
        _assembliesForTypeResolving = assembliesForTypeResolving;
    }

    private byte[]? _bufferForHasValidFileHeader;
    public byte[] BufferForHasValidFileHeader => _bufferForHasValidFileHeader ??= new byte[s_validFileHeader.Length];

    public FileInfo FileInfo => _fileInfo;

    public bool HasValidFileHeader
    {
        get
        {
            if (!_fileInfo.Exists) {return false;}

            using (var stream = _fileInfo.OpenRead())
            {
                int readLength = stream.Read(BufferForHasValidFileHeader, 0, BufferForHasValidFileHeader.Length);
                if (readLength < BufferForHasValidFileHeader.Length) {return false;}

                if (!s_validFileHeader.SequenceEqual(BufferForHasValidFileHeader)) {return false;}
            }

            return true;            
        }
    }

    public int CompareTo(SnapshotFileInfo? other)
    {
        Guard.IsNotNull(other);
        return _fileInfo.CreationTimeUtc.CompareTo(other._fileInfo.CreationTimeUtc);
    }

    public object ReadObject()
    {
        using var ds = new Deserializer(_fileInfo.FullName);
        ds.TypeResolver = ResolveType;
        return ds.GetEntryObject();
    }

    private Type ResolveType(string typeName)
    {
        Type? resolved;
        foreach (var assembly in _assembliesForTypeResolving)
        {
            resolved = assembly.GetType(typeName, throwOnError:false);
            if (resolved != null) {return resolved;}
        }

        resolved = typeof(object).Assembly.GetType(typeName, throwOnError:true);
        return resolved!;
    }
}