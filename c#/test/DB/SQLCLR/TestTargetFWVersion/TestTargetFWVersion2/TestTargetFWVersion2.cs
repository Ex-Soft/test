using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

namespace TestTargetFWVersion2
{
    public class TestTargetFWVersion2
    {
        [SqlProcedure]
        public static SqlInt32 CLRProcedureWithOutputParameters2(SqlString inParam, out SqlString outParam)
        {
            outParam = inParam + " " + inParam;

            return 0;
        }

        [SqlFunction]
        public static SqlString CLRFunction2(SqlString paramLeft, SqlString paramRight)
        {
            return paramLeft + " " + paramRight;
        }
    }
}

/*
use TestTargetFWVersion
go

if object_id(N'CLRProcedureWithOutputParameters2', N'pc') is not null
	drop procedure CLRProcedureWithOutputParameters2
go

if object_id(N'CLRFunction2', N'fs') is not null
	drop function CLRFunction2
go

if exists (select 1 from sys.assemblies asms where asms.name = N'TestTargetFWVersion2' and is_user_defined = 1)
	drop assembly TestTargetFWVersion2
go

create assembly TestTargetFWVersion2 from 'd:\soft.src\c#\test\SQLCLR\TestTargetFWVersion\TestTargetFWVersion2\bin\Debug\TestTargetFWVersion2.dll' with permission_set=unsafe
go

create function CLRFunction2 (@paramLeft nvarchar(255), @paramRight nvarchar(255))
returns nvarchar(255) external name TestTargetFWVersion2.[TestTargetFWVersion2.TestTargetFWVersion2].CLRFunction2
go

create procedure dbo.CLRProcedureWithOutputParameters2
	@inParam nvarchar(255),
	@outParam nvarchar(255) out
as
external name TestTargetFWVersion2.[TestTargetFWVersion2.TestTargetFWVersion2].CLRProcedureWithOutputParameters2
go
*/
