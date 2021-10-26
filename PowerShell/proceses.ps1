@echo off

rem List all processes
Get-Process

rem Search for specific service
Get-Process | Where-Object {$_.ProcessName -like "*sql*"}