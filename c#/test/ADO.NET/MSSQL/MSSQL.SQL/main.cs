#define TEST_DATA_ADAPTER
//#define TEST_BATCH
//#define TEST_DATE_TYPES
//#define ANY_TEST
//#define Determining_SET_Options_for_Current_Session // https://www.mssqltips.com/sqlservertip/1415/determining-set-options-for-a-current-session-in-sql-server/
//#define TEST_COLUMN_TYPES_BY_SP
//#define TEST_COLUMN_TYPES
//#define TEST_TRANSACTION
//#define TEST_NUMERIC // min -79228162514264.337593543950335 max 79228162514264.337593543950335 !!!
//#define TEST_SP_EXECUTESQL
//#define TEST_PARAMETERIZED_STATEMENTS
//#define TEST_TIMEOUT
//#define TEST_MARS
//#define TEST_CONNECTION_STRING
//#define TEST_CONNECTION_STATE
//#define INCLUDE_SQL_EXCEPTION
//#define TEST_SCALAR
//#define TEST_USING
//#define TEST_SQL_PARAMETER
//#define TEST_STORED_PROCEDURE
//#define TEST_QUERY
//#define TEST_PARAMETERS
//#define TEST_RAISERROR
//#define TEST_XML_PARAMETERS
//#define TEST_XML
//#define TEST_TABLE_VALUED_PARAMETERS
//#define TEST_TABLE_VALUED_PARAMETERS_IN_SELECT_STATEMENT // http://msdn.microsoft.com/en-us/library/bb675163%28v=vs.110%29.aspx
//#define GET_STORED_PROCEDURE_PARAMETERS
//#define TEST_BLOB
//#define TEST_BLOB_SAVE
//#define TEST_BLOB_SAVE_BY_SP
//#define TEST_BLOB_LOAD_BY_SP
//#define TEST_STORED_PROCEDURE_PARAMETERS
//#define TEST_FUNCTION

using System;
using System.Configuration;
using System.Data.SqlTypes;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml;

namespace MSSQLSQL
{
	class Program
	{
		static void Main(string[] args)
		{
			StreamWriter
				fstr_out = null;

			SqlConnection
				conn = null;

		    SqlTransaction
		        transaction = null;

			SqlCommand
				cmd = null,
                cmdII = null;

			SqlDataAdapter
				da = null;

			SqlDataReader
				rdr = null;

		    DataSet
		        tmpDataSet = null;

			DataTable
				tmpDataTable = null,
				tmpDataTableII = null;

			DataColumn
				tmpDataColumn = null;

			DataRow
				tmpDataRow = null;

			object
				tmpObject;

			int
				tmpInt;

		    long
		        tmpLong;

            DateTime
                tmpDateTime;

			string
				tmpString="log.log",
				fieldName;

		    StringBuilder
		        sb = null;

            SqlParameter
                sqlParameter = null;

		    string
		        tmpFieldName = null;


		    byte[]
		        tmpBytes = null;

		    decimal
		        tmpDecimal;

		    DateTimeOffset
		        dateTimeOffset,
		        dateTimeOffset2;

			try
			{
				try
				{
					fstr_out = new StreamWriter(tmpString, false, Encoding.UTF8);
					fstr_out.AutoFlush = true;

				    string
				        //ConnectionString = string.Empty;
                        //ConnectionString = "Server=ore-report-test.cloudapp.net,56550;Database=ReportServer;User ID=oredba;Password=ORE2015!";
				        //ConnectionString = "Server=air\\inst5;Database=SunEdge_Default;User ID=sa;Password=password";
                        //ConnectionString = "Server=test-robot-6.systtech.ru;Database=region_16_weekly_AUTOTEST-VM3_192.168.2.43;User ID=sa;Password=123456";
                        //ConnectionString = "Server=.;Database=ch;User ID=sa;Password=123";
                        //ConnectionString = "Server=.;Database=ch;User ID=sa;Password=123;Timeout=300";
                        //ConnectionString = "Server=.;Database=ch;User ID=sa;Password=123;ConnectTimeout=300";
                        //ConnectionString = "Server=.;Database=ch;User ID=sa;Password=123;Connection Timeout=300";
                        //ConnectionString = "Server=.;Database=ch;User ID=test_login;Password=12==3";
                        //ConnectionString = "Server=.;Database=testdb;User ID=test_login;Password=123";
                        //ConnectionString = "Server=.;Database=testdbtestdb;User ID=test_login;Password=123";
                        //ConnectionString = "Server=.;Database=testdb;User ID=sa;Password=123";
						ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=testdb;Integrated Security=True";
						//ConnectionString = "server=alpha_web;Initial Catalog=pretensions;User Id=sa;Pwd=developer";
						//ConnectionString = "server=alpha_web;Initial Catalog=pretensionsav;User Id=sa;Pwd=developer";
						//ConnectionString = "server=fobos_web;Initial Catalog=CMS_Connect;User Id=sa;Pwd=developer";
						//ConnectionString = "server=10.135.197.86,2057;Database=CMS_Connect;User ID=sa;Password=developer";
                        //ConnectionString = "Server=(localdb)\\v11.0;Integrated Security=true;AttachDbFileName=C:\\Users\\i.nozhenko.STU\\ABC.BloggingContext.mdf;";
                        //ConnectionString = "Server=np:\\\\.\\pipe\\LOCALDB#6ADD4424\\tsql\\query;Integrated Security=true;AttachDbFileName=C:\\Users\\i.nozhenko.STU\\ABC.BloggingContext.mdf;";

                    #if TEST_MARS
				        ConnectionString += ";MultipleActiveResultSets=True";
                    #endif

                    #if TEST_USING
                        using (SqlConnection c = new SqlConnection(ConnectionString))
                        {
                            c.Open();
                            cmd = c.CreateCommand();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "select @@servername";
                            if((tmpObject = cmd.ExecuteScalar()) != null && !Convert.IsDBNull(tmpObject))
                                Console.WriteLine("select @@servername = \"{0}\"", Convert.ToString(tmpObject));
                        }
                    #endif

                    #if TEST_SQL_PARAMETER
                        sqlParameter = new SqlParameter("ParamName", 1);
                        Console.WriteLine("DbType: {0}, Value: {1}, typeof(Value): {2}, SqlValue: {3}", sqlParameter.DbType, sqlParameter.Value, sqlParameter.Value.GetType(), sqlParameter.SqlValue);
                        sqlParameter = new SqlParameter("ParamName", "1");
                        Console.WriteLine("DbType: {0}, Value: {1}, typeof(Value): {2}, SqlValue: {3}", sqlParameter.DbType, sqlParameter.Value, sqlParameter.Value.GetType(), sqlParameter.SqlValue);
                        if (!DateTime.TryParse(sqlParameter.Value.ToString(), out tmpDateTime))
                        {
                            sqlParameter.Value = DBNull.Value;
                            if (sqlParameter.Value == DBNull.Value)
                                sqlParameter.Value = DateTime.Now;
                        }
                        sqlParameter = new SqlParameter("ParamName", DateTime.Now);
                        Console.WriteLine("DbType: {0}, Value: {1}, typeof(Value): {2}, SqlValue: {3}", sqlParameter.DbType, sqlParameter.Value, sqlParameter.Value.GetType(), sqlParameter.SqlValue);

                        sqlParameter = new SqlParameter
                                           {
                                               DbType = DbType.Boolean,
                                               Value = "False"
                                           };
                        Console.WriteLine("DbType: {0}, Value: {1}, typeof(Value): {2}, SqlValue: {3}", sqlParameter.DbType, sqlParameter.Value, sqlParameter.Value.GetType(), sqlParameter.SqlValue);
                    #endif

                    #if TEST_QUERY
                        sb = new StringBuilder();

                        using (SqlConnection _conn_ = new SqlConnection(ConnectionString))
                        {
                            _conn_.Open();

                            using (SqlCommand _cmd_ = new SqlCommand(string.Format("select id from {0} where dep=@dep", "Staff"), _conn_))
                            {
                                //_cmd_.Parameters.AddWithValue("@dep", 1);
                                _cmd_.Parameters.Add("@dep", SqlDbType.Int).SqlValue = 1;

                                using (SqlDataReader _rdr_ = _cmd_.ExecuteReader())
                                {
                                    while (_rdr_.Read())
                                        sb.Append(string.Format(",{0}", _rdr_.GetSqlInt64(0)));
                                }
                            }
                        }

				        tmpString = sb.ToString().Substring(1);
                    #endif

                    #if TEST_CONNECTION_STRING
				        const string connectionStringKey = "connectionString";

                        if (ConfigurationManager.ConnectionStrings.OfType<ConnectionStringSettings>().Any(cs => cs.Name == connectionStringKey))
                            ConnectionString = ConfigurationManager.ConnectionStrings[connectionStringKey].ConnectionString;
                    #endif

					conn = new SqlConnection(ConnectionString);

                    #if TEST_CONNECTION_STATE
                        conn.StateChange += ConnStateChange;
                    #endif

					conn.Open();

                    #if TEST_DATA_ADAPTER
                        if (tmpDataTable == null)
							tmpDataTable = new DataTable("Victim");
						else
							tmpDataTable.Reset();

						tmpDataColumn = tmpDataTable.Columns.Add("id", typeof(long)); 
						tmpDataColumn.AllowDBNull = false;
						tmpDataColumn.Unique = true;
						tmpDataColumn.AutoIncrement = true;
						tmpDataColumn.AutoIncrementSeed = -1;
						tmpDataColumn.AutoIncrementStep = -1;
						tmpDataTable.Columns.Add("f_int", typeof(int));
                        tmpDataTable.Columns.Add("f_bit", typeof(bool));

                        tmpDataRow = tmpDataTable.NewRow();
						tmpDataRow["id"] = 1;
						tmpDataRow["f_int"] = 1;
                        tmpDataRow["f_bit"] = true;
                        tmpDataTable.Rows.Add(tmpDataRow);

                        if (da == null)
                            da = new SqlDataAdapter();

                        /*var tblMap = da.TableMappings.Add("Victim", "Victim");
                        tblMap.ColumnMappings.Add("id", "id");
                        tblMap.ColumnMappings.Add("f_int", "f_int");
                        tblMap.ColumnMappings.Add("f_bit", "f_bit");*/

                        da.SelectCommand = conn.CreateCommand();
                        da.SelectCommand.CommandType = CommandType.Text;
                        da.SelectCommand.CommandText = "select id, f_int, f_bit from victim";

                        /*var cb = new SqlCommandBuilder(da);

                        da.InsertCommand = cb.GetInsertCommand(true);
                        da.UpdateCommand = cb.GetUpdateCommand(true);
                        da.DeleteCommand = cb.GetDeleteCommand(true);*/

                        
                        da.InsertCommand = conn.CreateCommand();
                        da.InsertCommand.CommandType = CommandType.Text;
                        da.InsertCommand.CommandText = "insert into victim (f_int, f_bit) values (@f_int, @f_bit)";
                        da.InsertCommand.Parameters.Add("@f_int", SqlDbType.Int);
                        da.InsertCommand.Parameters.Add("@f_bit", SqlDbType.Bit);

                        da.UpdateCommand = conn.CreateCommand();
                        da.UpdateCommand.CommandType = CommandType.Text;
                        da.UpdateCommand.CommandText = "update victim set f_int = @f_int, f_bit = @f_bit where id = @id";
                        da.UpdateCommand.Parameters.Add("@f_int", SqlDbType.Int);
                        da.UpdateCommand.Parameters.Add("@f_bit", SqlDbType.Bit);
                        da.UpdateCommand.Parameters.Add("@id", SqlDbType.BigInt);

                        da.DeleteCommand = conn.CreateCommand();
                        da.DeleteCommand.CommandType = CommandType.Text;
                        da.DeleteCommand.CommandText = "delete from victim where id = @id";
                        da.DeleteCommand.Parameters.Add("@id", SqlDbType.BigInt);
                        

                        da.Update(tmpDataTable);
                    #endif

                    #if TEST_BATCH
                        if (cmd == null)
							cmd = conn.CreateCommand();

						cmd.CommandType = CommandType.Text;
				        cmd.CommandText = @"
begin transaction;
insert into dbo.TestMasterX (Val) values (@ValX);
insert into dbo.TestMasterY (Val) values (@ValY);
commit transaction;
";
						cmd.Parameters.Clear();
                        cmd.Parameters.Add("@ValX", SqlDbType.NVarChar).Value = "101";
                        cmd.Parameters.Add("@ValY", SqlDbType.NVarChar).Value = "201";

                        tmpInt = cmd.ExecuteNonQuery();
                    #endif

                    #if TEST_DATE_TYPES
                        if (cmd == null)
							cmd = conn.CreateCommand();

						cmd.CommandType = CommandType.Text;
						cmd.Parameters.Clear();
						cmd.Parameters.Add("@Id", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@FDate", SqlDbType.Date).Value = new DateTime(2017, 1, 5, 21, 13, 13, 456);
                        cmd.Parameters.Add("@FDateTime", SqlDbType.DateTime).Value = new DateTime(2017, 1, 5, 21, 13, 13, 456);
                        cmd.Parameters.Add("@FDateTime2", SqlDbType.DateTime2).Value = new DateTime(2017, 1, 5, 21, 13, 13, 456);
                        cmd.Parameters.Add("@FSmallDateTime", SqlDbType.SmallDateTime).Value = new DateTime(2017, 1, 5, 21, 13, 13, 456);
                        cmd.Parameters.Add("@FTime", SqlDbType.Time).Value = new TimeSpan(0, 21, 13, 13, 456);
                        cmd.Parameters.Add("@FTime0", SqlDbType.Time).Value = new TimeSpan(0, 21, 13, 13, 456);
                        cmd.Parameters.Add("@FTime1", SqlDbType.Time).Value = new TimeSpan(0, 21, 13, 13, 456);
                        cmd.Parameters.Add("@FTime2", SqlDbType.Time).Value = new TimeSpan(0, 21, 13, 13, 456);
                        cmd.Parameters.Add("@FTime3", SqlDbType.Time).Value = new TimeSpan(0, 21, 13, 13, 456);
                        cmd.Parameters.Add("@FTime4", SqlDbType.Time).Value = new TimeSpan(0, 21, 13, 13, 456);
                        cmd.Parameters.Add("@FTime5", SqlDbType.Time).Value = new TimeSpan(0, 21, 13, 13, 456);
                        cmd.Parameters.Add("@FTime6", SqlDbType.Time).Value = new TimeSpan(0, 21, 13, 13, 456);
                        cmd.Parameters.Add("@FTime7", SqlDbType.Time).Value = new TimeSpan(0, 21, 13, 13, 456);
                        cmd.Parameters.Add("@FDateTimeOffset", SqlDbType.DateTimeOffset).Value = new DateTimeOffset(2017, 3, 26, 2, 13, 13, 456, new TimeSpan(0, 120, 0));
                        cmd.Parameters.Add("@FDateTimeOffset0", SqlDbType.DateTimeOffset).Value = new DateTimeOffset(2017, 1, 5, 21, 13, 13, 456, new TimeSpan(0, 120, 0));
                        cmd.Parameters.Add("@FDateTimeOffset1", SqlDbType.DateTimeOffset).Value = new DateTimeOffset(2017, 1, 5, 21, 13, 13, 456, new TimeSpan(0, 120, 0));
                        cmd.Parameters.Add("@FDateTimeOffset2", SqlDbType.DateTimeOffset).Value = new DateTimeOffset(2017, 1, 5, 21, 13, 13, 456, new TimeSpan(0, 120, 0));
                        cmd.Parameters.Add("@FDateTimeOffset3", SqlDbType.DateTimeOffset).Value = new DateTimeOffset(2017, 1, 5, 21, 13, 13, 456, new TimeSpan(0, 120, 0));
                        cmd.Parameters.Add("@FDateTimeOffset4", SqlDbType.DateTimeOffset).Value = new DateTimeOffset(2017, 1, 5, 21, 13, 13, 456, new TimeSpan(0, 120, 0));
                        cmd.Parameters.Add("@FDateTimeOffset5", SqlDbType.DateTimeOffset).Value = new DateTimeOffset(2017, 1, 5, 21, 13, 13, 456, new TimeSpan(0, 120, 0));
                        cmd.Parameters.Add("@FDateTimeOffset6", SqlDbType.DateTimeOffset).Value = new DateTimeOffset(2017, 1, 5, 21, 13, 13, 456, new TimeSpan(0, 120, 0));
                        cmd.Parameters.Add("@FDateTimeOffset7", SqlDbType.DateTimeOffset).Value = new DateTimeOffset(2017, 3, 26, 1, 13, 13, 456, new TimeSpan(0, 60, 0));
                        cmd.CommandText = "update TestTable4Date set FDate = @FDate, FDateTime = @FDateTime, FDateTime2 = @FDateTime2, FSmallDateTime = @FSmallDateTime, FTime = @FTime, FTime0 = @FTime0, FTime1 = @FTime1, FTime2 = @FTime2, FTime3 = @FTime3, FTime4 = @FTime4, FTime5 = @FTime5, FTime6 = @FTime6, FTime7 = @FTime7, FDateTimeOffset = @FDateTimeOffset, FDateTimeOffset0 = @FDateTimeOffset0, FDateTimeOffset1 = @FDateTimeOffset1, FDateTimeOffset2 = @FDateTimeOffset2, FDateTimeOffset3 = @FDateTimeOffset3, FDateTimeOffset4 = @FDateTimeOffset4, FDateTimeOffset5 = @FDateTimeOffset5, FDateTimeOffset6 = @FDateTimeOffset6, FDateTimeOffset7 = @FDateTimeOffset7 where Id = @Id";
						tmpObject = cmd.ExecuteScalar();

						cmd.Parameters.Clear();
						cmd.Parameters.Add("@Id", SqlDbType.Int).Value = 1;
                        cmd.CommandText = "select FDateTimeOffset from TestTable4Date where Id = @Id";
                        tmpObject = cmd.ExecuteScalar();
                        dateTimeOffset = tmpObject != null && !Convert.IsDBNull(tmpObject) ? (DateTimeOffset)tmpObject : new DateTimeOffset();

                        cmd.CommandText = "select FDateTimeOffset7 from TestTable4Date where Id = @Id";
                        tmpObject = cmd.ExecuteScalar();
                        dateTimeOffset2 = tmpObject != null && !Convert.IsDBNull(tmpObject) ? (DateTimeOffset)tmpObject : new DateTimeOffset();

                        Console.WriteLine($"dateTimeOffset {(dateTimeOffset == dateTimeOffset2 ? "=" : "!")}= dateTimeOffset2"); // ==
				        Console.WriteLine($"dateTimeOffset.Equals(dateTimeOffset2) = {dateTimeOffset.Equals(dateTimeOffset2)}"); // True
                        Console.WriteLine($"dateTimeOffset.EqualsExact(dateTimeOffset2) = {dateTimeOffset.EqualsExact(dateTimeOffset2)}"); // False
                    #endif

                    #if ANY_TEST
   				        const long UpdateInterval = 10000L;

                        if (cmd == null)
                            cmd = conn.CreateCommand();
                        else
                            cmd.Parameters.Clear();

                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = string.Format("select idDistr, LastID + {0} as LastID, cast({1} as bigint) as Cnt from chgetid where idRoute = 0", UpdateInterval, UpdateInterval);

                        if (da == null)
                            da = new SqlDataAdapter();
                        da.SelectCommand = cmd;

                        if (tmpDataTable == null)
                            tmpDataTable = new DataTable();
                        else
                            tmpDataTable.Reset();

                        da.Fill(tmpDataTable);
                    #endif

                    #if Determining_SET_Options_for_Current_Session
                        if (cmd == null)
                            cmd = conn.CreateCommand();
                        else
                            cmd.Parameters.Clear();

                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select @@options";
                        tmpObject = cmd.ExecuteScalar();
                        if (tmpObject != null && !Convert.IsDBNull(tmpObject))
                        {
                            var options = Convert.ToInt32(tmpObject);

                            Console.WriteLine("disable_def_cnst_chk {0}", (options & 1) != 0 ? "on" : "off");
                            Console.WriteLine("implicit_transactions {0}", (options & 2) != 0 ? "on" : "off");
                            Console.WriteLine("cursor_close_on_commit {0}", (options & 4) != 0 ? "on" : "off");
                            Console.WriteLine("ansi_warnings {0}", (options & 8) != 0 ? "on" : "off");
                            Console.WriteLine("ansi_padding {0}", (options & 16) != 0 ? "on" : "off");
                            Console.WriteLine("ansi_nulls {0}", (options & 32) != 0 ? "on" : "off");
                            Console.WriteLine("arithabort {0}", (options & 64) != 0 ? "on" : "off");
                            Console.WriteLine("arithignore {0}", (options & 128) != 0 ? "on" : "off");
                            Console.WriteLine("quoted_identifier {0}", (options & 256) != 0 ? "on" : "off");
                            Console.WriteLine("nocount {0}", (options & 512) != 0 ? "on" : "off");
                            Console.WriteLine("ansi_null_dflt_on {0}", (options & 1024) != 0 ? "on" : "off");
                            Console.WriteLine("ansi_null_dflt_off {0}", (options & 2048) != 0 ? "on" : "off");
                            Console.WriteLine("concat_null_yields_null {0}", (options & 4096) != 0 ? "on" : "off");
                            Console.WriteLine("numeric_roundabort {0}", (options & 8192) != 0 ? "on" : "off");
                            Console.WriteLine("xact_abort {0}", (options & 16384) != 0 ? "on" : "off");
                        }

				        var optionsList = new[] {"quoted_identifier", "arithabort", "numeric_roundabort", "ansi_warnings", "ansi_padding", "ansi_nulls", "concat_null_yields_null", "cursor_close_on_commit", "implicit_transactions", "language", "dateformat", "date_format", "datefirst", "date_first", "transaction isolation level" };
				        foreach (var option in optionsList)
				        {
                            cmd.CommandText = $"select sessionproperty(N'{option}')";
                            tmpObject = cmd.ExecuteScalar();
                            if (tmpObject != null && !Convert.IsDBNull(tmpObject))
                                Console.WriteLine("{0} {1}", option, tmpObject);
                        }

                        cmd.CommandText = "select * from sys.dm_exec_sessions where session_id = @@spid";
                        if (da == null)
                            da = new SqlDataAdapter();
                        da.SelectCommand = cmd;

                        if (tmpDataTable == null)
                            tmpDataTable = new DataTable();
                        else
                            tmpDataTable.Reset();

                        da.Fill(tmpDataTable);
				        foreach (DataRow row in tmpDataTable.Rows)
				            foreach (var option in optionsList)
                                if (tmpDataTable.Columns.Contains(option))
                                    Console.WriteLine("{0} {1}", option, !row.IsNull(option) ? row[option] : "null");
                    #endif

                    #if TEST_COLUMN_TYPES_BY_SP
                        if (cmd == null)
                            cmd = conn.CreateCommand();
                        else
                            cmd.Parameters.Clear();

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "rspQBGetProject";
                        SqlCommandBuilder.DeriveParameters(cmd);

				        cmd.Parameters["@Project_ID"].Value = 4850;

                        rdr = cmd.ExecuteReader();

                        do
                        {
                            if (rdr.HasRows)
                            {
                                for (var i = 0; i < rdr.FieldCount; ++i)
                                    fstr_out.WriteLine("Name: \"{0}\" DataTypeName: \"{1}\" FieldType: \"{2}\" ProviderSpecificFieldType: \"{3}\"", rdr.GetName(i), rdr.GetDataTypeName(i), rdr.GetFieldType(i), rdr.GetProviderSpecificFieldType(i));
                            }
                        } while (rdr.NextResult());
                        rdr.Close();
                    #endif

                    #if TEST_COLUMN_TYPES
                        if (cmd == null)
                            cmd = conn.CreateCommand();
                        else
                            cmd.Parameters.Clear();

                        cmd.CommandType = CommandType.Text;
                        //cmd.CommandText = "select * from sys.columns";
                        //cmd.CommandText = "select Dealer_Roofer_Name from [QUICKBASE].[QA_ORE_Project_Tracking]..[ORE_Project_Tracking__Projects_bkfnh9dk2] where Project_ID_ = 4850";
                        //cmd.CommandText = "select top 1 * from [QUICKBASE].[QA_ORE_Project_Tracking]..[ORE_Project_Tracking__Projects_bkfnh9dk2]";
						//cmd.CommandText = "select * from refObjects";
						cmd.CommandText = "select * from TestMaster";

                        rdr = cmd.ExecuteReader();

                        do
                        {
                            if (rdr.HasRows)
                            {
                                for (var i = 0; i < rdr.FieldCount; ++i)
                                    fstr_out.WriteLine("Name: \"{0}\" DataTypeName: \"{1}\" FieldType: \"{2}\" ProviderSpecificFieldType: \"{3}\"", rdr.GetName(i), rdr.GetDataTypeName(i), rdr.GetFieldType(i), rdr.GetProviderSpecificFieldType(i));
                            }
                        } while (rdr.NextResult());
                        rdr.Close();
                    #endif

                    #if TEST_TRANSACTION
                        if (cmd == null)
                            cmd = conn.CreateCommand();
                        else
                            cmd.Parameters.Clear();

                        if (cmdII == null)
                            cmdII = conn.CreateCommand();
                        else
                            cmdII.Parameters.Clear();

                        cmd.CommandType = CommandType.Text;
				        cmd.CommandText = @"update Table4TestTransaction set value = @value where id = @id";
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 2;
				        tmpDateTime = DateTime.Now;
                        cmd.Parameters.Add("@value", SqlDbType.NVarChar).Value = string.Format("update {0}:{1}:{2}.{3}", tmpDateTime.Hour, tmpDateTime.Minute, tmpDateTime.Second, tmpDateTime.Millisecond);

                        cmdII.CommandType = CommandType.StoredProcedure;
				        cmdII.CommandText = "TestProcedureWTransaction";

                        SqlCommandBuilder.DeriveParameters(cmdII);
                        if (cmdII.Parameters[tmpString = "@spid"].Direction != ParameterDirection.Output)
                            cmdII.Parameters[tmpString].Direction = ParameterDirection.Output;
                        if (cmdII.Parameters[tmpString = "@trancount"].Direction != ParameterDirection.Output)
                            cmdII.Parameters[tmpString].Direction = ParameterDirection.Output;

				        cmdII.Parameters["@id"].Value = 7;
				        cmdII.Parameters["@value"].Value = cmd.Parameters["@value"].Value;
				        cmdII.Parameters["@beginTransaction"].Value = true;
                        cmdII.Parameters["@rollbackTransaction"].Value = true;
                        cmdII.Parameters["@raiserrorAfter"].Value = true;

                        try
                        {
                            cmd.Transaction = cmdII.Transaction = transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            tmpInt = cmd.ExecuteNonQuery();
                            tmpInt = cmdII.ExecuteNonQuery();

                            transaction.Commit();
                        }
                        catch (SqlException eException)
                        {
                            Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                        }

                        if (cmdII.Parameters[tmpString = "@spid"].Value != null && !Convert.IsDBNull(cmdII.Parameters[tmpString].Value))
                            tmpInt = Convert.ToInt32(cmdII.Parameters[tmpString].Value);
                        if (cmdII.Parameters[tmpString = "@trancount"].Value != null && !Convert.IsDBNull(cmdII.Parameters[tmpString].Value))
                            tmpInt = Convert.ToInt32(cmdII.Parameters[tmpString].Value);
                    #endif

                    #if TEST_NUMERIC
				        tmpString = "FNumeric_30_15";

                        if (cmd == null)
                            cmd = conn.CreateCommand();
                        else
                            cmd.Parameters.Clear();

                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select * from TestTable4Types";

                        rdr = cmd.ExecuteReader();

                        do
                        {
                            if (rdr.HasRows)
                            {
                                tmpInt = rdr.GetOrdinal(tmpString);

                                while (rdr.Read())
                                {
                                    tmpDecimal = !rdr.IsDBNull(tmpInt) ? rdr.GetDecimal(tmpInt) : default(decimal);
                                }
                            }
                        } while (rdr.NextResult());
                        rdr.Close();

                        if (da == null)
                            da = new SqlDataAdapter();
                        da.SelectCommand = cmd;

                        if (tmpDataTable == null)
                            tmpDataTable = new DataTable();
                        else
                            tmpDataTable.Reset();

                        da.Fill(tmpDataTable);
                        if (tmpDataTable.Rows.Count > 0 && !tmpDataTable.Rows[0].IsNull(tmpString))
                            tmpDecimal = Convert.ToDecimal(tmpDataTable.Rows[0][tmpString]);
                    #endif

                    #if TEST_SP_EXECUTESQL
                        if (cmd == null)
                            cmd = conn.CreateCommand();
                        else
                            cmd.Parameters.Clear();

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_executesql";

                        //SqlCommandBuilder.DeriveParameters(cmd);

                        cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                        cmd.Parameters.Add("@stmt", SqlDbType.NVarChar).Value = "select @aout = id from Staff where (name = @name)";
                        cmd.Parameters.Add("@params", SqlDbType.NVarChar).Value = "@aout bigint output, @name nvarchar(255)";
                        cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = "Вашингтон Джордж";
                        cmd.Parameters.Add("@aout", SqlDbType.BigInt).Direction = ParameterDirection.Output;

				        cmd.ExecuteNonQuery();

                        if (!Convert.IsDBNull(cmd.Parameters["@RETURN_VALUE"].Value))
                            tmpInt = Convert.ToInt32(cmd.Parameters["@RETURN_VALUE"].Value);
				        if (!Convert.IsDBNull(cmd.Parameters["@aout"].Value))
                            tmpLong = Convert.ToInt64(cmd.Parameters["@aout"].Value);

                        if (cmd == null)
                            cmd = conn.CreateCommand();
                        else
                            cmd.Parameters.Clear();

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_executesql";

                        cmd.Parameters.Add("@stmt", SqlDbType.NVarChar).Value = @"select N0.id,N0.idDistr,N1.ObjectType,N0.TableName,N0.outercode,N0.idItem,N0.ObjectType,N0.Hash from (dbo.refOutercodes N0 with (nolock)
 left join dbo.refDistributors N1 with (nolock) on (N0.idDistr = N1.id))
where (N0.idItem in (@p0) and (N0.TableName = @p1))";
				        cmd.Parameters.Add("@params", SqlDbType.NVarChar).Value = "@p0 bigint,@p1 nvarchar(4000)";
                        cmd.Parameters.Add("p0", SqlDbType.BigInt).Value = 562954272099413;
                        cmd.Parameters.Add("p1", SqlDbType.NVarChar).Value = "DocJournal";

                        if (da == null)
                            da = new SqlDataAdapter();
                        da.SelectCommand = cmd;

                        if (tmpDataTable == null)
                            tmpDataTable = new DataTable();
                        else
                            tmpDataTable.Reset();

                        da.Fill(tmpDataTable);
                        tmpInt = tmpDataTable.Rows.Count;
                    #endif

                    #if TEST_PARAMETERIZED_STATEMENTS
                        if (cmd == null)
                            cmd = conn.CreateCommand();
                        else
                            cmd.Parameters.Clear();

                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = @"select N0.id,N0.idDistr,N1.ObjectType,N0.TableName,N0.outercode,N0.idItem,N0.ObjectType,N0.Hash from (dbo.refOutercodes N0 with (nolock)
 left join dbo.refDistributors N1 with (nolock) on (N0.idDistr = N1.id))
where (N0.idItem in (@p0) and (N0.TableName = @p1))";

                        cmd.Parameters.Add("p0", SqlDbType.BigInt).Value = 562954272099413;
                        cmd.Parameters.Add("p1", SqlDbType.NVarChar).Value = "DocJournal";

                        if (da == null)
                            da = new SqlDataAdapter();
                        da.SelectCommand = cmd;

                        if (tmpDataTable == null)
                            tmpDataTable = new DataTable();
                        else
                            tmpDataTable.Reset();

                        da.Fill(tmpDataTable);
                        tmpInt = tmpDataTable.Rows.Count;
                    #endif

                    #if TEST_TIMEOUT
                        try
                        { 
                            if (cmd == null)
                                cmd = conn.CreateCommand();

                            cmd.CommandType = CommandType.Text;

                            cmd.CommandText = "select @@spid";
                            tmpObject = cmd.ExecuteScalar();

                            cmd.CommandText = "select Value from TestTable4ReadLock where Value = 100";
                            tmpObject = cmd.ExecuteScalar();
                        }
                        catch(Exception eException)
                        {
                            Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                        }
                    #endif

                    #if TEST_MARS
                        if (cmd == null)
                            cmd = conn.CreateCommand();

                        cmd.CommandType = CommandType.Text;
				        cmd.CommandText = "select val from TestMARSForRead";

                        if (cmdII == null)
                            cmdII = conn.CreateCommand();

                        cmdII.CommandType = CommandType.Text;
                        cmdII.CommandText = "insert into TestMARSForWrite (val) values (@val)";
                        cmdII.Parameters.Add("@val", SqlDbType.Int);

                        rdr = cmd.ExecuteReader();

                        do
                        {
                            if (rdr.HasRows)
                            {
                                tmpInt = rdr.GetOrdinal("val");

                                while (rdr.Read())
                                {
                                    cmdII.Parameters["@val"].Value = rdr.GetInt32(tmpInt);
                                    cmdII.ExecuteNonQuery();
                                }
                            }
                        } while (rdr.NextResult());
                        rdr.Close();
                    #endif

                    #if TEST_CONNECTION_STRING
                        if (cmd == null)
                            cmd = conn.CreateCommand();

                        cmd.CommandType = CommandType.Text;
				        cmd.CommandText = "select system_user";

                        tmpObject = cmd.ExecuteScalar();

                        if(tmpObject != null && !Convert.IsDBNull(tmpObject))
                            tmpString = Convert.ToString(tmpObject);
                    #endif

                    #if TEST_SCALAR
                        if (cmd == null)
                            cmd = conn.CreateCommand();

                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = @"
select
    ID
from
    dbo.TestTable4Types t
where
    cast(t.FDateTime as date) = @d
    and datepart(hour, t.FDateTime) = @h
    and datepart(minute, t.FDateTime) = @m
";

				        cmd.Parameters.Add("@d", SqlDbType.Date).Value = DateTime.Now; //new DateTime(2014, 6, 12);
                        cmd.Parameters.Add("@h", SqlDbType.Int).Value = 11;
                        cmd.Parameters.Add("@m", SqlDbType.Int).Value = 2;

                        tmpObject = cmd.ExecuteScalar();

                        if(tmpObject != null && !Convert.IsDBNull(tmpObject))
                            tmpLong = Convert.ToInt64(tmpObject);
                    #endif

                    #if TEST_TABLE_VALUED_PARAMETERS_IN_SELECT_STATEMENT
/*
create type dbo.IdsTableType as table (id bigint not null primary key)
*/
                    if (tmpDataTableII == null)
                            tmpDataTableII = new DataTable();
                        else
                            tmpDataTableII.Reset();

                        tmpDataTableII.Columns.Add("id", typeof(long));

                        tmpDataRow = tmpDataTableII.NewRow();
                        tmpDataRow["id"] = 1;
                        tmpDataTableII.Rows.Add(tmpDataRow);

                        tmpDataRow = tmpDataTableII.NewRow();
                        tmpDataRow["id"] = 2;
                        tmpDataTableII.Rows.Add(tmpDataRow);

                        tmpDataRow = tmpDataTableII.NewRow();
                        tmpDataRow["id"] = 3;
                        tmpDataTableII.Rows.Add(tmpDataRow);

                        if (cmd == null)
                            cmd = conn.CreateCommand();

                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = @"
select
    *
from
    dbo.Staff staff
    join @ids ids on ids.id=staff.ID 
";

                        //sqlParameter = new SqlParameter("@ids", SqlDbType.Structured);
				        //cmd.Parameters.Add(sqlParameter);
                        //cmd.Parameters["@ids"].TypeName = "dbo.IdsTableType";
                        //cmd.Parameters["@ids"].Value = tmpDataTableII;

                        cmd.Parameters.AddWithValue("@ids", tmpDataTableII);
                        //cmd.Parameters["@ids"].SqlDbType = SqlDbType.Structured;
                        cmd.Parameters["@ids"].TypeName = "dbo.IdsTableType";

                        if (da == null)
                            da = new SqlDataAdapter();
                        da.SelectCommand = cmd;

                        if (tmpDataTable == null)
                            tmpDataTable = new DataTable();
                        else
                            tmpDataTable.Reset();

                        da.Fill(tmpDataTable);
                        tmpInt = tmpDataTable.Rows.Count;
                    #endif

                    #if TEST_STORED_PROCEDURE
                        if (cmd == null)
                            cmd = conn.CreateCommand();

                        cmd.CommandType=CommandType.StoredProcedure;
                        cmd.CommandText = "export_xls_routes_for_import";
                        SqlCommandBuilder.DeriveParameters(cmd);
                        cmd.Parameters["@selectedItemsIds"].Value = "562954254558294;562954255228976";
                        if(da==null)
                            da=new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        if(tmpDataSet==null)
                            tmpDataSet=new DataSet();
                        da.Fill(tmpDataSet);
                    #endif

					#if TEST_PARAMETERS
						if (cmd == null)
							cmd = conn.CreateCommand();

						cmd.CommandType = CommandType.Text;
						cmd.Parameters.Clear();
						cmd.Parameters.Add("@Id", SqlDbType.BigInt).Value = 3;
						cmd.CommandText = "select Id from TestTable4Types where Id=@Id";
						tmpObject = cmd.ExecuteScalar();
					#endif

					#if TEST_RAISERROR
						using (SqlConnection _conn_ = new SqlConnection(ConnectionString))
						{
							_conn_.Open();

							SqlCommand
								_cmd_ = _conn_.CreateCommand();

							_cmd_.CommandType = CommandType.StoredProcedure;
							_cmd_.CommandText = "TestProcedureWRaiserror";
							SqlCommandBuilder.DeriveParameters(_cmd_);
							if (_cmd_.Parameters["@output_param"].Direction != ParameterDirection.Output)
								_cmd_.Parameters["@output_param"].Direction = ParameterDirection.Output;
							_cmd_.Parameters["@input_param"].Value = 13;

							_cmd_.ExecuteNonQuery();
						}
					#endif

					#if TEST_XML_PARAMETERS
						XmlDocument
							doc = new XmlDocument();

						XmlNode
							node = doc.CreateXmlDeclaration("1.0", null, null),
							RootNode;

						doc.AppendChild(node);
						RootNode = doc.CreateElement("root");
						doc.AppendChild(RootNode);

						node = doc.CreateElement("item");
						node.AppendChild(doc.CreateTextNode("1"));
						RootNode.AppendChild(node);

						node = doc.CreateElement("item");
						node.AppendChild(doc.CreateTextNode("2"));
						RootNode.AppendChild(node);

						if (cmd == null)
							cmd = conn.CreateCommand();

						cmd.CommandType = CommandType.StoredProcedure;
						cmd.CommandText = "TestProcedureWithXmlTypeParameter";
						SqlCommandBuilder.DeriveParameters(cmd);
						cmd.Parameters["@StaffIds"].Value = doc.InnerXml;
						// equ
						// cmd.Parameters["@Staff"].SqlValue = tmpDataTableII;

						if (da == null)
							da = new SqlDataAdapter();
						da.SelectCommand = cmd;

						if (tmpDataTable == null)
							tmpDataTable = new DataTable();
						else
							tmpDataTable.Reset();

						da.Fill(tmpDataTable);
						tmpInt = tmpDataTable.Rows.Count;
					#endif

                    #if TEST_XML
                        if (cmd == null)
                            cmd = conn.CreateCommand();

                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select * from TestTable4Types where Id=@Id";
                        cmd.Parameters.Add("@Id", SqlDbType.BigInt).Value = 1;

                        rdr = cmd.ExecuteReader();

                        do
                        {
                            if (rdr.HasRows)
                            {
                                for (int i = 0; i < rdr.FieldCount; ++i)
                                    fstr_out.WriteLine(rdr.GetName(i) + " GetDataTypeName(): \"" + rdr.GetDataTypeName(i) + "\" GetFieldType(): \"" + rdr.GetFieldType(i) + "\"");

                                tmpInt = rdr.GetOrdinal("FXml");

                                // System.Data.SqlTypes.SqlXml
                                fstr_out.WriteLine(rdr.GetProviderSpecificFieldType(tmpInt));

                                while (rdr.Read())
                                {
                                    // System.Data.SqlTypes.SqlString
                                    tmpObject = rdr.GetProviderSpecificValue(tmpInt);
                                    fstr_out.WriteLine(tmpObject.GetType());

                                    if (!rdr.IsDBNull(tmpInt))
                                    {
                                        // http://msdn.microsoft.com/en-us/library/ms971534.aspx
                                        SqlXml sx = rdr.GetSqlXml(tmpInt);
                                        using (XmlReader xr = sx.CreateReader())
                                        {
                                            xr.MoveToContent();

                                            while (xr.Read())
                                            {
                                                if (xr.NodeType == XmlNodeType.Element)
                                                {
                                                    string elementLocalName = xr.LocalName;
                                                    xr.Read();
                                                    Console.WriteLine(elementLocalName + ": " + xr.Value);
                                                }
                                            }

                                            //xr.Read();
                                            //fstr_out.WriteLine(xr.ReadOuterXml());
                                        }
                                    }
                                }
                            }
                        } while (rdr.NextResult());
                        rdr.Close();

                        if (da == null)
                            da = new SqlDataAdapter();
                        da.SelectCommand = cmd;

                        if (tmpDataTable == null)
                            tmpDataTable = new DataTable();
                        else
                            tmpDataTable.Reset();

                        da.Fill(tmpDataTable);

                        if(tmpDataTable.Rows.Count > 0 && !tmpDataTable.Rows[0].IsNull(tmpFieldName="FXml"))
                        {
                            XmlDocument
                                doc = new XmlDocument();

                            doc.LoadXml(tmpDataTable.Rows[0][tmpFieldName].ToString());

                            foreach (XmlNode node in doc.SelectNodes("//item"))
                                Console.WriteLine("<{0} id=\"{2}\">{1}</{0}>", node.Name, node.InnerText, node.Attributes["id"].Value);
                        }
                    #endif

					#if TEST_TABLE_VALUED_PARAMETERS
						if (tmpDataTableII == null)
							tmpDataTableII = new DataTable();
						else
							tmpDataTableII.Reset();

						tmpDataColumn = tmpDataTableII.Columns.Add("Id", typeof(long)); 
						tmpDataColumn.AllowDBNull = false;
						tmpDataColumn.Unique = true;
						tmpDataColumn.AutoIncrement = true;
						tmpDataColumn.AutoIncrementSeed = -1;
						tmpDataColumn.AutoIncrementStep = -1;
						tmpDataTableII.Columns.Add("Name", typeof(string));

						tmpDataRow = tmpDataTableII.NewRow();
						tmpDataRow["Id"] = 1;
						tmpDataRow["Name"] = DBNull.Value;
						tmpDataTableII.Rows.Add(tmpDataRow);

						tmpDataRow = tmpDataTableII.NewRow();
						tmpDataRow["Id"] = 2;
						tmpDataRow["Name"] = DBNull.Value;
						tmpDataTableII.Rows.Add(tmpDataRow);

						if (cmd == null)
							cmd = conn.CreateCommand();

						cmd.CommandType = CommandType.StoredProcedure;
						cmd.CommandText = "TestProcedureWithTypeTableStaff";
						SqlCommandBuilder.DeriveParameters(cmd);

                        // Prevent SqlException "The incoming tabular data stream (TDS) remote procedure call (RPC) protocol stream is incorrect. Table-valued parameter 1 (\"@Staff\"), row 0, column 0: Data type 0xF3 (user-defined table type) has a non-zero length database name specified.  Database name is not allowed with a table-valued parameter, only schema name and type name are valid."
                        // http://www.codeitive.com/0QHgWegPkU/unable-to-access-table-variable-in-stored-procedure.html
                        if ((tmpInt = cmd.Parameters["@Staff"].TypeName.LastIndexOf('.')) != -1)
							cmd.Parameters["@Staff"].TypeName = cmd.Parameters["@Staff"].TypeName.Substring(tmpInt + 1);

						cmd.Parameters["@Staff"].Value = tmpDataTableII;
						// equ
						//cmd.Parameters["@Staff"].SqlValue = tmpDataTableII;

						if (da == null)
							da = new SqlDataAdapter();
						da.SelectCommand = cmd;

						if (tmpDataTable == null)
							tmpDataTable = new DataTable();
						else
							tmpDataTable.Reset();

						da.Fill(tmpDataTable);
						tmpInt = tmpDataTable.Rows.Count;
					#endif

					#if GET_STORED_PROCEDURE_PARAMETERS
						if (cmd == null)
							cmd = conn.CreateCommand();

						cmd.CommandType = CommandType.StoredProcedure;
				        cmd.CommandText = "SaveToTestTable4Date"; //"TestProcedureWParameters";
						SqlCommandBuilder.DeriveParameters(cmd);
						Console.WriteLine(cmd.CommandText);
						for (int ii = 0; ii < cmd.Parameters.Count; ++ii)
							Console.WriteLine("ParameterName: " + cmd.Parameters[ii].ParameterName + " SqlDbType: " + cmd.Parameters[ii].SqlDbType.ToString() + " Direction: " + cmd.Parameters[ii].Direction.ToString());
					#endif

					#if TEST_BLOB
						if (cmd == null)
							cmd = conn.CreateCommand();

						cmd.CommandType = CommandType.Text;

						FileStream
							fs;

						byte[]
							Blob;

						#if TEST_BLOB_SAVE
							cmd.CommandText="insert into TableWithImgSrc (Img) values (@Img)";
							cmd.Parameters.Clear();
							cmd.Parameters.Add("@Img",SqlDbType.Image);
							fs = new FileStream("xpfirewall.bmp", FileMode.Open, FileAccess.Read);
							Blob=new byte[fs.Length];
							fs.Read(Blob,0,Blob.Length);
							cmd.Parameters["@Img"].Value=Blob;
							tmpInt=cmd.ExecuteNonQuery();
						#endif

						#if TEST_BLOB_SAVE_BY_SP
							cmd.CommandType = CommandType.StoredProcedure;
							cmd.CommandText = "TableWithImgDestSave";
							SqlCommandBuilder.DeriveParameters(cmd);
							fs = new FileStream("xpfirewall.bmp", FileMode.Open, FileAccess.Read);
							Blob=new byte[fs.Length];
							fs.Read(Blob,0,Blob.Length);
							cmd.Parameters["@Id"].Value = 2;
							cmd.Parameters["@Img"].Value=Blob;
							tmpInt=cmd.ExecuteNonQuery();
							cmd.CommandType = CommandType.Text;
						#endif

                        #if !TEST_BLOB_LOAD_BY_SP
						    cmd.CommandType = CommandType.Text;
						    cmd.CommandText = "select * from TableWithImgDest";
                            //cmd.CommandText = "select ImageBody as Img from [current_weekly_AUTOTEST-VM2_192.168.2.42].dbo.refGoods where FullName = N'Goods_Copying_MixCO'";
						    cmd.Parameters.Clear();
                        #else
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "TableWithImgDestLoad";
                            SqlCommandBuilder.DeriveParameters(cmd);
                            cmd.Parameters["@Id"].Value = 1;
                        #endif
						rdr = cmd.ExecuteReader();

						do
						{
							if (rdr.HasRows)
							{
								for (int i = 0; i < rdr.FieldCount; ++i)
									fstr_out.WriteLine(rdr.GetName(i) + " GetDataTypeName(): \"" + rdr.GetDataTypeName(i) + "\" GetFieldType(): \"" + rdr.GetFieldType(i) + "\"");

								tmpInt = rdr.GetOrdinal("Img");

								while (rdr.Read())
								{
									tmpString = "FromBlob.bmp";
									if (File.Exists(tmpString))
										File.Delete(tmpString);

									Blob = (byte[])rdr["Img"];
									fs = new FileStream(tmpString, FileMode.Create);
									fs.Write(Blob, 0, Blob.Length);
									fs.Close();

									tmpString = "FromBlob_1.bmp";
									if (File.Exists(tmpString))
										File.Delete(tmpString);

									Blob = new byte[rdr.GetBytes(tmpInt, 0, null, 0, int.MaxValue)];
									rdr.GetBytes(tmpInt, 0, Blob, 0, Blob.Length);
									fs = new FileStream(tmpString, FileMode.Create);
									fs.Write(Blob, 0, Blob.Length);
									fs.Close();
								}
							}
						} while (rdr.NextResult());
						rdr.Close();
					#endif

					#if TEST_STORED_PROCEDURE_PARAMETERS
						if (cmd == null)
							cmd = conn.CreateCommand();

						cmd.CommandType = CommandType.StoredProcedure;
						cmd.CommandText = "TestProcedureWParameters";
						cmd.Parameters.Add(new SqlParameter("ThisParameterWillBeDeleted", SqlDbType.BigInt)).Value = 1;

						SqlCommandBuilder.DeriveParameters(cmd);
						cmd.Parameters["@input_param"].Value = 1;
						//if (cmd.Parameters[tmpString = "@output_param"].Direction != ParameterDirection.Output)
						//	cmd.Parameters[tmpString].Direction = ParameterDirection.Output;
						cmd.Parameters["@output_param"].Value = DBNull.Value;
						cmd.ExecuteNonQuery();
					#endif

					#if TEST_FUNCTION
						if (cmd == null)
							cmd = conn.CreateCommand();

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "TestFunctionReturnTable";
                        SqlCommandBuilder.DeriveParameters(cmd);
				        cmd.ExecuteNonQuery();

						cmd.CommandType = CommandType.StoredProcedure;
						cmd.CommandText = "TestFunctionReturnOnly";
						SqlCommandBuilder.DeriveParameters(cmd);

						cmd.Parameters["@a"].Value = 2;
						cmd.Parameters["@b"].Value = 3;
						cmd.ExecuteNonQuery();
						Console.WriteLine("cmd.Parameters[\"@RETURN_VALUE\"].Value=" + cmd.Parameters["@RETURN_VALUE"].Value);

						cmd.Parameters["@a"].Value = 3;
						cmd.Parameters["@b"].Value = 4;
						tmpObject = cmd.ExecuteScalar();
						Console.WriteLine("cmd.ExecuteScalar()" + (tmpObject != null ? "!" : "=") + "=null");
						Console.WriteLine("cmd.Parameters[\"@RETURN_VALUE\"].Value="+cmd.Parameters["@RETURN_VALUE"].Value);
					#endif
				}
                #if INCLUDE_SQL_EXCEPTION
                catch (SqlException eException)
                {
                    Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                    Console.WriteLine("ErrorCode={0} Class={1} Number={2} State={3} Server=\"{4}\"", eException.ErrorCode, eException.Class, eException.Number, eException.State, eException.Server);
                    // ErrorCode=-2146232060 Class=20 Number=53     State=0 Server="" - invalid server
                    // ErrorCode=-2146232060 Class=14 Number=18456  State=1 Server="server_name" Message "Login failed for user 's_a'." - invalid login
                    // ErrorCode=-2146232060 Class=14 Number=18456  State=1 Server="server_name" Message "Login failed for user 'sa'." - invalid password
                    // ErrorCode=-2146232060 Class=11 Number=4060   State=1 Server="server_name" Message "Cannot open database \"chicago_2_11_\" requested by the login. The login failed.\r\nLogin failed for user 'sa'."
                    // ErrorCode=-2146232060 Class=11 Number=4060   State=1 Server="server_name" Message "Cannot open database \"testdbtestdb\" requested by the login. The login failed.\r\nLogin failed for user 'test_login'." (Orphaned Users)
                }
                #endif
				catch (Exception eException)
				{
                    Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
				}
			}
			finally
			{
				if (rdr != null && !rdr.IsClosed)
					rdr.Close();

				if (conn != null && conn.State == ConnectionState. Open)
					conn.Close();

                //conn.Open();

				if (fstr_out != null)
					fstr_out.Close();
			}
		}
        #if TEST_CONNECTION_STATE
            static void ConnStateChange(object sender, StateChangeEventArgs e)
            {
                SqlConnection conn;

                if ((conn = sender as SqlConnection) == null)
                    return;

                System.Diagnostics.Debug.WriteLine(string.Format("{0} -> {1}", e.OriginalState, e.CurrentState));
            }
        #endif
	}
}
