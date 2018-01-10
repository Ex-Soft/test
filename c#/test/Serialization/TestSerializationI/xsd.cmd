@echo off

set full_path_2_app="c:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.7.1 Tools\x64\xsd.exe"
if exist %full_path_2_app% goto DoIt

set full_path_2_app="c:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.7.1 Tools\xsd.exe"
if exist %full_path_2_app% goto DoIt

set full_path_2_app="c:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.7 Tools\x64\xsd.exe"
if exist %full_path_2_app% goto DoIt

set full_path_2_app="c:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.7 Tools\xsd.exe"
if exist %full_path_2_app% goto DoIt

set full_path_2_app="c:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6.2 Tools\x64\xsd.exe"
if exist %full_path_2_app% goto DoIt

set full_path_2_app="c:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6.2 Tools\xsd.exe"
if exist %full_path_2_app% goto DoIt

set full_path_2_app="c:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6.1 Tools\x64\xsd.exe"
if exist %full_path_2_app% goto DoIt

set full_path_2_app="c:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6.1 Tools\xsd.exe"
if exist %full_path_2_app% goto DoIt

set full_path_2_app="c:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6 Tools\x64\xsd.exe"
if exist %full_path_2_app% goto DoIt

set full_path_2_app="c:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6 Tools\xsd.exe"
if exist %full_path_2_app% goto DoIt

set full_path_2_app="c:\Program Files (x86)\Microsoft SDKs\Windows\v8.1A\bin\NETFX 4.5.1 Tools\x64\xsd.exe"
if exist %full_path_2_app% goto DoIt

set full_path_2_app="c:\Program Files (x86)\Microsoft SDKs\Windows\v8.1A\bin\NETFX 4.5.1 Tools\xsd.exe"
if exist %full_path_2_app% goto DoIt

set full_path_2_app="c:\Program Files (x86)\Microsoft SDKs\Windows\v8.0A\bin\NETFX 4.0 Tools\x64\xsd.exe"
if exist %full_path_2_app% goto DoIt

set full_path_2_app="c:\Program Files (x86)\Microsoft SDKs\Windows\v8.0A\bin\NETFX 4.0 Tools\xsd.exe"
if exist %full_path_2_app% goto DoIt

set full_path_2_app="c:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\Bin\x64\xsd.exe"
if exist %full_path_2_app% goto DoIt

set full_path_2_app="c:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\Bin\xsd.exe"
if exist %full_path_2_app% goto DoIt

if -%1-==-- goto end

:DoIt
echo %full_path_2_app% %1 %2 %3 %4 %5 %6 %7 %8 %9
%full_path_2_app% %1 %2 %3 %4 %5 %6 %7 %8 %9
goto end

:end