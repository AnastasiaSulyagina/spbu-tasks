@echo off
if "%running%"=="" goto :EOF

git clone -b master %RepositoryURL% %RepositoryPath%\%RepositoryName% > %CloneLog%
if ERRORLEVEL 1 set CloningSucceeded=false

echo OLOLO