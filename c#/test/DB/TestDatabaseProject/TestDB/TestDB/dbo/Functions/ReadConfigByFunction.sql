CREATE FUNCTION [dbo].[ReadConfigByFunction]
(@key NVARCHAR (255))
RETURNS NVARCHAR (255)
AS
 EXTERNAL NAME [TestConfig].[TestConfig.TestConfig].[ReadConfigByFunction]

