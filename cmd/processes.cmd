@echo off

rem List all processes
tasklist
wmic process

rem Search for specific process
tasklist | find /i "sql"
wmic process | find /i "sql"
