namespace Nemonuri.NestedLogs;

public interface INestedLoggable
{
    IReadOnlyList<LoggingNameAndData> LoggingNameAndDatas {get;}
}
