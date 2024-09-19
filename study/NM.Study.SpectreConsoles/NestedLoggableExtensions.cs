using CommunityToolkit.Diagnostics;
using Spectre.Console;

namespace NM.Study.SpectreConsoles;

internal static class NestedLoggableExtensions
{
    internal static Table ToTable
    (
        this INestedLoggable self, 
        HeaderMode headerMode = HeaderMode.Show
    )
    {
        Guard.IsNotNull(self);

        Table table = new Table();

        table.AddColumn("Name");
        table.AddColumn("Value");

        if (headerMode == HeaderMode.Hide)
        {
            table.HideHeaders();
        }

        foreach (var nd in self.LoggingNameAndDatas ?? [])
        {
            if (nd.Name == null) {continue;}

            if (nd.DataAsString != null)
            {
                table.AddRow(new Text(nd.Name), new Text(nd.DataAsString));
            }
            else if (nd.DataAsNestedLoggable != null)
            {
                table.AddRow(new Text(nd.Name), 
                    nd.DataAsNestedLoggable.ToTable
                    (
                        headerMode: headerMode
                    ));
            }
            else
            {
                continue;
            }
        }

        return table;
    }
}

internal enum HeaderMode
{
    Show = 0,
    Hide = 1
}