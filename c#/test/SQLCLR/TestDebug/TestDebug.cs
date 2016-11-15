using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

namespace TestDebug
{
    public class TestDebug
    {
        [SqlProcedure]
        public static SqlInt32 CLRProcedureWithOutputParameters(SqlString inParam, out SqlString outParam)
        {
            outParam = inParam + " " + inParam;

            return 0;
        }

        [SqlFunction]
        public static SqlString CLRFunction(SqlString paramLeft, SqlString paramRight)
        {
            return paramLeft + " " + paramRight;
        }
    }
}

/*
create database TestDebug on (name = TestDebug, filename = N'd:\db\TestDebug.mdf') log on (name = TestDebug_log, filename = 'd:\db\TestDebug_log.ldf');
go
*/

/*
use TestDebug
go

sp_configure 'clr enabled', 1
go

reconfigure with override  
go

alter database TestDebug set trustworthy on
go
*/

/*
if object_id(N'CLRProcedureWithOutputParameters', N'pc') is not null
	drop procedure CLRProcedureWithOutputParameters
go

if object_id(N'CLRFunction', N'fs') is not null
	drop function CLRFunction
go

if exists (select 1 from sys.assemblies asms where asms.name = N'TestDebug' and is_user_defined = 1)
	drop assembly TestDebug
go

create assembly TestDebug from 'd:\soft.src\c#\test\SQLCLR\TestDebug\bin\Debug\TestDebug.dll' with permission_set=unsafe
go

create function CLRFunction (@paramLeft nvarchar(255), @paramRight nvarchar(255))
returns nvarchar(255) external name TestDebug.[TestDebug.TestDebug].CLRFunction
go

create procedure dbo.CLRProcedureWithOutputParameters
	@inParam nvarchar(255),
	@outParam nvarchar(255) out
as
external name TestDebug.[TestDebug.TestDebug].CLRProcedureWithOutputParameters
go
*/

/*
declare
	@paramLeft nvarchar(255) = N'paramLeft',
	@paramRight nvarchar(255) = N'paramRight',
	@resultStr nvarchar(255)

set @resultStr = N'''' + dbo.CLRFunction(@paramLeft, @paramRight) + N''''
print @resultStr

declare
	@inParam nvarchar(255) = N'inParam',
	@outParam nvarchar(255),
	@resultInt int

exec @resultInt = CLRProcedureWithOutputParameters @inParam = @inParam, @outParam = @outParam out
set @resultStr = N'''' + @outParam + N''''
print @resultStr
print @resultInt
*/
