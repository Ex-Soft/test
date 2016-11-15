@echo off
if -%1-==-on- goto on
goto off

:on
net start aspnet_state
goto end

:off
net stop aspnet_state
goto end

:end