@echo off
if "%running%"=="" goto :EOF

%MSBuildPath%\MSBuild.exe %RepositoryPath%\%RepositoryName%\%solution% /p:Configuration=Release;VisualStudioVersion=13.0
if ERRORLEVEL 1 echo BABAH

set BuildSucceeded=false