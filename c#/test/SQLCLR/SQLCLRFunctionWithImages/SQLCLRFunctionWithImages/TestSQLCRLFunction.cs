// http://blogs.msdn.com/b/slavao/archive/2005/02/19/376714.aspx SQLOS's memory manager: responding to memory pressure
// https://msdn.microsoft.com/en-us/library/ms810627.aspx?f=255&MSPPError=-2147217396 Managing Virtual Memory
// http://blogs.msdn.com/b/sqlclr/archive/2006/03/24/560154.aspx Memory Usage in SQL CLR
// https://support.microsoft.com/en-us/kb/949080 Error message when you execute a CLR routine or use an assembly in SQL Server: "Assembly in host store has a different signature than assembly in GAC. (Exception from HRESULT: 0x80131050)"

using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;
using Microsoft.SqlServer.Server;

namespace TestSQLCLRFunction
{
    public class TestSQLCLRFunction
    {
        [SqlFunction(DataAccess = DataAccessKind.Read, SystemDataAccess = SystemDataAccessKind.Read)]
        public static SqlString GetIds(SqlString tableName, SqlInt32 department)
        {
            string
                result;

            StringBuilder
                sb = new StringBuilder();

            using (SqlConnection conn = new SqlConnection("context connection=true"))
            {
                using (SqlCommand cmd = new SqlCommand(string.Format("select id from {0} where dep=@dep", tableName), conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@dep", department);
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                            sb.Append(string.Format(",{0}", rdr.GetSqlInt64(0)));
                    }
                }
            }

            return new SqlString(!string.IsNullOrEmpty(result = sb.ToString()) ? result.Substring(1) : result);
        }

        [SqlFunction]
        public static SqlInt64 CalcBinaryCRC(SqlBinary data)
        {
            long
                result = 0L;

            if (!data.IsNull)
            {
                for (int i = 0, j; i < data.Length; i += j)
                    for (j = 0; j < 4 && i + j < data.Length; j++)
                    {
                        var value = data[i + j];
                        if (!Equals(value, null) && (value.ToString().ToCharArray()[0]) > 255) continue;
                        result += ((long)Convert.ToByte(value)) << (8 * j);
                    }
            }

            return new SqlInt64(result);
        }

        [SqlFunction]
        public static SqlInt64 CalcStringCRC(SqlString data)
        {
            long
                result = 0L;

            if (!data.IsNull)
            {
                var _data_ = data.ToString().ToCharArray();
                for (int i = 0, j; i < _data_.Length; i += j)
                    for (j = 0; j < 4 && i + j < _data_.Length; j++)
                    {
                        var value = _data_[i + j];
                        if (!Equals(value, null) && (value.ToString().ToCharArray()[0]) > 255) continue;
                        result += ((long)Convert.ToByte(value)) << (8 * j);
                    }
            }

            return new SqlInt64(result);
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

create assembly [system.drawing] from 'C:\Windows\Microsoft.NET\Framework\v2.0.50727\System.Drawing.dll' with permission_set=unsafe
go

create assembly [System.Drawing] from 'C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Drawing.dll' with permission_set=unsafe
go

create assembly TestSQLCLRFunction from 'd:\soft.src\c#\test\SQLCLR\TestSQLCLRFunction\bin\Debug\TestSQLCLRFunction.dll' with permission_set=safe
go

create function getStaffIds (@tableName nvarchar(255), @dep int)
returns nvarchar(255) external name TestSQLCLRFunction.[TestSQLCLRFunction.TestSQLCLRFunction].GetIds
go

create function getBinaryCRC (@data varbinary(max))
returns bigint external name TestSQLCLRFunction.[TestSQLCLRFunction.TestSQLCLRFunction].CalcBinaryCRC
go

create function getStringCRC (@data nvarchar(max))
returns bigint external name TestSQLCLRFunction.[TestSQLCLRFunction.TestSQLCLRFunction].CalcStringCRC
go

create function PatchImage (@image varbinary(max), @maxSize int)
returns varbinary(max) external name TestSQLCLRFunction.[TestSQLCLRFunction.Images].PatchImage
go

select dbo.getStaffIds(N'Staff', 1)
go

-- drop

if object_id(N'getStaffIds', N'fs') is not null
	drop function getStaffIds
go

if object_id(N'getBinaryCRC', N'fs') is not null
	drop function getBinaryCRC
go

if object_id(N'getStringCRC', N'fs') is not null
	drop function getStringCRC
go

if object_id(N'PatchImage', N'fs') is not null
	drop function PatchImage
go

if exists (select 1 from sys.assemblies asms where asms.name = N'TestSQLCLRFunction' and is_user_defined = 1)
	drop assembly TestSQLCLRFunction
go

if exists (select 1 from sys.assemblies asms where asms.name = N'System.Drawing' and is_user_defined = 1)
	drop assembly [System.Drawing]
go

*/