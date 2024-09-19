
namespace NM.Study.SpectreConsoles;

public record Record1 : INestedLoggable
{
    public Record1() {}

    public int IntValue {get;init;}
    public string? StringValue {get;init;}
    public Record2? Record2 {get;init;}

    private IReadOnlyList<LoggingNameAndData>? _loggingNameAndDatas;
    public IReadOnlyList<LoggingNameAndData> LoggingNameAndDatas => _loggingNameAndDatas ??=
        [
            new (Constant.GetTypeMethodName, typeof(Record1).FullName),
            new (nameof(IntValue), IntValue.ToString()),
            new (nameof(StringValue), StringValue?.ToString()),
            new (nameof(Record2), Record2)
        ];
}

public static class Constant
{
    public const string GetTypeMethodName = "GetType()";
}