#define TEST_COMMENT
//#define TEST_BLOB
//#define TEST_BLOB_SAVE
//#define TEST_SMTH
//#define TEST_STORED_PROCEDURES

using System;
using System.Configuration;
using System.Data;
using System.IO;
using FirebirdSql.Data.FirebirdClient;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
			string
				tmpString = string.Empty;

			StreamWriter
				fstr_out = null;

        	FbConnection
        		cn = null;

        	FbCommand
        		cmd = null;

        	FbDataReader
        		rdr = null;

        	FbDataAdapter
        		da = null;

        	DataTable
        		tmpDataTable = null;

			object
				tmpObject;

			int
				tmpInt=int.MinValue;

        	long
        		tmpLong = long.MinValue;

			try
			{
				try
				{
					fstr_out = new StreamWriter("log.log", false, System.Text.Encoding.GetEncoding(1251));
					fstr_out.AutoFlush = true; 

					ConnectionStringSettingsCollection
						connectionStrings = ConfigurationManager.ConnectionStrings;

					if (connectionStrings != null)
					{
						try
						{
							tmpString = connectionStrings["FirebirdServer"].ConnectionString;
						}
						catch
						{
							tmpString = string.Empty;
						}
					}

					cn = new FbConnection(tmpString);
					cn.StateChange += new StateChangeEventHandler(conn_StateChange);
					cn.InfoMessage += new FbInfoMessageEventHandler(conn_InfoMessage);
					cn.Open();
					fstr_out.WriteLine("ConnectionString: " + cn.ConnectionString);
					fstr_out.WriteLine("ConnectionTimeout: " + cn.ConnectionTimeout.ToString());
					fstr_out.WriteLine("Database: " + cn.Database);
					fstr_out.WriteLine("DataSource: " + cn.DataSource);
					fstr_out.WriteLine("PacketSize: " + cn.PacketSize);
					fstr_out.WriteLine("ServerVersion: " + cn.ServerVersion);
					fstr_out.WriteLine("State: " + cn.State.ToString());
					fstr_out.WriteLine();

					#if TEST_COMMENT
						if (cmd == null)
							cmd = cn.CreateCommand();

						cmd.CommandType = CommandType.Text;
						cmd.CommandText = "select 5/**/*3 from rdb$database";
						tmpObject=cmd.ExecuteScalar();
					#endif

					#if TEST_SMTH
						if(cmd==null)
							cmd=cn.CreateCommand();

						cmd.CommandType=CommandType.Text;
						cmd.CommandText="select * from TestDate order by FDate";
						cmd.Parameters.Clear();

						if(da==null)
							da=new FbDataAdapter(cmd);
						else
							da.SelectCommand=cmd;

						if(tmpDataTable!=null)
							tmpDataTable.Reset();
						else
							tmpDataTable = new DataTable();							

						da.Fill(tmpDataTable);

						tmpString="";
						for(int i=0; i<tmpDataTable.Rows.Count; ++i)
						{
							if(tmpString!=string.Empty)
								tmpString+=" ";
							tmpString+=Convert.ToDateTime(tmpDataTable.Rows[i]["FDate"]).ToString("yyyy-MM-dd");
						}
					#endif

					if(tmpDataTable!=null)
						tmpDataTable.Reset();
					else
						tmpDataTable=new DataTable();

					fstr_out.WriteLine("FbConnection.GetSchema()");
					tmpDataTable = cn.GetSchema();
					tmpString = string.Empty;
					foreach (DataColumn col in tmpDataTable.Columns)
					{
						if (tmpString != string.Empty)
							tmpString += "\t";
						tmpString += col.ColumnName;
					}
					fstr_out.WriteLine("\t"+tmpString);

					foreach (DataRow row in tmpDataTable.Rows)
					{
						tmpString = string.Empty;
						foreach (DataColumn col in tmpDataTable.Columns)
						{
							if (tmpString != string.Empty)
								tmpString += "\t";
							tmpString += !row.IsNull(col.ColumnName) ? row[col.ColumnName] : "NULL";
						}
						fstr_out.WriteLine("\t" + tmpString);
					}
					fstr_out.WriteLine();

					cmd = cn.CreateCommand();
					cmd.Transaction = cn.BeginTransaction(new FbTransactionOptions { TransactionBehavior = FbTransactionBehavior.ReadCommitted } /*IsolationLevel.ReadCommitted*/);

					cmd.CommandType = CommandType.Text;
					cmd.CommandText = "select * from \"Staff\"";

					rdr = cmd.ExecuteReader();

					do
					{
						if (rdr.HasRows)
						{
							for (int i = 0; i < rdr.FieldCount; ++i)
								fstr_out.WriteLine(rdr.GetName(i) + " GetDataTypeName(): \"" + rdr.GetDataTypeName(i) + "\" GetFieldType(): \"" + rdr.GetFieldType(i) + "\"");

							while (rdr.Read())
							{
								fstr_out.WriteLine(rdr["Name"]+" "+rdr["Salary"]);
							}
						}
					} while (rdr.NextResult());
					rdr.Close();

					if(tmpDataTable!=null)
						tmpDataTable.Reset();
					else
						tmpDataTable=new DataTable();

					if(da!=null)
						da.SelectCommand = cmd;
					else
						da=new FbDataAdapter(cmd);

					da.Fill(tmpDataTable);

					foreach (DataRow row in tmpDataTable.Rows)
					{
						fstr_out.WriteLine(row["Name"] + " " + row["Salary"]);
					}

					#if TEST_STORED_PROCEDURES
						if (cmd == null)
							cmd = cn.CreateCommand();

						cmd.CommandType = CommandType.StoredProcedure;
						cmd.CommandText = "SP1";
						FbCommandBuilder.DeriveParameters(cmd);
						for (int i = 0; i < cmd.Parameters.Count; ++i)
							fstr_out.WriteLine(cmd.Parameters[i].ParameterName + " " + cmd.Parameters[i].Direction + " " + cmd.Parameters[i].FbDbType + " " + cmd.Parameters[i].DbType);

						cmd.Parameters["@ARGFIRST"].Value = 7;
						cmd.Parameters["@ARGSECOND"].Value = 8;
						cmd.ExecuteNonQuery();
						
						if(!Convert.IsDBNull(cmd.Parameters["@RESULT"].Value))
							fstr_out.WriteLine(cmd.Parameters["@RESULT"].Value);

						cmd.CommandText = "SP1_1";
						FbCommandBuilder.DeriveParameters(cmd);
						cmd.Parameters["@ARGFIRST"].Value = 20;
						cmd.Parameters["@ARGSECOND"].Value = 8;
						cmd.ExecuteNonQuery();

						if (!Convert.IsDBNull(cmd.Parameters["@RESULT"].Value))
							fstr_out.WriteLine(cmd.Parameters["@RESULT"].Value);

						cmd.CommandType = CommandType.Text;
						cmd.CommandText = "select * from SP1_1 (?, ?)";
						cmd.Parameters.Clear();

						FbParameter
							tmpParameter;

						tmpParameter = cmd.CreateParameter();
						tmpParameter.Direction = ParameterDirection.Input;
						tmpParameter.DbType = DbType.Decimal;
						tmpParameter.ParameterName = "@ARGSECOND";
						tmpParameter.Value = 8;
						cmd.Parameters.Add(tmpParameter);

						tmpParameter = cmd.CreateParameter();
						tmpParameter.Direction = ParameterDirection.Input;
						tmpParameter.DbType = DbType.Decimal;
						tmpParameter.ParameterName = "@ARGFIRST";
						tmpParameter.Value = 20;
						cmd.Parameters.Add(tmpParameter);

						if ((tmpObject = cmd.ExecuteScalar()) != null
							&& !Convert.IsDBNull(tmpObject))
							tmpInt = Convert.ToInt32(tmpObject);
						fstr_out.WriteLine(tmpInt);

						if (tmpDataTable != null)
							tmpDataTable.Reset();
						else
							tmpDataTable = new DataTable();

						if (da != null)
							da.SelectCommand = cmd;
						else
							da = new FbDataAdapter(cmd);

						da.Fill(tmpDataTable);
					
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.CommandText = "SP2";
						FbCommandBuilder.DeriveParameters(cmd);
						for (int i = 0; i < cmd.Parameters.Count; ++i)
							fstr_out.WriteLine(cmd.Parameters[i].ParameterName + " " + cmd.Parameters[i].Direction + " " + cmd.Parameters[i].FbDbType + " " + cmd.Parameters[i].DbType);

						cmd.Parameters["@TESTID"].Value = 1;

						if (tmpDataTable != null)
							tmpDataTable.Reset();
						else
							tmpDataTable = new DataTable();

						if (da != null)
							da.SelectCommand = cmd;
						else
							da = new FbDataAdapter(cmd);

						da.Fill(tmpDataTable);

						/*
						cmd.CommandType = CommandType.Text;
						cmd.CommandText = "{call SP2(?, ?)}";
						cmd.Parameters.Clear();

						tmpParameter = cmd.CreateParameter();
						tmpParameter.Direction = ParameterDirection.Input;
						tmpParameter.DbType = DbType.Int32;
						tmpParameter.ParameterName = "@TESTID";
						tmpParameter.Value = 1;
						cmd.Parameters.Add(tmpParameter);
						
						tmpParameter = cmd.CreateParameter();
						tmpParameter.Direction = ParameterDirection.Output;
						tmpParameter.DbType = DbType.String;
						tmpParameter.ParameterName = "@TESTVALUE";
						cmd.Parameters.Add(tmpParameter);
						
						if (tmpDataTable != null)
							tmpDataTable.Reset();
						else
							tmpDataTable = new DataTable();

						if (da != null)
							da.SelectCommand = cmd;
						else
							da = new FbDataAdapter(cmd);

						da.Fill(tmpDataTable);
						*/

						cmd.Parameters.Clear();
						cmd.CommandType = CommandType.Text;
						//cmd.CommandText = "\"Stub\""; //error
						//cmd.CommandText = "exec \"Stub\""; //error
						//cmd.CommandText = "execute \"Stub\""; //error
						cmd.CommandText = "execute procedure \"Stub\"";
						cmd.ExecuteNonQuery();

						//cmd.CommandText = "{call \"Stub\"}"; //error
						//cmd.ExecuteNonQuery();
					#endif

					#if TEST_BLOB
						cmd.CommandType = CommandType.Text;

						FileStream
							fs;

						byte[]
							Blob;

						#if TEST_BLOB_SAVE
							cmd.CommandText = "update \"TestDataTypes\" set \"CBlob\" = @CBlob";
							cmd.Parameters.Clear();
							cmd.Parameters.Add("@CBlob", FbDbType.Binary);
							fs=new FileStream("welcome.bmp",FileMode.Open,FileAccess.Read);
							Blob=new byte[fs.Length];
							fs.Read(Blob,0,Blob.Length);
							cmd.Parameters["@CBlob"].Value=Blob;
							tmpInt=cmd.ExecuteNonQuery();
						#endif

						cmd.CommandText = "select * from \"TestDataTypes\"";
						cmd.Parameters.Clear();
						rdr = cmd.ExecuteReader();

						do
						{
							if (rdr.HasRows)
							{
								for (int i = 0; i < rdr.FieldCount; ++i)
									fstr_out.WriteLine(rdr.GetName(i) + " GetDataTypeName(): \"" + rdr.GetDataTypeName(i) + "\" GetFieldType(): \"" + rdr.GetFieldType(i) + "\"");

								tmpInt = rdr.GetOrdinal("CBlob");

								while (rdr.Read())
								{
									tmpString = "FromBlob.bmp";
									if (File.Exists(tmpString))
										File.Delete(tmpString);

									if (!rdr.IsDBNull(tmpInt))
									{
										Blob = (byte[]) rdr["CBlob"];
										fs = new FileStream(tmpString, FileMode.Create);
										fs.Write(Blob, 0, Blob.Length);
										fs.Close();
									}

									tmpString = "FromBlob_1.bmp";
									if (File.Exists(tmpString))
										File.Delete(tmpString);

									if (!rdr.IsDBNull(tmpInt))
									{
										tmpLong = rdr.GetBytes(tmpInt, 0, null, 0, int.MaxValue);
										Blob = new byte[tmpLong];
										rdr.GetBytes(tmpInt, 0, Blob, 0, Blob.Length);
										fs = new FileStream(tmpString, FileMode.Create);
										fs.Write(Blob, 0, Blob.Length);
										fs.Close();
									}
								}
							}
						} while (rdr.NextResult());
						rdr.Close();
					#endif

					cmd.Transaction.Rollback();
					
					/*
					cn.ChangeDatabase("E:\\USI.Fil\\Base\\NODE.IB6");
					fstr_out.WriteLine(conn.Database);

					cmd.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

					cmd.CommandType = CommandType.Text;
					cmd.CommandText = "select * from \"Filial\"";
					tmpDataTable.Reset();
					da.Fill(tmpDataTable);

					cmd.Transaction.Rollback();
					*/

					cmd = null;

					cn.Close();
				}
				catch (Exception eException)
				{
					Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
				}
			}
			finally
			{

				if(rdr!=null && !rdr.IsClosed)
					rdr.Close();

				if(cmd!=null)
					cmd.Transaction.Rollback();

				if(cn!=null && cn.State == ConnectionState.Open)
					cn.Close();

				if (fstr_out != null)
					fstr_out.Close(); 
			}
        }

		static void conn_StateChange(object sender, StateChangeEventArgs e)
		{
			Console.WriteLine("StateChange event occurred (sender: " + sender.ToString() + ")");
			Console.WriteLine("\tFrom (OriginalState): " + e.OriginalState.ToString() + "\n\tTo (CurrentState): " + e.CurrentState.ToString());
		}

		static void conn_InfoMessage(object sender, FbInfoMessageEventArgs e)
		{
			Console.WriteLine("InfoMessage event occurred (sender: " + sender.ToString() + ")");
			Console.WriteLine("\tMessage received: " + e.Message);
		}
    }
}
