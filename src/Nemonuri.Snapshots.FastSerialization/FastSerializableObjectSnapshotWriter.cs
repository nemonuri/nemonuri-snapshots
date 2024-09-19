namespace Nemonuri.Snapshots.FastSerialization;

public class FastSerializableObjectSnapshotWriter
{
    private readonly DirectoryCreatingEventKind _eventKind;

    private DirectoryInfo? _directoryInfo;
    private DirectoryInfo DirectoryInfo => _directoryInfo ??= CreateDirectoryIfNeeded();

    private int _fileIndex = -1;

    public FastSerializableObjectSnapshotWriter():this(DirectoryCreatingEventKind.Default)
    {
    }

    public FastSerializableObjectSnapshotWriter(DirectoryCreatingEventKind eventKind)
    {
        Guard.IsTrue(eventKind.IsValid());
        _eventKind = eventKind;

        if (eventKind == DirectoryCreatingEventKind.Constructed)
        {
            _directoryInfo = CreateDirectory();
        }
    }

    private DirectoryInfo CreateDirectoryIfNeeded()
    {
        if 
        (
            _eventKind == DirectoryCreatingEventKind.Default ||
            _eventKind == DirectoryCreatingEventKind.Needed
        )
        {
            return CreateDirectory();
        }
        else
        {
            return ThrowHelper.ThrowInvalidOperationException<DirectoryInfo>();
        }
    }

    private DirectoryInfo CreateDirectory()
    {
        string dirPath = Path.Combine(AppContext.BaseDirectory, "FastSerializableObjectSnapshot_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"));
        var result = new DirectoryInfo(dirPath);
        result.Create();
        return result;
    }

    public void WriteToFile(IFastSerializable fastSerializableObject)
    {
        int fileIndex = Interlocked.Increment(ref _fileIndex);
        string filePath = Path.Combine(DirectoryInfo.FullName, fileIndex.ToString());
        Serializer serializer = new (filePath, fastSerializableObject);
        serializer.Dispose();
    }
}
