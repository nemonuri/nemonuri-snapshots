
namespace Nemonuri.Snapshots.FastSerialization;

public class FastSerializableObjectSnapshoter
{
    private readonly DirectoryCreatingEventKind _eventKind;

    private DirectoryInfo? _directoryInfo;
    private DirectoryInfo DirectoryInfo => _directoryInfo ??= CreateDirectoryInfo();

    public FastSerializableObjectSnapshoter():this(DirectoryCreatingEventKind.Default)
    {
    }

    public FastSerializableObjectSnapshoter(DirectoryCreatingEventKind eventKind)
    {
        Guard.IsTrue(eventKind.IsValid());
        _eventKind = eventKind;

        if (eventKind == DirectoryCreatingEventKind.Constructed)
        {
            _directoryInfo = CreateDirectoryInfo();
        }
    }

    private DirectoryInfo CreateDirectoryInfoIfNeeded()
    {
        if 
        (
            _eventKind == DirectoryCreatingEventKind.Default ||
            _eventKind == DirectoryCreatingEventKind.Needed
        )
        {
            return CreateDirectoryInfo();
        }
        else
        {
            return ThrowHelper.ThrowInvalidOperationException<DirectoryInfo>();
        }
    }

    private DirectoryInfo CreateDirectoryInfo()
    {
        throw new NotImplementedException();
    }
}
