@echo off

rem List all services
sc queryex type= service state= all

rem List service names only
sc queryex type= service state= all | find /i "SERVICE_NAME:"

rem Search for specific service
sc queryex type= service state= all | find /i "SERVICE_NAME: vpnagent"

rem Get the status of a specific service
sc query vpnagent

rem Get a list of the running services
sc queryex type= service
rem or
sc queryex type= service state= active
rem or
net start

rem Get a list of the stopped services
sc queryex type= service state= inactive