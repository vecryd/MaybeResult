$ProjectFile = [xml](Get-Content src\MaybeResult\MaybeResult.csproj)
$Version = $ProjectFile.Project.PropertyGroup.Version
$OutputPath = "artifacts\v$Version"

if (Test-Path $OutputPath) {
    Remove-Item -Path $OutputPath -Recurse -Force
}

dotnet build src\MaybeResult\MaybeResult.csproj -o $OutputPath -c Release -p:Optimize=true -p:DebugSymbols=false -p:DebugType=None
dotnet pack src\MaybeResult\MaybeResult.csproj -o $OutputPath -c Release -p:Optimize=true -p:DebugSymbols=false -p:DebugType=None