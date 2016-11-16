:setvar DatabaseName testdb
:setvar TableName Staff
:listvar
use $(DatabaseName);
select * from $(TableName);