Remove-Item nuget -Force -Recurse -ErrorAction Ignore
dotnet pack -c Release .\src\K9Nano.Modular.Module.Targets\K9Nano.Modular.Module.Targets.csproj -o nuget
dotnet pack -c Release .\src\K9Nano.Modular.Abstraction\K9Nano.Modular.Abstraction.csproj -o nuget
dotnet pack -c Release .\src\K9Nano.Modular.Core\K9Nano.Modular.Core.csproj -o nuget
dotnet pack -c Release .\src\K9Nano.Modular.Targets\K9Nano.Modular.Targets.csproj -o nuget
