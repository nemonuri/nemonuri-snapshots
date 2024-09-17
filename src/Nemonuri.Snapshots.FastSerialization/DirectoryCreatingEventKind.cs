namespace Nemonuri.Snapshots.FastSerialization;

public enum DirectoryCreatingEventKind
{
    Default = 0, /* Needed */
    Constructed = 1,
    Needed = 2
}


partial class EnumExtensions
{
    internal static bool IsValid(this DirectoryCreatingEventKind value)
    {
        return
            value >= DirectoryCreatingEventKind.Default &&
            value <= DirectoryCreatingEventKind.Constructed
            ;
    }
}