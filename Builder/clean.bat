@echo off
if "%running%"=="" goto :EOF

rmdir /s /q %RepositoryPath%\%RepositoryName%