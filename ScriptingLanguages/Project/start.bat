@echo off

title %WI_DATY- Projekt Jezyki Skryptowe%

set curr_date=%DATE:~10,4%-%DATE:~4,2%-%DATE:~7,2%


:main
cls
echo.
echo WI_DATY - Konwersja dat
echo.
echo.
echo 1. Start
echo 2. Informacje
echo 3. Kopia zapasowa
echo 4. Zakoncz
echo.
echo.
echo.
set /p chose="Wybierz opcje: "
if %chose%==1 goto start
if %chose%==2 goto informacje
if %chose%==3 goto kopia
if %chose%==4 goto exit

:start

start program.exe

IF EXIST "wykres.png" (
  echo Wykres Istnieje!
) ELSE (
  start wykres.py
)

start strona.py
timeout 2 >nul

start strona.html

goto exit



:kopia
cls
xcopy /Q /Y input.txt .\kopie_zapasowe\kopia_%curr_date%\
xcopy /Q /Y output.txt .\kopie_zapasowe\kopia_%curr_date%\
xcopy /Q /Y strona.html .\kopie_zapasowe\kopia_%curr_date%\
xcopy /Q /Y style.css .\kopie_zapasowe\kopia_%curr_date%\
xcopy /Q /Y strona.py .\kopie_zapasowe\kopia_%curr_date%\
xcopy /Q /Y wykres.py .\kopie_zapasowe\kopia_%curr_date%\

echo Ukonczono! Nacisnij spacje.
pause
goto main

:informacje
cls
echo Projekt Jezyki Skryptowe -WI_DATY - Konwersja dat
echo Adam Kierat
pause
goto main

:exit
cls
pause
echo on
