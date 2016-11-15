#define TEST_SELECTED_STORED_PROCEDURE
//#define TEST_DBMS_OUTPUT

using System;
using System.Data;
using System.IO;
using Oracle.DataAccess.Client;

namespace Oracle.ODAC
{
	class Program
	{
		static void Main(string[] args)
		{
			StreamWriter
				fstr_out = null; 

			OracleConnection
				conn = null;

			OracleCommand
				cmd = null;

			OracleDataAdapter
				da = null;

			DataTable
				tmpDataTable = null;

			string
				FieldName;

			try
			{
				try
				{
					fstr_out = new StreamWriter("log.log", false, System.Text.Encoding.GetEncoding(1251));
					fstr_out.AutoFlush = true;

					string
						ConnectionString = "User ID=aspnetuser;Password=aspnet;Data Source=SM";

					conn = new OracleConnection(ConnectionString);

					#if TEST_DBMS_OUTPUT
						conn.StateChange += new StateChangeEventHandler(conn_StateChange);
						conn.InfoMessage += new OracleInfoMessageEventHandler(conn_InfoMessage);
					#endif
					
					conn.Open();

					#if TEST_SELECTED_STORED_PROCEDURE
						if (cmd == null)
							cmd = conn.CreateCommand();

						cmd.CommandType = CommandType.StoredProcedure;
						cmd.CommandText = "StoredProcedureForPaging";
						OracleCommandBuilder.DeriveParameters(cmd);
						cmd.Parameters["start_in"].Value = 2;
						cmd.Parameters["limit_in"].Value = 2;
						if (da == null)
							da = new OracleDataAdapter();
						da.SelectCommand = cmd;
						if (tmpDataTable == null)
							tmpDataTable = new DataTable();
						else
							tmpDataTable.Reset();
						da.Fill(tmpDataTable);

						FieldName="id";
						foreach(DataRow r in tmpDataTable.Rows)
						{
							Console.WriteLine(!r.IsNull(FieldName) ? Convert.ToInt32(r[FieldName]).ToString() : "null");
						}
					#endif

					#if TEST_DBMS_OUTPUT
						if (cmd == null)
							cmd = conn.CreateCommand();

						cmd.CommandType = CommandType.StoredProcedure;
						cmd.CommandText = "TestProcedureWithDBMSOutput";
						OracleCommandBuilder.DeriveParameters(cmd);
						cmd.ExecuteNonQuery();
					#endif
				}
				catch (Exception eException)
				{
					Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
				}
			}
			finally
			{/*
				if (rdr != null && !rdr.IsClosed)
					rdr.Close();*/

				if (conn != null && conn.State == ConnectionState.Open)
					conn.Close();

				if (fstr_out != null)
					fstr_out.Close();
			}
		}

		#if TEST_DBMS_OUTPUT
			static void conn_StateChange(object sender, StateChangeEventArgs e)
			{
				Console.WriteLine("StateChange event occurred (sender: " + sender.ToString() + ")");
				Console.WriteLine("\tFrom (OriginalState): " + e.OriginalState.ToString() + "\n\tTo (CurrentState): " + e.CurrentState.ToString());
			}

			static void conn_InfoMessage(object sender, OracleInfoMessageEventArgs e)
			{
				Console.WriteLine("InfoMessage event occurred (sender: " + sender.ToString() + ")");
				Console.WriteLine("\tMessage resceived: " + e.Message);
			}
		#endif

	}
}
