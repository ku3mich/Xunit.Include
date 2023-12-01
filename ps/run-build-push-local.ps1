#!/usr/bin/env pwsh
dotnet build --configuration Release ../Xunit.Include/Xunit.Include.csproj 

./run-pack.ps1

function Push-Package {
  param($pkg)
	nuget push $pkg -source local
}

Get-ChildItem ../bin/pkgs -Filter '*.nupkg' | % { Push-Package $_.FullName }
