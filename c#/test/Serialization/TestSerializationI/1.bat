@echo off

set PATH_TO_XSD=c:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\bin

if -%1-==-- goto end

"%PATH_TO_XSD%\xsd.exe" "%1" /classes /fields

:end