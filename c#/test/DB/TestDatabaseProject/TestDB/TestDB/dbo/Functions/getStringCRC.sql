CREATE FUNCTION [dbo].[getStringCRC]
(@data NVARCHAR (MAX))
RETURNS BIGINT
AS
 EXTERNAL NAME [TestSQLCLRFunction].[TestSQLCLRFunction.TestSQLCLRFunction].[CalcStringCRC]

