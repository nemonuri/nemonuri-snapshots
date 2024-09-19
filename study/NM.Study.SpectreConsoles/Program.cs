using Spectre.Console;

namespace NM.Study.SpectreConsoles;

internal class Program
{
    private static void Main(string[] args)
    {   
        //--- data ---
        Record1 data1 = new Record1()
        {
            IntValue = 123,
            StringValue = "asdfgggg",
            Record2 = new Record2()
            {
                Vector2s = [new (1f,2f), new(2.5f, 0f), new (1.25f, 0.1f+0.3f)]
            }
        };
        //---|

        //--- log ---
        Table table = data1.ToTable().Title("0").HideHeaders();
        AnsiConsole.Write(table);
        //---|
    }
}
