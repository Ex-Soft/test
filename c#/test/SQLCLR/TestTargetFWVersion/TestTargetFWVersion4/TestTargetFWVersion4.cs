using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

namespace TestTargetFWVersion4
{
    public class TestTargetFWVersion4
    {
        [SqlProcedure]
        public static SqlInt32 CLRProcedureWithOutputParameters4(SqlString inParam, out SqlString outParam)
        {
            outParam = inParam + " " + inParam;

            return 0;
        }

        [SqlFunction]
        public static SqlString CLRFunction4(SqlString paramLeft, SqlString paramRight)
        {
            return paramLeft + " " + paramRight;
        }
    }
}

/*
use TestTargetFWVersion
go

if object_id(N'CLRProcedureWithOutputParameters4', N'pc') is not null
	drop procedure CLRProcedureWithOutputParameters4
go

if object_id(N'CLRFunction4', N'fs') is not null
	drop function CLRFunction4
go

if exists (select 1 from sys.assemblies asms where asms.name = N'TestTargetFWVersion4' and is_user_defined = 1)
	drop assembly TestTargetFWVersion4
go

create assembly TestTargetFWVersion4 from 'd:\soft.src\c#\test\SQLCLR\TestTargetFWVersion\TestTargetFWVersion4\bin\Debug\TestTargetFWVersion4.dll' with permission_set=unsafe
go

create function CLRFunction4 (@paramLeft nvarchar(255), @paramRight nvarchar(255))
returns nvarchar(255) external name TestTargetFWVersion4.[TestTargetFWVersion4.TestTargetFWVersion4].CLRFunction4
go

create procedure dbo.CLRProcedureWithOutputParameters4
	@inParam nvarchar(255),
	@outParam nvarchar(255) out
as
external name TestTargetFWVersion4.[TestTargetFWVersion4.TestTargetFWVersion4].CLRProcedureWithOutputParameters4
go
*/
