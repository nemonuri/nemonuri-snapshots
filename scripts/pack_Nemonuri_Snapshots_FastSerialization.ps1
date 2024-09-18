$projectPath = [System.IO.Path]::Combine($PSScriptRoot, "../src/Nemonuri.Snapshots.FastSerialization/Nemonuri.Snapshots.FastSerialization.csproj")

& dotnet pack $projectPath