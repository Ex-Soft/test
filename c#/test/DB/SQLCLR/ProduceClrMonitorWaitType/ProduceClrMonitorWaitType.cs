// http://www.sqlnotes.info/2012/03/07/produce-clr_monitor-wait-type/

using System.Data.SqlTypes;
using System.Threading;

namespace ProduceClrMonitorWaitType
{
    internal static class StaticVariables
    {
        public static object SyncObj = new object();
    }

    public class ProduceClrMonitorWaitType
    {
        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlInt32 Wait10Sec()
        {
            lock (StaticVariables.SyncObj)
            {
                Thread.Sleep(10000);
                return new SqlInt32(1);
            }
        }

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlInt32 Wait10Sec_1()
        {
            try
            {
                Monitor.Enter(StaticVariables.SyncObj);
                Thread.Sleep(10000);
                return new SqlInt32(1);
            }
            finally
            {
                Monitor.Exit(StaticVariables.SyncObj);
            }
        }
    }
}

/*
if object_id(N'Wait10Sec', N'fs') is not null
	drop function Wait10Sec
go

if object_id(N'Wait10Sec_1', N'fs') is not null
	drop function Wait10Sec_1
go

if exists (select 1 from sys.assemblies asms where asms.name = N'ProduceClrMonitorWaitType' and is_user_defined = 1)
	drop assembly ProduceClrMonitorWaitType
go

create assembly ProduceClrMonitorWaitType from 'd:\soft.src\c#\test\SQLCLR\ProduceClrMonitorWaitType\bin\Debug\ProduceClrMonitorWaitType.dll' with permission_set = unsafe
go

create function Wait10Sec()
returns int external name ProduceClrMonitorWaitType.[ProduceClrMonitorWaitType.ProduceClrMonitorWaitType].Wait10Sec
go

create function Wait10Sec_1()
returns int external name ProduceClrMonitorWaitType.[ProduceClrMonitorWaitType.ProduceClrMonitorWaitType].Wait10Sec_1
go

*/

/*

select dbo.Wait10Sec()

select dbo.Wait10Sec()
 
select  session_id, wait_type, wait_time from sys.dm_exec_requests where session_id = 54

*/