@echo off

echo DLLs Merging
if not exist bin\Merged (
	cd bin
	mkdir Merged
	cd..
)
call vendor\ILMerge\ILMerge.exe /out:bin\Merged\alifeDB.dll %1%\alifeDB.dll alifeDB\vendor\protobuf-net\protobuf.dll
echo DLLs Merged

echo DLL Replacing
xcopy %~dp0bin\Merged %~dp0%1\ /y
echo DLL Replaced
echo.

echo DLL Copying To Sandbox and GUI Apps
xcopy %~dp0%1\alifeDB.dll* %~dp0%1\..\Sandbox\ /y /d
xcopy %~dp0%1\alifeDB.dll* %~dp0\%1\..\GUI\ /y /d
echo.

echo Deleting Unnecessary Files and Folders
rmdir /s /q %~dp0bin\Merged
rmdir /s /q %~dp0%1\vendor
rmdir /s /q %~dp0%1\..\GUI\vendor
rmdir /s /q %~dp0%1\..\Sandbox\vendor
del %~dp0%1\protobuf.dll /s /f /q
del %~dp0%1\..\GUI\protobuf.dll /s /f /q
del %~dp0%1\..\Sandbox\protobuf.dll /s /f /q
echo.

pause