#!/usr/bin/env pwsh

dotnet pack --configuration Release -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg -o ../bin/pkgs ../Xunit.Include/Xunit.Include.csproj 
