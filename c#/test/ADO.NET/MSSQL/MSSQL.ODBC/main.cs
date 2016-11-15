#define TEST_PARAMETERIZED_STATEMENTS
//#define TEST_COUNT
//#define TEST_STORED_PROCEDURE_PARAMETERS

using System;
using System.Data;
using System.Data.Odbc;

namespace MSSQLODBC
{
	class Program
	{
		static void Main(string[] args)
		{
			OdbcConnection
				conn = null;

			OdbcCommand
				cmd=null;

			OdbcDataAdapter
				da=null;

			DataTable
				tmpDataTable=null;

			string
				tmpString;

			object
				tmpObject;

		    int
		        tmpInt;

			try
			{
				string
                    ConnectionString = "Driver={SQL Server Native Client 11.0};Server=.;Database=testdb;Uid=sa;Pwd=123";
                    //ConnectionString = "Driver={SQL Server Native Client 11.0};Server=.;Database=testdb;Trusted_Connection=yes;";
					//ConnectionString = "Driver={SQL Server Native Client 10.0};Server=NOZHENKO-PC\\SQLEXPRESS; Database=testdb;Trusted_Connection=yes;";
					//ConnectionString = "Driver={SQL Native Client};Server=alpha_web;Port=2057;Database=pretensions;Uid=sa;Pwd=developer";
					//ConnectionString = "Driver={SQL Server};Server=alpha_web;Port=2057;Database=pretensions;Uid=sa;Pwd=developer";
					//ConnectionString = "Driver={SQL Server Native Client 10.0};Server=alpha_web;Port=2057;Database=pretensions;Uid=sa;Pwd=developer";

				conn = new OdbcConnection(ConnectionString);
				conn.Open();

                #if TEST_PARAMETERIZED_STATEMENTS
                    if (cmd == null)
                        cmd = conn.CreateCommand();
                    else
                        cmd.Parameters.Clear();

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"select id from Staff where name = ?";

			        cmd.Parameters.Add("@name", OdbcType.NVarChar).Value = "Вашингтон Джордж";

                    if (da == null)
                        da = new OdbcDataAdapter();
                    da.SelectCommand = cmd;

                    if (tmpDataTable == null)
                        tmpDataTable = new DataTable();
                    else
                        tmpDataTable.Reset();

                    da.Fill(tmpDataTable);
                    tmpInt = tmpDataTable.Rows.Count;
                #endif

                #if TEST_STORED_PROCEDURE_PARAMETERS
					if(cmd==null)
						cmd = conn.CreateCommand();

					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "TestProcedureWParameters";
					OdbcCommandBuilder.DeriveParameters(cmd);
					cmd.Parameters["@input_param"].Value = 1;
					//if (cmd.Parameters[tmpString = "@output_param"].Direction != ParameterDirection.Output)
					//	cmd.Parameters[tmpString].Direction = ParameterDirection.Output;
					//cmd.Parameters["@output_param"].Value = DBNull.Value;
					cmd.ExecuteNonQuery();
                #endif

                #if TEST_COUNT
                    if (cmd == null)
						cmd = conn.CreateCommand();

					cmd.CommandType = CommandType.Text;
					cmd.CommandText = "select count(*) from Staff where (id is null)";
					tmpObject = cmd.ExecuteScalar();
				#endif
			}
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
			finally
			{
				if (conn != null && conn.State == ConnectionState.Open)
					conn.Close();
			}
		}
	}
}
