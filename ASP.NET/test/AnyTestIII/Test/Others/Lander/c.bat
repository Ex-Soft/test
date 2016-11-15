@echo off
set path=%path%;c:\Progra~1\Micros~1.NET\Common7\IDE
set lib=c:\Progra~1\Micros~1.NET\VC7\lib;c:\Progra~1\Micros~1.NET\SDK\V1.1\Lib

"C:\Program Files\Microsoft Visual Studio .NET 2003\Vc7\bin\cl.exe" /clr lander.cpp /link /dll /out:bin\Lander.dll
pause