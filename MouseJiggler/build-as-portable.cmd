@echo off
dotnet clean
dotnet publish /p:PublishTrimmed=true /p:ReadyToRun=true /p:SelfContained=true
