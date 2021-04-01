Get-ChildItem -Path nuget | ForEach-Object {
    dotnet nuget push $_.FullName -s http://nuget.ytzx.com -k ytzx1234
}