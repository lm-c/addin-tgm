@echo off
chcp 65001 > nul
setlocal enabledelayedexpansion

xcopy "P:\Projetos Leonardo\01 - Clientes\05 - TGM\03 - ADDIN TGM 4.0\AddinTGM\bin\Debug\*.*" "C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS" /E /I /Y

echo pause


