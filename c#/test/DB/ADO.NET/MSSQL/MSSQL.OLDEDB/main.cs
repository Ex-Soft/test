#define TEST_PARAMETERIZED_STATEMENTS
#define TEST_TYPES

using System;
using System.Data;
using System.Data.OleDb;

namespace MSSQLOLDEDB
{
	class Program
	{
		static void Main(string[] args)
		{
			OleDbConnection
				conn = null;

			OleDbCommand
				cmd = null;

            OleDbDataReader
                rdr = null;

			OleDbDataAdapter
				da = null;

			DataTable
				tmpDataTable = null;

		    string
		        tmpString;

		    int
		        tmpInt;

			try
			{
				string
                    //ConnectionString = "Provider=sqloledb;Server=.;Initial Catalog=testdb;User Id=sa;Password=123";
                    ConnectionString = "Provider=SQLNCLI11;Server=.;Database=testdb;Uid=sa;Pwd=123";
                    //ConnectionString = "Provider=sqloledb;Server=NOZHENKO-S8\\SQLEXPRESS;Database=testdb;Trusted_Connection=yes;";
					//ConnectionString = "Provider=SQLNCLI10;Server=NOZHENKO-S8\\SQLEXPRESS;Database=testdb;Trusted_Connection=yes;";
					//ConnectionString = "Provider=sqloledb;Data Source=fobos_web;Initial Catalog=CMS_Connect;User Id=sa;Password=developer";
					//ConnectionString = "Provider=sqloledb;Data Source=10.135.197.86,2057;Initial Catalog=CMS_Connect;User Id=sa;Password=developer";

				conn = new OleDbConnection(ConnectionString);
				conn.Open();

                #if TEST_PARAMETERIZED_STATEMENTS
                    if (cmd == null)
                        cmd = conn.CreateCommand();
                    else
                        cmd.Parameters.Clear();

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"select id from Staff where name = ?";

			        cmd.Parameters.Add("@name", OleDbType.VarChar).Value = "Вашингтон Джордж";

                    if (da == null)
                        da = new OleDbDataAdapter();
                    da.SelectCommand = cmd;

                    if (tmpDataTable == null)
                        tmpDataTable = new DataTable();
                    else
                        tmpDataTable.Reset();

                    da.Fill(tmpDataTable);
                    tmpInt = tmpDataTable.Rows.Count;
                #endif

                #if TEST_TYPES
                    if (cmd == null)
                        cmd = conn.CreateCommand();
                    else
                        cmd.Parameters.Clear();

				    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select top 10 * from TestTable4Types";

                    rdr = cmd.ExecuteReader();

                    do
                    {
                        if (rdr.HasRows)
                        {
                            tmpInt = rdr.GetOrdinal("FVarChar");

                            while (rdr.Read())
                                tmpString = !rdr.IsDBNull(tmpInt) ? rdr.GetString(tmpInt) : string.Empty;
                        }
                    } while (rdr.NextResult());
                    rdr.Close();

				    if (da == null)
					    da = new OleDbDataAdapter();
                    da.SelectCommand = cmd;

				    if (tmpDataTable == null)
					    tmpDataTable = new DataTable();
				    else
					    tmpDataTable.Reset();

				    da.Fill(tmpDataTable);
                #endif
			}
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
			finally
			{
                if (rdr != null && !rdr.IsClosed)
                    rdr.Close();

				if (conn != null && conn.State == ConnectionState.Open)
					conn.Close();
			}
		}
	}
}