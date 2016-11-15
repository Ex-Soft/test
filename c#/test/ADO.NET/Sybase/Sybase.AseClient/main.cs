#define TEST_CHARSET
//#define TEST_EXECUTE_NON_QUERY
//#define TEST_BLOB
//#define TEST_BLOB_SAVE
//#define TEST_SMTH
//#define TEST_DATA_ADAPTER_FILL_SCHEMA
//#define TEST_STORED_PROCEDURES
//#define WITH_REFLECTION
//#define WITH_TRACE

using System;
using System.Configuration;
using System.Data;
using System.IO;
#if WITH_REFLECTION
	using System.Reflection;
#endif
#if WITH_TRACE
	using System.Text;
#endif
using Sybase.Data.AseClient;

namespace Sybase
{
	class TestSybaseADONETDataProvider
	{
		#if WITH_TRACE
			static StreamWriter
				_strmWriter=null;

			static int
				indentLevel=0; 
		#endif

		[STAThread]
		static int Main(string[] args)
		{
			int
				Result=-1,
				tmpInt;

			decimal
				tmpDecimal;

			object
				tmpObject;

			StreamWriter
				fstr_out=null;

			string
				tmpString,
				OutputFileName="log.log";

			#if WITH_TRACE
				string
					TraceFileName="trace.log";
			#endif

			AseConnection
				conn=null;

			AseCommand
				cmd=null;

			AseTransaction
				Transaction=null;

			AseDataReader
				reader=null; 

			AseParameter
				Parameter=null;

			AseDataAdapter
				da=null;

			DataTable
				tmpDataTable=null;

			try
			{
				try
				{
					fstr_out=new StreamWriter(OutputFileName,false,System.Text.Encoding.GetEncoding(1251));
					fstr_out.AutoFlush=true;

					#if WITH_REFLECTION
						Assembly[]
							asms=AppDomain.CurrentDomain.GetAssemblies();

						Assembly
							asm=null;

						foreach(Assembly a in asms)
						{
							if(a.FullName.ToLower().IndexOf("sybase.data.aseclient")>-1)
								asm=a;

							fstr_out.WriteLine("Assembly.CodeBase: "+a.CodeBase);
							fstr_out.WriteLine("Assembly.EscapedCodeBase: "+a.EscapedCodeBase);
							fstr_out.WriteLine("Assembly.FullName: "+a.FullName);
							fstr_out.WriteLine("Assembly.GlobalAssemblyCache: "+a.GlobalAssemblyCache.ToString().ToLower());
							fstr_out.WriteLine("Assembly.ImageRuntimeVersion: "+a.ImageRuntimeVersion);
							fstr_out.WriteLine("Assembly.Location: "+a.Location);
							fstr_out.WriteLine();
						}

						if(asm!=null)
						{
							Type[]
								alltypes=asm.GetTypes();

							for(tmpInt=0; tmpInt<alltypes.Length; ++tmpInt)
							{
								fstr_out.WriteLine("Обнаружено: "+alltypes[tmpInt].Name);
								if(alltypes[tmpInt].Name.CompareTo("AseConnection")==0)
								{
									Type
										t=alltypes[tmpInt];

									FieldInfo[]
										fi=t.GetFields(BindingFlags.Instance|BindingFlags.NonPublic|BindingFlags.Public);

									fstr_out.WriteLine("Анализ Field, определенных в "+t.Name);
									foreach(FieldInfo f in fi)
									{
										fstr_out.Write("   "+f.Name);
										fstr_out.WriteLine();
									}
									fstr_out.WriteLine();

									PropertyInfo[]
										//pi_=t.GetProperties(BindingFlags.Instance|BindingFlags.NonPublic|BindingFlags.Static); // AseConnection.Language
										pi_=t.GetProperties(BindingFlags.Instance|BindingFlags.NonPublic|BindingFlags.Public);

									fstr_out.WriteLine("Анализ Property, определенных в "+t.Name);
									foreach(PropertyInfo p_ in pi_)
									{
										fstr_out.Write("   "+p_.Name);
										fstr_out.WriteLine();
									}
									fstr_out.WriteLine();

									fstr_out.WriteLine("Поддерживаемые методы:");

									ParameterInfo[]
										pi;

									MethodInfo[]
										mi;

									//mi=t.GetMethods();
									mi=t.GetMethods(BindingFlags.DeclaredOnly
										| BindingFlags.Instance
										| BindingFlags.Public);

									foreach(MethodInfo m in mi)
									{
										fstr_out.Write("   "+m.ReturnType.Name+" "+m.Name+"(");
										pi=m.GetParameters();

										for(int i=0; i<pi.Length; ++i)
										{
											fstr_out.Write(pi[i].ParameterType.Name+" "+pi[i].Name);
											if(i+1<pi.Length)
												fstr_out.Write(", ");
										}
										fstr_out.WriteLine(")");
									}
									fstr_out.WriteLine();
								}
							}
							fstr_out.WriteLine();
						}
					#endif

					#if WITH_TRACE
						_strmWriter=new StreamWriter(TraceFileName,false,System.Text.Encoding.GetEncoding(1251));
						_strmWriter.AutoFlush=true;
					#endif

					if((tmpString=ConfigurationSettings.AppSettings["connectionString"])==null
						|| tmpString==string.Empty)
					{
						fstr_out.WriteLine("ConfigurationSettings.AppSettings[\"connectionString\"] is empty!!!");
						return(Result);
					}

					conn=new AseConnection(tmpString);
					conn.InfoMessage+=new AseInfoMessageEventHandler(conn_InfoMessage);
					conn.StateChange+=new System.Data.StateChangeEventHandler(conn_StateChange);
					#if WITH_TRACE
						conn.TraceEnter+=new TraceEnterEventHandler(conn_TraceEnter);
						conn.TraceExit+=new TraceExitEventHandler(conn_TraceExit);
					#endif
					conn.Open();

					fstr_out.WriteLine("AseConnection.ConnectionString: "+conn.ConnectionString);
					fstr_out.WriteLine("AseConnection.ConnectionTimeout: "+conn.ConnectionTimeout);
					fstr_out.WriteLine("AseConnection.Database: "+conn.Database);
					fstr_out.WriteLine("AseConnection.NamedParameters: "+conn.NamedParameters.ToString().ToLower());
					fstr_out.WriteLine("AseConnection.State: "+conn.State);
					fstr_out.WriteLine("AseConnection.DriverVersion: "+AseConnection.DriverVersion);
					//fstr_out.WriteLine("AseConnection.Language: "+AseConnection.Language);
					fstr_out.WriteLine();

					cmd=conn.CreateCommand();
					cmd.CommandType=CommandType.Text;
					cmd.CommandText="select @@spid";
					
					if((tmpObject=cmd.ExecuteScalar())!=null)
						tmpString=Convert.ToString(tmpObject);

					#if TEST_CHARSET
						cmd.CommandText="select cast(val as date) from T4 where GroupId=4 and Id=1";
						if(da==null)
							da=new AseDataAdapter(cmd);
						else
							da.SelectCommand=cmd;

						if(tmpDataTable==null)
							tmpDataTable=new DataTable();
						else
							tmpDataTable.Reset();

						da.Fill(tmpDataTable);
					#endif

					#if TEST_EXECUTE_NON_QUERY
						if(cmd==null)
							cmd=conn.CreateCommand();
						cmd.NamedParameters=false;
						cmd.CommandType=CommandType.Text;
						cmd.Parameters.Clear();
						cmd.CommandText="update Victim set Val = ? where Id = ?";
						cmd.Parameters.Add("Val",AseDbType.Integer);
						cmd.Parameters.Add("Id",AseDbType.Integer);
						for(int Id=1; Id<=5; Id+=2)
						{
							cmd.Parameters["Val"].Value=Id;
							cmd.Parameters["Id"].Value=Id;
							tmpInt=cmd.ExecuteNonQuery();
						}
						cmd.NamedParameters=true;
					#endif

					#if TEST_BLOB
						if(cmd==null)
							cmd=conn.CreateCommand();

						cmd.CommandType=CommandType.Text;

						FileStream
							fs;

						byte[]
							Blob;

						#if TEST_BLOB_SAVE
							tmpString="@FImage";
							cmd.CommandText="update TestTypes set FImage = "+tmpString;
							cmd.Parameters.Clear();
							cmd.Parameters.Add(tmpString,AseDbType.Image);
							fs=new FileStream("welcome.bmp",FileMode.Open,FileAccess.Read);
							Blob=new byte[fs.Length];
							fs.Read(Blob,0,Blob.Length);
							cmd.Parameters[tmpString].Value=Blob;
							tmpInt=cmd.ExecuteNonQuery();
						#endif

						cmd.Parameters.Clear();
						cmd.CommandText="select * from TestTypes";
						reader=cmd.ExecuteReader();

						do
						{
							if(reader.HasRows)
							{
								for(int i=0; i<reader.FieldCount; ++i)
									fstr_out.WriteLine(reader.GetName(i)+" GetDataTypeName(): \""+reader.GetDataTypeName(i)+"\" GetFieldType(): \""+reader.GetFieldType(i)+"\"");

								tmpInt=reader.GetOrdinal("FImage");

								while(reader.Read())
								{
									tmpString="FromBlob.bmp";
									if(File.Exists(tmpString))
										File.Delete(tmpString);

									Blob=(byte[])reader["FImage"];
									fs=new FileStream(tmpString,FileMode.Create);
									fs.Write(Blob,0,Blob.Length);
									fs.Close();

									tmpString="FromBlob_1.bmp";
									if(File.Exists(tmpString))
										File.Delete(tmpString);

									Blob=new byte[reader.GetBytes(tmpInt,0,null,0,int.MaxValue)];
									reader.GetBytes(tmpInt,0,Blob,0,Blob.Length);
									fs=new FileStream(tmpString,FileMode.Create);
									fs.Write(Blob,0,Blob.Length);
									fs.Close();
								}
							}
						}while(reader.NextResult());
						reader.Close();
					#endif

					#if TEST_SMTH
						if(cmd==null)
							cmd=conn.CreateCommand();

						cmd.CommandType=CommandType.Text;
						cmd.CommandText="select * from TestDate order by FDate";
						cmd.Parameters.Clear();

						if(da==null)
							da=new AseDataAdapter(cmd);
						else
							da.SelectCommand=cmd;

						if(tmpDataTable!=null)
							tmpDataTable.Reset();
						else
							tmpDataTable=new DataTable();

						da.Fill(tmpDataTable);

						tmpString="";
						for(int i=0; i<tmpDataTable.Rows.Count; ++i)
						{
							if(tmpString!=string.Empty)
								tmpString+=" ";
							tmpString+=Convert.ToDateTime(tmpDataTable.Rows[i]["FDate"]).ToString("yyyy-MM-dd");
						}

						cmd.NamedParameters=false;
						cmd.CommandText="update TestTypes set FDatetime = ?";
						cmd.Parameters.Clear();
						cmd.Parameters.Add("FDate",AseDbType.DateTime).Value=DateTime.Now;
						tmpInt=cmd.ExecuteNonQuery();

						cmd.NamedParameters=true;
						cmd.CommandText="update TestTypes set FDatetime = @FDatetime";
						cmd.Parameters.Clear();
						cmd.Parameters.Add("@FDatetime",AseDbType.DateTime).Value=DateTime.Now;
						tmpInt=cmd.ExecuteNonQuery();
					#endif

					#if TEST_DATA_ADAPTER_FILL_SCHEMA
						if(cmd==null)
							cmd=conn.CreateCommand();

						cmd.CommandType=CommandType.Text;
						cmd.CommandText="select * from Staff";

						if(da==null)
							da=new AseDataAdapter(cmd);
						else
							da.SelectCommand=cmd;

						if(tmpDataTable!=null)
							tmpDataTable.Reset();
						else
							tmpDataTable=new DataTable();

						da.FillSchema(tmpDataTable,SchemaType.Source);
					#endif

					#if TEST_STORED_PROCEDURES
						if(cmd==null)
							cmd=conn.CreateCommand();

						object[]
							tmpObjects=new object[]{5,6};

						cmd.CommandType=CommandType.StoredProcedure;
						cmd.NamedParameters=false;
						cmd.CommandType=CommandType.StoredProcedure;
						cmd.CommandText="mathtutor";
						for(int i=0; i<tmpObjects.Length; ++i)
						{
							Parameter=new AseParameter();
							Parameter.ParameterName="Param"+i;
							switch(Type.GetTypeCode(tmpObjects[i].GetType()))
							{
								case System.TypeCode.Int32 :
								{
									Parameter.DbType=DbType.Int32;
									break;
								}
							}
							Parameter.Value=tmpObjects[i];
							cmd.Parameters.Add(Parameter);
						}
						Parameter=new AseParameter();
						Parameter.ParameterName="Param3";
						Parameter.DbType=DbType.Int32;
						Parameter.Direction=ParameterDirection.Output;
						cmd.Parameters.Add(Parameter);
						cmd.ExecuteNonQuery();
						tmpInt = !Convert.IsDBNull(cmd.Parameters["Param3"].Value) ? Convert.ToInt32(cmd.Parameters["Param3"].Value) : Int32.MinValue;

						cmd.CommandType=CommandType.StoredProcedure;
						cmd.CommandText="sp_TestTypes_Decimal_10_6";
						AseCommandBuilder.DeriveParameters(cmd);
						cmd.Parameters["@FDecimal_10_6"].Value=123.45m;
						cmd.ExecuteNonQuery();
						tmpDecimal = !Convert.IsDBNull(cmd.Parameters["@FDecimal_10_6_out"].Value) ? Convert.ToDecimal(cmd.Parameters["@FDecimal_10_6_out"].Value) : decimal.MinValue;
						
						cmd.Parameters.Clear();	
						cmd.CommandType=CommandType.Text;
						cmd.CommandText="{? = call sp_TestTypes_Decimal_10_6(? ,?)}";
						cmd.NamedParameters=false;

						Parameter=new AseParameter("@RETURN_VALUE",AseDbType.Integer);
						Parameter.Direction=ParameterDirection.ReturnValue;
						cmd.Parameters.Add(Parameter);

						Parameter=new AseParameter("@FDecimal_10_6",AseDbType.Decimal); //AseDbType.Numeric
						//Parameter=new AseParameter();
						//Parameter.ParameterName="@FDecimal_10_6";
						//Parameter.DbType=DbType.Decimal;
						//Parameter.AseDbType=AseDbType.Decimal; //AseDbType.Numeric
						Parameter.Direction=ParameterDirection.Input;
						//Parameter.Precision=10;
						//Parameter.Scale=6;
						Parameter.Value=123.45m;
						cmd.Parameters.Add(Parameter);

						Parameter=new AseParameter("@FDecimal_10_6_out",AseDbType.Decimal);  //AseDbType.Numeric
						Parameter.Direction=ParameterDirection.Output;
						Parameter.Precision=10;
						Parameter.Scale=6;
						cmd.Parameters.Add(Parameter);

						cmd.ExecuteNonQuery();
						tmpDecimal = !Convert.IsDBNull(cmd.Parameters["@FDecimal_10_6_out"].Value) ? Convert.ToDecimal(cmd.Parameters["@FDecimal_10_6_out"].Value) : decimal.MinValue;

						tmpDecimal=2;
											
						if(cmd==null)
							cmd=conn.CreateCommand();

						cmd.Parameters.Clear();
						cmd.CommandType=CommandType.Text;
						cmd.CommandText="{call UpdateTestTypes(?)}";
						cmd.NamedParameters=false;
						
						Parameter=new AseParameter("@rate",AseDbType.Decimal);
						Parameter.Direction=ParameterDirection.Input;
						Parameter.Value=tmpDecimal;
						cmd.Parameters.Add(Parameter);
						
						/*
						if(cmd==null)
							cmd=conn.CreateCommand();

						cmd.CommandType=CommandType.StoredProcedure;
						cmd.CommandText="UpdateTestTypes";
						AseCommandBuilder.DeriveParameters(cmd);
						cmd.Parameters["@Decimal_18_4"].Value=tmpDecimal;
						*/

						tmpInt=cmd.ExecuteNonQuery();

						cmd.CommandType=CommandType.StoredProcedure;
						for(int size=255; size<=258; ++size)
						{
							cmd.CommandText="sp_ReturnAndOutputVarChar"+size;
							AseCommandBuilder.DeriveParameters(cmd);
							cmd.ExecuteNonQuery();
							tmpString = !Convert.IsDBNull(cmd.Parameters["@OutParam"].Value) ? Convert.ToString(cmd.Parameters["@OutParam"].Value) : "NULL";
						}

						conn.ChangeDatabase("master");
						cmd.CommandText="testdb..sp_ReturnAndOutput";
						AseCommandBuilder.DeriveParameters(cmd);
						conn.ChangeDatabase("testdb"); 
					#endif

					Transaction=conn.BeginTransaction(IsolationLevel.ReadCommitted);

					if(cmd==null)
						cmd=conn.CreateCommand();
					cmd.Transaction=Transaction;
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="sp_Staff_Save";
					//cmd.CommandText="sp_TestTypes";
					fstr_out.WriteLine("AseCommandBuilder.DeriveParameters(\""+cmd.CommandText+"\")");
					AseCommandBuilder.DeriveParameters(cmd);
					foreach(AseParameter parameter in cmd.Parameters)
					{
						fstr_out.WriteLine("\tParameterIndex: "+parameter.ParameterIndex+Environment.NewLine+
											"\tParameterName: "+parameter.ParameterName+Environment.NewLine+
											"\tDirection: "+parameter.Direction+Environment.NewLine+
											"\tDbType: "+parameter.DbType+Environment.NewLine+
											"\tAseDbType: "+parameter.AseDbType+Environment.NewLine+
											"\tSize: "+parameter.Size+Environment.NewLine+
											"\tPrecision: "+parameter.Precision+Environment.NewLine+											
											"\tScale: "+parameter.Scale+Environment.NewLine+
											"\tIsNullable: "+parameter.IsNullable.ToString().ToLower()+Environment.NewLine+
											"\tSourceColumn: "+parameter.SourceColumn+Environment.NewLine+
											"\tSourceVersion: "+parameter.SourceVersion+Environment.NewLine);
					}
					fstr_out.WriteLine();

					conn.ChangeDatabase("veksel");
					cmd.CommandText="sp_CONTRACT_SAVE";
					fstr_out.WriteLine("AseCommandBuilder.DeriveParameters(\""+cmd.CommandText+"\")");
					AseCommandBuilder.DeriveParameters(cmd);
					foreach(AseParameter parameter in cmd.Parameters)
					{
						fstr_out.WriteLine("\tParameterIndex: "+parameter.ParameterIndex+Environment.NewLine+
							"\tParameterName: "+parameter.ParameterName+Environment.NewLine+
							"\tDirection: "+parameter.Direction+Environment.NewLine+
							"\tDbType: "+parameter.DbType+Environment.NewLine+
							"\tAseDbType: "+parameter.AseDbType+Environment.NewLine+
							"\tSize: "+parameter.Size+Environment.NewLine+
							"\tPrecision: "+parameter.Precision+Environment.NewLine+											
							"\tScale: "+parameter.Scale+Environment.NewLine+
							"\tIsNullable: "+parameter.IsNullable.ToString().ToLower()+Environment.NewLine+
							"\tSourceColumn: "+parameter.SourceColumn+Environment.NewLine+
							"\tSourceVersion: "+parameter.SourceVersion+Environment.NewLine);
					}
					fstr_out.WriteLine();

					Transaction.Rollback();
					Transaction=null;

					Result=0;
				}
				catch (AseException eException)
				{
					Console.WriteLine(eException.GetType().FullName+Environment.NewLine+
						"Errors:"+Environment.NewLine+ErrorsToString(eException.Errors)+Environment.NewLine+
						"Message: "+eException.Message+Environment.NewLine+
						"Source: "+eException.Source+Environment.NewLine+
						"StackTrace:"+Environment.NewLine+eException.StackTrace+Environment.NewLine+
						"TargetSite: "+eException.TargetSite+Environment.NewLine);

				}
				catch(Exception eException)
				{
					Console.WriteLine(eException.GetType().FullName+Environment.NewLine+
					"Message: "+eException.Message+Environment.NewLine+
					"Source: "+eException.Source+Environment.NewLine+
					"StackTrace:"+Environment.NewLine+eException.StackTrace+Environment.NewLine+
					"TargetSite: "+eException.TargetSite+Environment.NewLine+
					"InnerException:"+Environment.NewLine+eException.InnerException.GetType().FullName+Environment.NewLine+
					"InnerException.Message: "+eException.InnerException.Message+Environment.NewLine+
					"InnerException.Source: "+eException.InnerException.Source+Environment.NewLine+
					"InnerException.StackTrace:"+Environment.NewLine+eException.InnerException.StackTrace+Environment.NewLine+
					"InnerException.TargetSite: "+eException.InnerException.TargetSite);
				}
			}
			finally
			{
				if(Transaction!=null)
				{
					try
					{
						Transaction.Rollback();
					}
					catch
					{
						;
					}
				}

				if(reader!=null && !reader.IsClosed)
					reader.Close();

				if(cmd!=null)
					cmd.Dispose();

				if(conn!=null && conn.State==System.Data.ConnectionState.Open)
					conn.Close();

				if(fstr_out!=null)
					fstr_out.Close();

				#if WITH_TRACE
					if(_strmWriter!=null)
						_strmWriter.Close();
				#endif
			}

			return(Result);
		}
		//---------------------------------------------------------------------------

		private static string ErrorsToString(AseErrorCollection Errors)
		{
			string
				tmpString=string.Empty;

			int
				tmpInt=0;

			foreach(AseError error in Errors)
			{
				if(tmpString!=string.Empty)
					tmpString+=Environment.NewLine;
				tmpString+="\t#"+(++tmpInt)+Environment.NewLine+
					"\tIsError: "+error.IsError.ToString().ToLower()+Environment.NewLine+
					"\tIsFromClient: "+error.IsFromClient.ToString().ToLower()+Environment.NewLine+
					"\tIsFromServer: "+error.IsFromServer.ToString().ToLower()+Environment.NewLine+
					"\tIsInformation: "+error.IsInformation.ToString().ToLower()+Environment.NewLine+
					"\tIsWarning: "+error.IsWarning.ToString().ToLower()+Environment.NewLine+
					"\tLineNum: "+error.LineNum+Environment.NewLine+
					"\tMessage: "+error.Message+Environment.NewLine+
					"\tMessageNumber: "+error.MessageNumber+Environment.NewLine+
					"\tProcName: "+error.ProcName+Environment.NewLine+
					"\tServerName: "+error.ServerName+Environment.NewLine+
					"\tSeverity: "+error.Severity+Environment.NewLine+
					"\tSqlState: "+error.SqlState+Environment.NewLine+
					"\tState: "+error.State+Environment.NewLine+
					"\tStatus: "+error.Status+Environment.NewLine+
					"\tTranState: "+error.TranState+Environment.NewLine;
			}

			return(tmpString);
		}
		//---------------------------------------------------------------------------
			
		private static void conn_InfoMessage(object obj, AseInfoMessageEventArgs args)
		{
			Console.WriteLine("InfoMessage event occurred (sender: "+obj.ToString()+")");
			Console.WriteLine("\tMessage received: "+args.Message+(args.Errors.Count>0 ? Environment.NewLine+"\tErrors:"+Environment.NewLine+ErrorsToString(args.Errors) : string.Empty));
		}
		//---------------------------------------------------------------------------

		private static void conn_StateChange(object sender, System.Data.StateChangeEventArgs e)
		{
			Console.WriteLine("StateChange event occurred (sender: "+sender.ToString()+")");
			Console.WriteLine("\tFrom (OriginalState): "+e.OriginalState.ToString()+"\n\tTo (CurrentState): "+e.CurrentState.ToString());
		}
		//---------------------------------------------------------------------------
		
		#if WITH_TRACE
		private static void conn_TraceEnter(AseConnection connection, object source, string method, object[] parameters)
		{
			indentLevel++;
			StringBuilder str = new StringBuilder(255);
			for(int i = 0; i < indentLevel; i++)
				str.Append("  ");
			str.Append("TraceEnter---");
			str.Append(source.GetType().Name + "(" + source.GetHashCode().ToString() + ")." + method + "(");
			if (parameters != null && parameters.Length > 0)
			{
				for (int i = 0; i < parameters.Length-1; i++)
				{
					str.Append(parameters[i].ToString() + ",");
				}
				str.Append(parameters[parameters.Length-1].ToString());
			}
			str.Append(")");

			if(source.GetType().Name == "AseConnection" && method == "Open")
			{
				str.Append(" DriverVersion = \"" + AseConnection.DriverVersion + "\"");
				str.Append(" ConnectionString = \"" + connection.ConnectionString + "\"");
			}

			_strmWriter.WriteLine(str.ToString());
		}
		//---------------------------------------------------------------------------

		private static void conn_TraceExit(AseConnection connection, object source, string method, object returnValue)
		{
			StringBuilder str = new StringBuilder(255);
			for(int i = 0; i < indentLevel; i++)
				str.Append("  ");
			str.Append("TraceExit---");
			str.Append(source.GetType().Name + "(" + source.GetHashCode().ToString() + ")." + method + "() returned - ");
			if (returnValue != null)
				str.Append(returnValue.ToString());
			else
				str.Append("null / void");

			_strmWriter.WriteLine(str.ToString());
			indentLevel--;
		}
		//---------------------------------------------------------------------------
		#endif
	}
}
