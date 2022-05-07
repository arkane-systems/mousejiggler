@echo off
dotnet clean
rem We cannot use trimming with the .NET 6/VS 2022 toolchain until Windows Forms is
rem converted to use ComWrappers. See: https://docs.microsoft.com/en-us/dotnet/core/deploying/trimming/incompatibilities
rem dotnet publish /p:PublishTrimmed=true /p:ReadyToRun=true /p:SelfContained=true
dotnet publish /p:PublishTrimmed=false /p:ReadyToRun=true /p:SelfContained=true -c Release
