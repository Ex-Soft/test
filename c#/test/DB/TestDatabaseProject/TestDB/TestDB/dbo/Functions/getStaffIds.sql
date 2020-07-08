CREATE FUNCTION [dbo].[getStaffIds]
(@tableName NVARCHAR (255), @dep INT)
RETURNS NVARCHAR (255)
AS
 EXTERNAL NAME [TestSQLCLRFunction].[TestSQLCLRFunction.TestSQLCLRFunction].[GetIds]

