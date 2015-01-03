@echo off
if "%running%"=="" goto :EOF

set EmailSubject=Build result
set EmailBody=Build succeeded. All tests passed.
set FileToAttach=%MSBuildLog%

if %CloningSucceeded%==false (
  set EmailBody=Cloning failed.
  set FileToAttach=%CloneLog%
)
 
if %BuildSucceeded%==false set EmailBody=Build failed.

if %TestingSucceeded%==false (
  set EmailBody=Testing failed.
  set FileToAttach=%TestOutput%
)

%BlatPath%\blat.exe -s "%EmailSubject%" -body "%EmailBody%" -to %EmailReceiver% -attacht %FileToAttach% 