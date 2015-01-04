@echo off
if "%running%"=="" goto :EOF

set CloningSucceeded=true
set BuildSucceeded=true
set TestingSucceeded=true
set CloneLog=clone.txt
set BuildLog=msbuild.txt
set TestOutput=tests.txt

set GitPath="C:\Program Files (x86)\Git\bin"
set MSBuildPath="C:\Windows\Microsoft.NET\Framework\v4.0.30319"
set BlatPath="C:\Program Files (x86)\blat-2.6.2\full\"
set NUnitPath="C:\Program Files (x86)\NUnit-2.6.4\bin\"
set FileList=files.txt

set RepositoryPath="C:\GitHub"
set RepositoryName=Geometry_For_Builder
set RepositoryURL=http://github.com/AnastasiaSulyagina/%RepositoryName%

set Solution=Geometry.sln
set BuildLocation="%RepositoryPath%\%RepositoryName%\UI\bin\Release"
set TestLocation="%RepositoryPath%\%RepositoryName%\Tests\bin\Release"

set EmailReceiver=anastasia.sulyagina@gmail.com