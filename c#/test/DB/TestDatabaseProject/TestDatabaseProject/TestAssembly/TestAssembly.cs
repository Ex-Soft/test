using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

namespace TestAssembly
{
    public class TestAssembly
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
use ForTestDatabaseProject
go

sp_configure 'clr enabled', 1
go

reconfigure with override  
go

alter database ForTestDatabaseProject set trustworthy on
go
*/

/*
if object_id(N'CLRProcedureWithOutputParameters', N'pc') is not null
	drop procedure CLRProcedureWithOutputParameters
go

if object_id(N'CLRFunction', N'fs') is not null
	drop function CLRFunction
go

if exists (select 1 from sys.assemblies asms where asms.name = N'TestAssembly' and is_user_defined = 1)
	drop assembly TestAssembly
go

create assembly TestAssembly from 'D:\soft.src\c#\test\TestDatabaseProject\TestDatabaseProject\TestAssembly\bin\Debug\TestAssembly.dll' with permission_set=unsafe
go

create function CLRFunction (@paramLeft nvarchar(255), @paramRight nvarchar(255))
returns nvarchar(255) external name TestAssembly.[TestAssembly.TestAssembly].CLRFunction
go

create procedure dbo.CLRProcedureWithOutputParameters
	@inParam nvarchar(255),
	@outParam nvarchar(255) out
as
external name TestAssembly.[TestAssembly.TestAssembly].CLRProcedureWithOutputParameters
go
*/
