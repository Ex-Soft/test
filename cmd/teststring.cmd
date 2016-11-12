@echo off

rem http://www.dostips.com/DtTipsStringManipulation.php
rem http://www.sql.ru/forum/actualthread.aspx?tid=981951

set str=teh cat in teh hat
echo %str%
set str=%str:teh=the%
echo %str%