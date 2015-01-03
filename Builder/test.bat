@echo off
if "%running%"=="" goto :EOF

%NUnitPath%\nunit-console.exe %TestLocation%\Tests.dll > %TestOutput%
if ERRORLEVEL 1 set TestingSucceeded=false