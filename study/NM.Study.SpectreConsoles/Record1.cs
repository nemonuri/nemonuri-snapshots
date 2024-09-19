namespace NM.Study.SpectreConsoles;

public record Record1
{
    public Record1() {}

    public int IntValue {get;init;}
    public string? StringValue {get;init;}
    public Record2? Record2 {get;init;}
}
