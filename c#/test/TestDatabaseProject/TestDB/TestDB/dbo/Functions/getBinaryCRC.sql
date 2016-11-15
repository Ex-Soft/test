CREATE FUNCTION [dbo].[getBinaryCRC]
(@data VARBINARY (MAX))
RETURNS BIGINT
AS
 EXTERNAL NAME [TestSQLCLRFunction].[TestSQLCLRFunction.TestSQLCLRFunction].[CalcBinaryCRC]

