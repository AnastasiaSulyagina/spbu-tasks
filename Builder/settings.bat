@echo off
if "%running%"=="" goto :EOF

set CloningSucceeded=true
set BuildSucceeded=true
set TestingSucceeded=true
set CloneLog=clone.log
set BuildLog=msbuild.log

set GitPath="C:\Program Files (x86)\Git\bin"
set MSBuildPath="C:\Windows\Microsoft.NET\Framework\v4.0.30319"
set BlatPath="C:\Program Files (x86)\blat-2.6.2\full"
set NUnitpath="C:\Program Files (x86)\NUnit-2.6.4\bin"
set FileList=%folder%\files.txt

set RepositoryPath="C:\GitHub"
set RepositoryName=Geometry_For_Builder
set RepositoryURL=http://github.com/AnastasiaSulyagina/%RepositoryName%

set Solution=Geometry.sln
set BuildFolder="%RepositoryPath%\%RepositoryName%\UI\bin\Release"

set TestLocation="%RepositoryPath%\%RepositoryName%\Tests\bin\Release"
set TestOutput=tests.txt

set EmailReceiver=anastasia.sulyagina@gmail.com