using CommunityToolkit.Diagnostics;
using Spectre.Console;

namespace NM.Study.SpectreConsoles;

internal static class NestedLoggableExtensions
{
    internal static Table ToTable(this INestedLoggable self)
    {
        Guard.IsNotNull(self);

        Table table = new Table();

        table.AddColumn("Name");
        table.AddColumn("Value");

        foreach (var nd in self.LoggingNameAndDatas ?? [])
        {
            if (nd.Name == null) {continue;}

            if (nd.DataAsString != null)
            {
                table.AddRow(nd.Name, nd.DataAsString);
            }
            else if (nd.DataAsNestedLoggable != null)
            {
                table.AddRow(new Text(nd.Name), nd.DataAsNestedLoggable.ToTable());
            }
            else
            {
                continue;
            }
        }

        return table;
    }
}
