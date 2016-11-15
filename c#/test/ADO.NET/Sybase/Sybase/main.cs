#define TEST_GET_SCHEMA_TABLE
//#define TEST_AUTO_INCREMENT
//#define TEST_CONNECTION_TRANSACTION
//#define TEST_DATA_ADAPTER
//#define TEST_PARAM
//#define WITHOUT_CONNECTION_POOL

using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace Test
{
    class TestAdoNetClass
    {
        public static int Main(string[] args)
        {
            int
                Result = -1;

            StreamWriter
                fstr_out = null;

            string
                SQLText,
                OutputFileName = "log.log",
                strConn;

            OleDbConnection
                cn = null;

        	OleDbCommand
        		cmd = null;

        	OleDbTransaction
        		Transaction = null;

            OleDbDataReader
                rdr = null;

        	OleDbDataAdapter
        		da = null;

            DataSet
                ds = null;

        	DataTable
        		tmpDataTable = null;

        	DataColumn
        		tmpDataColumn = null;

            DataRow
                tmpDataRow = null;

            object
                tmpObject = null;

            int
                tmpInt;

            try
            {
                try
                {
                    fstr_out = new StreamWriter(OutputFileName, false, System.Text.Encoding.GetEncoding(1251));
                    fstr_out.AutoFlush = true;

                    fstr_out.WriteLine("Environment.SystemDirectory: " + Environment.SystemDirectory);
                    fstr_out.WriteLine("Environment.CurrentDirectory: " + Environment.CurrentDirectory);
                    fstr_out.WriteLine("System.IO.Directory.GetCurrentDirectory(): " + Directory.GetCurrentDirectory());
                    fstr_out.WriteLine("Environment.MachineName: " + Environment.MachineName);
                    fstr_out.WriteLine("Environment.OSVerison: " + Environment.OSVersion);
                    fstr_out.WriteLine("Environment.UserName: " + Environment.UserName);
                    fstr_out.WriteLine("Environment.UserDomainName: " + Environment.UserDomainName);
                    fstr_out.WriteLine("Environment.Version: " + Environment.Version);
                    fstr_out.WriteLine("Environment.WorkingSet: " + Environment.WorkingSet);
                    fstr_out.WriteLine();

                    ConnectionStringSettingsCollection
                        connectionStrings = ConfigurationManager.ConnectionStrings;

                    if (connectionStrings!=null)
                    {
                        System.Text.StringBuilder
                            sb = new System.Text.StringBuilder();

                        SQLText = "Section Name: ";
                        foreach (ConnectionStringSettings s in connectionStrings)
                        {
                            sb.Append(SQLText + s.Name + Environment.NewLine);
                            sb.Append(new string('-',SQLText.Length+s.Name.Length)+Environment.NewLine);
                            sb.Append("Provider Name: " + s.ProviderName + Environment.NewLine);
                            sb.Append("Full Connection String: "+s.ConnectionString+Environment.NewLine);
                            fstr_out.WriteLine(sb);
                        }
                    }
                    fstr_out.WriteLine();

                    SQLText = "SybaseASEServer";
                    strConn = "Provider=" + connectionStrings[SQLText].ProviderName + ";" + connectionStrings[SQLText].ConnectionString;
                    // ||
                    //ConnectionStringSettings
                    //  connectionString = ConfigurationManager.ConnectionStrings[SQLText];
                    //
                    //strConn = "Provider=" + connectionString.ProviderName + ";" + connectionString.ConnectionString;
                    					
                    #if WITHOUT_CONNECTION_POOL
						strConn+=";OLE DB Services=-4"; // strConn+=";Pooling=False" // 4 SqlConnection
                    #endif

					#if TEST_CONNECTION_TRANSACTION
						cn=new OleDbConnection(strConn);
                		cmd = cn.CreateCommand();

						OleDbCommand
							cmd2 = cn.CreateCommand();
										
						cn.Open();

                		cmd.CommandType = CommandType.Text;
                		cmd.CommandText = "select @@spid";
                		tmpObject = cmd.ExecuteScalar();

						cmd2.CommandType = CommandType.Text;
						cmd2.CommandText = "select @@spid";
						tmpObject = cmd2.ExecuteScalar();

                		cmd.Transaction = cn.BeginTransaction(IsolationLevel.ReadCommitted);
						tmpObject = cmd.ExecuteScalar();
						cmd2.Transaction = cn.BeginTransaction(IsolationLevel.ReadCommitted); // InvalidOperationException: "OleDbConnection does not support parallel transactions."
						tmpObject = cmd2.ExecuteScalar(); // InvalidOperationException: "ExecuteScalar requires the command to have a transaction when the connection assigned to the command is in a pending local transaction.  The Transaction property of the command has not been initialized."

						tmpObject = cmd.ExecuteScalar();
						tmpObject = cmd2.ExecuteScalar();
					#endif

                    cn = new OleDbConnection(strConn);
                    // ||
                    //cn=new OleDbConnection();
                    //cn.ConnectionString=strConn;

                    cn.InfoMessage += new OleDbInfoMessageEventHandler(cn_InfoMessage);
                    cn.StateChange += new StateChangeEventHandler(cn_StateChange);

                    cn.Open();
                    fstr_out.WriteLine("ConnectionString: " + cn.ConnectionString);
                    fstr_out.WriteLine("ConnectionTimeout: " + cn.ConnectionTimeout.ToString());
                    fstr_out.WriteLine("Database: " + cn.Database);
                    fstr_out.WriteLine("DataSource: " + cn.DataSource);
                    fstr_out.WriteLine("Provider: " + cn.Provider);
                    fstr_out.WriteLine("ServerVersion: " + cn.ServerVersion);
                    fstr_out.WriteLine("State: " + cn.State.ToString());
                    fstr_out.WriteLine();

                	cmd = cn.CreateCommand();
                	cmd.CommandType = CommandType.StoredProcedure;
                	cmd.CommandText = "mathtutor";
					OleDbCommandBuilder.DeriveParameters(cmd);
                	cmd.Parameters["mult1"].Value = 5;
                	cmd.Parameters["mult2"].Value = 6;
                	tmpInt=cmd.ExecuteNonQuery();

					#if TEST_GET_SCHEMA_TABLE
						if (cmd == null)
							cmd = cn.CreateCommand();

                		cmd.CommandType = CommandType.Text;
                		cmd.CommandText = "select * from TestTypes";
                		rdr = cmd.ExecuteReader();
                		tmpDataTable = rdr.GetSchemaTable();
                		foreach (DataRow r in tmpDataTable.Rows)
                		{
                			fstr_out.WriteLine(r["ColumnName"]+" "+r["DataType"]+" "+r["ProviderType"]);
                		}
						rdr.Close();
					#endif

					#if TEST_AUTO_INCREMENT
						if (tmpDataTable != null)
							tmpDataTable.Reset();
						else
							tmpDataTable = new DataTable();

						tmpDataColumn = tmpDataTable.Columns.Add("Id", typeof(int));
						tmpDataColumn.AllowDBNull = false;
						tmpDataColumn.Unique = true;
						tmpDataColumn.AutoIncrement = true;
						tmpDataColumn.AutoIncrementSeed = 1;
						tmpDataColumn.AutoIncrementStep = 1;
						tmpDataTable.PrimaryKey = new DataColumn[] { tmpDataTable.Columns["Id"] };

						if (da == null)
							da = new OleDbDataAdapter("{call sp_Select_NULL}", cn);

						da.Fill(tmpDataTable);

						tmpDataTable.Clear();
						da.SelectCommand.CommandText = "{call sp_Select_NULL(?)}";
						da.SelectCommand.Parameters.Add("IsSelectNull", OleDbType.Boolean).Value = true;
						da.Fill(tmpDataTable);

						da = null;
						tmpDataTable.Reset();
						tmpDataTable = null;
					#endif

					#if TEST_PARAM
						OleDbParameter
							Parameter=new OleDbParameter();

                		Parameter.ParameterName = "TestParameter";
                		Parameter.DbType = DbType.Int32;
						Parameter.DbType = DbType.DateTime;
						Parameter.DbType = DbType.Date;
						Parameter.DbType = DbType.Time;
					#endif

					#if TEST_DATA_ADAPTER
                		cmd.Transaction = cn.BeginTransaction(IsolationLevel.ReadCommitted);
						if(da==null)
							da=new OleDbDataAdapter();
                		cmd.CommandType = CommandType.Text;
                		cmd.CommandText = "select * from Staff";
                		da.SelectCommand = cmd;
						if(tmpDataTable==null)
							tmpDataTable=new DataTable();
						else 
							tmpDataTable.Reset();
                		da.Fill(tmpDataTable);
						cmd.Transaction.Rollback();
                		cmd.Transaction = null;
					#endif

                    Result = 0; 
                }
                catch (IOException eException) // 4 FileStream
                {
                    Console.WriteLine(eException.Message);
                }
                catch (OleDbException eException)
                {
                    Console.WriteLine("ErrorCode=" + eException.ErrorCode.ToString() + "\nMessage: " + eException.Message + "\nSource: " + eException.Source + "\nStackTrace: " + eException.StackTrace + "\nTargetSite: " + eException.TargetSite);
                }
                catch (InvalidCastException eException) // 4 OleDbDataReader.Get...
                {
                    Console.WriteLine("InvalidCastException: \"" + eException.Message + "\"");
                }
                catch (IndexOutOfRangeException eException) // 4 OleDbDataReader.GetOrdinal
                {
                    Console.WriteLine(eException.Message);
                }
                catch (OutOfMemoryException eException) // 4 new
                {
                    Console.WriteLine(eException.Message);
                }
                catch (OverflowException eException)
                {
                    Console.WriteLine(eException.Message);
                }
				catch (InvalidOperationException eException)
				{
					Console.WriteLine(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message);
				}
                catch (Exception eException)
                {
                    Console.WriteLine(eException.Message);
                }
            }
            finally
            {
                if (rdr != null && !rdr.IsClosed)
                    rdr.Close();

                if (cn != null && cn.State == System.Data.ConnectionState.Open)
                    cn.Close();

                if (fstr_out != null)
                    fstr_out.Close();
            }

            return (Result);
        }

        static void cn_InfoMessage(object sender, OleDbInfoMessageEventArgs e)
        {
            Console.WriteLine("InfoMessage event occurred (sender: " + sender.ToString() + ")");
            Console.WriteLine("\tMessage received: " + e.Message);
        }

        static void cn_StateChange(object sender, StateChangeEventArgs e)
        {
            Console.WriteLine("StateChange event occurred (sender: " + sender.ToString() + ")");
            Console.WriteLine("\tFrom (OriginalState): " + e.OriginalState.ToString() + "\n\tTo (CurrentState): " + e.CurrentState.ToString());
        }
    }
}
