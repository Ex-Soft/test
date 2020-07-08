//#define TEST_TYPES
//#define TEST_PARAMETERS
//#define TEST_EXECUTE_NON_QUERY
//#define TEST_STORED_PROCEDURES_PARAM
//#define TEST_AUTO_INCREMENT
//#define TEST_BLOB
//#define TEST_BLOB_SAVE
//#define TEST_SMTH
//#define TEST_EXECUTE_SCALAR
//#define TEST_UPDATE_AND_RELOAD
//#define TEST_SYBASE_BY_ODBC
//#define TEST_STORED_PROCEDURES
//#define TEST_CLASS
//#define TEST_TRANSACTION
//#define TEST_SELF_ENCODING
//#define TEST_PARAM
//#define TEST_DELETE
//#define TEST_VIEW
//#define TEST_VERSION
//#define WITHOUT_CONNECTION_POOL
//#define USE_COMMAND_TYPE_STORED_PROCEDURE
//#define TEST_IDENTITY
//#define WITH_TRANSACTION
//#define TEST_DECIMAL

using System;
using System.Collections;
using System.Data.Common;
#if TEST_SYBASE_BY_ODBC
	using System.Data.Odbc;
#endif
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Data;
using System.Data.OleDb;
#if TEST_SELF_ENCODING
	using System.Text;
#endif
using System.Reflection;

namespace Test
{
	class TestAdoNetClass
	{
		#if TEST_CLASS
			public class AdoData
			{
				public OleDbConnection
					Connection;

				public OleDbCommand
					Command;

				public OleDbDataReader
					Reader;

				public AdoData(OleDbConnection aConnection)
				{
					try
					{
						Connection = aConnection==null ? new OleDbConnection() : aConnection;
						Command=new OleDbCommand();
						Command.Connection=Connection;
						Reader=null;
					}
					catch(OutOfMemoryException eException)
					{
						throw(new Exception(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace));
					}
				}
				//---------------------------------------------------------------------------

				public AdoData(AdoData aObj):this(aObj.Connection)
				{}
				//---------------------------------------------------------------------------

				public AdoData():this((OleDbConnection)null)
				{}
				//---------------------------------------------------------------------------

				~AdoData()
				{
					if(Reader!=null && !Reader.IsClosed)
						/*Reader.Close()*/;
					
					if(Connection!=null && Connection.State==ConnectionState.Open)
						Connection.Close();
				}
				//---------------------------------------------------------------------------
			}
			//---------------------------------------------------------------------------
		#endif

		[STAThread]
		public static int Main(string[] args)
		{
			int
				Result=-1;
			
			StreamWriter
				fstr_out=null;

			string
				SQLText=string.Empty,
				OutputFileName="log.log",
				strConn=string.Empty;
				
			OleDbConnection
				cn=null;
			
			DataTable
				tbl=null;

			OleDbCommand
				cmd=null;

			OleDbDataReader
				rdr=null;

			OleDbDataAdapter
				da=null;

			DataSet
				ds=null;
			
			DataRow
				tmpDataRow=null;

			OleDbParameter
				tmpOleDbParameter;

			int
				tmpInt;

			decimal
				tmpDecimal;

			object
				tmpObject=null;

			string
				tmpString;

			DataColumn
				tmpDataColumn;

			DataRow[]
				tmpDataRows;

			#if TEST_SYBASE_BY_ODBC
				OdbcConnection
					odbc_cn=null;

				OdbcCommand
					odbc_cmd=null;

				OdbcDataReader
					odbc_rdr=null;

				OdbcParameter
					tmpOdbcParameter;
			#endif

			try
			{
				try
				{
					fstr_out=new StreamWriter(OutputFileName,false,System.Text.Encoding.GetEncoding(1251));
					fstr_out.AutoFlush=true;

					fstr_out.WriteLine("Environment.SystemDirectory: "+Environment.SystemDirectory);
					fstr_out.WriteLine("Environment.CurrentDirectory: "+Environment.CurrentDirectory);
					fstr_out.WriteLine("System.IO.Directory.GetCurrentDirectory(): "+System.IO.Directory.GetCurrentDirectory());
					fstr_out.WriteLine("Environment.MachineName: "+Environment.MachineName);
					fstr_out.WriteLine("Environment.OSVerison: "+Environment.OSVersion);
					fstr_out.WriteLine("Environment.UserName: "+Environment.UserName);
					fstr_out.WriteLine("Environment.UserDomainName: "+Environment.UserDomainName);
					fstr_out.WriteLine("Environment.Version: "+Environment.Version);
					fstr_out.WriteLine("Environment.WorkingSet: "+Environment.WorkingSet);
					fstr_out.WriteLine();

					#if TEST_PARAM
						OleDbParameter
							Parameter=new OleDbParameter();

                		Parameter.ParameterName = "TestParameter";
                		Parameter.DbType = DbType.Int32;
						Parameter.DbType = DbType.DateTime;
						Parameter.DbType = DbType.Date;
						Parameter.DbType = DbType.Time;

						strConn="Provider=Sybase.ASEOLEDBProvider;Server Name=localhost;Server Port Address=5000;User ID=sa;Password='';Initial Catalog=veksel";
						cn=new OleDbConnection(strConn);
						cn.Open();
						SQLText=
@"select
CIP.*
from
CONTRACT_PARAM_ADD CPA
join CONTRACT_INFO_PRINT CIP on (CIP.CONTRACT_INFO_PRINT_ID=cast(CPA.PARAM_ADD_VALUE as numeric(18,0))) and (CIP.CLIENT_ID=?)
where
(CPA.CONTRACT_ID=?)
and (CPA.PARAM_ADD_ID=?)
and (CPA.RECORD_STATE=?)";
						cmd=new OleDbCommand(SQLText,cn);
						cmd.Parameters.Add("@CLIENT_ID",OleDbType.Numeric).Value=8;
						cmd.Parameters.Add("@CONTRACT_ID",OleDbType.Numeric).Value=1000000000000260;
						cmd.Parameters.Add("@PARAM_ADD_ID",OleDbType.SmallInt).Value=27;
						cmd.Parameters.Add("@RECORD_STATE",OleDbType.UnsignedTinyInt).Value=100;
						da=new OleDbDataAdapter(cmd);
						tbl=new DataTable();
						da.Fill(tbl);

						string
							FieldName;

						foreach(DataRow row in tbl.Rows)
						{
							SQLText=string.Empty;

							FieldName="DOC_ID";
							if(!row.IsNull(FieldName))
							{
								if(SQLText!=string.Empty)
									SQLText+=" ";
								SQLText+=Convert.ToString(Convert.ToInt64(row[FieldName]));
							}

							FieldName="ADDRESS_ID";
							if(!row.IsNull(FieldName))
							{
								if(SQLText!=string.Empty)
									SQLText+=" ";
								SQLText+=Convert.ToString(Convert.ToInt64(row[FieldName]));
							}

							FieldName="PHONE_ID";
							if(!row.IsNull(FieldName))
							{
								if(SQLText!=string.Empty)
									SQLText+=" ";
								SQLText+=Convert.ToString(Convert.ToInt64(row[FieldName]));
							}

							if(SQLText!=string.Empty)
								SQLText+=Environment.NewLine;
						}
						cn.Close();
					#endif

					//strConn="Provider=Sybase.ASEOLEDBProvider;Server Name=localhost;Server Port Address=5000;User ID=sa;Password=;Initial Catalog=veksel";
					strConn="Provider=Sybase.ASEOLEDBProvider;Server Name=localhost;Server Port Address=5000;User ID=sa;Password=;Initial Catalog=testdb";
					//strConn="Provider=ASEOLEDB;Server=localhost;Port=4999;Language=russian;Initial Catalog=testdb;User ID=sa;Password=";

					#if TEST_CLASS
						{	
							AdoData
								AdoData=new AdoData();

							AdoData.Connection.ConnectionString=strConn;
							AdoData.Connection.Open();
							AdoData.Command.CommandText="select * from Staff";
							AdoData.Reader=AdoData.Command.ExecuteReader();
							if(AdoData.Reader.HasRows)
								do
								{
									while(AdoData.Reader.Read())
										;
								}while(AdoData.Reader.NextResult());
						}
					#endif

					#if WITHOUT_CONNECTION_POOL
						strConn+=";OLE DB Services=-4"; // strConn+=";Pooling=False" // 4 SqlConnection
					#endif

					SQLText=string.Empty;
					if(strConn.IndexOf("Provider=Sybase.ASEOLEDBProvider")>=0)
						SQLText="OLEDB"+Path.DirectorySeparatorChar+"sydaase.dll";
					else if(strConn.IndexOf("Provider=ASEOLEDB")>=0)
						SQLText="DataAccess\\OLEDB\\dll"+Path.DirectorySeparatorChar+"sybdrvoledb.dll";

					FileVersionInfo
						OleDbProviderVersionInfo=null;

					if(SQLText!=string.Empty
						&& File.Exists(SQLText=Environment.GetEnvironmentVariable("SYBASE")+Path.DirectorySeparatorChar+SQLText))
					{
						OleDbProviderVersionInfo=FileVersionInfo.GetVersionInfo(SQLText);
						fstr_out.WriteLine(SQLText+" ver. "+OleDbProviderVersionInfo.FileMajorPart+"."+OleDbProviderVersionInfo.FileMinorPart+"."+OleDbProviderVersionInfo.FileBuildPart+"."+OleDbProviderVersionInfo.FilePrivatePart);
						fstr_out.WriteLine();
					}

					cn=new OleDbConnection(strConn);
					// ||
					//cn=new OleDbConnection();
					//cn.ConnectionString=strConn;

					cn.InfoMessage+=new OleDbInfoMessageEventHandler(cn_InfoMessage);
					cn.StateChange+=new StateChangeEventHandler(cn_StateChange);

					cn.Open();
					fstr_out.WriteLine("ConnectionString: "+cn.ConnectionString);
					fstr_out.WriteLine("ConnectionTimeout: "+cn.ConnectionTimeout.ToString());
					fstr_out.WriteLine("Database: "+cn.Database);
					fstr_out.WriteLine("DataSource: "+cn.DataSource);
					fstr_out.WriteLine("Provider: "+cn.Provider);
					fstr_out.WriteLine("ServerVersion: "+cn.ServerVersion);
					fstr_out.WriteLine("State: "+cn.State.ToString());
					fstr_out.WriteLine();
					
					fstr_out.WriteLine("System.Data."+DbType.AnsiString.ToString()+"="+Convert.ToInt32(DbType.AnsiString));
					fstr_out.WriteLine("System.Data."+DbType.Binary.ToString()+"="+Convert.ToInt32(DbType.Binary));
					fstr_out.WriteLine("System.Data."+DbType.Byte.ToString()+"="+Convert.ToInt32(DbType.Byte));
					fstr_out.WriteLine("System.Data."+DbType.Boolean.ToString()+"="+Convert.ToInt32(DbType.Boolean));
					fstr_out.WriteLine("System.Data."+DbType.Currency.ToString()+"="+Convert.ToInt32(DbType.Currency));
					fstr_out.WriteLine("System.Data."+DbType.Date.ToString()+"="+Convert.ToInt32(DbType.Date));
					fstr_out.WriteLine("System.Data."+DbType.DateTime.ToString()+"="+Convert.ToInt32(DbType.DateTime));
					fstr_out.WriteLine("System.Data."+DbType.Decimal.ToString()+"="+Convert.ToInt32(DbType.Decimal));
					fstr_out.WriteLine("System.Data."+DbType.Double.ToString()+"="+Convert.ToInt32(DbType.Double));
					fstr_out.WriteLine("System.Data."+DbType.Guid.ToString()+"="+Convert.ToInt32(DbType.Guid));
					fstr_out.WriteLine("System.Data."+DbType.Int16.ToString()+"="+Convert.ToInt32(DbType.Int16));
					fstr_out.WriteLine("System.Data."+DbType.Int32.ToString()+"="+Convert.ToInt32(DbType.Int32));
					fstr_out.WriteLine("System.Data."+DbType.Int64.ToString()+"="+Convert.ToInt32(DbType.Int64));
					fstr_out.WriteLine("System.Data."+DbType.Object.ToString()+"="+Convert.ToInt32(DbType.Object));
					fstr_out.WriteLine("System.Data."+DbType.SByte.ToString()+"="+Convert.ToInt32(DbType.SByte));
					fstr_out.WriteLine("System.Data."+DbType.Single.ToString()+"="+Convert.ToInt32(DbType.Single));
					fstr_out.WriteLine("System.Data."+DbType.String.ToString()+"="+Convert.ToInt32(DbType.String));
					fstr_out.WriteLine("System.Data."+DbType.Time.ToString()+"="+Convert.ToInt32(DbType.Time));
					fstr_out.WriteLine("System.Data."+DbType.UInt16.ToString()+"="+Convert.ToInt32(DbType.UInt16));
					fstr_out.WriteLine("System.Data."+DbType.UInt32.ToString()+"="+Convert.ToInt32(DbType.UInt32));
					fstr_out.WriteLine("System.Data."+DbType.UInt64.ToString()+"="+Convert.ToInt32(DbType.UInt64));
					fstr_out.WriteLine("System.Data."+DbType.VarNumeric.ToString()+"="+Convert.ToInt32(DbType.VarNumeric));
					fstr_out.WriteLine("System.Data."+DbType.AnsiStringFixedLength.ToString()+"="+Convert.ToInt32(DbType.AnsiStringFixedLength));
					fstr_out.WriteLine("System.Data."+DbType.StringFixedLength.ToString()+"="+Convert.ToInt32(DbType.StringFixedLength));
					fstr_out.WriteLine();

					#if TEST_TYPES
						if(cmd==null)
							cmd=cn.CreateCommand();
						cmd.CommandType=CommandType.Text;
						cmd.CommandText="select * from TestTypes";

						if(da==null)
							da=new OleDbDataAdapter(cmd);
						else
							da.SelectCommand=cmd;

						if(tbl==null)
							tbl=new DataTable();
						else
							tbl.Reset();

						da.Fill(tbl);
					#endif

					#if TEST_PARAMETERS
						if(cmd==null)
							cmd=cn.CreateCommand();
						cmd.CommandType=CommandType.Text;
						cmd.CommandText="select * from Staff where ((Dep=?) and (ID=?)) or ((Dep=?) and (ID=?))";
						cmd.Parameters.Add("Dep1",OleDbType.Integer).Value=2;
						cmd.Parameters.Add("Id1",OleDbType.SmallInt).Value=5;
						cmd.Parameters.Add("Dep2",OleDbType.Integer).Value=2;
						cmd.Parameters.Add("Id2",OleDbType.SmallInt).Value=7;

						if(da==null)
							da=new OleDbDataAdapter(cmd);
						else
							da.SelectCommand=cmd;

						if(tbl==null)
							tbl=new DataTable();
						else
							tbl.Reset();

						da.Fill(tbl);
					#endif

					#if TEST_EXECUTE_NON_QUERY
						if(cmd==null)
							cmd=cn.CreateCommand();
						cmd.CommandType=CommandType.Text;
						cmd.Parameters.Clear();
						cmd.CommandText="update Victim set Val = ? where Id = ?";
						cmd.Parameters.Add("Val",OleDbType.Integer);
						cmd.Parameters.Add("Id",OleDbType.Integer);
						for(int Id=1; Id<=5; Id+=2)
						{
							cmd.Parameters["Val"].Value=Id;
							cmd.Parameters["Id"].Value=Id;
							tmpInt=cmd.ExecuteNonQuery();
						}
					#endif

					#if TEST_STORED_PROCEDURES_PARAM
						if(cmd==null)
							cmd=cn.CreateCommand();

						cmd.CommandType=CommandType.Text;
						cmd.CommandText="{call sp_WithDefaultParam}";
						rdr=cmd.ExecuteReader();
						do
						{
							if(rdr.HasRows)
							{
								while(rdr.Read())
								{
									for(int i=0; i<rdr.FieldCount; ++i)
										tmpInt = !rdr.IsDBNull(i) ? rdr.GetInt32(i) : int.MinValue;
								}
							}
						}while(rdr.NextResult());
						rdr.Close();

						cmd.CommandText="call sp_WithDefaultParam(?)";
						cmd.Parameters.Add("Param1",OleDbType.Integer).Value=1;
						rdr=cmd.ExecuteReader();
						rdr.Close();

						cmd.CommandType=CommandType.StoredProcedure;
						cmd.CommandText="sp_WithDefaultParam";
						OleDbCommandBuilder.DeriveParameters(cmd);
						rdr=cmd.ExecuteReader();
						do
						{
							if(rdr.HasRows)
							{
								while(rdr.Read())
								{
									for(int i=0; i<rdr.FieldCount; ++i)
										tmpInt = !rdr.IsDBNull(i) ? rdr.GetInt32(i) : int.MinValue;
								}
							}
						}while(rdr.NextResult());
						rdr.Close();

						rdr.Close();

						cmd=null;
					#endif

					#if TEST_AUTO_INCREMENT
						if(tbl!=null)
							tbl.Reset();
						else
							tbl=new DataTable();

						tmpDataColumn=tbl.Columns.Add("Id",typeof(int));
						tmpDataColumn.AllowDBNull=false;
						tmpDataColumn.Unique=true;
						tmpDataColumn.AutoIncrement=true;
						tmpDataColumn.AutoIncrementSeed=1;
						tmpDataColumn.AutoIncrementStep=1;
						tbl.PrimaryKey=new DataColumn[]{tbl.Columns["Id"]};

						if(da==null)
							da=new OleDbDataAdapter("{call sp_Select_NULL}",cn);

						da.Fill(tbl);

						tbl.Clear();
						da.SelectCommand.CommandText="{call sp_Select_NULL(?)}";
						da.SelectCommand.Parameters.Add("IsSelectNull",OleDbType.Boolean).Value=true;
						da.Fill(tbl);

						da=null;
						tbl.Reset();
						tbl=null;
					#endif

					#if TEST_BLOB
						if(cmd==null)
							cmd=cn.CreateCommand();

						cmd.CommandType=CommandType.Text;

						FileStream
							fs;

						byte[]
							Blob;

						#if TEST_BLOB_SAVE
							cmd.CommandText="update TestTypes set FImage = ?";
							cmd.Parameters.Clear();
							cmd.Parameters.Add("FImage",OleDbType.LongVarBinary);
							fs=new FileStream("welcome.bmp",FileMode.Open,FileAccess.Read);
							Blob=new byte[fs.Length];
							fs.Read(Blob,0,Blob.Length);
							cmd.Parameters["FImage"].Value=Blob;
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

								tmpInt=rdr.GetOrdinal("FImage");

								while(rdr.Read())
								{
									tmpString="FromBlob.bmp";
									if(File.Exists(tmpString))
										File.Delete(tmpString);

									Blob=(byte[])rdr["FImage"];
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

					#if TEST_SMTH
						if(cmd==null)
							cmd=cn.CreateCommand();

						cmd.CommandType=CommandType.Text;
						cmd.CommandText="select * from TestDate order by FDate";
						cmd.Parameters.Clear();

						if(da==null)
							da=new OleDbDataAdapter(cmd);

						if(tbl==null)
							tbl=new DataTable();
						else
							tbl.Reset();

						da.Fill(tbl);

						SQLText="";
						for(int i=0; i<tbl.Rows.Count; ++i)
						{
							if(SQLText!=string.Empty)
								SQLText+=" ";
							SQLText+=Convert.ToDateTime(tbl.Rows[i]["FDate"]).ToString("yyyy-MM-dd");
						}
					#endif

					#if TEST_UPDATE_AND_RELOAD
						if(tbl==null)
							tbl=new DataTable();
						else
							tbl.Reset();

						cmd=cn.CreateCommand();
						cmd.CommandType=CommandType.Text;
						cmd.CommandText="select * from Staff where Id=1";
						if(da==null)
							da=new OleDbDataAdapter(cmd);
						da.Fill(tbl);

						if(tbl.Rows.Count>0)
							tbl.Rows[0]["Salary"]=0m;

						tmpDataRow=tbl.NewRow();
						tmpDataRow["Id"]=999;
						tmpDataRow["Name"]="Name";
						tbl.Rows.Add(tmpDataRow);

						da.Fill(tbl);

						da=null;
						cmd=null;
						tbl=null;
					#endif

					#if TEST_VIEW
						ds=new DataSet();
						ds.Tables.Add("Staff");
						ds.Tables["Staff"].Columns.Add("ID",typeof(short));
						ds.Tables["Staff"].Columns.Add("Name",typeof(string));
						ds.Tables["Staff"].Columns.Add("Salary",typeof(decimal));
						ds.Tables["Staff"].PrimaryKey=new DataColumn[]{ds.Tables["Staff"].Columns["ID"]};

						tmpDataRow=ds.Tables["Staff"].NewRow();
						tmpDataRow["ID"]=999;
						tmpDataRow["Name"]="Шариков Полиграф Полиграфович";
						tmpDataRow["Salary"]=2500.00m;
						ds.Tables["Staff"].Rows.Add(tmpDataRow);

						DataView
							TestView=new DataView(ds.Tables["Staff"]);

						TypeCode
							tcT,
							tcV;

						TestView.RowFilter="Salary>1500";
						SQLText="";
						for(int i=0; i<TestView.Count; ++i)
						{
							tcT=Type.GetTypeCode(TestView[i].Row["Name"].GetType());
							tcV=Type.GetTypeCode(TestView[i]["Name"].GetType());
							if(tcT!=tcV)
							{
								if(SQLText.Length!=0)
									SQLText+=" ";
								SQLText+="!!! tcT!=tcV !!!";
							}
							if(SQLText.Length!=0)
								SQLText+=" ";
							SQLText+=Convert.ToString(TestView[i]["Name"])+" "+Convert.ToDecimal(TestView[i]["Salary"]);
						}

						da=new OleDbDataAdapter("select * from Staff",cn);
						da.Fill(ds.Tables["Staff"]);
							
						SQLText="";
						for(int i=0; i<TestView.Count; ++i)
						{
							if(SQLText.Length!=0)
								SQLText+=" ";
							SQLText+=Convert.ToString(TestView[i]["Name"])+" "+Convert.ToDecimal(TestView[i]["Salary"]);	
						}

						SQLText="";
						ds.Reset();
					#endif

					#if TEST_DELETE
						int[]
							array={0, 1, 2, 3, 4, 5, 6, 7, 8, 9};

						int
							_i_,
							__i__;

						if(ds==null)
							ds=new DataSet();

						ds.Tables.Add("TestTable");
						ds.Tables["TestTable"].Columns.Add("Id",typeof(int));
						ds.Tables["TestTable"].PrimaryKey=new DataColumn[]{ds.Tables["TestTable"].Columns["Id"]};

						object
							tmpO=ds.Tables["TestTable"].Compute("count("+ds.Tables["TestTable"].Columns[0].ColumnName+")",null);

						if(!Convert.IsDBNull(tmpO))
							SQLText=Convert.ToString(tmpO);

						ds.Tables.Add("TestTableDetail");
						ds.Tables["TestTableDetail"].Columns.Add("Id",typeof(int));
						ds.Tables["TestTableDetail"].Columns.Add("SubId",typeof(int));
						ds.Tables["TestTableDetail"].PrimaryKey=new DataColumn[]{ds.Tables["TestTableDetail"].Columns["Id"],ds.Tables["TestTableDetail"].Columns["SubId"]};

						//ForeignKeyConstraint
						//	_fk_=new ForeignKeyConstraint("fk_Master_Detail",ds.Tables["TestTable"].Columns["Id"],ds.Tables["TestTableDetail"].Columns["Id"]);

						//_fk_.DeleteRule=Rule.Cascade;
						//_fk_.UpdateRule=Rule.Cascade;
						//ds.Tables["TestTableDetail"].Constraints.Add(_fk_);

						DataRelation
							_rel_=new DataRelation("fk_Master_Detail",ds.Tables["TestTable"].Columns["Id"],ds.Tables["TestTableDetail"].Columns["Id"]);

						ds.Relations.Add(_rel_);

						Rule
							rule=(ds.Tables["TestTableDetail"].Constraints["fk_Master_Detail"] as System.Data.ForeignKeyConstraint).DeleteRule;

						if(rule!=Rule.Cascade)
							(ds.Tables["TestTableDetail"].Constraints["fk_Master_Detail"] as System.Data.ForeignKeyConstraint).DeleteRule=Rule.Cascade;

						for(_i_=0; _i_<array.Length; ++_i_)
						{
							tmpDataRow=ds.Tables["TestTable"].NewRow();
							tmpDataRow["Id"]=array[_i_];
							ds.Tables["TestTable"].Rows.Add(tmpDataRow);
							for(__i__=0; __i__<array.Length; ++__i__)
							{
								tmpDataRow=ds.Tables["TestTableDetail"].NewRow();
								tmpDataRow["Id"]=array[_i_];
								tmpDataRow["SubId"]=array[__i__];
								ds.Tables["TestTableDetail"].Rows.Add(tmpDataRow);
							}
						}
						ds.Tables["TestTable"].AcceptChanges();
						ds.Tables["TestTableDetail"].AcceptChanges();

						ArrayList
							tmpArrayList=new ArrayList();

						SQLText=string.Empty;
						foreach(DataRow r in ds.Tables["TestTable"].Rows)
						{
							if(SQLText!=string.Empty)
								SQLText+=Environment.NewLine;

							SQLText+=Convert.ToString(Convert.ToInt32(r["Id"]));

							tmpArrayList.Add(r);
						}

						SQLText=string.Empty;
						for(_i_=0; _i_<tmpArrayList.Count; ++_i_)
						{
							if(SQLText!=string.Empty)
								SQLText+=Environment.NewLine;
							
							SQLText+=Convert.ToString(Convert.ToInt32(((DataRow)tmpArrayList[_i_])["Id"]));
						}

						tmpArrayList.Clear();
						for(_i_=0; _i_<ds.Tables["TestTable"].Rows.Count; ++_i_)
						{
							tmpDataRow=ds.Tables["TestTable"].Rows[_i_];
							tmpArrayList.Add(tmpDataRow);
						}

						SQLText=string.Empty;
						for(_i_=0; _i_<tmpArrayList.Count; ++_i_)
						{
							if(SQLText!=string.Empty)
								SQLText+=Environment.NewLine;
							
							SQLText+=Convert.ToString(Convert.ToInt32(((DataRow)tmpArrayList[_i_])["Id"]));
						}
						
						SQLText=Convert.ToString(ds.Tables["TestTable"].Compute("count("+ds.Tables["TestTable"].Columns[0].ColumnName+")",null));
						array[5]=555;
						for(int _ii_=0; _ii_<ds.Tables["TestTable"].Rows.Count; ++_ii_)
						{
							tmpDataRow=ds.Tables["TestTable"].Rows[_ii_];
							_i_=Convert.ToInt32(tmpDataRow["Id"]);
							if(array[_i_]!=_i_)
								tmpDataRow.Delete();
							//if(AcceptChanges())
							//  RowState==DataRowState.Deleted
							//else
							//  RowState==DataRowState.Detached
						}
						SQLText=Convert.ToString(ds.Tables["TestTable"].Compute("count("+ds.Tables["TestTable"].Columns[0].ColumnName+")",null));

						SQLText=string.Empty;
						foreach(DataRow r in ds.Tables["TestTable"].Rows)
						{
							if(SQLText!=string.Empty)
								SQLText+=Environment.NewLine;

							SQLText += r.RowState==DataRowState.Deleted ? Convert.ToString(Convert.ToInt32(r["Id",DataRowVersion.Original]))+" (deleted)" : Convert.ToString(Convert.ToInt32(r["Id"]));
						}
						foreach(DataRow r in ds.Tables["TestTableDetail"].Rows)
						{
							if(SQLText!=string.Empty)
								SQLText+=Environment.NewLine;

							SQLText += r.RowState==DataRowState.Deleted ? Convert.ToString(Convert.ToInt32(r["Id",DataRowVersion.Original]))+" (deleted)" : Convert.ToString(Convert.ToInt32(r["Id"]));
						}

						SQLText=string.Empty;
						for(_i_=0; _i_<ds.Tables["TestTable"].Rows.Count; ++_i_)
						{
							if(SQLText!=string.Empty)
								SQLText+=Environment.NewLine;

							SQLText += ds.Tables["TestTable"].Rows[_i_].RowState==DataRowState.Deleted ? Convert.ToString(Convert.ToInt32(ds.Tables["TestTable"].Rows[_i_]["Id",DataRowVersion.Original]))+" (deleted)" : Convert.ToString(Convert.ToInt32(ds.Tables["TestTable"].Rows[_i_]["Id"]));
						}

						if(ds.Tables["TestTable"].Rows.Find(5)==null)
						{
							tmpDataRow=ds.Tables["TestTable"].NewRow();
							tmpDataRow["Id"]=5;
							ds.Tables["TestTable"].Rows.Add(tmpDataRow);
						}

						if((tmpDataRow=ds.Tables["TestTable"].Rows.Find(4))!=null)
							tmpDataRow.Delete();

						DataRow[]
							drs=ds.Tables["TestTable"].Select("(Id>=2) and (Id<=7)");

						for(_i_=0; _i_<drs.Length; ++_i_)
							drs[_i_].Delete();

						SQLText=string.Empty;
						foreach(DataRow r in ds.Tables["TestTable"].Rows)
						{
							if(SQLText!=string.Empty)
								SQLText+=Environment.NewLine;

							SQLText += r.RowState==DataRowState.Deleted ? Convert.ToString(Convert.ToInt32(r["Id",DataRowVersion.Original]))+" (deleted)" : Convert.ToString(Convert.ToInt32(r["Id"]));
						}

						SQLText=string.Empty;
						for(_i_=0; _i_<ds.Tables["TestTable"].Rows.Count; ++_i_)
						{
							if(SQLText!=string.Empty)
								SQLText+=Environment.NewLine;

							SQLText += ds.Tables["TestTable"].Rows[_i_].RowState==DataRowState.Deleted ? Convert.ToString(Convert.ToInt32(ds.Tables["TestTable"].Rows[_i_]["Id",DataRowVersion.Original]))+" (deleted)" : Convert.ToString(Convert.ToInt32(ds.Tables["TestTable"].Rows[_i_]["Id"]));
						}

						drs=ds.Tables["TestTable"].Select("Id<=1");

						for(_i_=0; _i_<drs.Length; ++_i_)
							ds.Tables["TestTable"].Rows.Remove(drs[_i_]);

						SQLText=string.Empty;
						foreach(DataRow r in ds.Tables["TestTable"].Rows)
						{
							if(SQLText!=string.Empty)
								SQLText+=Environment.NewLine;

							SQLText += r.RowState==DataRowState.Deleted ? Convert.ToString(Convert.ToInt32(r["Id",DataRowVersion.Original]))+" (deleted)" : Convert.ToString(Convert.ToInt32(r["Id"]));
						}

						SQLText=string.Empty;
						for(_i_=0; _i_<ds.Tables["TestTable"].Rows.Count; ++_i_)
						{
							if(SQLText!=string.Empty)
								SQLText+=Environment.NewLine;

							SQLText += ds.Tables["TestTable"].Rows[_i_].RowState==DataRowState.Deleted ? Convert.ToString(Convert.ToInt32(ds.Tables["TestTable"].Rows[_i_]["Id",DataRowVersion.Original]))+" (deleted)" : Convert.ToString(Convert.ToInt32(ds.Tables["TestTable"].Rows[_i_]["Id"]));
						}

						ds.Reset();
					#endif

					#if TEST_DECIMAL
						double
							tmpDoubleIn,
							tmpDoubleOut;

						decimal
							tmpDecimalIn,
							tmpDecimalOut;

						int
							ReturnValue;

						tmpDoubleIn=13.0;
						SQLText="sp_TestTypes_Decimal_10_6";
						cmd=cn.CreateCommand();
						cmd.CommandType=CommandType.StoredProcedure;
						cmd.CommandText=SQLText;
						OleDbCommandBuilder.DeriveParameters(cmd);
						cmd.Parameters["FDecimal_10_6"].Value=tmpDoubleIn;
						cmd.ExecuteNonQuery();
						ReturnValue=Convert.ToInt32(cmd.Parameters["RETURN_VALUE"].Value);
						if(ReturnValue==65535)
						{
							tmpDoubleOut=Convert.ToDouble(cmd.Parameters["FDecimal_10_6_out"].Value);
							if(Math.Abs(tmpDoubleIn-tmpDoubleOut)>Double.Epsilon)
							{
								Console.WriteLine("In != Out");
							}
						}

						SQLText="sp_TestTypes_Numeric_10_6";
						cmd.CommandText=SQLText;
						OleDbCommandBuilder.DeriveParameters(cmd);
						cmd.Parameters["FNumeric_10_6"].Value=tmpDoubleIn;
						cmd.ExecuteNonQuery();
						ReturnValue=Convert.ToInt32(cmd.Parameters["RETURN_VALUE"].Value);
						if(ReturnValue==65535)
						{
							tmpDoubleOut=Convert.ToDouble(cmd.Parameters["FNumeric_10_6_out"].Value);
							if(Math.Abs(tmpDoubleIn-tmpDoubleOut)>Double.Epsilon)
							{
								Console.WriteLine("In != Out");
							}
						}

						tmpDecimalIn=13.539m;
						SQLText="sp_TestTypes_Decimal_10_6";
						cmd.CommandText=SQLText;
						OleDbCommandBuilder.DeriveParameters(cmd);
						cmd.Parameters["FDecimal_10_6"].Value=tmpDecimalIn;
						cmd.ExecuteNonQuery();
						ReturnValue=Convert.ToInt32(cmd.Parameters["RETURN_VALUE"].Value);
						if(ReturnValue==65535)
						{
							tmpDecimalOut=Convert.ToDecimal(cmd.Parameters["FDecimal_10_6_out"].Value);
							if(tmpDecimalIn!=tmpDecimalOut)
							{
								Console.WriteLine("In != Out");
							}
						}

						SQLText="sp_TestTypes_Numeric_10_6";
						cmd.CommandText=SQLText;
						OleDbCommandBuilder.DeriveParameters(cmd);
						cmd.Parameters["FNumeric_10_6"].Value=tmpDecimalIn;
						cmd.ExecuteNonQuery();
						ReturnValue=Convert.ToInt32(cmd.Parameters["RETURN_VALUE"].Value);
						if(ReturnValue==65535)
						{
							tmpDecimalOut=Convert.ToDecimal(cmd.Parameters["FNumeric_10_6_out"].Value);
							if(tmpDecimalIn!=tmpDecimalOut)
							{
								Console.WriteLine("In != Out");
							}
						}
					#endif

					#if TEST_IDENTITY
						#if WITH_TRANSACTON
							OleDbTransaction
								transaction=cn.BeginTransaction(IsolationLevel.ReadCommitted);
						#endif

						cmd=cn.CreateCommand();
						#if WITH_TRANSACTON
							cmd.Transaction=transaction;
						#endif
						cmd.CommandText="insert into TestIdentity (Value) values (?)";
						cmd.Parameters.Add("@Value",OleDbType.VarChar,255);

						for(int i=1; i<=20; ++i)
						{
							cmd.Parameters[0].Value=i.ToString();
							cmd.ExecuteNonQuery();
						}
						#if WITH_TRANSACTION
							transaction.Commit();
						#endif
					#endif

					#if TEST_STORED_PROCEDURES
						if(cmd==null)
							cmd=cn.CreateCommand();

						cmd.CommandType=CommandType.Text;
						cmd.CommandText="exec UpdateTestTypes 123.456";
						cmd.ExecuteNonQuery();

						cmd.CommandType=CommandType.Text;
						cmd.CommandText="exec UpdateTestTypes @Decimal_18_4=123.456";
						cmd.ExecuteNonQuery();

						cmd.CommandType=CommandType.Text;
						cmd.CommandText="exec UpdateIDS 1, 1, '1'";
						cmd.ExecuteNonQuery();

						cmd.CommandType=CommandType.Text;
						cmd.CommandText="exec UpdateIDS @TABLE_ID=1, @VALUE_ID=1, @TABLE_NAME='1'";
						cmd.ExecuteNonQuery();

						cmd.CommandType=CommandType.StoredProcedure;
						cmd.CommandText="sp_TestTypes_Decimal_10_6";
						OleDbCommandBuilder.DeriveParameters(cmd);
						cmd.Parameters["FDecimal_10_6"].Precision=0;
						cmd.Parameters["FDecimal_10_6"].Scale=0;
						cmd.Parameters["FDecimal_10_6"].Value=123.45m;
						cmd.ExecuteNonQuery();
						tmpDecimal=Convert.ToDecimal(cmd.Parameters["FDecimal_10_6_out"].Value);

						cmd.Parameters.Clear();

						tmpOleDbParameter=new OleDbParameter("RETURN_VALUE",OleDbType.Integer);
						tmpOleDbParameter.Direction=ParameterDirection.ReturnValue;
						cmd.Parameters.Add(tmpOleDbParameter);

						tmpOleDbParameter=new OleDbParameter("FDecimal_10_6",OleDbType.Numeric); //OleDbType.Decimal
						tmpOleDbParameter.Direction=ParameterDirection.Input;
						//tmpOleDbParameter.Precision=10;
						//tmpOleDbParameter.Scale=6;
						tmpOleDbParameter.Value=123.45m;
						cmd.Parameters.Add(tmpOleDbParameter);

						tmpOleDbParameter=new OleDbParameter("FDecimal_10_6_out",OleDbType.Numeric); //OleDbType.Decimal
						tmpOleDbParameter.Direction=ParameterDirection.Output;
						tmpOleDbParameter.Precision=10;
						tmpOleDbParameter.Scale=6;
						cmd.Parameters.Add(tmpOleDbParameter);

						cmd.CommandType=CommandType.Text;
						cmd.CommandText="{? = call sp_TestTypes_Decimal_10_6(? ,?)}";
						cmd.ExecuteNonQuery();
						tmpDecimal=Convert.ToDecimal(cmd.Parameters["FDecimal_10_6_out"].Value);

						tmpDecimal=2m;

						if(cmd==null)
							cmd=cn.CreateCommand();

						cmd.CommandType=CommandType.Text;
						cmd.CommandText="{? = call UpdateTestTypes(?)}";

						cmd.Parameters.Clear();

						tmpOleDbParameter=new OleDbParameter("RETURN_VALUE",OleDbType.Integer);
						tmpOleDbParameter.Direction=ParameterDirection.ReturnValue;
						cmd.Parameters.Add(tmpOleDbParameter);

						tmpOleDbParameter=new OleDbParameter("@rate",OleDbType.Decimal);
						tmpOleDbParameter.Value=tmpDecimal;
						cmd.Parameters.Add(tmpOleDbParameter);
						
						/*
						cmd.CommandType=CommandType.StoredProcedure;
						cmd.CommandText="UpdateTestTypes";
						OleDbCommandBuilder.DeriveParameters(cmd);
						cmd.Parameters["Decimal_18_4"].Value=tmpDecimal;
						*/

						int
							res=cmd.ExecuteNonQuery();

						if(cmd==null)
							cmd=cn.CreateCommand();

						cmd.CommandType=CommandType.StoredProcedure;

						cmd.CommandText="TestParamDirection";
						OleDbCommandBuilder.DeriveParameters(cmd);
						Console.WriteLine(cmd.Parameters["FirstOutput"].Direction.ToString());
						Console.WriteLine(cmd.Parameters["First"].Direction.ToString());

						cmd.CommandText="sp_WithInputOutput";
						OleDbCommandBuilder.DeriveParameters(cmd);
						cmd.Parameters["InputParam"].Value=1;
						cmd.Parameters["InputOutputParam"].Value=2;
						cmd.Parameters["OutputParam"].Value=3;
						cmd.ExecuteNonQuery();
						// !!!!!!!!!!
						// Without
						// cmd.Parameters["InputOutputParam"].Direction=ParameterDirection.InputOutput;
						// cmd.Parameters["OutputParam"].Value == DBNull.Value;
						// !!!!!!!!!!

						OleDbCommandBuilder.DeriveParameters(cmd);
						cmd.Parameters["InputParam"].Value=1;
						cmd.Parameters["InputOutputParam"].Direction=ParameterDirection.InputOutput;
						cmd.Parameters["InputOutputParam"].Value=2;
						cmd.Parameters["OutputParam"].Value=3;
						cmd.ExecuteNonQuery();
	
						cmd.CommandText="sp_ReturnOnly";
						cmd.Parameters.Clear();
						cmd.ExecuteNonQuery();

						cmd.CommandText="sp_ReturnAndOutput";
						OleDbCommandBuilder.DeriveParameters(cmd);
						cmd.ExecuteNonQuery();

						for(int size=255; size<=258; ++size)
						{
							cmd.CommandText="sp_ReturnAndOutputVarChar"+size;
							OleDbCommandBuilder.DeriveParameters(cmd);
							cmd.ExecuteNonQuery();
							SQLText = !Convert.IsDBNull(cmd.Parameters["OutParam"].Value) ? Convert.ToString(cmd.Parameters["OutParam"].Value) : "NULL";
						}

						cn.ChangeDatabase("master");
						cmd.CommandText="testdb..sp_ReturnAndOutput";
						OleDbCommandBuilder.DeriveParameters(cmd);
						cn.ChangeDatabase("testdb");

						cmd.CommandText="sp_ReturnAndOutputAndSelect";
						OleDbCommandBuilder.DeriveParameters(cmd);
						cmd.ExecuteNonQuery();

						cmd.CommandText="sp_SalaryMaxListWReturn_Output";
						OleDbCommandBuilder.DeriveParameters(cmd);
						cmd.ExecuteNonQuery();

						if(da==null)
							da=new OleDbDataAdapter();

						cmd.CommandType=CommandType.Text;
						cmd.CommandText="sp_Staff";
						da.SelectCommand=cmd;

						if(tbl!=null)
							tbl.Reset();
						else
							tbl=new DataTable();

						da.Fill(tbl);

						da.SelectCommand.CommandText="exec sp_Staff";
						tbl.Reset();
						da.Fill(tbl);

						da.SelectCommand.CommandText="exec sp_SalaryMaxList 2";
						tbl.Reset();
						da.Fill(tbl);

						da.SelectCommand.CommandText="exec sp_SalaryMaxList @MaxCount=2";
						tbl.Reset();
						da.Fill(tbl);

						cmd.CommandType=CommandType.StoredProcedure;
						cmd.CommandText="sp_MaxFromEmptyTable";
						OleDbCommandBuilder.DeriveParameters(cmd);
						cmd.ExecuteNonQuery();
						tmpObject=cmd.Parameters["MaxId"].Value;
					#endif

					#if TEST_SYBASE_BY_ODBC
						strConn="DSN=SybaseODBCTest";
						//strConn="Driver={SYBASE ASE ODBC Driver};NA=localhost,5000;Uid=sa;Pwd=;DB=testdb"; // || Database=testdb
						//strConn="DSN=SybaseODBCNewTest";
						//strConn="Driver={Adaptive Server Enterprise};Server=localhost;Port=5000;Language=russian;Uid=sa;Pwd=;Database=testdb";

						SQLText=string.Empty;
						if(strConn.IndexOf("Driver={SYBASE ASE ODBC Driver}")>=0
							|| strConn.IndexOf("DSN=SybaseODBCTest")>=0)
							SQLText="ODBC"+Path.DirectorySeparatorChar+"syodase.dll";
						else if(strConn.IndexOf("Driver={Adaptive Server Enterprise}")>=0
							|| strConn.IndexOf("DSN=SybaseODBCNewTest")>=0)
							SQLText="DataAccess\\ODBC\\dll"+Path.DirectorySeparatorChar+"sybdrvodb.dll";

						FileVersionInfo
							OdbcDriverVersionInfo=null;

						if(SQLText!=string.Empty
							&& File.Exists(SQLText=Environment.GetEnvironmentVariable("SYBASE")+Path.DirectorySeparatorChar+SQLText))
						{
							OdbcDriverVersionInfo=FileVersionInfo.GetVersionInfo(SQLText);
							fstr_out.WriteLine(SQLText+" ver. "+OdbcDriverVersionInfo.FileMajorPart+"."+OdbcDriverVersionInfo.FileMinorPart+"."+OdbcDriverVersionInfo.FileBuildPart+"."+OdbcDriverVersionInfo.FilePrivatePart);
							fstr_out.WriteLine();
						}

						odbc_cn=new OdbcConnection(strConn);
						odbc_cn.Open();
						fstr_out.WriteLine("ConnectionString: "+odbc_cn.ConnectionString);
						fstr_out.WriteLine("ConnectionTimeout: "+odbc_cn.ConnectionTimeout.ToString());
						fstr_out.WriteLine("Database: "+odbc_cn.Database);
						fstr_out.WriteLine("DataSource: "+odbc_cn.DataSource);
						fstr_out.WriteLine("Driver: "+odbc_cn.Driver);
						fstr_out.WriteLine("ServerVersion: "+odbc_cn.ServerVersion);
						fstr_out.WriteLine("State: "+odbc_cn.State.ToString());
						fstr_out.WriteLine();

						odbc_cmd=odbc_cn.CreateCommand();
						odbc_cmd.CommandType=CommandType.Text;
						odbc_cmd.CommandText="select @@spid";
						if((tmpObject=odbc_cmd.ExecuteScalar())!=null)
							SQLText=Convert.ToString(tmpObject);

						odbc_cmd.Parameters.Clear();
						tmpOdbcParameter=new OdbcParameter("RETURN_VALUE",OdbcType.Int);
						tmpOdbcParameter.Direction=ParameterDirection.ReturnValue;
						odbc_cmd.Parameters.Add(tmpOdbcParameter);

						tmpOdbcParameter=new OdbcParameter("FDecimal_10_6",OdbcType.Decimal);
						tmpOdbcParameter.Direction=ParameterDirection.Input;
						tmpOdbcParameter.Precision=10;
						tmpOdbcParameter.Scale=6;
						tmpOdbcParameter.Value=123.45m;
						odbc_cmd.Parameters.Add(tmpOdbcParameter);

						tmpOdbcParameter=new OdbcParameter("FDecimal_10_6_out",OdbcType.Decimal);
						tmpOdbcParameter.Direction=ParameterDirection.Output;
						tmpOdbcParameter.Precision=10;
						tmpOdbcParameter.Scale=6;
						odbc_cmd.Parameters.Add(tmpOdbcParameter);

						odbc_cmd.CommandType=CommandType.Text;
						odbc_cmd.CommandText="{? = call sp_TestTypes_Decimal_10_6(? ,?)}";
						//odbc_cmd.ExecuteNonQuery();

						if(OdbcDriverVersionInfo!=null
							&& (OdbcDriverVersionInfo.FileMajorPart==5 // 4
								&& OdbcDriverVersionInfo.FileMinorPart==0 //20
								&& OdbcDriverVersionInfo.FileBuildPart==0
								&& OdbcDriverVersionInfo.FilePrivatePart==129)) //15
						{
							odbc_cmd.CommandType=CommandType.StoredProcedure;
							odbc_cmd.CommandText="mathtutor";
							OdbcCommandBuilder.DeriveParameters(odbc_cmd);
							odbc_cmd.Parameters["@mult1"].Value=5;
							odbc_cmd.Parameters["@mult2"].Value=6;
						}
						else
						{
							odbc_cmd.CommandType=CommandType.Text;
							odbc_cmd.CommandText="{? = call mathtutor(?, ?, ?)}";
							odbc_cmd.Parameters.Clear();

							tmpOdbcParameter=new OdbcParameter("RETURN_VALUE",OdbcType.Int);
							tmpOdbcParameter.Direction=ParameterDirection.ReturnValue;
							odbc_cmd.Parameters.Add(tmpOdbcParameter);

							tmpOdbcParameter=new OdbcParameter("@mult1",OdbcType.Int);
							tmpOdbcParameter.Direction=ParameterDirection.Input;
							tmpOdbcParameter.Value=5;
							odbc_cmd.Parameters.Add(tmpOdbcParameter);

							tmpOdbcParameter=new OdbcParameter("@mult2",OdbcType.Int);
							tmpOdbcParameter.Direction=ParameterDirection.Input;
							tmpOdbcParameter.Value=6;
							odbc_cmd.Parameters.Add(tmpOdbcParameter);

							tmpOdbcParameter=new OdbcParameter("@result",OdbcType.Int);
							tmpOdbcParameter.Direction=ParameterDirection.Output;
							odbc_cmd.Parameters.Add(tmpOdbcParameter);
						}

						odbc_cmd.ExecuteNonQuery();
						SQLText=Convert.ToString(odbc_cmd.Parameters["RETURN_VALUE"].Value);
						SQLText=Convert.ToString(odbc_cmd.Parameters["@result"].Value);
						odbc_cn.Close();
					#endif

					#if TEST_VERSION
						ds=new DataSet();
						ds.Tables.Add("MasterTable");
						ds.Tables["MasterTable"].Columns.Add("Id",typeof(int));
						ds.Tables["MasterTable"].Columns.Add("Value",typeof(int));
						ds.Tables["MasterTable"].PrimaryKey=new DataColumn[]{ds.Tables["MasterTable"].Columns["Id"]};
					
						ds.Tables["MasterTable"].ColumnChanged+=new DataColumnChangeEventHandler(TestColumnChanged);
						ds.Tables["MasterTable"].ColumnChanging+=new DataColumnChangeEventHandler(TestColumnChanging);

						ds.Tables.Add("DetailTable");
						ds.Tables["DetailTable"].Columns.Add("Id",typeof(int));
						ds.Tables["DetailTable"].Columns.Add("SubId",typeof(int));
						ds.Tables["DetailTable"].Columns.Add("Value",typeof(int));
						ds.Tables["DetailTable"].PrimaryKey=new DataColumn[]{ds.Tables["DetailTable"].Columns["Id"],ds.Tables["DetailTable"].Columns["SubId"]};

						ds.Relations.Add(new DataRelation("Master_Detail",ds.Tables["MasterTable"].Columns["Id"],ds.Tables["DetailTable"].Columns["Id"]));

						tmpDataRow=ds.Tables["MasterTable"].NewRow();
						tmpDataRow["Id"]=1;
						tmpDataRow["Value"]=11;
						ds.Tables["MasterTable"].Rows.Add(tmpDataRow);

						tmpDataRow=ds.Tables["MasterTable"].NewRow();
						tmpDataRow["Id"]=2;
						tmpDataRow["Value"]=22;
						ds.Tables["MasterTable"].Rows.Add(tmpDataRow);

						ds.Tables["MasterTable"].AcceptChanges();

						SQLText="";
						foreach(DataRow r in ds.Tables["MasterTable"].Rows)
						{
							SQLText+=" "+r.RowState;
						}

						tmpDataRow=ds.Tables["MasterTable"].Rows.Find(1);
						tmpDataRow["Value"]=11;

						SQLText="";
						foreach(DataRow r in ds.Tables["MasterTable"].Rows)
						{
							SQLText+=" "+r.RowState;
						}
						
						tmpDataRow=ds.Tables["DetailTable"].NewRow();
						tmpDataRow["Id"]=1;
						tmpDataRow["SubId"]=1;
						tmpDataRow["Value"]=111;
						ds.Tables["DetailTable"].Rows.Add(tmpDataRow);

						tmpDataRow=ds.Tables["DetailTable"].NewRow();
						tmpDataRow["Id"]=2;
						tmpDataRow["SubId"]=1;
						tmpDataRow["Value"]=221;
						ds.Tables["DetailTable"].Rows.Add(tmpDataRow);
						
						ds.Tables["DetailTable"].AcceptChanges();
						SQLText="";
						foreach(DataRow r in ds.Tables["DetailTable"].Rows)
						{
							SQLText+=" "+r.RowState;
						}

						tmpDataRow=ds.Tables["MasterTable"].Rows.Find(2);
						tmpDataRow["Id"]=11;

						SQLText=tmpDataRow.RowState.ToString();
						foreach(DataRow r in ds.Tables["DetailTable"].Rows)
						{
							SQLText+=" "+r.RowState;
						}
						
						ds.Tables.Add("TestFillTable");
						da=new OleDbDataAdapter("select * from Staff",cn);
						da.Fill(ds.Tables["TestFillTable"]);
						SQLText="RecCount: "+ds.Tables["TestFillTable"].Rows.Count;
						foreach(DataRow r in ds.Tables["TestFillTable"].Rows)
						{
							SQLText+=" "+r.RowState;
						}

						da.SelectCommand.CommandText="select * from Staff where Salary>1500";
						da.Fill(ds.Tables["TestFillTable"]);
						SQLText="RecCount: "+ds.Tables["TestFillTable"].Rows.Count;
						foreach(DataRow r in ds.Tables["TestFillTable"].Rows)
						{
							SQLText+=" "+r.RowState;
						}

						ds.Tables["TestFillTable"].Rows[0].Delete();
						SQLText="";
						foreach(DataRow r in ds.Tables["TestFillTable"].Rows)
						{
							SQLText+=" "+r.RowState;
						}

						ds.Tables["TestFillTable"].AcceptChanges();
						SQLText="";
						foreach(DataRow r in ds.Tables["TestFillTable"].Rows)
						{
							SQLText+=" "+r.RowState;
						}

						SQLText="";
						ds.Reset();
					#endif

					#if TEST_EXECUTE_SCALAR
						if(cmd==null)
							cmd=cn.CreateCommand();

						cmd.CommandType=CommandType.Text;

						tmpObject=null;
						cmd.CommandText="select ID from Staff where ID=-999";
						tmpObject=cmd.ExecuteScalar(); // null

						tmpObject=null;
						cmd.CommandText="select sum(Salary) from Staff where ID=-999 group by ID";
						tmpObject=cmd.ExecuteScalar(); // null

						tmpObject=null;
						cmd.CommandText="select avg(Salary) from Staff where ID=-999 group by ID";
						tmpObject=cmd.ExecuteScalar(); // null

						tmpObject=null;
						cmd.CommandText="select min(Salary) from Staff where ID=-999 group by ID";
						tmpObject=cmd.ExecuteScalar(); // null

						tmpObject=null;
						cmd.CommandText="select max(Salary) from Staff where ID=-999 group by ID";
						tmpObject=cmd.ExecuteScalar(); // null

						tmpObject=null;
						cmd.CommandText="select count(Salary) from Staff where ID=-999 group by ID";
						tmpObject=cmd.ExecuteScalar(); // null

						tmpObject=null;
						cmd.CommandText="select count(*) from Staff where ID=-999 group by ID";
						tmpObject=cmd.ExecuteScalar(); // null

						tmpObject=null;
						cmd.CommandText="select NullField from Staff where ID=-999";
						tmpObject=cmd.ExecuteScalar(); // null

						tmpObject=null;
						cmd.CommandText="select sum(NullField) from Staff";
						tmpObject=cmd.ExecuteScalar(); // DBNull.Value

						tmpObject=null;
						cmd.CommandText="select avg(NullField) from Staff";
						tmpObject=cmd.ExecuteScalar(); // DBNull.Value

						tmpObject=null;
						cmd.CommandText="select min(NullField) from Staff";
						tmpObject=cmd.ExecuteScalar(); // DBNull.Value

						tmpObject=null;
						cmd.CommandText="select max(NullField) from Staff";
						tmpObject=cmd.ExecuteScalar(); // DBNull.Value

						tmpObject=null;
						cmd.CommandText="select count(NullField) from Staff";
						tmpObject=cmd.ExecuteScalar(); // 0

						tmpObject=null;
						cmd.CommandText="select count(*) from Staff";
						tmpObject=cmd.ExecuteScalar(); // 11

						cmd=null;
					#endif

					fstr_out.WriteLine("OleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Provider_Types)");
					tbl=cn.GetOleDbSchemaTable(OleDbSchemaGuid.Provider_Types,null);
					foreach(DataRow row in tbl.Rows)
						fstr_out.WriteLine("\t"+row["TYPE_NAME"]+" "+row["DATA_TYPE"]+" "+row["LOCAL_TYPE_NAME"]+" "+row["BEST_MATCH"]);
					fstr_out.WriteLine();

					fstr_out.WriteLine("OleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables)");
					tbl=cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,null);
					foreach(DataRow row in tbl.Rows)
						fstr_out.WriteLine("\t"+row["TABLE_CATALOG"]+" "+row["TABLE_NAME"]+" "+row["TABLE_TYPE"]+" "+row["TABLE_SCHEMA"]+" "+row["TABLE_GUID"]+" "+row["DESCRIPTION"]+" "+row["TABLE_PROPID"]+" "+row["DATE_CREATED"]+" "+row["DATE_MODIFIED"]);
					fstr_out.WriteLine();

					fstr_out.WriteLine("OleDbConnection.GetOleDbSchemaTable()");
					tbl=cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,new object[]{null, null, null, "TABLE"});
					foreach(DataRow row in tbl.Rows)
						fstr_out.WriteLine("\t"+row["TABLE_CATALOG"]+" "+row["TABLE_NAME"]+" "+row["TABLE_TYPE"]+" "+row["TABLE_SCHEMA"]+" "+row["TABLE_GUID"]+" "+row["DESCRIPTION"]+" "+row["TABLE_PROPID"]+" "+row["DATE_CREATED"]+" "+row["DATE_MODIFIED"]);
					fstr_out.WriteLine();

					string
						TableName="TestTypes";

					object[]
						objRestrictions=new object[]{null, null, TableName, null};

					fstr_out.WriteLine("OleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Columns)");
					tbl=cn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns,objRestrictions);
					fstr_out.WriteLine("Columns in "+TableName+" table:");
					foreach(DataRow row in tbl.Rows)
						fstr_out.WriteLine("\t"+row["TABLE_CATALOG"]+" "+row["TABLE_NAME"]+" "+row["COLUMN_NAME"].ToString()+" "+row["DATA_TYPE"]+" "+row["TABLE_SCHEMA"]);
					fstr_out.WriteLine();
					
					fstr_out.WriteLine("OleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Columns)");
					objRestrictions[3]="FNumeric_18_0";
                    tbl=cn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns,objRestrictions);
					fstr_out.WriteLine("Columns "+objRestrictions[3].ToString()+" in "+TableName+" table:");
					foreach(DataRow row in tbl.Rows)
						fstr_out.WriteLine("\t"+row["TABLE_CATALOG"]+" "+row["TABLE_NAME"]+" "+row["COLUMN_NAME"].ToString()+" "+row["DATA_TYPE"]+" "+row["TABLE_SCHEMA"]);
					fstr_out.WriteLine();

					cmd=cn.CreateCommand();
					// ||
					//cmd=new OleDbCommand();
					//cmd.CommandText=SQLText;
					//cmd.Connection=cn;
					// ||
					//cmd=new OleDbCommand(SQLText,cn);
					// ||
					//using (OleDbCommand cmd=new OleDbCommand())
					//{
					//	cmd.CommandText="creat table TableName...";
					//	cmd.ExecuteNonQuery();
					//}
					#region Test OleDbCommand.ExecuteScalar() // !OLEDB.2.70.0.32
						if(OleDbProviderVersionInfo!=null
							&& ((OleDbProviderVersionInfo.FileMajorPart==2
									&& OleDbProviderVersionInfo.FileMinorPart==70
									&& OleDbProviderVersionInfo.FileBuildPart==0
									&& OleDbProviderVersionInfo.FilePrivatePart==23)
								|| (OleDbProviderVersionInfo.FileMajorPart==2
									&& OleDbProviderVersionInfo.FileMinorPart==70
									&& OleDbProviderVersionInfo.FileBuildPart==0
									&& OleDbProviderVersionInfo.FilePrivatePart==82)))
						{
							cmd.CommandType=CommandType.Text;
							cmd.CommandText="select @@spid";
							if((tmpObject=cmd.ExecuteScalar())!=null) // Create new connect OLEDB.2.70.0.23, OLEDB.2.70.0.82
								SQLText=Convert.ToString(tmpObject);

							// cmd.Cancel();

							cmd.CommandText="select @@spid";
							if((tmpObject=cmd.ExecuteScalar())!=null)
								SQLText=Convert.ToString(tmpObject);

							SQLText="select Salary from Staff where ID=999";
							cmd.CommandText=SQLText;
							if((tmpObject=cmd.ExecuteScalar())!=null)
								SQLText=Convert.ToString(tmpObject);

							SQLText="select BirthDate from Staff where ID=9";
							cmd.CommandText=SQLText;
							if((tmpObject=cmd.ExecuteScalar())!=null
								&& !Convert.IsDBNull(tmpObject))
								SQLText=Convert.ToString(tmpObject);
						}
					#endregion

					SQLText="select * from TestTypes";
					cmd.CommandText=SQLText;
					fstr_out.WriteLine("OleDbCommand.ExecuteReader(CommandBehavior.SchemaOnly)");
					rdr=cmd.ExecuteReader(CommandBehavior.SchemaOnly);
					fstr_out.WriteLine("OleDbDataReader.HasRows="+rdr.HasRows.ToString());
					for(int i=0; i<rdr.FieldCount; ++i)
					{
						fstr_out.WriteLine(rdr.GetName(i)+" "+rdr.GetDataTypeName(i)+" "+rdr.GetFieldType(i));
					}
					fstr_out.WriteLine();
					rdr.Close();

					SQLText="select * from Staff";
					cmd.CommandText=SQLText;

					#region Fill DataTable Schema from Database
						if(ds==null)
							ds=new DataSet();
						if(da==null)
							da=new OleDbDataAdapter(cmd);
						da.FillSchema(ds,SchemaType.Source,"Staff");
						if(OleDbProviderVersionInfo!=null
							&& ((OleDbProviderVersionInfo.FileMajorPart==2
									&& OleDbProviderVersionInfo.FileMinorPart==70
									&& OleDbProviderVersionInfo.FileBuildPart==0
									&& OleDbProviderVersionInfo.FilePrivatePart==23)
								|| (OleDbProviderVersionInfo.FileMajorPart==2
									&& OleDbProviderVersionInfo.FileMinorPart==70
									&& OleDbProviderVersionInfo.FileBuildPart==0
									&& OleDbProviderVersionInfo.FilePrivatePart==82)))
							da.Fill(ds,"Staff"); // !OLEDB.2.70.0.32
					#endregion

					rdr=cmd.ExecuteReader();
					if(rdr.HasRows)
					{
						int
							NameOrdinal=rdr.GetOrdinal("Name"),
							SalaryOrdinal=rdr.GetOrdinal("Salary");
						
						fstr_out.WriteLine("OleDbDataReader.Get...(i)");
						for(int i=0; i<rdr.FieldCount; ++i)
						{
							fstr_out.WriteLine(rdr.GetName(i)+" "+rdr.GetDataTypeName(i)+" "+rdr.GetFieldType(i));
						}
						fstr_out.WriteLine();
						
						fstr_out.WriteLine("OleDbDataReader.GetSchemaTable()");
						tbl=rdr.GetSchemaTable();
						fstr_out.WriteLine("Columns");
						for(int i=0; i<tbl.Columns.Count; ++i)
						{
							fstr_out.WriteLine(tbl.Columns[i].ToString());
						}
						fstr_out.WriteLine();

						fstr_out.WriteLine("Rows");
						foreach(DataRow row in tbl.Rows)
						{
							fstr_out.WriteLine(row["ColumnName"]+" - "+((OleDbType)row["ProviderType"]).ToString()+" ("+row["DataType"].ToString()+") ColumnSize="+row["ColumnSize"].ToString()+" NumericPrecision="+row["NumericPrecision"].ToString()+" NumericScale="+row["NumericScale"].ToString());
						}
						fstr_out.WriteLine();
                        
						fstr_out.WriteLine(SQLText);

						#if TEST_SELF_ENCODING
							byte[]
								UTF8Bytes,
								ASCIIBytes;

							char[]
								ASCIIChars;
						#endif

						while(rdr.Read())
						{
							//fstr_out.WriteLine(rdr["Name"]+": "+rdr["Salary"]); // by ColumnName without type (AsObject)
							SQLText=rdr.GetString(NameOrdinal);
							#if TEST_SELF_ENCODING
								UTF8Bytes=Encoding.UTF8.GetBytes(SQLText);
								ASCIIBytes=Encoding.Convert(Encoding.UTF8,Encoding.Default,UTF8Bytes);
								ASCIIChars=new char[Encoding.Default.GetCharCount(ASCIIBytes,0,ASCIIBytes.Length)];
								Encoding.Default.GetChars(ASCIIBytes,0,ASCIIBytes.Length,ASCIIChars,0);
								SQLText=new string(ASCIIChars);
							#endif
							fstr_out.WriteLine(SQLText+": "+rdr.GetDecimal(SalaryOrdinal));
						}
						fstr_out.WriteLine();
					}
					rdr.Close();

					SQLText="select * from Staff;"+
                            "select Name, Salary from Staff S where (select count(distinct Salary) from Staff where Salary > S.Salary) < 2 order by Salary desc";
					cmd.CommandText=SQLText;
					rdr=cmd.ExecuteReader();
					fstr_out.WriteLine(SQLText);
					do{
						while(rdr.Read())
							fstr_out.WriteLine(rdr["Name"]+": "+rdr["Salary"]);
						fstr_out.WriteLine();
					}while(rdr.NextResult());
					rdr.Close();

					cmd.CommandText="select * from TestTypes";
					fstr_out.WriteLine(cmd.CommandText);
					rdr=cmd.ExecuteReader();
					do
					{
						if(rdr.HasRows)
						{
							tbl=rdr.GetSchemaTable();
                            
							int
								i=0;
							
							foreach(DataRow row in tbl.Rows)
							{
								fstr_out.WriteLine("i="+Convert.ToString(i++)+" ColumnOrdinal="+Convert.ToString(Convert.ToInt32(row["ColumnOrdinal"]))+" \""+row["ColumnName"]+"\" - "+((OleDbType)row["ProviderType"]).ToString()+" ("+row["DataType"].ToString()+") ColumnSize="+row["ColumnSize"].ToString()+" NumericPrecision="+row["NumericPrecision"].ToString()+" NumericScale="+row["NumericScale"].ToString());
							}
							fstr_out.WriteLine();

							fstr_out.WriteLine("Reader.FieldCount="+rdr.FieldCount);
							fstr_out.WriteLine();

							i=0;
							foreach(DataRow row in tbl.Rows)
							{
								fstr_out.WriteLine("i="+Convert.ToString(i)+" ColumnOrdinal="+Convert.ToString(Convert.ToInt32(row["ColumnOrdinal"]))+" \""+row["ColumnName"]+"\" "+(Convert.ToString(row["ColumnName"])==rdr.GetName(i) ? "==" : "!=")+" \""+rdr.GetName(i)+"\"");
								++i;
							}
							fstr_out.WriteLine();

						}
					}while(rdr.NextResult());
					rdr.Close();

					cmd.CommandText="{call sp_SalaryMaxList34}";
					fstr_out.WriteLine(cmd.CommandText);
					rdr=cmd.ExecuteReader();
					do
					{
						if(rdr.HasRows)
						{
							tbl=rdr.GetSchemaTable();
							foreach(DataRow row in tbl.Rows)
							{
								fstr_out.WriteLine(row["ColumnName"]+" - "+((OleDbType)row["ProviderType"]).ToString()+" ("+row["DataType"].ToString()+") ColumnSize="+row["ColumnSize"].ToString()+" NumericPrecision="+row["NumericPrecision"].ToString()+" NumericScale="+row["NumericScale"].ToString());
							}
							fstr_out.WriteLine();

							while(rdr.Read())
								fstr_out.WriteLine(rdr["Name"]+": "+rdr["Salary"]);
							fstr_out.WriteLine();
						}
					}while(rdr.NextResult());
					rdr.Close();

					SQLText=
@"select Salary
from Staff
where
ID=?";
					cmd.CommandText=SQLText;
					cmd.Parameters.Clear();
					cmd.Parameters.Add("@ID",OleDbType.SmallInt).Value=1;
					tmpObject=cmd.ExecuteScalar();
					if(tmpObject!=null)
						SQLText=Convert.ToString(tmpObject);

					SQLText=
@"select ID
from Staff
where
Salary=?";
					cmd.CommandText=SQLText;
					cmd.Parameters.Clear();
					cmd.Parameters.Add("@Salary",OleDbType.Currency).Value=300;
					tmpObject=cmd.ExecuteScalar();
					if(tmpObject!=null)
						SQLText=Convert.ToString(tmpObject);

					SQLText="select count(*) from Staff";
					cmd.CommandText=SQLText;
					fstr_out.WriteLine(SQLText);
					
					tmpObject=cmd.ExecuteScalar();

					int 
					  Res=Convert.ToInt32(cmd.ExecuteScalar());

					if(Res!=0)
					{
						fstr_out.WriteLine(Res.ToString());
						fstr_out.WriteLine();
					}

					SQLText=
@"select Name, Salary
from Staff S
where
(select count(distinct Salary)
 from Staff
 where Salary > S.Salary) < ?
order by Salary desc";
					cmd.CommandText=SQLText;
					cmd.Prepare();
					cmd.Parameters.Clear();
					cmd.Parameters.Add("@MaxCount",OleDbType.Integer).Value=2;
					rdr=cmd.ExecuteReader();
					fstr_out.WriteLine(SQLText);
					fstr_out.WriteLine();

					if(rdr.HasRows)
					{
						int
							NameOrdinal=rdr.GetOrdinal("Name"),
							SalaryOrdinal=rdr.GetOrdinal("Salary");
						
						while(rdr.Read())
						{
							//fstr_out.WriteLine(rdr["Name"]+": "+rdr["Salary"]);
							fstr_out.WriteLine(rdr.GetString(NameOrdinal)+": "+rdr.GetDecimal(SalaryOrdinal));
							fstr_out.WriteLine(rdr.GetType().InvokeMember("GetString",BindingFlags.InvokeMethod,null,rdr,new object[]{NameOrdinal})+": "+rdr.GetType().InvokeMember("GetDecimal",BindingFlags.InvokeMethod,null,rdr,new object[]{SalaryOrdinal})+" (by InvokeMember)");
						}
						fstr_out.WriteLine();
					}
					rdr.Close();

					fstr_out.WriteLine(cmd.CommandText);
					fstr_out.WriteLine("OleDbCommandBuilder.DeriveParameters()");

					cmd.CommandType=CommandType.StoredProcedure;

					cmd.CommandText="sp_TestTypes";
					cmd.Parameters.Clear();
					OleDbCommandBuilder.DeriveParameters(cmd);
					foreach(OleDbParameter param in cmd.Parameters)
					{
						fstr_out.WriteLine(param.ParameterName);
						fstr_out.WriteLine("\tDirection: "+param.Direction.ToString());
						fstr_out.WriteLine("\tOleDbType: "+param.OleDbType.ToString());
						fstr_out.WriteLine("\tDbType: "+param.DbType.ToString()+" ("+Convert.ToInt32(param.DbType)+")");
						fstr_out.WriteLine("\tPrecision: "+param.Precision.ToString());
						fstr_out.WriteLine("\tScale: "+param.Scale.ToString());
						fstr_out.WriteLine("\tSize: "+param.Size.ToString());
						fstr_out.WriteLine();
					}
					fstr_out.WriteLine();
					
					cmd.CommandText="mathtutor";
					cmd.Parameters.Clear();
					OleDbCommandBuilder.DeriveParameters(cmd);
					cmd.Parameters["mult1"].Value=3;
					cmd.Parameters["mult2"].Value=9;
					cmd.ExecuteNonQuery();
					Res=Convert.ToInt32(cmd.Parameters["result"].Value);
					if(Res!=0)
						Res-=Convert.ToInt32(cmd.Parameters["RETURN_VALUE"].Value);

					cmd.CommandText="mathtutor";
					cmd.Parameters.Clear();

					OleDbParameter
						SPRetValue=cmd.Parameters.Add("@return",OleDbType.Integer);

					SPRetValue.Direction=ParameterDirection.ReturnValue;
					cmd.Parameters.Add("@mult1",OleDbType.Integer).Value=5;
					cmd.Parameters.Add("@mult2",OleDbType.Integer).Value=5;

					OleDbParameter
						SPResult=cmd.Parameters.Add("@result",OleDbType.Integer);

					SPResult.Direction=ParameterDirection.Output;

					cmd.ExecuteNonQuery();
					
					Res=Convert.ToInt32(SPResult.Value);
					
					int
						RetValue=Convert.ToInt32(SPRetValue.Value);

					fstr_out.WriteLine(cmd.CommandText+" Result: {0} Return {0}",Res,RetValue);
					fstr_out.WriteLine();

					cmd.CommandType=CommandType.Text;
					cmd.CommandText="{? = call mathtutor(?, ?, ?)}";
					cmd.Parameters.Clear();

					SPRetValue=cmd.Parameters.Add("@return",OleDbType.Integer);
					SPRetValue.Direction=ParameterDirection.ReturnValue;
					//cmd.Parameters["@return"].Direction=ParameterDirection.ReturnValue;

					cmd.Parameters.Add("@mult1",OleDbType.Integer).Value=6;
					cmd.Parameters.Add("@mult2",OleDbType.Integer).Value=6;

					SPResult=cmd.Parameters.Add("@result",OleDbType.Integer);
					SPResult.Direction=ParameterDirection.Output;

					cmd.ExecuteNonQuery();
				
					Res=Convert.ToInt32(SPResult.Value);
					RetValue=Convert.ToInt32(SPRetValue.Value);
					//RetValue=Convert.ToInt32(cmd.Parameters["@return"].Value);

					fstr_out.Write(cmd.CommandText);
					fstr_out.WriteLine(" Result: {0} Return {0}",Res,RetValue);
					fstr_out.WriteLine();

					cmd.Parameters.Clear();
					cmd.CommandText="{CALL sp_SalaryMaxList(?)}";
					cmd.Parameters.Add("@MaxCount",OleDbType.Integer).Value=2;
					rdr=cmd.ExecuteReader();
					fstr_out.WriteLine(cmd.CommandText);
					if(rdr.HasRows)
					{
						int
							NameOrdinal=rdr.GetOrdinal("Name"),
							SalaryOrdinal=rdr.GetOrdinal("Salary");
						
						while(rdr.Read())
						{
							fstr_out.WriteLine(rdr.GetString(NameOrdinal)+": "+rdr.GetDecimal(SalaryOrdinal));
						}
						fstr_out.WriteLine();
					}
					rdr.Close();

					cmd.CommandType=CommandType.Text;
					cmd.CommandText="{? = call sp_SalaryMaxListWReturnOnly(?)}";
					cmd.Parameters.Clear();
					SPRetValue=cmd.Parameters.Add("@return",OleDbType.Integer);
					SPRetValue.Direction=ParameterDirection.ReturnValue;
					cmd.Parameters.Add("@MaxCount",OleDbType.Integer).Value=3;

					if(da==null)
						da=new OleDbDataAdapter();
					if(tbl==null)
						tbl=new DataTable();
					else
						tbl.Reset();

					da.SelectCommand=cmd;
					da.Fill(tbl);
					RetValue=Convert.ToInt32(cmd.Parameters["@return"].Value);

					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="sp_SalaryMaxListWReturnOnly";
					OleDbCommandBuilder.DeriveParameters(cmd);
					cmd.Parameters["MaxCount"].Value=4;
					tbl.Reset();
					da.SelectCommand=cmd;
					da.Fill(tbl);
					RetValue=Convert.ToInt32(cmd.Parameters["RETURN_VALUE"].Value);

					cmd.CommandType=CommandType.Text;
					cmd.CommandText="{? = call sp_SalaryMaxListWReturn_Output(?, ?)}";
					cmd.Parameters.Clear();
					SPRetValue=cmd.Parameters.Add("@return",OleDbType.Integer);
					SPRetValue.Direction=ParameterDirection.ReturnValue;
					cmd.Parameters.Add("@MaxCount",OleDbType.Integer).Value=3;
					SPResult=cmd.Parameters.Add("@RC",OleDbType.Integer);
					SPResult.Direction=ParameterDirection.Output;
					rdr=cmd.ExecuteReader();
					do
					{
						if(rdr.HasRows)
						{
							Res=0;
							while(rdr.Read())
								++Res;
						}
					}while(rdr.NextResult());
					rdr.Close();
					RetValue=Convert.ToInt32(cmd.Parameters["@return"].Value);
					Res=Convert.ToInt32(SPResult.Value);
					// ||
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="sp_SalaryMaxListWReturn_Output";
					OleDbCommandBuilder.DeriveParameters(cmd);
					cmd.Parameters["MaxCount"].Value=4;
					rdr=cmd.ExecuteReader();
					do
					{
						if(rdr.HasRows)
						{
							Res=0;
							while(rdr.Read())
								++Res;
						}
					}while(rdr.NextResult());
					rdr.Close();
					RetValue=Convert.ToInt32(cmd.Parameters["RETURN_VALUE"].Value);
					Res=Convert.ToInt32(cmd.Parameters["RC"].Value);

					cmd.CommandType=CommandType.Text;
					cmd.CommandText="{? = call sp_SalaryMaxListWReturn_Output(?, ?)}";
					cmd.Parameters.Clear();
					SPRetValue=cmd.Parameters.Add("@return",OleDbType.Integer);
					SPRetValue.Direction=ParameterDirection.ReturnValue;
					cmd.Parameters.Add("@MaxCount",OleDbType.Integer).Value=3;
					SPResult=cmd.Parameters.Add("@RC",OleDbType.Integer);
					SPResult.Direction=ParameterDirection.Output;
					da.SelectCommand=cmd;
					tbl.Reset();
					da.Fill(tbl);
					RetValue=Convert.ToInt32(cmd.Parameters["@return"].Value);
					Res=Convert.ToInt32(SPResult.Value);
					// ||
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="sp_SalaryMaxListWReturn_Output";
					OleDbCommandBuilder.DeriveParameters(cmd);
					cmd.Parameters["MaxCount"].Value=4;
					da.SelectCommand=cmd;
					tbl.Reset();
					da.Fill(tbl);
					RetValue=Convert.ToInt32(cmd.Parameters["RETURN_VALUE"].Value);
					Res=Convert.ToInt32(cmd.Parameters["RC"].Value);

					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="sp_ReturnOnly";
					OleDbCommandBuilder.DeriveParameters(cmd);
					cmd.ExecuteNonQuery();
					RetValue=Convert.ToInt32(cmd.Parameters["RETURN_VALUE"].Value);

					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="sp_ReturnAndOutput";
					OleDbCommandBuilder.DeriveParameters(cmd);
					cmd.ExecuteNonQuery();
					RetValue=Convert.ToInt32(cmd.Parameters["RETURN_VALUE"].Value);
					Res=Convert.ToInt32(cmd.Parameters["OutParam"].Value);

					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="sp_ReturnAndOutputAndSelect";
					OleDbCommandBuilder.DeriveParameters(cmd);
					cmd.ExecuteNonQuery();
					RetValue=Convert.ToInt32(cmd.Parameters["RETURN_VALUE"].Value);
					Res=Convert.ToInt32(cmd.Parameters["OutParam"].Value);

					cmd.CommandType=CommandType.Text;
					cmd.CommandText="{call SelectFromStaff(?, ?, ?, ?)}";
					cmd.Parameters.Clear();

					tmpOleDbParameter=new OleDbParameter("Name",OleDbType.VarChar);
					tmpOleDbParameter.Direction=ParameterDirection.Input;
					tmpOleDbParameter.Value=DBNull.Value;
					cmd.Parameters.Add(tmpOleDbParameter);

					tmpOleDbParameter=new OleDbParameter("Salary",OleDbType.Currency);
					tmpOleDbParameter.Direction=ParameterDirection.Input;
					tmpOleDbParameter.Value=1000m;
					cmd.Parameters.Add(tmpOleDbParameter);

					tmpOleDbParameter=new OleDbParameter("Dep",OleDbType.Integer);
					tmpOleDbParameter.Direction=ParameterDirection.Input;
					tmpOleDbParameter.Value=1;
					cmd.Parameters.Add(tmpOleDbParameter);

					tmpOleDbParameter=new OleDbParameter("BirthDate",OleDbType.DBTimeStamp);
					tmpOleDbParameter.Direction=ParameterDirection.Input;
					tmpOleDbParameter.Value=new DateTime(1870,4,22);
					cmd.Parameters.Add(tmpOleDbParameter);

					da.SelectCommand=cmd;
					tbl.Reset();
					da.Fill(tbl);

					cmd.Parameters.Clear();

					tmpOleDbParameter=new OleDbParameter("Name",OleDbType.VarChar);
					tmpOleDbParameter.Direction=ParameterDirection.Input;
					tmpOleDbParameter.Value="%Дем'ян%";
					cmd.Parameters.Add(tmpOleDbParameter);

					tmpOleDbParameter=new OleDbParameter("Salary",OleDbType.Currency);
					tmpOleDbParameter.Direction=ParameterDirection.Input;
					tmpOleDbParameter.Value=DBNull.Value;
					cmd.Parameters.Add(tmpOleDbParameter);

					tmpOleDbParameter=new OleDbParameter("Dep",OleDbType.Integer);
					tmpOleDbParameter.Direction=ParameterDirection.Input;
					tmpOleDbParameter.Value=DBNull.Value;
					cmd.Parameters.Add(tmpOleDbParameter);

					tmpOleDbParameter=new OleDbParameter("BirthDate",OleDbType.DBTimeStamp);
					tmpOleDbParameter.Direction=ParameterDirection.Input;
					tmpOleDbParameter.Value=DBNull.Value;
					cmd.Parameters.Add(tmpOleDbParameter);

					da.SelectCommand=cmd;
					tbl.Reset();
					da.Fill(tbl);

					cmd.CommandType=CommandType.Text;
					cmd.CommandText=@"
select *
from
Staff
where
Name like ?
";
					cmd.Parameters.Clear();
					SQLText="м'я";
					tmpOleDbParameter=new OleDbParameter("Name",OleDbType.VarChar);
					tmpOleDbParameter.Direction=ParameterDirection.Input;
					tmpOleDbParameter.Value="%"+SQLText+"%";
					// tmpOleDbParameter.Value="%"+SQLText.Replace("'","''")+"%"; // Wrong!!! Never do so!!!
					cmd.Parameters.Add(tmpOleDbParameter);
					da.SelectCommand=cmd;
					tbl.Reset();
					da.Fill(tbl);

					#if TEST_TRANSACTION
						cmd.CommandType=CommandType.StoredProcedure;
						cmd.CommandText="TestTransaction";

						cmd.Parameters.Clear();
						OleDbCommandBuilder.DeriveParameters(cmd);
						cmd.Parameters["WithSelfTransaction"].Value=0;
						cmd.ExecuteNonQuery();

						int
							TransactionCount=Convert.ToInt32(cmd.Parameters["TransactionCount"].Value),
							TransactionState=Convert.ToInt32(cmd.Parameters["TransactionState"].Value),
							TransactionChained=Convert.ToInt32(cmd.Parameters["TransactionChained"].Value);

						cmd.Parameters.Clear();
						OleDbCommandBuilder.DeriveParameters(cmd);
						cmd.Parameters["WithSelfTransaction"].Value=1;
						cmd.ExecuteNonQuery();
						TransactionCount=Convert.ToInt32(cmd.Parameters["TransactionCount"].Value);
						TransactionState=Convert.ToInt32(cmd.Parameters["TransactionState"].Value);
						TransactionChained=Convert.ToInt32(cmd.Parameters["TransactionChained"].Value);

						OleDbTransaction
							Transaction=cn.BeginTransaction(IsolationLevel.ReadCommitted);

						cmd.Transaction=Transaction;

						cmd.Parameters.Clear();
						OleDbCommandBuilder.DeriveParameters(cmd);
						cmd.Parameters["WithSelfTransaction"].Value=0;
						cmd.ExecuteNonQuery();
						TransactionCount=Convert.ToInt32(cmd.Parameters["TransactionCount"].Value);
						TransactionState=Convert.ToInt32(cmd.Parameters["TransactionState"].Value);
						TransactionChained=Convert.ToInt32(cmd.Parameters["TransactionChained"].Value);

						cmd.Parameters.Clear();
						OleDbCommandBuilder.DeriveParameters(cmd);
						cmd.Parameters["WithSelfTransaction"].Value=1;
						cmd.ExecuteNonQuery();
						TransactionCount=Convert.ToInt32(cmd.Parameters["TransactionCount"].Value);
						TransactionState=Convert.ToInt32(cmd.Parameters["TransactionState"].Value);
						TransactionChained=Convert.ToInt32(cmd.Parameters["TransactionChained"].Value);

						Transaction.Commit();

						cmd.Parameters.Clear();
						OleDbCommandBuilder.DeriveParameters(cmd);
						cmd.Parameters["WithSelfTransaction"].Value=0;
						cmd.ExecuteNonQuery();
						TransactionCount=Convert.ToInt32(cmd.Parameters["TransactionCount"].Value);
						TransactionState=Convert.ToInt32(cmd.Parameters["TransactionState"].Value);
						TransactionChained=Convert.ToInt32(cmd.Parameters["TransactionChained"].Value);

						cmd.Parameters.Clear();
						OleDbCommandBuilder.DeriveParameters(cmd);
						cmd.Parameters["WithSelfTransaction"].Value=1;
						cmd.ExecuteNonQuery();
						TransactionCount=Convert.ToInt32(cmd.Parameters["TransactionCount"].Value);
						TransactionState=Convert.ToInt32(cmd.Parameters["TransactionState"].Value);
						TransactionChained=Convert.ToInt32(cmd.Parameters["TransactionChained"].Value);
					#endif

					cmd.CommandType=CommandType.Text;
					cmd.Parameters.Clear();
					SQLText="select * from Staff";
					cmd.CommandText=SQLText;
					rdr=cmd.ExecuteReader();
					fstr_out.WriteLine(cmd.CommandText);

					object[]
						aData=new object[rdr.FieldCount];

					while(rdr.Read())
					{
						rdr.GetValues(aData);
						fstr_out.WriteLine(aData[0].ToString()+" "+aData[1]+": "+aData[2].ToString());
					}
					rdr.Close();
					fstr_out.WriteLine();

					ds=new DataSet("DataSetName");
					ds.Locale=new CultureInfo("ru-RU");
					SQLText=ds.Locale.DisplayName;

					//vs DataAdapter ;)
					tbl=ds.Tables.Add("Staff");
					tbl.Columns.Add("Name",Type.GetType("System.String"));
					SQLText="select * from Staff";
					cmd.CommandText=SQLText;
					rdr=cmd.ExecuteReader();
					
					DataRow
						rw;

					while(rdr.Read())
					{
						rw=tbl.NewRow();
						rw["Name"]=rdr["Name"];
						tbl.Rows.Add(rw);
					}
					rdr.Close();

					fstr_out.WriteLine("vs DataAdapter ;)");
					foreach(DataRow row in tbl.Rows)
						fstr_out.WriteLine(row["Name"]);
					fstr_out.WriteLine();

					SQLText="select ID as IdentificationNumber, Name as FullName, Salary as MinimumSalary from Staff order by ID";

					//da=new OleDbDataAdapter(SQLText,strConn);
					// ||
					//da=new OleDbDataAdapter(SQLText,cn);
					// ||
					// cmd.CommandText=SQLText;
					//da=new OleDbDataAdapter(cmd);
					// ||
					cmd.CommandText=SQLText;
					if(da==null)
						da=new OleDbDataAdapter();
					da.SelectCommand=cmd;

					da.FillError+=new FillErrorEventHandler(da_FillError);
					da.RowUpdated+=new OleDbRowUpdatedEventHandler(da_RowUpdated);
					da.RowUpdating+=new OleDbRowUpdatingEventHandler(da_RowUpdating);

					DataTableMapping
						TblMap=null;

					TblMap=da.TableMappings.Add("Table","Staff");

					DataColumnMapping
						ColMap=null;
					
					ColMap=TblMap.ColumnMappings.Add("ID","IdentificationNumber");
					ColMap=TblMap.ColumnMappings.Add("Name","FullName");
					ColMap=TblMap.ColumnMappings.Add("Salary","MinimumSalary");
					// ||
					//DataColumnMapping[]
					//	ColMapArray;

					//ColMapArray=new DataColumnMapping[]
					//	{new DataColumnMapping("ID","IdentificationNumber"),
					//	new DataColumnMapping("Name","FullName"),
					//	new DataColumnMapping("Salary","MinimumSalary")
					//	};

					//TblMap.ColumnMappings.AddRange(ColMapArray);

					//da.MissingMappingAction=MissingMappingAction.Error;
					//da.MissingSchemaAction=MissingSchemaAction.Error;

					ds.Reset();
					da.FillSchema(ds,SchemaType.Source,"Staff");
					fstr_out.WriteLine("DataAdapter.FillSchema()");
					foreach(DataTable table in ds.Tables)
					{
						fstr_out.WriteLine(table.TableName+": ");
						for(int i=0; i<table.Columns.Count; ++i)
						{
							fstr_out.WriteLine(table.Columns[i].ColumnName+" "+table.Columns[i].ColumnMapping+" "+table.Columns[i].Caption+" "+table.Columns[i].DataType.ToString()+" "+table.Columns[i].MaxLength.ToString());
						}
						fstr_out.WriteLine();
					}

					ds.Reset();
					da.Fill(ds,2,4,"Staff");
					fstr_out.WriteLine(da.SelectCommand.CommandText);
					foreach(DataRow row in ds.Tables[0].Rows)
						fstr_out.WriteLine(row["IdentificationNumber"].ToString()+" "+row["FullName"]+" "+row["MinimumSalary"].ToString());
					fstr_out.WriteLine();

					SQLText="select Name, Salary, Dep from Staff;"+
						"select Name, Salary from Staff S where (select count(distinct Salary) from Staff where Salary > S.Salary) < 2 order by Salary desc";
					da.SelectCommand.CommandText=SQLText;
					da.TableMappings.Clear();
					da.TableMappings.Add("Table","FullSelect");
					da.TableMappings.Add("Table1","MaxCount2Select");
					ds.Reset();
					ds.EnforceConstraints=false;
					da.Fill(ds);
					ds.EnforceConstraints=true;

					tmpDataRows=ds.Tables["FullSelect"].Select(string.Empty);
					tmpDataRows=ds.Tables["FullSelect"].Select("not (Dep in (2, 3))");
					tmpDataRows=ds.Tables["FullSelect"].Select("Dep in (2, 3)");

					tbl=ds.Tables[1];
					fstr_out.WriteLine("Column information for "+tbl.TableName+" DataTable");
					foreach(DataColumn col in tbl.Columns)
						fstr_out.WriteLine("\t"+col.ColumnName+" - "+col.DataType.ToString());
					fstr_out.WriteLine();

					rw=tbl.Rows[0];
					fstr_out.WriteLine(rw["Name"]+" "+rw["Salary"].ToString());
					fstr_out.WriteLine();

					foreach(DataTable table in ds.Tables)
					{
						fstr_out.WriteLine(table.TableName);
						Res=0;
						foreach(DataRow row in table.Rows)
						{
							fstr_out.WriteLine(row["Name"]+" "+row["Salary"].ToString());
							++Res;
							Console.WriteLine("Contents of row #"+Res.ToString());
							DisplayRow(row);
						}
						fstr_out.WriteLine();
					}
					
					SQLText="sp_SalaryMaxList34";
					cmd.CommandText=SQLText;
					cmd.CommandType=CommandType.StoredProcedure;
					da.TableMappings.Clear();
					da.TableMappings.Add("Table","MaxCount3Select");
					da.TableMappings.Add("Table1","MaxCount4Select");
					da.SelectCommand=cmd;
					ds.Reset();
					ds.EnforceConstraints=false;
					da.Fill(ds);
					ds.EnforceConstraints=true;
					foreach(DataTable table in ds.Tables)
					{
						fstr_out.WriteLine(table.TableName);
						Res=0;
						foreach(DataRow row in table.Rows)
						{
							fstr_out.WriteLine(row["Name"]+" "+row["Salary"].ToString());
							++Res;
							Console.WriteLine("Contents of row #"+Res.ToString());
							DisplayRow(row);
						}
						fstr_out.WriteLine();
					}

					SQLText="select Name, Salary from Staff S where (select count(distinct Salary) from Staff where Salary > S.Salary) < ? order by Salary desc";
					cmd.CommandText=SQLText;
					cmd.CommandType=CommandType.Text;
					da.TableMappings.Clear();
					da.SelectCommand=cmd;
					da.SelectCommand.Parameters.Add("@MaxCount",OleDbType.Integer);
					da.GetFillParameters()[0].Value=2;
					ds.Reset();
					da.Fill(ds);
					foreach(DataTable table in ds.Tables)
					{
						fstr_out.WriteLine(table.TableName);
						Res=0;
						foreach(DataRow row in table.Rows)
						{
							fstr_out.WriteLine(row["Name"]+" "+row["Salary"].ToString());
							++Res;
							Console.WriteLine("Contents of row #"+Res.ToString());
							DisplayRow(row);
						}
						fstr_out.WriteLine();
					}

					DataColumn
						cl;

					ds.Reset();
					
					tbl=ds.Tables.Add("Customers");
					// ||
					//tbl=new DataTable("Customers");
					//ds.Tables.Add(tbl);

					cl=tbl.Columns.Add("CustomerID",typeof(int));
					cl.AllowDBNull=false;
					cl.Unique=true;
					cl.AutoIncrement=true;
					cl.AutoIncrementSeed=-1;
					cl.AutoIncrementStep=-1;
					cl.ReadOnly=true;
					tbl.PrimaryKey=new DataColumn[]{tbl.Columns["CustomerID"]};
					// || (if Unique==false)
					//tbl.Constraints.Add(new UniqueConstraint(tbl.Columns["CustomerID"]));
					// || (if Unique==false)
					//tbl.Constraints.Add("UK_Customers",tbl.Columns["CustomerID"],false);

					tbl=ds.Tables.Add("Orders");
					tbl.Columns.Add("OrderID",typeof(int));
					tbl.PrimaryKey=new DataColumn[]{tbl.Columns["OrderID"]};

					tbl=ds.Tables.Add("Order Details");
					tbl.Columns.Add("OrderID",typeof(int));
					tbl.Columns.Add("ProductID",typeof(int));
					tbl.Columns.Add("Quantity",typeof(int));
					tbl.Columns.Add("UnitPrice",typeof(Decimal));
					tbl.Columns.Add("ItemTotal",typeof(Decimal),"Quantity * UnitPrice");
					tbl.PrimaryKey=new DataColumn[]{tbl.Columns["OrderID"],tbl.Columns["ProductID"]};
					// ||
					//
					// DataColumn[]
					//	cols=new DataColumn[]{tbl.Columns["OrderID"],tbl.Columns["ProductID"]};
					//
					//tbl.Constraints.Add(new UniqueConstraint(cols));
					// ||
					//tbl.Constraints.Add("UK_Order Details",cols,false);
					
					IEnumerator
						enumTables=ds.Tables.GetEnumerator();

					Console.WriteLine();
					while(enumTables.MoveNext())
					{
						tbl=enumTables.Current as DataTable;
						if(tbl!=null)
						{
							Console.WriteLine(tbl.TableName);
							for(int j=0; j<tbl.Columns.Count; ++j)
								Console.WriteLine("\t"+tbl.Columns[j].ColumnName);
						}
					}
					Console.WriteLine();

					tbl.Constraints.Add(new ForeignKeyConstraint(ds.Tables["Orders"].Columns["OrderID"],tbl.Columns["OrderID"]));
					// ||
					//tbl.Constraints.Add("FK_Order Details_Orders",ds.Tables["Orders"].Columns["OrderID"],tbl.Columns["OrderID"]);

					ds.Reset();
					tbl=ds.Tables.Add("Customers");
					cl=tbl.Columns.Add("CustomerID",typeof(string));
					cl.MaxLength=5;
					cl=tbl.Columns.Add("CompanyName",typeof(string));
					cl.MaxLength=40;
					cl=tbl.Columns.Add("ContactName",typeof(string));
					cl.MaxLength=30;
					cl=tbl.Columns.Add("Phone",typeof(string));
					cl.MaxLength=24;
					tbl.Columns.Add("CreateDate",typeof(DateTime));
					tbl.PrimaryKey=new DataColumn[]{tbl.Columns["CustomerID"]};

					tbl=ds.Tables.Add("Orders");
					cl=tbl.Columns.Add("OrderID",typeof(int));
					cl.AutoIncrement=true;
					cl.AutoIncrementSeed=-1;
					cl.AutoIncrementStep=-1;
					cl.ReadOnly=true;
					cl=tbl.Columns.Add("CustomerID",typeof(string));
					cl.AllowDBNull=false;
					cl.MaxLength=5;
					tbl.Columns.Add("EmployeeID",typeof(int));
					tbl.Columns.Add("OrderDate",typeof(DateTime));
					tbl.PrimaryKey=new DataColumn[]{tbl.Columns["OrderID"]};
					
					tbl=ds.Tables.Add("Order Details");
					tbl.Columns.Add("OrderID",typeof(int));
					tbl.Columns.Add("ProductID",typeof(int));
					cl=tbl.Columns.Add("UnitPrice",typeof(Decimal));
					cl.AllowDBNull=false;
					cl=tbl.Columns.Add("Quantity",typeof(int));
					cl.AllowDBNull=false;
					cl.DefaultValue=1;
					cl=tbl.Columns.Add("Discount",typeof(Decimal));
					cl.DefaultValue=0;
					tbl.Columns.Add("ItemTotal",typeof(Decimal),"Quantity * UnitPrice * (1 - Discount)");
					tbl.PrimaryKey=new DataColumn[]{tbl.Columns["OrderID"],tbl.Columns["ProductID"]};

					enumTables=ds.Tables.GetEnumerator();
					Console.WriteLine();
					while(enumTables.MoveNext())
					{
						Console.WriteLine(((DataTable)enumTables.Current).TableName);
						for(int j=0; j<((DataTable)enumTables.Current).Columns.Count; ++j)
							Console.WriteLine("\t"+((DataTable)enumTables.Current).Columns[j].ColumnName);
					}
					Console.WriteLine();

					ForeignKeyConstraint
						fk=null;

					fk=new ForeignKeyConstraint("fk_Customers_Orders",ds.Tables["Customers"].Columns["CustomerID"],ds.Tables["Orders"].Columns["CustomerID"]);
					ds.Tables["Orders"].Constraints.Add(fk);

					fk=new ForeignKeyConstraint("fk_Orders_OrderDetails",ds.Tables["Orders"].Columns["OrderID"],ds.Tables["Order Details"].Columns["OrderID"]);
					fk.DeleteRule=Rule.Cascade;
					fk.UpdateRule=Rule.Cascade;
					ds.Tables["Order Details"].Constraints.Add(fk);
					
					DataRelation
						rel;

					rel=new DataRelation("Customers_Orders",ds.Tables["Customers"].Columns["CustomerID"],ds.Tables["Orders"].Columns["CustomerID"]);
					ds.Relations.Add(rel);
					rel=new DataRelation("Orders_OrderDetails",ds.Tables["Orders"].Columns["OrderID"],ds.Tables["Order Details"].Columns["OrderID"]);
					ds.Relations.Add(rel);

					rw=ds.Tables["Customers"].NewRow();
					rw["CustomerID"]="ALFKI";
					rw["CreateDate"]=DateTime.Now.Date.AddDays(-3);
					ds.Tables["Customers"].Rows.Add(rw);

					object[]
						aValues={"ALFKY","Alfreds Futterkiste","Maria Anders","030-0074321",DateTime.Now.Date};

					ds.Tables["Customers"].LoadDataRow(aValues,false);

					tmpDataRows=ds.Tables["Customers"].Select("CreateDate='"+DateTime.Now.Date.AddDays(-3).ToString()+"'");
					if(tmpDataRows.Length>0)
					{
						SQLText="CreateDate='"+DateTime.Now.Date.ToString()+"'";
						tmpDataRows=ds.Tables["Customers"].Select(SQLText);
						if(tmpDataRows.Length>0)
							tmpDataRows[0]["CreateDate"]=DateTime.Now.Date.AddYears(-3);
						tmpDataRows=ds.Tables["Customers"].Select(@"CustomerID='ALF''KY'");
						if(tmpDataRows.Length>0)
							SQLText=Convert.ToDateTime(tmpDataRows[0]["CreateDate"]).ToString();
					}

					tmpDataRows=ds.Tables["Customers"].Select("CreateDate=#"+DateTime.Now.Date.AddDays(-3).ToString(CultureInfo.InvariantCulture)+"#");
					if(tmpDataRows.Length>0)
					{
						SQLText="CreateDate=#"+DateTime.Now.Date.AddYears(-3).ToString(CultureInfo.InvariantCulture)+"#";
						tmpDataRows=ds.Tables["Customers"].Select(SQLText);
						if(tmpDataRows.Length>0)
							tmpDataRows[0]["CreateDate"]=DateTime.Now.Date.AddYears(3);
						tmpDataRows=ds.Tables["Customers"].Select(@"CustomerID='ALF''KY'");
						if(tmpDataRows.Length>0)
							SQLText=Convert.ToDateTime(tmpDataRows[0]["CreateDate"]).ToString();
					}

					rw=ds.Tables["Customers"].Rows.Find("ANTON");
					if(rw!=null)
					{
						rw.BeginEdit();
						rw["CompanyName"]="NewCompanyName";
						rw["ContactName"]="NewContactName";
						fstr_out.WriteLine(rw["CompanyName",DataRowVersion.Current]);
						fstr_out.WriteLine(rw["CompanyName",DataRowVersion.Original]);
						rw.EndEdit();
						fstr_out.WriteLine(rw["CompanyName",DataRowVersion.Current]);
						fstr_out.WriteLine(rw["CompanyName",DataRowVersion.Original]);
					}

					object[]
						aCustomer={null,"NewCompanyName","NewContactName",null,DateTime.Now.AddDays(-1)};

					rw=ds.Tables["Customers"].Rows.Find("ALFKI");
					if(rw!=null)
					{
						rw.BeginEdit();
						rw.ItemArray=aCustomer;
						rw.EndEdit();
					}

					rw=ds.Tables["Customers"].Rows.Find("ALFKI");
					if(rw!=null)
					{
						ds.Tables["Customers"].ColumnChanged+=new DataColumnChangeEventHandler(dt_ColumnChanged);
						ds.Tables["Customers"].ColumnChanging+=new DataColumnChangeEventHandler(dt_ColumnChanging);
						if(!rw.IsNull("Phone"))
						{
							fstr_out.WriteLine(rw["Phone"]);
							rw.BeginEdit();
							rw["Phone"]=DBNull.Value;
							rw.EndEdit();
						}
						else
						{
							rw.BeginEdit();
							rw["Phone"]="537-06-60";
							rw.EndEdit();
						}
						ds.Tables["Customers"].ColumnChanged-=new DataColumnChangeEventHandler(dt_ColumnChanged);
						ds.Tables["Customers"].ColumnChanging-=new DataColumnChangeEventHandler(dt_ColumnChanging);
					}

					rw.Delete();
					//ds.Tables["Customers"].Rows.Remove(rw);
					// ||
					//ds.Tables["Customers"].Rows.RemoveAt(1);

					foreach(DataRelation Rel in ds.Relations)
					{
						SQLText="";
						SQLText+=Rel.RelationName;
						SQLText+=" ";
						SQLText+=Rel.ParentTable.TableName;
						SQLText+=" ";
						SQLText+=Rel.ChildTable.TableName;
					}
					tbl=ds.Tables["Customers"];
					tbl.Clear();

					tbl.ColumnChanged+=new DataColumnChangeEventHandler(dt_ColumnChanged);
					tbl.ColumnChanging+=new DataColumnChangeEventHandler(dt_ColumnChanging);
					tbl.RowChanged+=new DataRowChangeEventHandler(dt_RowChanged);
					tbl.RowChanging+=new DataRowChangeEventHandler(dt_RowChanging);
					tbl.RowDeleted+=new DataRowChangeEventHandler(dt_RowDeleted);
					tbl.RowDeleting+=new DataRowChangeEventHandler(dt_RowDeleting);
					
					rw=tbl.NewRow();
					rw["CustomerID"]="1";
					rw["CompanyName"]="1st";
					rw["ContactName"]="Lenin";
					rw["Phone"]="01";
					tbl.Rows.Add(rw);
					aValues[0]="2";
					aValues[1]="2nd";
					aValues[2]="Stalin";
					aValues[3]="02";
					rw=tbl.LoadDataRow(aValues,false);
					rw=tbl.NewRow();
					rw["CustomerID"]="3";
					rw["CompanyName"]="3rd";
					rw["ContactName"]="Khruschev";
					rw["Phone"]="03";
					tbl.Rows.Add(rw);

					fstr_out.WriteLine();
					foreach(DataRow row in tbl.Rows)
					{
						SQLText="";
						if(row.HasVersion(DataRowVersion.Current))
						{
							if(SQLText.Length!=0)
								SQLText+=" ";
							SQLText+="Current: "+row["ContactName",DataRowVersion.Current];
						}
						if(row.HasVersion(DataRowVersion.Original))
						{
							if(SQLText.Length!=0)
								SQLText+=" ";
							SQLText+="Original: "+row["ContactName",DataRowVersion.Original];
						}
						
						// DataRowVersion.Proposed exists only with BeginEdit && etc.
						if(row.HasVersion(DataRowVersion.Proposed))
						{
							if(SQLText.Length!=0)
								SQLText+=" ";
							SQLText+="Proposed: "+row["ContactName",DataRowVersion.Proposed];
						}
						if(row.HasVersion(DataRowVersion.Default))
						{
							if(SQLText.Length!=0)
								SQLText+=" ";
							SQLText+="Default: "+row["ContactName",DataRowVersion.Default];
						}

						fstr_out.Write(SQLText);
						fstr_out.WriteLine(" RowState: "+row.RowState.ToString());
					}

					tbl.AcceptChanges();

					Res=Convert.ToInt32(tbl.Compute("count(CustomerID)","CustomerID='1'"));
					
					rw=tbl.Rows[0];
					rw["ContactName"]=rw["ContactName"].ToString()+" "+rw["ContactName"].ToString();
					rw=tbl.Rows[1];
					aValues[0]=null;
					aValues[1]=null;
					aValues[2]=rw["ContactName"].ToString()+" "+rw["ContactName"].ToString();
					aValues[3]=null;
					rw.ItemArray=aValues;
					rw=tbl.Rows[2];
					rw["ContactName"]=rw["ContactName"].ToString()+" "+rw["ContactName"].ToString();

					fstr_out.WriteLine();
					foreach(DataRow row in tbl.Rows)
					{
						SQLText="";
						if(row.HasVersion(DataRowVersion.Current))
						{
							if(SQLText.Length!=0)
								SQLText+=" ";
							SQLText+="Current: "+row["ContactName",DataRowVersion.Current];
						}
						if(row.HasVersion(DataRowVersion.Original))
						{
							if(SQLText.Length!=0)
								SQLText+=" ";
							SQLText+="Original: "+row["ContactName",DataRowVersion.Original];
						}
						if(row.HasVersion(DataRowVersion.Proposed))
						{
							if(SQLText.Length!=0)
								SQLText+=" ";
							SQLText+="Proposed: "+row["ContactName",DataRowVersion.Proposed];
						}
						if(row.HasVersion(DataRowVersion.Default))
						{
							if(SQLText.Length!=0)
								SQLText+=" ";
							SQLText+="Default: "+row["ContactName",DataRowVersion.Default];
						}

						fstr_out.Write(SQLText);
						fstr_out.WriteLine(" RowState: "+row.RowState.ToString());
					}
					
					tbl.AcceptChanges();
					
					fstr_out.WriteLine();
					foreach(DataRow row in tbl.Rows)
					{
						SQLText="";
						if(row.HasVersion(DataRowVersion.Current))
						{
							if(SQLText.Length!=0)
								SQLText+=" ";
							SQLText+="Current: "+row["ContactName",DataRowVersion.Current];
						}
						if(row.HasVersion(DataRowVersion.Original))
						{
							if(SQLText.Length!=0)
								SQLText+=" ";
							SQLText+="Original: "+row["ContactName",DataRowVersion.Original];
						}
						if(row.HasVersion(DataRowVersion.Proposed))
						{
							if(SQLText.Length!=0)
								SQLText+=" ";
							SQLText+="Proposed: "+row["ContactName",DataRowVersion.Proposed];
						}
						if(row.HasVersion(DataRowVersion.Default))
						{
							if(SQLText.Length!=0)
								SQLText+=" ";
							SQLText+="Default: "+row["ContactName",DataRowVersion.Default];
						}

						fstr_out.Write(SQLText);
						fstr_out.WriteLine(" RowState: "+row.RowState.ToString());
					}
					
					rw=tbl.Rows[1];
					rw.BeginEdit();
					rw["ContactName"]="BeginEdit()";
					fstr_out.WriteLine();
					foreach(DataRow row in tbl.Rows)
					{
						SQLText="";
						if(row.HasVersion(DataRowVersion.Current))
						{
							if(SQLText.Length!=0)
								SQLText+=" ";
							SQLText+="Current: "+row["ContactName",DataRowVersion.Current];
						}
						if(row.HasVersion(DataRowVersion.Original))
						{
							if(SQLText.Length!=0)
								SQLText+=" ";
							SQLText+="Original: "+row["ContactName",DataRowVersion.Original];
						}
						if(row.HasVersion(DataRowVersion.Proposed))
						{
							if(SQLText.Length!=0)
								SQLText+=" ";
							SQLText+="Proposed: "+row["ContactName",DataRowVersion.Proposed];
						}
						if(row.HasVersion(DataRowVersion.Default))
						{
							if(SQLText.Length!=0)
								SQLText+=" ";
							SQLText+="Default: "+row["ContactName",DataRowVersion.Default];
						}

						fstr_out.Write(SQLText);
						fstr_out.WriteLine(" RowState: "+row.RowState.ToString());
					}
					
					rw.EndEdit();
					fstr_out.WriteLine();
					foreach(DataRow row in tbl.Rows)
					{
						SQLText="";
						if(row.HasVersion(DataRowVersion.Current))
						{
							if(SQLText.Length!=0)
								SQLText+=" ";
							SQLText+="Current: "+row["ContactName",DataRowVersion.Current];
						}
						if(row.HasVersion(DataRowVersion.Original))
						{
							if(SQLText.Length!=0)
								SQLText+=" ";
							SQLText+="Original: "+row["ContactName",DataRowVersion.Original];
						}
						if(row.HasVersion(DataRowVersion.Proposed))
						{
							if(SQLText.Length!=0)
								SQLText+=" ";
							SQLText+="Proposed: "+row["ContactName",DataRowVersion.Proposed];
						}
						if(row.HasVersion(DataRowVersion.Default))
						{
							if(SQLText.Length!=0)
								SQLText+=" ";
							SQLText+="Default: "+row["ContactName",DataRowVersion.Default];
						}

						fstr_out.Write(SQLText);
						fstr_out.WriteLine(" RowState: "+row.RowState.ToString());
					}

					tbl.AcceptChanges();

					fstr_out.WriteLine();
					foreach(DataRow row in tbl.Rows)
					{
						SQLText="";
						if(row.HasVersion(DataRowVersion.Current))
						{
							if(SQLText.Length!=0)
								SQLText+=" ";
							SQLText+="Current: "+row["ContactName",DataRowVersion.Current];
						}
						if(row.HasVersion(DataRowVersion.Original))
						{
							if(SQLText.Length!=0)
								SQLText+=" ";
							SQLText+="Original: "+row["ContactName",DataRowVersion.Original];
						}
						if(row.HasVersion(DataRowVersion.Proposed))
						{
							if(SQLText.Length!=0)
								SQLText+=" ";
							SQLText+="Proposed: "+row["ContactName",DataRowVersion.Proposed];
						}
						if(row.HasVersion(DataRowVersion.Default))
						{
							if(SQLText.Length!=0)
								SQLText+=" ";
							SQLText+="Default: "+row["ContactName",DataRowVersion.Default];
						}

						fstr_out.Write(SQLText);
						fstr_out.WriteLine(" RowState: "+row.RowState.ToString());
					}

					tbl=ds.Tables["Orders"];
					foreach(DataColumn col in tbl.PrimaryKey)
					{
						SQLText="";
						SQLText+=col.Table;
						SQLText+=" ";
						SQLText+=col.ColumnName;
					}
					for(int i=0; i<tbl.Constraints.Count; ++i)
					{
						SQLText="";
						SQLText+=tbl.Constraints[i].ConstraintName;
						SQLText+=" ";
						SQLText+=tbl.Constraints[i].Table;
						SQLText+=" ";
						SQLText+=tbl.Constraints[i].ToString();
						SQLText+=" ";
						SQLText+=tbl.Constraints[i].GetType().ToString();
						if(tbl.Constraints[i].GetType()==typeof(System.Data.UniqueConstraint))
						{
							SQLText+=" ";
							SQLText+=(tbl.Constraints[i] as System.Data.UniqueConstraint).ConstraintName;
						}
						if(tbl.Constraints[i].GetType()==typeof(System.Data.ForeignKeyConstraint))
						{
							fk=tbl.Constraints[i] as System.Data.ForeignKeyConstraint;
							SQLText+=" ";
							SQLText+=fk.RelatedTable.TableName;
						}
					}
					
					rw=tbl.NewRow();
					rw["CustomerID"]="2";
					rw["EmployeeID"]=1;
					rw["OrderDate"]=DateTime.Now;
					tbl.Rows.Add(rw);
					rw=tbl.NewRow();
					rw["CustomerID"]="2";
					rw["EmployeeID"]=2;
					rw["OrderDate"]=DateTime.Now;
					tbl.Rows.Add(rw);
					rw=tbl.NewRow();
					rw["CustomerID"]="2";
					rw["EmployeeID"]=3;
					rw["OrderDate"]=DateTime.Now;
					tbl.Rows.Add(rw);

					if(rw.HasErrors)
					{
						SQLText="";
						foreach(DataColumn col in rw.GetColumnsInError())
						{
							if(SQLText.Length!=0)
								SQLText+="\n";
							SQLText="Error in "+col.ColumnName+": "+rw.GetColumnError(col);
						}

					}

					fstr_out.WriteLine();
					foreach(DataRow rowCustomer in ds.Tables["Customers"].Rows)
					{
						foreach(DataRow rowOrder in rowCustomer.GetChildRows("Customers_Orders"))
						{
							SQLText="";
							SQLText+=rowOrder["OrderID"];
							SQLText+=" ";
							SQLText+=rowOrder["CustomerID"];
							SQLText+=" ";
							SQLText+=rowOrder["EmployeeID"];
							SQLText+=" ";
							SQLText+=rowOrder["OrderDate"];
							fstr_out.WriteLine(SQLText);
						}
					}

					foreach(DataRelation Rel in tbl.ParentRelations)
					{
						SQLText="";
						rw=tbl.Rows[0].GetParentRow(Rel);
						SQLText+=rw["CustomerID"];
						SQLText+=" ";
						SQLText+=rw["CompanyName"];
					}

					rw=ds.Tables["Order Details"].NewRow();
					rw["OrderId"]=-2;
					rw["ProductID"]=1;
					rw["UnitPrice"]=100;
					ds.Tables["Order Details"].Rows.Add(rw);
					rw=ds.Tables["Order Details"].NewRow();
					rw["OrderId"]=-2;
					rw["ProductID"]=2;
					rw["UnitPrice"]=200;
					ds.Tables["Order Details"].Rows.Add(rw);
					rw=ds.Tables["Order Details"].NewRow();
					rw["OrderId"]=-2;
					rw["ProductID"]=3;
					rw["UnitPrice"]=300;
					ds.Tables["Order Details"].Rows.Add(rw);

					DataRow[]
						aRows;

					foreach(DataRelation Rel in tbl.ChildRelations)
					{
						aRows=tbl.Rows[1].GetChildRows(Rel);
						SQLText="";
						for(int i=0; i<aRows.Length; ++i)
						{
							if(SQLText.Length!=0)
								SQLText+=" ";
							SQLText+=aRows[i]["OrderId"].ToString()+" "+aRows[i]["ProductID"].ToString();
						}
					}
					
					object[]
						KeyValues=new object[]{-2,1};

					rw=ds.Tables["Order Details"].Rows.Find(KeyValues);
					if(rw!=null)
						SQLText=rw["OrderId"].ToString()+" "+rw["ProductID"].ToString();
					else
						SQLText="Row not found!!!";

					aRows=ds.Tables["Order Details"].Select("((OrderId=-2) and (UnitPrice>100))","UnitPrice DESC",DataViewRowState.OriginalRows);
					foreach(DataRow row in aRows)
					{
						SQLText="";
						if(SQLText.Length!=0)
							SQLText+=" ";
						SQLText+=row["OrderId"].ToString()+" "+row["ProductID"].ToString();
					}

					DataView
						view;

					view=new DataView();
					view.Table=ds.Tables["Order Details"];
					view.RowFilter="((OrderId=-2) and (UnitPrice>100))";
					view.Sort="OrderId, UnitPrice DESC";
					view.RowStateFilter=DataViewRowState.Added|DataViewRowState.Deleted;
					// ||
					// view=new DataView(ds.Tables["Order Details"],"((OrderId=-2) and (UnitPrice>100))","UnitPrice DESC",DataViewRowState.ModifiedOriginal|DataViewRowState.CurrentRows);

					DataRowView
						drw=view[0];

					SQLText+=drw["OrderId"].ToString()+" "+drw["ProductID"].ToString();

					for(int i=0; i<view.Count; ++i)
					{
						drw=view[i];
						SQLText="";
						if(SQLText.Length!=0)
							SQLText+=" ";
						SQLText+=drw["OrderId"].ToString()+" "+drw["ProductID"].ToString();
					}

					enumTables=view.GetEnumerator();
					while(enumTables.MoveNext())
					{
						drw=(DataRowView)enumTables.Current;
						SQLText="";
						if(SQLText.Length!=0)
							SQLText+=" ";
						SQLText+=drw["OrderId"].ToString()+" "+drw["ProductID"].ToString();
					}
					
					KeyValues[0]=-2;
					KeyValues[1]=200;
					Res=view.Find(KeyValues); // by view.Sort
					if(Res!=-1)
						SQLText=view[Res]["OrderId"].ToString()+" "+view[Res]["ProductID"].ToString();
					else
						SQLText="Row not found!!!";

					DataRowView[]
						aDRView=view.FindRows(KeyValues);

					if(aDRView.Length!=0)
						foreach(DataRowView row in aDRView)
							SQLText=row["OrderId"].ToString()+" "+row["ProductID"].ToString();
					else
						SQLText="Row not found!!!";

					drw=view.AddNew();
					drw["OrderId"]=-2;
					drw["ProductID"]=4;
					drw["UnitPrice"]=400;
					drw.EndEdit();

					drw.BeginEdit();
					drw["UnitPrice"]=800;
					drw.EndEdit();

					SQLText="select count(*) from TestTypes";
					cmd.CommandText=SQLText;
					Res=Convert.ToInt32(cmd.ExecuteScalar());

					ulong
						ulValue=999999999999999999UL;

					long
						lValue=9999999999L;

					if(Res!=0)
					{
						SQLText="update TestTypes set FNumeric_18_0="+ulValue.ToString()+", FNumeric_10_0="+lValue.ToString()+", FDecimal_18_0="+ulValue.ToString()+", FDecimal_10_0="+lValue.ToString();
					}
					else
					{
						SQLText="insert into TestTypes (FBit, FNumeric_18_0, FNumeric_10_0, FDecimal_18_0, FDecimal_10_0) values (1, "+ulValue.ToString()+", "+lValue.ToString()+", "+ulValue.ToString()+", "+lValue.ToString()+")";
					}
					cmd.CommandText=SQLText;
					cmd.ExecuteNonQuery();

					SQLText="select sum(FNumeric_18_0) from TestTypes";
					cmd.CommandText=SQLText;
					ulValue=Convert.ToUInt64(cmd.ExecuteScalar()); //Convert.ToInt32(cmd.ExecuteScalar()) - OverflowException

					SQLText="select sum(FNumeric_10_0) from TestTypes";
					cmd.CommandText=SQLText;
					lValue=Convert.ToInt64(cmd.ExecuteScalar()); //Convert.ToInt32(cmd.ExecuteScalar()) - OverflowException
					
					cmd.CommandText="{? = call sp_TestTypes_Decimal_4_0(?, ?)}";

					cmd.Parameters.Clear();

					SPRetValue=cmd.Parameters.Add("@return",OleDbType.Integer);
					SPRetValue.Direction=ParameterDirection.ReturnValue;
		
					cmd.Parameters.Add("@FDecimal_4_0",OleDbType.Numeric).Value=9999;
					SPResult=cmd.Parameters.Add("@FDecimal_4_0_out",OleDbType.Numeric);
					SPResult.Direction=ParameterDirection.Output;
					
					cmd.ExecuteNonQuery();
				
					RetValue=Convert.ToInt32(SPRetValue.Value);

					ushort
						tmpUShort;

					uint
						tmpUInt;

					if(RetValue==65535)
					{
						tmpUShort=Convert.ToUInt16(cmd.Parameters["@FDecimal_4_0_out"].Value);
						RetValue=Convert.ToInt32(cmd.Parameters["@FDecimal_4_0_out"].Value);
						tmpUInt=Convert.ToUInt32(cmd.Parameters["@FDecimal_4_0_out"].Value);
						lValue=Convert.ToInt64(cmd.Parameters["@FDecimal_4_0_out"].Value);
						ulValue=Convert.ToUInt64(cmd.Parameters["@FDecimal_4_0_out"].Value);
						tmpDecimal=Convert.ToUInt16(cmd.Parameters["@FDecimal_4_0_out"].Value);
						fstr_out.WriteLine("{0} {1} {2} {3} {4} {5}",tmpUShort,RetValue,tmpUInt,lValue,ulValue,tmpDecimal);
					}

					cmd.CommandText="{? = call sp_TestTypes_Decimal_4_2(?, ?)}";
					
					cmd.Parameters.Clear();

					SPRetValue=cmd.Parameters.Add("@return",OleDbType.Integer);
					SPRetValue.Direction=ParameterDirection.ReturnValue;
					
					SPResult=cmd.Parameters.Add("@FDecimal_4_2",OleDbType.Numeric);
					SPResult.Value=99.99;
					SPResult.Precision=4;
					SPResult.Scale=2;
					//SPResult.Value=99.99;
					SPResult=cmd.Parameters.Add("@FDecimal_4_2_out",OleDbType.Numeric);
					SPResult.Precision=4;
					SPResult.Scale=2;
					SPResult.Direction=ParameterDirection.Output;
					
					cmd.ExecuteNonQuery();
				
					RetValue=Convert.ToInt32(SPRetValue.Value);
					if(RetValue==65535)
					{
						tmpDecimal=Convert.ToDecimal(cmd.Parameters["@FDecimal_4_2_out"].Value);
						fstr_out.WriteLine("{0}",tmpDecimal);
					}

					cmd.CommandText="{? = call sp_TestTypes_Numeric_4_0(?, ?)}";

					cmd.Parameters.Clear();

					SPRetValue=cmd.Parameters.Add("@return",OleDbType.Integer);
					SPRetValue.Direction=ParameterDirection.ReturnValue;
		
					cmd.Parameters.Add("@FNumeric_4_0",OleDbType.Numeric).Value=9999;
					SPResult=cmd.Parameters.Add("@FNumeric_4_0_out",OleDbType.Numeric);
					SPResult.Direction=ParameterDirection.Output;
					
					cmd.ExecuteNonQuery();
				
					RetValue=Convert.ToInt32(SPRetValue.Value);
					if(RetValue==65535)
					{
						tmpUShort=Convert.ToUInt16(cmd.Parameters["@FNumeric_4_0_out"].Value);
						RetValue=Convert.ToInt32(cmd.Parameters["@FNumeric_4_0_out"].Value);
						tmpUInt=Convert.ToUInt32(cmd.Parameters["@FNumeric_4_0_out"].Value);
						lValue=Convert.ToInt64(cmd.Parameters["@FNumeric_4_0_out"].Value);
						ulValue=Convert.ToUInt64(cmd.Parameters["@FNumeric_4_0_out"].Value);
						tmpDecimal=Convert.ToUInt16(cmd.Parameters["@FNumeric_4_0_out"].Value);
						fstr_out.WriteLine("{0} {1} {2} {3} {4} {5}",tmpUShort,RetValue,tmpUInt,lValue,ulValue,tmpDecimal);
					}

					cmd.CommandText="{? = call sp_TestTypes_Numeric_4_2(?, ?)}";
					
					cmd.Parameters.Clear();

					SPRetValue=cmd.Parameters.Add("@return",OleDbType.Integer);
					SPRetValue.Direction=ParameterDirection.ReturnValue;
					
					SPResult=cmd.Parameters.Add("@FNumeric_4_2",OleDbType.Numeric);
					SPResult.Precision=4;
					SPResult.Scale=2;
					SPResult.Value=99.99;
					SPResult=cmd.Parameters.Add("@FNumeric_4_2_out",OleDbType.Numeric);
					SPResult.Precision=4;
					SPResult.Scale=2;
					SPResult.Direction=ParameterDirection.Output;
					
					cmd.ExecuteNonQuery();
				
					RetValue=Convert.ToInt32(SPRetValue.Value);
					if(RetValue==65535)
					{
						tmpDecimal=Convert.ToDecimal(cmd.Parameters["@FNumeric_4_2_out"].Value);
						fstr_out.WriteLine("{0}",tmpDecimal);
					}

					cmd.CommandText="{? = call sp_TestTypes_Numeric_4_2_T(?, ?)}";
					
					cmd.Parameters.Clear();

					SPRetValue=cmd.Parameters.Add("@return",OleDbType.Integer);
					SPRetValue.Direction=ParameterDirection.ReturnValue;
					
					SPResult=cmd.Parameters.Add("@FNumeric_4_2",OleDbType.Numeric);
					SPResult.Precision=4;
					SPResult.Scale=2;
					SPResult.Value=99.99;
					SPResult=cmd.Parameters.Add("@FNumeric_4_2_out",OleDbType.Numeric);
					SPResult.Precision=4;
					SPResult.Scale=2;
					SPResult.Direction=ParameterDirection.Output;
					
					cmd.ExecuteNonQuery();
				
					RetValue=Convert.ToInt32(SPRetValue.Value);
					if(RetValue==65535)
					{
						tmpDecimal=Convert.ToDecimal(cmd.Parameters["@FNumeric_4_2_out"].Value);
						fstr_out.WriteLine("{0}",tmpDecimal);
					}

					cmd.CommandText="{? = call sp_TestTypes_Money(?, ?)}";
					
					cmd.Parameters.Clear();

					SPRetValue=cmd.Parameters.Add("@return",OleDbType.Integer);
					SPRetValue.Direction=ParameterDirection.ReturnValue;
					
					cmd.Parameters.Add("@FMoney",OleDbType.Currency).Value=922337203685477.5807m;
					SPResult=cmd.Parameters.Add("@FMoney_out",OleDbType.Currency);
					SPResult.Direction=ParameterDirection.Output;
					
					cmd.ExecuteNonQuery();
				
					RetValue=Convert.ToInt32(SPRetValue.Value);
					if(RetValue==65535)
					{
						tmpDecimal=Convert.ToDecimal(cmd.Parameters["@FMoney_out"].Value);
						fstr_out.WriteLine("{0}",tmpDecimal);
					}
					
					cmd.CommandText="{? = call sp_TestTypes(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)}";
					
					cmd.Parameters.Clear();

					SPRetValue=cmd.Parameters.Add("@return",OleDbType.Integer);
					SPRetValue.Direction=ParameterDirection.ReturnValue;
					
					cmd.Parameters.Add("@FDecimal_4_0",OleDbType.Numeric).Value=9999;
					SPResult=cmd.Parameters.Add("@FDecimal_4_2",OleDbType.Numeric);
					SPResult.Precision=4;
					SPResult.Scale=2;
					SPResult.Value=99.99;
					cmd.Parameters.Add("@FDecimal_5_0",OleDbType.Numeric).Value=99999;
					SPResult=cmd.Parameters.Add("@FDecimal_5_2",OleDbType.Numeric);
					SPResult.Precision=5;
					SPResult.Scale=2;
					SPResult.Value=999.99;
					cmd.Parameters.Add("@FDecimal_8_0",OleDbType.Numeric).Value=99999999;
					SPResult=cmd.Parameters.Add("@FDecimal_8_2",OleDbType.Numeric);
					SPResult.Precision=8;
					SPResult.Scale=2;
					SPResult.Value=999999.99;
					cmd.Parameters.Add("@FDecimal_9_0",OleDbType.Numeric).Value=999999999;
					SPResult=cmd.Parameters.Add("@FDecimal_9_2",OleDbType.Numeric);
					SPResult.Precision=9;
					SPResult.Scale=2;
					SPResult.Value=9999999.99;
					cmd.Parameters.Add("@FDecimal_10_0",OleDbType.Numeric).Value=9999999999;
					SPResult=cmd.Parameters.Add("@FDecimal_10_2",OleDbType.Numeric);
					SPResult.Precision=10;
					SPResult.Scale=2;
					SPResult.Value=99999999.99;
					cmd.Parameters.Add("@FDecimal_18_0",OleDbType.Numeric).Value=999999999999999999;
					SPResult=cmd.Parameters.Add("@FDecimal_18_2",OleDbType.Numeric);
					SPResult.Precision=18;
					SPResult.Scale=2;
					SPResult.Value=9999999999999999.99;
					cmd.Parameters.Add("@FNumeric_4_0",OleDbType.Numeric).Value=9999;
					SPResult=cmd.Parameters.Add("@FNumeric_4_2",OleDbType.Numeric);
					SPResult.Precision=4;
					SPResult.Scale=2;
					SPResult.Value=99.99;
					cmd.Parameters.Add("@FNumeric_5_0",OleDbType.Numeric).Value=99999;
					SPResult=cmd.Parameters.Add("@FNumeric_5_2",OleDbType.Numeric);
					SPResult.Precision=5;
					SPResult.Scale=2;
					SPResult.Value=999.99;
					cmd.Parameters.Add("@FNumeric_8_0",OleDbType.Numeric).Value=99999999;
					SPResult=cmd.Parameters.Add("@FNumeric_8_2",OleDbType.Numeric);
					SPResult.Precision=8;
					SPResult.Scale=2;
					SPResult.Value=999999.99;
					cmd.Parameters.Add("@FNumeric_9_0",OleDbType.Numeric).Value=999999999;
					SPResult=cmd.Parameters.Add("@FNumeric_9_2",OleDbType.Numeric);
					SPResult.Precision=9;
					SPResult.Scale=2;
					SPResult.Value=9999999.99;
					cmd.Parameters.Add("@FNumeric_10_0",OleDbType.Numeric).Value=9999999999;
					SPResult=cmd.Parameters.Add("@FNumeric_10_2",OleDbType.Numeric);
					SPResult.Precision=10;
					SPResult.Scale=2;
					SPResult.Value=99999999.99;
					cmd.Parameters.Add("@FNumeric_18_0",OleDbType.Numeric).Value=999999999999999999;
					SPResult=cmd.Parameters.Add("@FNumeric_18_2",OleDbType.Numeric);
					SPResult.Precision=18;
					SPResult.Scale=2;
					SPResult.Value=9999999999999999.99;
					cmd.Parameters.Add("@FMoney",OleDbType.Currency).Value=922337203685477.5807m;
					SPResult=cmd.Parameters.Add("@FDecimal_4_0_out",OleDbType.Numeric);
					SPResult.Direction=ParameterDirection.Output;
					SPResult=cmd.Parameters.Add("@FDecimal_4_2_out",OleDbType.Numeric);
					SPResult.Precision=4;
					SPResult.Scale=2;
					SPResult.Direction=ParameterDirection.Output;
					SPResult=cmd.Parameters.Add("@FDecimal_5_0_out",OleDbType.Numeric);
					SPResult.Direction=ParameterDirection.Output;
					SPResult=cmd.Parameters.Add("@FDecimal_5_2_out",OleDbType.Numeric);
					SPResult.Precision=5;
					SPResult.Scale=2;
					SPResult.Direction=ParameterDirection.Output;
					SPResult=cmd.Parameters.Add("@FDecimal_8_0_out",OleDbType.Numeric);
					SPResult.Direction=ParameterDirection.Output;
					SPResult=cmd.Parameters.Add("@FDecimal_8_2_out",OleDbType.Numeric);
					SPResult.Precision=8;
					SPResult.Scale=2;
					SPResult.Direction=ParameterDirection.Output;
					SPResult=cmd.Parameters.Add("@FDecimal_9_0_out",OleDbType.Numeric);
					SPResult.Direction=ParameterDirection.Output;
					SPResult=cmd.Parameters.Add("@FDecimal_9_2_out",OleDbType.Numeric);
					SPResult.Precision=9;
					SPResult.Scale=2;
					SPResult.Direction=ParameterDirection.Output;
					SPResult=cmd.Parameters.Add("@FDecimal_10_0_out",OleDbType.Numeric);
					SPResult.Direction=ParameterDirection.Output;
					SPResult=cmd.Parameters.Add("@FDecimal_10_2_out",OleDbType.Numeric);
					SPResult.Precision=10;
					SPResult.Scale=2;
					SPResult.Direction=ParameterDirection.Output;
					SPResult=cmd.Parameters.Add("@FDecimal_18_0_out",OleDbType.Numeric);
					SPResult.Direction=ParameterDirection.Output;
					SPResult=cmd.Parameters.Add("@FDecimal_18_2_out",OleDbType.Numeric);
					SPResult.Precision=18;
					SPResult.Scale=2;
					SPResult.Direction=ParameterDirection.Output;
					SPResult=cmd.Parameters.Add("@FNumeric_4_0_out",OleDbType.Numeric);
					SPResult.Direction=ParameterDirection.Output;
					SPResult=cmd.Parameters.Add("@FNumeric_4_2_out",OleDbType.Numeric);
					SPResult.Precision=4;
					SPResult.Scale=2;
					SPResult.Direction=ParameterDirection.Output;
					SPResult=cmd.Parameters.Add("@FNumeric_5_0_out",OleDbType.Numeric);
					SPResult.Direction=ParameterDirection.Output;
					SPResult=cmd.Parameters.Add("@FNumeric_5_2_out",OleDbType.Numeric);
					SPResult.Precision=5;
					SPResult.Scale=2;
					SPResult.Direction=ParameterDirection.Output;
					SPResult=cmd.Parameters.Add("@FNumeric_8_0_out",OleDbType.Numeric);
					SPResult.Direction=ParameterDirection.Output;
					SPResult=cmd.Parameters.Add("@FNumeric_8_2_out",OleDbType.Numeric);
					SPResult.Precision=8;
					SPResult.Scale=2;
					SPResult.Direction=ParameterDirection.Output;
					SPResult=cmd.Parameters.Add("@FNumeric_9_0_out",OleDbType.Numeric);
					SPResult.Direction=ParameterDirection.Output;
					SPResult=cmd.Parameters.Add("@FNumeric_9_2_out",OleDbType.Numeric);
					SPResult.Precision=9;
					SPResult.Scale=2;
					SPResult.Direction=ParameterDirection.Output;
					SPResult=cmd.Parameters.Add("@FNumeric_10_0_out",OleDbType.Numeric);
					SPResult.Direction=ParameterDirection.Output;
					SPResult=cmd.Parameters.Add("@FNumeric_10_2_out",OleDbType.Numeric);
					SPResult.Precision=10;
					SPResult.Scale=2;
					SPResult.Direction=ParameterDirection.Output;
					SPResult=cmd.Parameters.Add("@FNumeric_18_0_out",OleDbType.Numeric);
					SPResult.Direction=ParameterDirection.Output;
					SPResult=cmd.Parameters.Add("@FNumeric_18_2_out",OleDbType.Numeric);
					SPResult.Precision=18;
					SPResult.Scale=2;
					SPResult.Direction=ParameterDirection.Output;
					SPResult=cmd.Parameters.Add("@FMoney_out",OleDbType.Currency);
					SPResult.Direction=ParameterDirection.Output;

					cmd.ExecuteNonQuery();
				
					RetValue=Convert.ToInt32(SPRetValue.Value);
					if(RetValue==65535)
					{
						tmpUShort=Convert.ToUInt16(cmd.Parameters["@FDecimal_4_0_out"].Value);
						RetValue=Convert.ToInt32(cmd.Parameters["@FDecimal_4_0_out"].Value);
						tmpUInt=Convert.ToUInt32(cmd.Parameters["@FDecimal_4_0_out"].Value);
						lValue=Convert.ToInt64(cmd.Parameters["@FDecimal_4_0_out"].Value);
						ulValue=Convert.ToUInt64(cmd.Parameters["@FDecimal_4_0_out"].Value);
						tmpDecimal=Convert.ToUInt16(cmd.Parameters["@FDecimal_4_0_out"].Value);
						fstr_out.WriteLine("{0} {1} {2} {3} {4} {5}",tmpUShort,RetValue,tmpUInt,lValue,ulValue,tmpDecimal);
						tmpDecimal=Convert.ToDecimal(cmd.Parameters["@FDecimal_4_2_out"].Value);
						fstr_out.WriteLine("{0}",tmpDecimal);
					}
					
					ds.Reset();
					tbl=ds.Tables.Add("Test");
					cl=tbl.Columns.Add("ID",typeof(long));
					cl.AutoIncrement=true;
					cl.AutoIncrementSeed=-1;
					cl.AutoIncrementStep=-1;
					tbl.Columns.Add("Value",typeof(string));
					rw=tbl.NewRow();
					rw["Value"]="1st";
					tbl.Rows.Add(rw);
					rw=tbl.NewRow();
					rw["ID"]=2;
					rw["Value"]="2nd";
					tbl.Rows.Add(rw);
					rw=tbl.NewRow();
					rw["Value"]="3rd";
					tbl.Rows.Add(rw);
					rw=tbl.NewRow();
					rw["ID"]=4;
					rw["Value"]="4th";
					tbl.Rows.Add(rw);
					rw=tbl.NewRow();
					rw["ID"]=DBNull.Value;
					rw["Value"]="5th";
					tbl.Rows.Add(rw);
					
					DataRowCollection
						rc=tbl.Rows;
					
					aData=new object[2];
					aData[0]=null;
					aData[1]="6th";
					rc.Add(aData);

					aData[0]=7;
					aData[1]="7th";
					rc.Add(aData);

					foreach(DataRow row in tbl.Rows)
					{
						SQLText="";
						if(SQLText.Length!=0)
							SQLText+=" ";
						SQLText+="ID: "+(!row.IsNull("ID") ? row["ID"] : "null");
						if(SQLText.Length!=0)
							SQLText+=" ";
						SQLText+="Value: "+row["Value"];
						fstr_out.Write(SQLText);
					}

					Result=0;
				}
				catch(IOException eException) // 4 FileStream
				{
					Console.WriteLine(eException.Message);
				}
				catch (OleDbException eException)
				{
					Console.WriteLine("ErrorCode="+eException.ErrorCode.ToString()+"\nMessage: "+eException.Message+"\nSource: "+eException.Source+"\nStackTrace: "+eException.StackTrace+"\nTargetSite: "+eException.TargetSite);
				}
				catch(InvalidCastException eException) // 4 OleDbDataReader.Get...
				{
					Console.WriteLine("InvalidCastException: \""+eException.Message+"\"");
				}
				catch(IndexOutOfRangeException eException) // 4 OleDbDataReader.GetOrdinal
				{
					Console.WriteLine(eException.Message);
				}
				catch(OutOfMemoryException eException) // 4 new
				{
					Console.WriteLine(eException.Message);
				}
				catch(OverflowException eException)
				{
					Console.WriteLine(eException.Message);
				}
				catch(InvalidOperationException eException)
				{
					Console.WriteLine(eException.Message);
				}
				catch(Exception eException)
				{
					Console.WriteLine(eException.Message);
				}
			}
			finally
			{
				if(rdr!=null && !rdr.IsClosed)
					rdr.Close();

				if(cn!=null && cn.State==System.Data.ConnectionState.Open)
					cn.Close();

				#if TEST_SYBASE_BY_ODBC
					if(odbc_rdr!=null && !odbc_rdr.IsClosed)
						odbc_rdr.Close();

					if(odbc_cn!=null && odbc_cn.State==System.Data.ConnectionState.Open)
						odbc_cn.Close();
				#endif

				if(fstr_out!=null)
					fstr_out.Close();
			}

			return(Result);
		}

		static void cn_InfoMessage(object sender, OleDbInfoMessageEventArgs e)
		{
			Console.WriteLine("InfoMessage event occurred (sender: "+sender.ToString()+")");
			Console.WriteLine("\tMessage received: "+e.Message);
		}

		static void cn_StateChange(object sender, StateChangeEventArgs e)
		{
			Console.WriteLine("StateChange event occurred (sender: "+sender.ToString()+")");
			Console.WriteLine("\tFrom (OriginalState): "+e.OriginalState.ToString()+"\n\tTo (CurrentState): "+e.CurrentState.ToString());
		}

		static void da_FillError(object sender, FillErrorEventArgs args)
		{
			Console.WriteLine("FillError event occurred (sender: "+sender.ToString()+")");
			Console.WriteLine("\tErrors.Message: "+args.Errors.Message);
		}

		static void da_RowUpdated(object sender, OleDbRowUpdatedEventArgs args)
		{
			Console.WriteLine("RowUpdated event occurred (sender: "+sender.ToString()+")");
			Console.WriteLine("\tCommand.CommandText: "+args.Command.CommandText);
			Console.WriteLine("\tErrors.Message: "+args.Errors.Message);
			Console.WriteLine("\tRecordsAffected: "+args.RecordsAffected.ToString());
			Console.WriteLine("\tRow: "+args.Row.ToString());
			Console.WriteLine("\tStatementType: "+args.StatementType.ToString());
			Console.WriteLine("\tStatus: "+args.Status.ToString());
			Console.WriteLine("\tTableMapping: "+args.TableMapping.ToString());
		}

		static void da_RowUpdating(object sender, OleDbRowUpdatingEventArgs args)
		{
			Console.WriteLine("RowUpdating event occurred (sender: "+sender.ToString()+")");
			Console.WriteLine("\tCommand.CommandText: "+args.Command.CommandText);
			Console.WriteLine("\tErrors.Message: "+args.Errors.Message);
			Console.WriteLine("\tRow: "+args.Row.ToString());
			Console.WriteLine("\tStatementType: "+args.StatementType.ToString());
			Console.WriteLine("\tStatus: "+args.Status.ToString());
			Console.WriteLine("\tTableMapping: "+args.TableMapping.ToString());
		}

		static void dt_ColumnChanged(object sender, DataColumnChangeEventArgs e)
		{
			Console.WriteLine("ColumnChanged event occurred (sender: "+sender.ToString()+")");
			Console.WriteLine("Value={0}; Column={1}; Original value={2}",e.Row[e.Column.ColumnName],e.Column.ColumnName,e.Row[e.Column.ColumnName/*, DataRowVersion.Original*/]);
		}

		static void dt_ColumnChanging(object sender, DataColumnChangeEventArgs e)
		{
			Console.WriteLine("ColumnChanging event occurred (sender: "+sender.ToString()+")");
			Console.WriteLine("Value={0}; Column={1}; Proposed value={2}",e.Row[e.Column.ColumnName],e.Column.ColumnName,e.ProposedValue);
		}

		static void dt_RowChanged(object sender, DataRowChangeEventArgs e)
		{
			Console.WriteLine("RowChanged event occurred (sender: "+sender.ToString()+")");
			Console.WriteLine("Action={0}, RowState={1}",e.Action,e.Row.RowState);
		}

		static void dt_RowChanging(object sender, DataRowChangeEventArgs e)
		{
			Console.WriteLine("RowChanging event occurred (sender: "+sender.ToString()+")");
			Console.WriteLine("Action={0}, RowState={1}",e.Action,e.Row.RowState);
		}

		static void dt_RowDeleted(object sender, DataRowChangeEventArgs e)
		{
			Console.WriteLine("RowDeleted event occurred (sender: "+sender.ToString()+")");
			Console.WriteLine("Action={0}, RowState={1}",e.Action,e.Row.RowState);
		}

		static void dt_RowDeleting(object sender, DataRowChangeEventArgs e)
		{
			Console.WriteLine("RowDeleting event occurred (sender: "+sender.ToString()+")");
			Console.WriteLine("Action={0}, RowState={1}",e.Action,e.Row.RowState);
		}

		static void DisplayRow(DataRow row)
		{
			DataTable
				tbl=row.Table;

			foreach(DataColumn col in tbl.Columns)
				Console.WriteLine("\t"+col.ColumnName+": "+row[col]);
		}

		static void TestColumnChanged(object sender, DataColumnChangeEventArgs e)
		{
			Console.WriteLine("ColumnChanged event occurred (sender: "+sender.ToString()+")");
			Console.WriteLine("Column={0}; Value={1}; Value(Current)={2}; Value(Original)={3}; Value(Proposed)={4}; Value(Default)={5}",
				e.Column.ColumnName,
				e.Row[e.Column.ColumnName],
				e.Row.HasVersion(DataRowVersion.Current) ? (e.Row[e.Column.ColumnName,DataRowVersion.Current] != DBNull.Value ? e.Row[e.Column.ColumnName,DataRowVersion.Current] : DBNull.Value.ToString()) : "!HasVersion(DataRowVersion.Current)",
				e.Row.HasVersion(DataRowVersion.Original) ? (e.Row[e.Column.ColumnName,DataRowVersion.Original] != DBNull.Value ? e.Row[e.Column.ColumnName,DataRowVersion.Original] : DBNull.Value.ToString()) : "!HasVersion(DataRowVersion.Original)",
				e.Row.HasVersion(DataRowVersion.Proposed) ? (e.Row[e.Column.ColumnName,DataRowVersion.Proposed] != DBNull.Value ? e.Row[e.Column.ColumnName,DataRowVersion.Proposed] : DBNull.Value.ToString()) : "!HasVersion(DataRowVersion.Proposed)",
				e.Row.HasVersion(DataRowVersion.Default) ? (e.Row[e.Column.ColumnName,DataRowVersion.Default] != DBNull.Value ? e.Row[e.Column.ColumnName,DataRowVersion.Default] : DBNull.Value.ToString()) : "!HasVersion(DataRowVersion.Default)");
		}

		static void TestColumnChanging(object sender, DataColumnChangeEventArgs e)
		{
			Console.WriteLine("ColumnChanging event occurred (sender: "+sender.ToString()+")");
			Console.WriteLine("Column={0}; Value={1}; Value(Current)={2}; Value(Original)={3}; Value(Proposed)={4}; Value(Default)={5} ProposedValue={6}",
				e.Column.ColumnName,
				e.Row[e.Column.ColumnName],
				e.Row.HasVersion(DataRowVersion.Current) ? (e.Row[e.Column.ColumnName,DataRowVersion.Current] != DBNull.Value ? e.Row[e.Column.ColumnName,DataRowVersion.Current] : DBNull.Value.ToString()) : "!HasVersion(DataRowVersion.Current)",
				e.Row.HasVersion(DataRowVersion.Original) ? (e.Row[e.Column.ColumnName,DataRowVersion.Original] != DBNull.Value ? e.Row[e.Column.ColumnName,DataRowVersion.Original] : DBNull.Value.ToString()) : "!HasVersion(DataRowVersion.Original)",
				e.Row.HasVersion(DataRowVersion.Proposed) ? (e.Row[e.Column.ColumnName,DataRowVersion.Proposed] != DBNull.Value ? e.Row[e.Column.ColumnName,DataRowVersion.Proposed] : DBNull.Value.ToString()) : "!HasVersion(DataRowVersion.Proposed)",
				e.Row.HasVersion(DataRowVersion.Default) ? (e.Row[e.Column.ColumnName,DataRowVersion.Default] != DBNull.Value ? e.Row[e.Column.ColumnName,DataRowVersion.Default] : DBNull.Value.ToString()) : "!HasVersion(DataRowVersion.Default)",
				e.ProposedValue);
		}
	}
}
