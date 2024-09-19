namespace NM.Study.SpectreConsoles;

public readonly struct WrappedAsNestedLogableReadonlyList<T> : INestedLoggable
{
    public WrappedAsNestedLogableReadonlyList(IReadOnlyList<T>? innerValue) : this(innerValue, null)
    {}

    public WrappedAsNestedLogableReadonlyList(IReadOnlyList<T>? innerValue, Func<T, INestedLoggable>? nestedLogableFacotry)
    {
        _innerValue = innerValue;
        _nestedLogableFacotry = nestedLogableFacotry;
        _logNameAndDatas = InnerValue.Select(SelectLogNameAndData)
            .Prepend(new LoggingNameAndData(Constant.GetTypeMethodName, typeof(T).FullName + "[]"))
            .ToArray();
    }

    private readonly IReadOnlyList<T>? _innerValue;
    public IReadOnlyList<T> InnerValue => _innerValue ?? [];

    private readonly Func<T, INestedLoggable>? _nestedLogableFacotry;

    private readonly IReadOnlyList<LoggingNameAndData>? _logNameAndDatas;
    public IReadOnlyList<LoggingNameAndData> LoggingNameAndDatas => _logNameAndDatas ?? [];

    private LoggingNameAndData SelectLogNameAndData(T element, int index)
    {
        string logName = index.ToString();

        if (_nestedLogableFacotry != null)
        {
            return new (logName, _nestedLogableFacotry.Invoke(element));
        }
        else if (element is INestedLoggable nestedLogableElement)
        {
            return new (logName, nestedLogableElement);
        }
        else
        {
            return new (logName, element?.ToString());
        }
    }
}
