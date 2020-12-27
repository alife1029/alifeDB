@echo off

echo Supported Build Systems:
echo vs2019   (Visual Studio 2019 Projects)
echo vs2017   (Visual Studio 2017 Projects)
echo vs2015   (Visual Studio 2015 Projects)
echo vs2013   (Visual Studio 2013 Projects)
echo vs2012   (Visual Studio 2012 Projects)
echo vs2010   (Visual Studio 2010 Projects)
echo vs2008   (Visual Studio 2008 Projects)
echo vs2005   (Visual Studio 2005 Projects)
echo gmake    (GNU Makefiles)
echo gmake2   (GNU Makefiles)
echo.
echo.

set /p ide=Which Build System will you use: 
echo.

call vendor\bin\premake\premake5.exe %ide%

echo.
pause