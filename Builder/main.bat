@echo off
set running=true

call settings.bat
call clean.bat

call clone.bat
if "%CloningSucceeded%"=="false" goto :mail

call build.bat
if "%BuildSucceeded%"=="false" goto :mail

call test.bat

:mail
call email.bat
