CREATE PROCEDURE [dbo].[CLRProcedureWithOutputParameters]
@inParam NVARCHAR (255), @outParam NVARCHAR (255) OUTPUT
AS EXTERNAL NAME [TestSQLCLRFunction].[TestSQLCLRFunction.TestSQLCLRFunction].[CLRProcedureWithOutputParameters]

