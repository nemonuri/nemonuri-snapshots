$projectPath = [System.IO.Path]::Combine($PSScriptRoot, "../src/Nemonuri.NestedLogs/Nemonuri.NestedLogs.csproj")

& dotnet pack $projectPath