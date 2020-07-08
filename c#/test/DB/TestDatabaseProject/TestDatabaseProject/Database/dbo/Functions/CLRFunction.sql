CREATE FUNCTION [dbo].[CLRFunction]
(@paramLeft NVARCHAR (255), @paramRight NVARCHAR (255))
RETURNS NVARCHAR (255)
AS
 EXTERNAL NAME [TestAssembly].[TestAssembly.TestAssembly].[CLRFunction]

