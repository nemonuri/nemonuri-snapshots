using System.Numerics;

namespace NM.Study.SpectreConsoles;

public readonly struct WrappedAsNestedLogableVector2 : INestedLoggable
{
    public WrappedAsNestedLogableVector2(Vector2 innerValue)
    {
        InnerValue = innerValue;
        _logNameAndDatas =
        [
            new (Constant.GetTypeMethodName, typeof(Vector2).ToString()),
            new (nameof(InnerValue.X), InnerValue.X.ToString()),
            new (nameof(InnerValue.Y), InnerValue.Y.ToString())
        ];
    }

    public Vector2 InnerValue {get;}

    private readonly IReadOnlyList<LoggingNameAndData>? _logNameAndDatas;
    public IReadOnlyList<LoggingNameAndData> LoggingNameAndDatas => _logNameAndDatas ?? [];
}
