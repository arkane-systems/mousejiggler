@echo off
dotnet clean
dotnet publish /p:PublishTrimmed=false /p:ReadyToRun=true /p:SelfContained=true -c Release

