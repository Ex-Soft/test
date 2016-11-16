/* http://blog.sqlauthority.com/2013/06/28/sql-server-how-to-set-variable-and-use-variable-in-sqlcmd-mode/ */

:setvar DatabaseName "testdb"
use $(DatabaseName);

/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END
ELSE
	PRINT N'oB!'
