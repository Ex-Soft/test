@echo off

set PATH_TO_WDSL=c:\Program Files\Microsoft SDKs\Windows\v7.0A\bin

"%PATH_TO_WDSL%\wsdl.exe" /nologo /urlkey:URL http://localhost/ServiceI/ServiceI.asmx
