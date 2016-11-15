//#define GET_UNLOCALIZE_EXCEPTION_MESSAGE

using System;
using System.Configuration;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

#if GET_UNLOCALIZE_EXCEPTION_MESSAGE
    using System.Globalization;
    using System.Threading;
#endif

namespace TestConfig
{
    public class TestConfig
    {
        [SqlFunction]
        public static SqlString ReadConfigByFunction(SqlString key)
        {
            var result = SqlString.Null;

            #if GET_UNLOCALIZE_EXCEPTION_MESSAGE
                var currentCulture = Thread.CurrentThread.CurrentCulture;
                var currentUICulture = Thread.CurrentThread.CurrentUICulture;

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
            #endif

            try
            {
                string
                    keyStr,
                    value;

                if (!key.IsNull
                    && !string.IsNullOrWhiteSpace(keyStr = key.ToString())
                    && !string.IsNullOrWhiteSpace(value = ConfigurationManager.AppSettings[keyStr]))
                    result = value;
            }
            catch (Exception eException)
            {
                result = eException.Message;
            }

            #if GET_UNLOCALIZE_EXCEPTION_MESSAGE
                Thread.CurrentThread.CurrentCulture = currentCulture;
                Thread.CurrentThread.CurrentUICulture = currentUICulture;
            #endif

            return result;
        }
    }
}

/*

use testdb
go

sp_configure 'clr enabled', 1
go

reconfigure with override  
go

alter database testdb set trustworthy on
go

if object_id(N'ReadConfigByFunction', N'fs') is not null
	drop function ReadConfigByFunction
go

if exists (select 1 from sys.assemblies asms where asms.name = N'TestConfig' and is_user_defined = 1)
	drop assembly TestConfig
go

create assembly TestConfig from 'D:\soft.src\c#\test\SQLCLR\TestConfig\bin\Debug\TestConfig.dll' with permission_set=unsafe
go

create function ReadConfigByFunction(@key nvarchar(255))
returns nvarchar(255) external name TestConfig.[TestConfig.TestConfig].ReadConfigByFunction
go

-- 4 test
declare
	@result nvarchar(255)

set @result = dbo.ReadConfigByFunction(N'endPointAddr')

if @result is not null
	print N'''' + @result + N''''
else
	print N'NULL'

- 4 reread sqlservr.exe.config
dbcc freesystemcache('all')
go

*/