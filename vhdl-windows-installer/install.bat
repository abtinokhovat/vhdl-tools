@echo off
set GHDL_DIR=%~dp0Assets\GHDL
set GTKWAVE_DIR=%~dp0Assets\gtkwave

rem Copy GHDL directory to root of C drive
xcopy /E /I %GHDL_DIR% C:\GHDL

rem Copy gtkwave directory to root of C drive
xcopy /E /I %GTKWAVE_DIR% C:\gtkwave

rem Add GHDL/bin directory to PATH
SETX PATH "%PATH%;C:\GHDL\bin"

rem Add gtkwave/bin directory to PATH
SETX PATH "%PATH%;C:\gtkwave\bin"

rem Check if GHDL is added to PATH
where ghdl.exe
if %ERRORLEVEL% == 0 (
    echo GHDL added to PATH successfully.
) else (
    echo Error: GHDL was not added to PATH.
)

rem Check if gtkwave is added to PATH
where gtkwave.exe
if %ERRORLEVEL% == 0 (
    echo gtkwave added to PATH successfully.
) else (
    echo Error: gtkwave was not added to PATH.
)

pause
