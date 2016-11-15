//#define TEST_BLOB
//#define TEST_DB_BY_ODBC

using System;
using System.Data;
#if TEST_DB_BY_ODBC
	using System.Data.Odbc;
#endif
using System.Data.OleDb;
using System.IO;

namespace TestParadoxDB
{
	class TestParadoxDB
	{
		[STAThread]
		static int Main(string[] args)
		{
			int
				Result=-1;

			StreamWriter
				fstr_out=null;

			string
				tmpString="log.log",
				TableName;

			#if TEST_DB_BY_ODBC
				OdbcConnection
					odbc_conn=null;

				OdbcCommand
					odbc_cmd=null;

				OdbcDataReader
					odbc_rdr=null;

				OdbcDataAdapter
					odbc_da=null;
			#endif

			OleDbConnection
				conn=null;

			OleDbCommand
				cmd=null;

			OleDbDataReader
				rdr=null;

			OleDbDataAdapter
				da=null;

			DataTable
				tmpDataTable;

			int
				tmpInt;

			object[]
				tmpObjects;

			FileStream
				fs;

			byte[]
				Blob;

			try
			{
				try
				{
					fstr_out=new StreamWriter(tmpString,false,System.Text.Encoding.GetEncoding(1251));
					fstr_out.AutoFlush=true;

					string
						PathToDb="E:\\Soft.src\\CBuilder\\Tests\\Paradox\\Test.#1\\db",
						CommonDbTableName="Common",
						CommonDbTableSQLCreate=@"
create table "+CommonDbTableName+@"(
FInt integer,
FChar char(254)
)";

					#if TEST_DB_BY_ODBC
						if(!PathToDb.EndsWith(Path.DirectorySeparatorChar.ToString()))
							PathToDb+=Path.DirectorySeparatorChar;

						tmpString="Driver={Microsoft Paradox Driver (*.db )};DriverID=538;Fil=Paradox 5.X;DefaultDir="+PathToDb+";Dbq="+PathToDb+";CollatingSequence=ASCII";
						odbc_conn=new OdbcConnection(tmpString);
						odbc_conn.Open();
						fstr_out.WriteLine("ConnectionString: "+odbc_conn.ConnectionString);
						fstr_out.WriteLine("ConnectionTimeout: "+odbc_conn.ConnectionTimeout.ToString());
						fstr_out.WriteLine("Database: "+odbc_conn.Database);
						fstr_out.WriteLine("DataSource: "+odbc_conn.DataSource);
						fstr_out.WriteLine("Driver: "+odbc_conn.Driver);
						fstr_out.WriteLine("ServerVersion: "+odbc_conn.ServerVersion);
						fstr_out.WriteLine("State: "+odbc_conn.State.ToString());
						fstr_out.WriteLine();

						tmpString=PathToDb+CommonDbTableName+".db";
						if(File.Exists(tmpString))
							File.Delete(tmpString);

						odbc_cmd=odbc_conn.CreateCommand();
						odbc_cmd.CommandType=CommandType.Text;
						odbc_cmd.CommandText=CommonDbTableSQLCreate;
						odbc_cmd.ExecuteNonQuery();

						odbc_cmd.CommandText="insert into "+CommonDbTableName+" values (1,'FChar (Ô×àð)')";
						odbc_cmd.ExecuteNonQuery();

						#if TEST_BLOB
							if(odbc_cmd==null)
								odbc_cmd=odbc_conn.CreateCommand();
							odbc_cmd.CommandType=CommandType.Text;

							odbc_cmd.CommandText="select * from TestTypes";
							odbc_cmd.Parameters.Clear();
							odbc_rdr=odbc_cmd.ExecuteReader();

							do
							{
								if(odbc_rdr.HasRows)
								{
									for(int i=0; i<odbc_rdr.FieldCount; ++i)
										fstr_out.WriteLine(odbc_rdr.GetName(i)+" GetDataTypeName(): \""+odbc_rdr.GetDataTypeName(i)+"\" GetFieldType(): \""+odbc_rdr.GetFieldType(i)+"\"");

									tmpInt=odbc_rdr.GetOrdinal("FGraphic");

									while(odbc_rdr.Read())
									{
										tmpString="FromBlob.bmp";
										if(File.Exists(tmpString))
											File.Delete(tmpString);

										Blob=(byte[])odbc_rdr["FGraphic"];
										fs=new FileStream(tmpString,FileMode.Create);
										fs.Write(Blob,0,Blob.Length);
										fs.Close();

										tmpString="FromBlob_1.bmp";
										if(File.Exists(tmpString))
											File.Delete(tmpString);

										Blob=new byte[odbc_rdr.GetBytes(tmpInt,0,null,0,int.MaxValue)];
										rdr.GetBytes(tmpInt,0,Blob,0,Blob.Length);
										fs=new FileStream(tmpString,FileMode.Create);
										fs.Write(Blob,0,Blob.Length);
										fs.Close();
									}
								}
							}while(rdr.NextResult());
							odbc_rdr.Close();
						#endif

						odbc_conn.Close();
					#endif

					if(PathToDb.EndsWith(Path.DirectorySeparatorChar.ToString()))
						PathToDb=PathToDb.Remove(PathToDb.Length-1,1);

					tmpString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+PathToDb+";Extended Properties=Paradox 5.x";
					conn=new OleDbConnection(tmpString);
					conn.Open();
					fstr_out.WriteLine("ConnectionString: "+conn.ConnectionString);
					fstr_out.WriteLine("ConnectionTimeout: "+conn.ConnectionTimeout.ToString());
					fstr_out.WriteLine("Database: "+conn.Database);
					fstr_out.WriteLine("DataSource: "+conn.DataSource);
					fstr_out.WriteLine("Provider: "+conn.Provider);
					fstr_out.WriteLine("ServerVersion: "+conn.ServerVersion);
					fstr_out.WriteLine("State: "+conn.State.ToString());
					fstr_out.WriteLine();

					tmpString=PathToDb+Path.DirectorySeparatorChar+CommonDbTableName+".db";
					if(File.Exists(tmpString))
						File.Delete(tmpString);

					cmd=conn.CreateCommand();
					cmd.CommandType=CommandType.Text;
					cmd.CommandText=CommonDbTableSQLCreate;
					cmd.ExecuteNonQuery();

					cmd.CommandText="insert into "+CommonDbTableName+" values (1,'FChar (Ô×àð)')";
					cmd.ExecuteNonQuery();

					#if TEST_BLOB
						if(cmd==null)
							cmd=conn.CreateCommand();
						cmd.CommandType=CommandType.Text;

						TableName="TestTypes";
						tmpObjects=new object[]{null, null, TableName, null};
						
						fstr_out.WriteLine("OleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Columns)");
						tmpDataTable=conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns,tmpObjects);
						fstr_out.WriteLine("Columns in "+TableName+" table:");
						foreach(DataRow row in tmpDataTable.Rows)
							fstr_out.WriteLine("\t"+row["TABLE_CATALOG"]+" "+row["TABLE_NAME"]+" "+row["COLUMN_NAME"].ToString()+" "+row["DATA_TYPE"]+" "+row["TABLE_SCHEMA"]);
						fstr_out.WriteLine();

						#if TEST_BLOB_SAVE
							cmd.CommandText="update TestTypes set FGraphic = ?";
							cmd.Parameters.Clear();
							cmd.Parameters.Add("FGraphic",OleDbType.LongVarBinary);
							fs=new FileStream("welcome.bmp",FileMode.Open,FileAccess.Read);
							Blob=new byte[fs.Length];
							fs.Read(Blob,0,Blob.Length);
							cmd.Parameters["FGraphic"].Value=Blob;
							tmpInt=cmd.ExecuteNonQuery();
						#endif

						cmd.CommandText="select * from TestTypes";
						cmd.Parameters.Clear();
						rdr=cmd.ExecuteReader();

						do
						{
							if(rdr.HasRows)
							{
								for(int i=0; i<rdr.FieldCount; ++i)
									fstr_out.WriteLine(rdr.GetName(i)+" GetDataTypeName(): \""+rdr.GetDataTypeName(i)+"\" GetFieldType(): \""+rdr.GetFieldType(i)+"\"");

								tmpInt=rdr.GetOrdinal("FGraphic");

								while(rdr.Read())
								{
									tmpString="FromBlob.bmp";
									if(File.Exists(tmpString))
										File.Delete(tmpString);

									Blob=(byte[])rdr["FGraphic"];
									fs=new FileStream(tmpString,FileMode.Create);
									fs.Write(Blob,0,Blob.Length);
									fs.Close();

									tmpString="FromBlob_1.bmp";
									if(File.Exists(tmpString))
										File.Delete(tmpString);

									Blob=new byte[rdr.GetBytes(tmpInt,0,null,0,int.MaxValue)];
									rdr.GetBytes(tmpInt,0,Blob,0,Blob.Length);
									fs=new FileStream(tmpString,FileMode.Create);
									fs.Write(Blob,0,Blob.Length);
									fs.Close();
								}
							}
						}while(rdr.NextResult());
						rdr.Close();
					#endif

					Result=0;
				}
				catch(Exception eException)
				{
					Console.WriteLine(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace);
				} 			
			}
			finally
			{
				#if TEST_DB_BY_ODBC
					if(odbc_rdr!=null && !odbc_rdr.IsClosed)
						odbc_rdr.Close();

					if(odbc_conn!=null && odbc_conn.State==System.Data.ConnectionState.Open)
						odbc_conn.Close();
				#endif

				if(rdr!=null && !rdr.IsClosed)
					rdr.Close();

				if(conn!=null && conn.State==System.Data.ConnectionState.Open)
					conn.Close();

				if(fstr_out!=null)
					fstr_out.Close();
			}

			return(Result);
		}
	}
}
