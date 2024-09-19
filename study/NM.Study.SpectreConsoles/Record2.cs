using System.Numerics;

namespace NM.Study.SpectreConsoles;

public record Record2 : INestedLoggable
{
    public Record2() {}

    public Vector2[]? Vector2s {get;init;}

    private IReadOnlyList<LoggingNameAndData>? _logNameAndDatas;
    public IReadOnlyList<LoggingNameAndData> LoggingNameAndDatas => _logNameAndDatas ??= 
        [
            new (Constant.GetTypeMethodName, typeof(Record2).FullName),
            new LoggingNameAndData(nameof(Vector2s), new WrappedAsNestedLogableReadonlyList<Vector2>(Vector2s, a => new WrappedAsNestedLogableVector2(a)))
        ];
}
