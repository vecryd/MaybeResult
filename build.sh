#!/bin/bash
Version=$(grep -oPm1 "(?<=<Version>)[^<]+" src/MaybeResult/MaybeResult.csproj)
OutputPath="artifacts/v$Version"

if [ -d $OutputPath ]; then
    rm -r -f $OutputPath
fi

dotnet build src/MaybeResult/MaybeResult.csproj -o $OutputPath -c Release -p:Optimize=true -p:DebugSymbols=false -p:DebugType=None
dotnet pack src/MaybeResult/MaybeResult.csproj -o $OutputPath -c Release -p:Optimize=true -p:DebugSymbols=false -p:DebugType=None