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

        Table table = new Table();

        table.Title("0");

        table.AddColumn("Name");
        table.AddColumn("Value");



        //table.AddRow(nameof(Record1.IntValue), )

        AnsiConsole.Write(table);
    }
}
