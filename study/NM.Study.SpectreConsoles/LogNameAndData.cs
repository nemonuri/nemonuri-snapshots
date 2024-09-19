namespace NM.Study.SpectreConsoles;

public readonly struct LogNameAndData
{
    public LogNameAndData(string? logName, string? logDataAsString)
    {
        LogName = logName;
        LogDataAsString = logDataAsString;
        LogDataAsNestedLogable = null;
    }

    public LogNameAndData(string? logName, INestedLogable? logDataAsNestedLogable)
    {
        LogName = logName;
        LogDataAsString = null;
        LogDataAsNestedLogable = logDataAsNestedLogable;
    }

    public string? LogName {get;}
    public string? LogDataAsString {get;}
    public INestedLogable? LogDataAsNestedLogable {get;}

}