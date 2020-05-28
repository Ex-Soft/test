@echo off

rem List all services
Get-Service

rem Search for specific service
Get-Service | Where-Object {$_.Name -like "*vpnagent*"}

rem Get the status of a specific service
Get-Service vpnagent

rem Get a list of the running services
Get-Service | Where-Object {$_.Status -eq "Running"}

rem Get a list of the stopped services
sc queryex type= service state= inactive