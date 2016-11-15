#define TEST_DBF_BY_ODBC
//#define TEST_DBF
//#define TEST_DBF_JOIN
//#define TEST_VFP

using System;
using System.Data;
#if TEST_DBF_BY_ODBC
	using System.Data.Odbc;
#endif
using System.Data.OleDb;
using System.IO;

namespace TestDbf
{
	class TestDbf
	{
		[STAThread]
		public static int Main(string[] args)
		{
			int
				Result=-1,
				_ID_;

			StreamWriter
				fstr_out=null,
				fstr_out_866=null;

			string
				tmpString="log.log",
				DbfFileName,
				asciiString,
				cp866String;

			byte[]
				asciiBytes,
				cp866Bytes;

			char[]
				cp866Chars;

			#if TEST_DBF_BY_ODBC
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
				tmpDataTable=null;

			object
				tmpObject;

			try
			{
				try
				{
					fstr_out=new StreamWriter(tmpString,false,System.Text.Encoding.GetEncoding(1251));
					fstr_out.AutoFlush=true;

					fstr_out_866=new StreamWriter(tmpString+"_866",false,System.Text.Encoding.GetEncoding(866));
					fstr_out_866.AutoFlush=true;

					#if TEST_DBF_BY_ODBC || TEST_DBF || TEST_VFP
						string
							PathToDbf="C:\\FPD26\\dbf",
							CommonDbfTableName="Common",
							CommonDbfTableSQLCreate=@"
create table "+CommonDbfTableName+@"(
FInt integer,
FChar char(254),
FDate1 date,
FDate2 date
)";
					#endif

					#if TEST_DBF_BY_ODBC
						if(PathToDbf.EndsWith(Path.DirectorySeparatorChar.ToString()))
							PathToDbf=PathToDbf.Remove(PathToDbf.Length-1,1);

						tmpString="Driver={Microsoft dBASE Driver (*.dbf)};DriverID=277;Dbq="+PathToDbf+";";
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

						tmpString=PathToDbf+Path.DirectorySeparatorChar+CommonDbfTableName+".dbf";
						if(File.Exists(tmpString))
							File.Delete(tmpString);

						odbc_cmd=odbc_conn.CreateCommand();
						odbc_cmd.CommandType=CommandType.Text;
						odbc_cmd.CommandText=CommonDbfTableSQLCreate;
						odbc_cmd.ExecuteNonQuery();

						odbc_cmd.CommandText="insert into "+CommonDbfTableName+" (FInt, FChar, FDate1, FDate2) values (1, 'Line# 1 Ëèíèÿ ¹ 1 Ë³í³ÿ ¹ 1', {d'2008-12-31'}, {d'2008-12-31'})";
						odbc_cmd.ExecuteNonQuery();

						odbc_cmd.CommandText="insert into "+CommonDbfTableName+" (FInt, FChar) values (?, ?)";
						odbc_cmd.Parameters.Clear();
						odbc_cmd.Parameters.Add("FInt",OdbcType.Int).Value=2;
						odbc_cmd.Parameters.Add("FChar",OdbcType.VarChar).Value="Line# 2 Ëèíèÿ ¹ 2 Ë³í³ÿ ¹ 2";
						odbc_cmd.ExecuteNonQuery();

						tmpString="select * from baza";
						odbc_cmd=new OdbcCommand(tmpString,odbc_conn);

						odbc_rdr=odbc_cmd.ExecuteReader();
						while(odbc_rdr.Read())
						{
							for(int i=0; i<odbc_rdr.FieldCount; ++i)
							{
								fstr_out.Write(odbc_rdr[odbc_rdr.GetName(i)]);
								if(i<odbc_rdr.FieldCount)
									fstr_out.Write("\t");
							}
							fstr_out.WriteLine();
						}
						odbc_rdr.Close();

						odbc_da=new OdbcDataAdapter(tmpString,odbc_conn);
						if(tmpDataTable==null)
							tmpDataTable=new DataTable();
						odbc_da.Fill(tmpDataTable);
						ShowStru(tmpDataTable,fstr_out);
						tmpDataTable.Reset();
						
						odbc_cmd.CommandText="select * from testtype_1";

						fstr_out.WriteLine();
						fstr_out.WriteLine("OdbcDataAdapter.FillSchema()");
						odbc_da.SelectCommand=odbc_cmd;
						odbc_da.FillSchema(tmpDataTable,SchemaType.Source);
						foreach(DataColumn c in tmpDataTable.Columns)
							fstr_out.WriteLine(c.ColumnName+": \""+c.DataType.ToString()+"\"");
						tmpDataTable.Reset();

						odbc_rdr=odbc_cmd.ExecuteReader(CommandBehavior.SchemaOnly);
						fstr_out.WriteLine(Environment.NewLine+"OdbcDataReader.HasRows="+odbc_rdr.HasRows.ToString());
						for(int i=0; i<odbc_rdr.FieldCount; ++i)
							fstr_out.WriteLine(odbc_rdr.GetName(i)+" GetDataTypeName(): \""+odbc_rdr.GetDataTypeName(i)+"\" GetFieldType(): \""+odbc_rdr.GetFieldType(i)+"\"");
						odbc_rdr.Close();

						/*
						odbc_cmd.CommandText="insert into testtype_1 (FLogical) values (true)";
						odbc_cmd.ExecuteNonQuery();

						odbc_cmd.CommandText="update testtype_1 set FLogical=false";
						odbc_cmd.ExecuteNonQuery();
						*/

						try
						{
							tmpString="select * from t"; // t is FoxPro (with cdx) table
							odbc_cmd.CommandText=tmpString;
							odbc_rdr=odbc_cmd.ExecuteReader();
							odbc_rdr.Close();
						}
						catch(OdbcException eException)
						{
							tmpString=string.Empty;
							for(int i=0; i<eException.Errors.Count; ++i)
							{
								if(tmpString!=string.Empty)
									tmpString+=Environment.NewLine;

								tmpString+="Index #"+i+"\t"+
									"Message: \""+eException.Errors[i].Message+"\"\t"+
									"Native: \""+eException.Errors[i].NativeError.ToString()+"\"\t"+
									"Source: \""+eException.Errors[i].Source+"\"\t"+
									"SQL: \""+eException.Errors[i].SQLState+"\"";
							}
							fstr_out.WriteLine(Environment.NewLine+"OdbcException:"+Environment.NewLine+tmpString+Environment.NewLine);
						}
						odbc_conn.Close();
					#endif

					#if TEST_DBF
						if(PathToDbf.EndsWith(Path.DirectorySeparatorChar.ToString()))
							PathToDbf=PathToDbf.Remove(PathToDbf.Length-1,1);

						tmpString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+PathToDbf+";Extended Properties=dBASE IV;User ID=;Password=";
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

						tmpString=PathToDbf+Path.DirectorySeparatorChar+CommonDbfTableName+".dbf";
						if(File.Exists(tmpString))
							File.Delete(tmpString);

						cmd=conn.CreateCommand();
						cmd.CommandType=CommandType.Text;
						cmd.CommandText=CommonDbfTableSQLCreate;
						cmd.ExecuteNonQuery();

						cmd.CommandText="insert into "+CommonDbfTableName+" (FInt, FChar, FDate1, FDate2) values (1, 'Line# 1 Ëèíèÿ ¹ 1 Ë³í³ÿ ¹ 1',{12/31/2008},{12/31/2008})";
						cmd.ExecuteNonQuery();

						cmd.CommandText="insert into "+CommonDbfTableName+" (FInt, FChar) values (?, ?)";
						cmd.Parameters.Clear();
						cmd.Parameters.Add("FInt",OleDbType.Integer).Value=2;
						cmd.Parameters.Add("FChar",OleDbType.VarChar).Value="Line# 2 Ëèíèÿ ¹ 2 Ë³í³ÿ ¹ 2";
						cmd.ExecuteNonQuery();

						tmpString="select * from baza";
						cmd=new OleDbCommand(tmpString,conn);
						rdr=cmd.ExecuteReader();
						while(rdr.Read())
						{
							for(int i=0; i<rdr.FieldCount; ++i)
							{
								fstr_out.Write(rdr[rdr.GetName(i)]);
								if(i<rdr.FieldCount)
									fstr_out.Write("\t");
							}
							fstr_out.WriteLine();
						}
						rdr.Close();

						tmpString="select * from dbffile";
						cmd=new OleDbCommand(tmpString,conn);
						rdr=cmd.ExecuteReader();
						fstr_out.WriteLine();
						while(rdr.Read())
							fstr_out.WriteLine(rdr.GetString(rdr.GetOrdinal("BANK")));
						rdr.Close();

						if(tmpDataTable==null)
							tmpDataTable=new DataTable();
						else
							tmpDataTable.Reset();

						if(da==null)
							da=new OleDbDataAdapter(cmd);
						da.Fill(tmpDataTable);
						ShowStru(tmpDataTable,fstr_out);
						tmpDataTable.Reset();
						fstr_out.WriteLine();

						cmd.CommandText="select * from testtype_1";
							
						fstr_out.WriteLine(cmd.CommandText);
						fstr_out.WriteLine(new string('-',cmd.CommandText.Length));
						fstr_out.WriteLine();
						fstr_out.WriteLine("OleDbDataAdapter.FillSchema()");
						da.SelectCommand=cmd;
						da.FillSchema(tmpDataTable,SchemaType.Source);
						foreach(DataColumn c in tmpDataTable.Columns)
							fstr_out.WriteLine(c.ColumnName+": \""+c.DataType.ToString()+"\"");
						tmpDataTable.Reset();
						fstr_out.WriteLine();

						fstr_out.WriteLine("OleDbCommand.ExecuteReader(CommandBehavior.SchemaOnly)");
						rdr=cmd.ExecuteReader(CommandBehavior.SchemaOnly);
						fstr_out.WriteLine("OleDbDataReader.HasRows="+rdr.HasRows.ToString());
						for(int i=0; i<rdr.FieldCount; ++i)
							fstr_out.WriteLine(rdr.GetName(i)+" "+rdr.GetDataTypeName(i)+" "+rdr.GetFieldType(i));
						rdr.Close();
						fstr_out.WriteLine();

						cmd.CommandText="select * from testtype_2";
							
						fstr_out.WriteLine(cmd.CommandText);
						fstr_out.WriteLine(new string('-',cmd.CommandText.Length));
						fstr_out.WriteLine();
						fstr_out.WriteLine("OleDbDataAdapter.FillSchema()");
						da.SelectCommand=cmd;
						da.FillSchema(tmpDataTable,SchemaType.Source);
						foreach(DataColumn c in tmpDataTable.Columns)
							fstr_out.WriteLine(c.ColumnName+": \""+c.DataType.ToString()+"\"");
						tmpDataTable.Reset();
						fstr_out.WriteLine();

						fstr_out.WriteLine("OleDbCommand.ExecuteReader(CommandBehavior.SchemaOnly)");
						rdr=cmd.ExecuteReader(CommandBehavior.SchemaOnly);
						fstr_out.WriteLine("OleDbDataReader.HasRows="+rdr.HasRows.ToString());
						for(int i=0; i<rdr.FieldCount; ++i)
							fstr_out.WriteLine(rdr.GetName(i)+" "+rdr.GetDataTypeName(i)+" "+rdr.GetFieldType(i));
						rdr.Close();
						fstr_out.WriteLine();

						try
						{
							tmpString="select * from t"; // t is FoxPro (with cdx) table
							cmd.CommandText=tmpString;
							rdr=cmd.ExecuteReader();
							rdr.Close();
						}
						catch(OleDbException eException)
						{
							tmpString=string.Empty;
							for(int i=0; i<eException.Errors.Count; ++i)
							{
								if(tmpString!=string.Empty)
									tmpString+=Environment.NewLine;

								tmpString+="Index #"+i+"\t"+
									"Message: \""+eException.Errors[i].Message+"\"\t"+
									"Native: \""+eException.Errors[i].NativeError.ToString()+"\"\t"+
									"Source: \""+eException.Errors[i].Source+"\"\t"+
									"SQL: \""+eException.Errors[i].SQLState+"\"";
							}
							fstr_out.WriteLine(Environment.NewLine+"OleDbException:"+Environment.NewLine+tmpString+Environment.NewLine);
						}

						cmd.CommandType=CommandType.Text;
						DbfFileName="test_ins";
						cmd.CommandText="delete from "+DbfFileName;
						cmd.ExecuteNonQuery();

						cmd.CommandText="select max(ID) from "+DbfFileName;
						tmpObject=cmd.ExecuteScalar();
						_ID_= !Convert.IsDBNull(tmpObject) ? Convert.ToInt32(tmpObject)+1 : 1;

						cmd.CommandText="insert into "+DbfFileName+" (ID, FCHAR, DDATE, FNUMERIC) values (?, ?, ?, ?)";
						cmd.Parameters.Clear();
						cmd.Parameters.Add("ID",OleDbType.Numeric).Value=_ID_;
						cmd.Parameters.Add("FCHAR",OleDbType.VarChar).Value="ABCDEFGHIJKLMNOPQRSTUVWXYZ";
						cmd.Parameters.Add("DDATE",OleDbType.Date).Value=DateTime.Now;
						cmd.Parameters.Add("FNUMERIC",OleDbType.Numeric).Value=99.999*_ID_;
						cmd.ExecuteNonQuery();

						cmd.Parameters["ID"].Value=++_ID_;
						cmd.Parameters["FCHAR"].Value="abcdefghijklmnopqrstuvwxyz";
						cmd.Parameters["DDATE"].Value=DateTime.Now;
						cmd.Parameters["FNUMERIC"].Value=99.999*_ID_;
						cmd.ExecuteNonQuery();

						cmd.Parameters["ID"].Value=++_ID_;
						cmd.Parameters["FCHAR"].Value="ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞß";
						cmd.Parameters["DDATE"].Value=DateTime.Now;
						cmd.Parameters["FNUMERIC"].Value=99.999*_ID_;
						cmd.ExecuteNonQuery();

						cmd.Parameters["ID"].Value=++_ID_;
						cmd.Parameters["FCHAR"].Value="àáâãäåæçèéêëìíîïðñòóôõö÷øùúûüýþÿ";
						cmd.Parameters["DDATE"].Value=DateTime.Now;
						cmd.Parameters["FNUMERIC"].Value=99.999*_ID_;
						cmd.ExecuteNonQuery();

						cmd.Parameters["ID"].Value=++_ID_;
						cmd.Parameters["FCHAR"].Value="¨¸¥´²³¯¿ªº¹";
						cmd.Parameters["DDATE"].Value=DateTime.Now;
						cmd.Parameters["FNUMERIC"].Value=99.999*_ID_;
						cmd.ExecuteNonQuery();

						asciiString="ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞß";
						asciiBytes=System.Text.Encoding.GetEncoding(1251).GetBytes(asciiString);
						cp866Bytes=System.Text.Encoding.Convert(System.Text.Encoding.GetEncoding(1251),System.Text.Encoding.GetEncoding(866),asciiBytes);
						cp866Chars=new char[System.Text.Encoding.GetEncoding(866).GetCharCount(cp866Bytes,0,cp866Bytes.Length)];
						System.Text.Encoding.GetEncoding(866).GetChars(cp866Bytes,0,cp866Bytes.Length,cp866Chars,0);
						cp866String=new string(cp866Chars);
						cmd.Parameters["ID"].Value=++_ID_;
						cmd.Parameters["FCHAR"].Value=cp866String;
						cmd.Parameters["DDATE"].Value=DateTime.Now;
						cmd.Parameters["FNUMERIC"].Value=99.999*_ID_;
						cmd.ExecuteNonQuery();

						asciiString="àáâãäåæçèéêëìíîïðñòóôõö÷øùúûüýþÿ";
						asciiBytes=System.Text.Encoding.GetEncoding(1251).GetBytes(asciiString);
						cp866Bytes=System.Text.Encoding.Convert(System.Text.Encoding.GetEncoding(1251),System.Text.Encoding.GetEncoding(866),asciiBytes);
						cp866Chars=new char[System.Text.Encoding.GetEncoding(866).GetCharCount(cp866Bytes,0,cp866Bytes.Length)];
						System.Text.Encoding.GetEncoding(866).GetChars(cp866Bytes,0,cp866Bytes.Length,cp866Chars,0);
						cp866String=new string(cp866Chars);
						cmd.Parameters["ID"].Value=++_ID_;
						cmd.Parameters["FCHAR"].Value=cp866String;
						cmd.Parameters["DDATE"].Value=DateTime.Now;
						cmd.Parameters["FNUMERIC"].Value=99.999*_ID_;
						cmd.ExecuteNonQuery();

						asciiString="¨¸¥´²³¯¿ªº¹";
						asciiBytes=System.Text.Encoding.GetEncoding(1251).GetBytes(asciiString);
						asciiBytes[2]=0x0c3; // 0x0a5 (165) -> 0x0c3 (195) ¥ -> Ã
						asciiBytes[3]=0x0e3; // 0x0b4 (180) -> 0x0e3 (227) ´ -> ã
						asciiBytes[4]=0x0a1; // 0x0b2 (178) -> 0x0a1 (161) ² -> ¡
						asciiBytes[5]=0x0a2; // 0x0b3 (179) -> 0x0a2 (162) ³ -> ¢
						asciiBytes[6]=0x0b0; // 0x0af (175) -> 0x0b0 (176) ¯ -> °
						asciiBytes[7]=0x0b7; // 0x0bf (191) -> 0x0b7 (183) ¿ -> ·
						asciiBytes[8]=0x0af; // 0x0aa (170) -> 0x0af (175) ª -> ¯
						asciiBytes[9]=0x0bf; // 0x0ba (186) -> 0x0bf (191) º -> ¿						
						cp866Bytes=System.Text.Encoding.Convert(System.Text.Encoding.GetEncoding(1251),System.Text.Encoding.GetEncoding(866),asciiBytes);
						cp866Chars=new char[System.Text.Encoding.GetEncoding(866).GetCharCount(cp866Bytes,0,cp866Bytes.Length)];
						System.Text.Encoding.GetEncoding(866).GetChars(cp866Bytes,0,cp866Bytes.Length,cp866Chars,0);
						cp866Chars[7]=(char)0x02219;
						cp866String=new string(cp866Chars);
					
						cmd.Parameters["ID"].Value=++_ID_;
						cmd.Parameters["FCHAR"].Value=cp866String;
						cmd.Parameters["DDATE"].Value=DateTime.Now;
						cmd.Parameters["FNUMERIC"].Value=99.999*_ID_;
						cmd.ExecuteNonQuery();

						cmd.Parameters["ID"].Value=++_ID_;
						cmd.Parameters["FCHAR"].Value=CP1251ToCP866("Line# 2 Ëèíèÿ ¹ 2 Ë³í³ÿ ¹ 2");
						cmd.Parameters["DDATE"].Value=DateTime.Now;
						cmd.Parameters["FNUMERIC"].Value=99.999*_ID_;
						cmd.ExecuteNonQuery();

						if(!PathToDbf.EndsWith(Path.DirectorySeparatorChar.ToString()))
							PathToDbf+=Path.DirectorySeparatorChar;

						DbfFileName="test_ADO.dbf";
						if(File.Exists(PathToDbf+DbfFileName))
							File.Delete(PathToDbf+DbfFileName);

						DbfFileName=Path.GetFileNameWithoutExtension(DbfFileName);

						cmd.CommandText="create table "+DbfFileName+"(ID numeric(18,0), FCHAR varchar(254), DDATE date, FNUMERIC numeric(10,4))";
						cmd.ExecuteNonQuery();

						cmd.CommandText="select max(ID) from "+DbfFileName;
						tmpObject=cmd.ExecuteScalar();
						_ID_= !Convert.IsDBNull(tmpObject) ? Convert.ToInt32(tmpObject)+1 : 1;

						cmd.CommandText="insert into "+DbfFileName+" (ID, FCHAR, DDATE, FNUMERIC) values (?, ?, ?, ?)";
						cmd.Parameters.Clear();
						cmd.Parameters.Add("ID",OleDbType.Numeric).Value=_ID_;
						cmd.Parameters.Add("FCHAR",OleDbType.VarChar).Value="ABCDEFGHIJKLMNOPQRSTUVWXYZ";
						cmd.Parameters.Add("DDATE",OleDbType.Date).Value=DateTime.Now;
						cmd.Parameters.Add("FNUMERIC",OleDbType.Numeric).Value=99.999*_ID_;
						cmd.ExecuteNonQuery();

						cmd.Parameters["ID"].Value=++_ID_;
						cmd.Parameters["FCHAR"].Value="abcdefghijklmnopqrstuvwxyz";
						cmd.Parameters["DDATE"].Value=DateTime.Now;
						cmd.Parameters["FNUMERIC"].Value=99.999*_ID_;
						cmd.ExecuteNonQuery();

						cmd.Parameters["ID"].Value=++_ID_;
						cmd.Parameters["FCHAR"].Value="ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞß";
						cmd.Parameters["DDATE"].Value=DateTime.Now;
						cmd.Parameters["FNUMERIC"].Value=99.999*_ID_;
						cmd.ExecuteNonQuery();

						cmd.Parameters["ID"].Value=++_ID_;
						cmd.Parameters["FCHAR"].Value="àáâãäåæçèéêëìíîïðñòóôõö÷øùúûüýþÿ";
						cmd.Parameters["DDATE"].Value=DateTime.Now;
						cmd.Parameters["FNUMERIC"].Value=99.999*_ID_;
						cmd.ExecuteNonQuery();

						cmd.Parameters["ID"].Value=++_ID_;
						cmd.Parameters["FCHAR"].Value="¨¸¥´²³¯¿ªº¹";
						cmd.Parameters["DDATE"].Value=DateTime.Now;
						cmd.Parameters["FNUMERIC"].Value=99.999*_ID_;
						cmd.ExecuteNonQuery();

						asciiString="ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞß";
						asciiBytes=System.Text.Encoding.GetEncoding(1251).GetBytes(asciiString);
						cp866Bytes=System.Text.Encoding.Convert(System.Text.Encoding.GetEncoding(1251),System.Text.Encoding.GetEncoding(866),asciiBytes);
						cp866Chars=new char[System.Text.Encoding.GetEncoding(866).GetCharCount(cp866Bytes,0,cp866Bytes.Length)];
						System.Text.Encoding.GetEncoding(866).GetChars(cp866Bytes,0,cp866Bytes.Length,cp866Chars,0);
						cp866String=new string(cp866Chars);
						cmd.Parameters["ID"].Value=++_ID_;
						cmd.Parameters["FCHAR"].Value=cp866String;
						cmd.Parameters["DDATE"].Value=DateTime.Now;
						cmd.Parameters["FNUMERIC"].Value=99.999*_ID_;
						cmd.ExecuteNonQuery();

						asciiString="àáâãäåæçèéêëìíîïðñòóôõö÷øùúûüýþÿ";
						asciiBytes=System.Text.Encoding.GetEncoding(1251).GetBytes(asciiString);
						cp866Bytes=System.Text.Encoding.Convert(System.Text.Encoding.GetEncoding(1251),System.Text.Encoding.GetEncoding(866),asciiBytes);
						cp866Chars=new char[System.Text.Encoding.GetEncoding(866).GetCharCount(cp866Bytes,0,cp866Bytes.Length)];
						System.Text.Encoding.GetEncoding(866).GetChars(cp866Bytes,0,cp866Bytes.Length,cp866Chars,0);
						cp866String=new string(cp866Chars);
						cmd.Parameters["ID"].Value=++_ID_;
						cmd.Parameters["FCHAR"].Value=cp866String;
						cmd.Parameters["DDATE"].Value=DateTime.Now;
						cmd.Parameters["FNUMERIC"].Value=99.999*_ID_;
						cmd.ExecuteNonQuery();

						asciiString="¨¸¥´²³¯¿ªº¹";
						asciiBytes=System.Text.Encoding.GetEncoding(1251).GetBytes(asciiString);
						asciiBytes[2]=0x0c3; // 0x0a5 (165) -> 0x0c3 (195) ¥ -> Ã
						asciiBytes[3]=0x0e3; // 0x0b4 (180) -> 0x0e3 (227) ´ -> ã
						asciiBytes[4]=0x0a1; // 0x0b2 (178) -> 0x0a1 (161) ² -> ¡
						asciiBytes[5]=0x0a2; // 0x0b3 (179) -> 0x0a2 (162) ³ -> ¢
						asciiBytes[6]=0x0b0; // 0x0af (175) -> 0x0b0 (176) ¯ -> °
						asciiBytes[7]=0x0b7; // 0x0bf (191) -> 0x0b7 (183) ¿ -> ·
						asciiBytes[8]=0x0af; // 0x0aa (170) -> 0x0af (175) ª -> ¯
						asciiBytes[9]=0x0bf; // 0x0ba (186) -> 0x0bf (191) º -> ¿						
						cp866Bytes=System.Text.Encoding.Convert(System.Text.Encoding.GetEncoding(1251),System.Text.Encoding.GetEncoding(866),asciiBytes);
						cp866Chars=new char[System.Text.Encoding.GetEncoding(866).GetCharCount(cp866Bytes,0,cp866Bytes.Length)];
						System.Text.Encoding.GetEncoding(866).GetChars(cp866Bytes,0,cp866Bytes.Length,cp866Chars,0);
						cp866Chars[7]=(char)0x02219; // •
						cp866String=new string(cp866Chars);
						cmd.Parameters["ID"].Value=++_ID_;
						cmd.Parameters["FCHAR"].Value=cp866String;
						cmd.Parameters["DDATE"].Value=DateTime.Now;
						cmd.Parameters["FNUMERIC"].Value=99.999*_ID_;
						cmd.ExecuteNonQuery();

						cmd.Parameters["ID"].Value=++_ID_;
						cmd.Parameters["FCHAR"].Value=tmpString=CP1251ToCP866("Line# 2 Ëèíèÿ ¹ 2 Ë³í³ÿ ¹ 2");
						cmd.Parameters["DDATE"].Value=DateTime.Now;
						cmd.Parameters["FNUMERIC"].Value=99.999*_ID_;
						cmd.ExecuteNonQuery();
						fstr_out_866.WriteLine(tmpString);

						#if TEST_DBF_JOIN
							cmd.CommandType=CommandType.Text;
/*
							cmd.CommandText=@"
select
m.*,
d_l_I.*,
d_l_II.*
from
master m
left outer join det_l_I d_l_I on (d_l_I.Master_ID=m.ID)
left outer join det_l_II d_l_II on (d_l_II.Master_ID=m.ID) and (d_l_II.det_l_I_ID=d_l_I.ID)
order by m.ID, d_l_I.ID, d_l_II.ID
";
*/
/*
							cmd.CommandText=@"
select
m.*,
d_l_I.*,
d_l_II.*
from
master m
left outer join det_l_I d_l_I on (d_l_I.Master_ID=m.ID)
left outer join det_l_II d_l_II on (d_l_II.Master_ID=d_l_I.Master_ID) and (d_l_II.det_l_I_ID=d_l_I.ID)
order by m.ID, d_l_I.ID, d_l_II.ID
";
*/
							cmd.CommandText=@"
select
m.*,
d_l_I.*,
d_l_II.*
from
master m
join det_l_I d_l_I on (d_l_I.Master_ID=m.ID)
join det_l_II d_l_II on (d_l_II.Master_ID=m.ID) and (d_l_II.det_l_I_ID=d_l_I.ID)
order by m.ID, d_l_I.ID, d_l_II.ID
";

/*
							cmd.CommandText=@"
select
m.*,
d_l_I.*,
d_l_II.*
from
master m
join det_l_I d_l_I on (d_l_I.Master_ID=m.ID)
join det_l_II d_l_II on (d_l_II.Master_ID=d_l_I.Master_ID) and (d_l_II.det_l_I_ID=d_l_I.ID)
order by m.ID, d_l_I.ID, d_l_II.ID
";
*/

							if(da==null)
								da=new OleDbDataAdapter(cmd);
							else
								da.SelectCommand=cmd;

							if(tmpDataTable==null)
								tmpDataTable=new DataTable();
							else
								tmpDataTable.Reset();

							da.Fill(tmpDataTable);
							tmpDataTable.Reset();
						#endif

						conn.Close();
					#endif

					#if TEST_VFP
						if(!PathToDbf.EndsWith(Path.DirectorySeparatorChar.ToString()))
							PathToDbf+=Path.DirectorySeparatorChar;

						tmpString="Provider=vfpoledb.1;Data Source="+PathToDbf;//Collating Sequence=general";
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

						tmpString=PathToDbf+CommonDbfTableName+".dbf";
						if(File.Exists(tmpString))
							File.Delete(tmpString);

						cmd=conn.CreateCommand();
						cmd.CommandType=CommandType.Text;
						cmd.CommandText=CommonDbfTableSQLCreate;
						cmd.ExecuteNonQuery();

						cmd.CommandText="insert into "+CommonDbfTableName+" (FInt, FChar) values (1, 'Line# 1 Ëèíèÿ ¹ 1 Ë³í³ÿ ¹ 1')";
						cmd.ExecuteNonQuery();

						cmd.CommandText="insert into "+CommonDbfTableName+" (FInt, FChar, FDate1, FDate2) values (?, ?, ?, ?)";
						cmd.Parameters.Clear();
						cmd.Parameters.Add("FInt",OleDbType.Integer).Value=2;
						cmd.Parameters.Add("FChar",OleDbType.VarChar).Value="Line# 2 Ëèíèÿ ¹ 2 Ë³í³ÿ ¹ 2";
						cmd.Parameters.Add("FDate1",OleDbType.DBDate).Value=DateTime.Now;
						cmd.Parameters.Add("FDate2",OleDbType.Date).Value=DateTime.Now;	
						cmd.ExecuteNonQuery();

						cmd.CommandText="insert into test_t3 (FDate1, FDate2, FChar1) values (?, ?, ?)";
						cmd.Parameters.Clear();
						cmd.Parameters.Add("FDate1",OleDbType.Date).Value=DateTime.Now;
						cmd.Parameters.Add("FDate2",OleDbType.DBDate).Value=DateTime.Now;
						cmd.Parameters.Add("FChar1",OleDbType.Char).Value=CP1251ToCP866("Line# 2 Ëèíèÿ ¹ 2 Ë³í³ÿ ¹ 2");
						cmd.ExecuteNonQuery();

						cmd.CommandText="insert into test_t3 (FDate1, FDate2, FChar1) values ({12/31/2008},{12/31/2008},'"+CP1251ToCP866("Line# 2 Ëèíèÿ ¹ 2 Ë³í³ÿ ¹ 2")+"')";
						cmd.ExecuteNonQuery();

						DbfFileName="test_ins";
						cmd.CommandText="delete from "+DbfFileName;
						cmd.ExecuteNonQuery();

						cmd.CommandText="select max(ID) from "+DbfFileName;
						tmpObject=cmd.ExecuteScalar();
						_ID_= !Convert.IsDBNull(tmpObject) ? Convert.ToInt32(tmpObject)+1 : 1;

						cmd.CommandText="insert into "+DbfFileName+" (ID, FCHAR, DDATE, FNUMERIC) values (?, ?, ?, ?)";
						cmd.Parameters.Clear();
						cmd.Parameters.Add("ID",OleDbType.Numeric).Value=_ID_;
						cmd.Parameters.Add("FCHAR",OleDbType.VarChar).Value="ABCDEFGHIJKLMNOPQRSTUVWXYZ";
						cmd.Parameters.Add("DDATE",OleDbType.Date).Value=DateTime.Now;
						cmd.Parameters.Add("FNUMERIC",OleDbType.Numeric).Value=99.999*_ID_;
						cmd.ExecuteNonQuery();

						cmd.Parameters["ID"].Value=++_ID_;
						cmd.Parameters["FCHAR"].Value="abcdefghijklmnopqrstuvwxyz";
						cmd.Parameters["DDATE"].Value=DateTime.Now;
						cmd.Parameters["FNUMERIC"].Value=99.999*_ID_;
						cmd.ExecuteNonQuery();

						cmd.Parameters["ID"].Value=++_ID_;
						cmd.Parameters["FCHAR"].Value="ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞß";
						cmd.Parameters["DDATE"].Value=DateTime.Now;
						cmd.Parameters["FNUMERIC"].Value=99.999*_ID_;
						cmd.ExecuteNonQuery();

						cmd.Parameters["ID"].Value=++_ID_;
						cmd.Parameters["FCHAR"].Value="àáâãäåæçèéêëìíîïðñòóôõö÷øùúûüýþÿ";
						cmd.Parameters["DDATE"].Value=DateTime.Now;
						cmd.Parameters["FNUMERIC"].Value=99.999*_ID_;
						cmd.ExecuteNonQuery();

						cmd.Parameters["ID"].Value=++_ID_;
						cmd.Parameters["FCHAR"].Value="¨¸¥´²³¯¿ªº¹";
						cmd.Parameters["DDATE"].Value=DateTime.Now;
						cmd.Parameters["FNUMERIC"].Value=99.999*_ID_;
						cmd.ExecuteNonQuery();

						asciiString="ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞß";
						asciiBytes=System.Text.Encoding.GetEncoding(1251).GetBytes(asciiString);
						cp866Bytes=System.Text.Encoding.Convert(System.Text.Encoding.GetEncoding(1251),System.Text.Encoding.GetEncoding(866),asciiBytes);
						cp866Chars=new char[System.Text.Encoding.GetEncoding(866).GetCharCount(cp866Bytes,0,cp866Bytes.Length)];
						System.Text.Encoding.GetEncoding(866).GetChars(cp866Bytes,0,cp866Bytes.Length,cp866Chars,0);
						cp866String=new string(cp866Chars);
						cmd.Parameters["ID"].Value=++_ID_;
						cmd.Parameters["FCHAR"].Value=cp866String;
						cmd.Parameters["DDATE"].Value=DateTime.Now;
						cmd.Parameters["FNUMERIC"].Value=99.999*_ID_;
						cmd.ExecuteNonQuery();

						asciiString="àáâãäåæçèéêëìíîïðñòóôõö÷øùúûüýþÿ";
						asciiBytes=System.Text.Encoding.GetEncoding(1251).GetBytes(asciiString);
						cp866Bytes=System.Text.Encoding.Convert(System.Text.Encoding.GetEncoding(1251),System.Text.Encoding.GetEncoding(866),asciiBytes);
						cp866Chars=new char[System.Text.Encoding.GetEncoding(866).GetCharCount(cp866Bytes,0,cp866Bytes.Length)];
						System.Text.Encoding.GetEncoding(866).GetChars(cp866Bytes,0,cp866Bytes.Length,cp866Chars,0);
						cp866String=new string(cp866Chars);
						cmd.Parameters["ID"].Value=++_ID_;
						cmd.Parameters["FCHAR"].Value=cp866String;
						cmd.Parameters["DDATE"].Value=DateTime.Now;
						cmd.Parameters["FNUMERIC"].Value=99.999*_ID_;
						cmd.ExecuteNonQuery();

						asciiString="¨¸¥´²³¯¿ªº¹";
						asciiBytes=System.Text.Encoding.GetEncoding(1251).GetBytes(asciiString);
						asciiBytes[2]=0x0c3; // 0x0a5 (165) -> 0x0c3 (195) ¥ -> Ã
						asciiBytes[3]=0x0e3; // 0x0b4 (180) -> 0x0e3 (227) ´ -> ã
						asciiBytes[4]=0x0a1; // 0x0b2 (178) -> 0x0a1 (161) ² -> ¡
						asciiBytes[5]=0x0a2; // 0x0b3 (179) -> 0x0a2 (162) ³ -> ¢
						asciiBytes[6]=0x0b0; // 0x0af (175) -> 0x0b0 (176) ¯ -> °
						asciiBytes[7]=0x0b7; // 0x0bf (191) -> 0x0b7 (183) ¿ -> ·
						asciiBytes[8]=0x0af; // 0x0aa (170) -> 0x0af (175) ª -> ¯
						asciiBytes[9]=0x0bf; // 0x0ba (186) -> 0x0bf (191) º -> ¿						
						cp866Bytes=System.Text.Encoding.Convert(System.Text.Encoding.GetEncoding(1251),System.Text.Encoding.GetEncoding(866),asciiBytes);
						cp866Chars=new char[System.Text.Encoding.GetEncoding(866).GetCharCount(cp866Bytes,0,cp866Bytes.Length)];
						System.Text.Encoding.GetEncoding(866).GetChars(cp866Bytes,0,cp866Bytes.Length,cp866Chars,0);
						cp866Chars[7]=(char)0x02219;
						cp866String=new string(cp866Chars);
						
						cmd.Parameters["ID"].Value=++_ID_;
						cmd.Parameters["FCHAR"].Value=cp866String;
						cmd.Parameters["DDATE"].Value=DateTime.Now;
						cmd.Parameters["FNUMERIC"].Value=99.999*_ID_;
						cmd.ExecuteNonQuery();

						cmd.Parameters["ID"].Value=++_ID_;
						cmd.Parameters["FCHAR"].Value=CP1251ToCP866("Line# 2 Ëèíèÿ ¹ 2 Ë³í³ÿ ¹ 2");
						cmd.Parameters["DDATE"].Value=DateTime.Now;
						cmd.Parameters["FNUMERIC"].Value=99.999*_ID_;
						cmd.ExecuteNonQuery();

						if(tmpDataTable==null)
							tmpDataTable=new DataTable();
						else
							tmpDataTable.Reset();

						cmd.CommandText="select * from "+CommonDbfTableName;
						if(da==null)
							da=new OleDbDataAdapter(cmd);
						else
							da.SelectCommand=cmd;

						da.Fill(tmpDataTable);

						tmpString="select * from baza";
						cmd=new OleDbCommand(tmpString,conn);
						rdr=cmd.ExecuteReader();
						while(rdr.Read())
						{
							for(int i=0; i<rdr.FieldCount; ++i)
							{
								fstr_out.Write(rdr[rdr.GetName(i)]);
								if(i<rdr.FieldCount)
									fstr_out.Write("\t");
							}
							fstr_out.WriteLine();
						}
						rdr.Close();
						fstr_out.WriteLine();

						if(tmpDataTable==null)
							tmpDataTable=new DataTable();
						else
							tmpDataTable.Reset();

						if(da==null)
							da=new OleDbDataAdapter(cmd);
						else
							da.SelectCommand=cmd;

						da.Fill(tmpDataTable);
						foreach(DataRow _r_ in tmpDataTable.Rows)
						{
							foreach(DataColumn _c_ in tmpDataTable.Columns)
								fstr_out.Write(_r_[_c_.ColumnName]+"\t");
							fstr_out.WriteLine();
						}
						fstr_out.WriteLine();

						cmd.CommandText="select * from test_ins";
						da.SelectCommand=cmd;
						tmpDataTable.Reset();
						da.Fill(tmpDataTable);
						foreach(DataRow _r_ in tmpDataTable.Rows)
						{
							foreach(DataColumn _c_ in tmpDataTable.Columns)
								fstr_out.Write(_r_[_c_.ColumnName]+"\t");
							fstr_out.WriteLine();
						}
						fstr_out.WriteLine();
		
						tmpString="select * from t";
						cmd=new OleDbCommand(tmpString,conn);
						rdr=cmd.ExecuteReader();
						while(rdr.Read())
						{
							for(int i=0; i<rdr.FieldCount; ++i)
							{
								fstr_out.Write(rdr[rdr.GetName(i)]);
								if(i<rdr.FieldCount)
									fstr_out.Write("\t");
							}
							fstr_out.WriteLine();
						}
						rdr.Close();
						fstr_out.WriteLine();

						cmd.CommandType=CommandType.Text;
/*
						cmd.CommandText=@"
select
m.*,
d_l_I.*,
d_l_II.*
from
master m
left outer join det_l_I d_l_I on (d_l_I.Master_ID=m.ID)
left outer join det_l_II d_l_II on (d_l_II.Master_ID=m.ID) and (d_l_II.det_l_I_ID=d_l_I.ID)
order by m.ID, d_l_I.ID, d_l_II.ID
";
*/
/*
						cmd.CommandText=@"
select
m.*,
d_l_I.*,
d_l_II.*
from
master m
left outer join det_l_I d_l_I on (d_l_I.Master_ID=m.ID)
left outer join det_l_II d_l_II on (d_l_II.Master_ID=d_l_I.Master_ID) and (d_l_II.det_l_I_ID=d_l_I.ID)
order by m.ID, d_l_I.ID, d_l_II.ID
";
*/

						cmd.CommandText=@"
select
m.*,
d_l_I.*,
d_l_II.*
from
master m
join det_l_I d_l_I on (d_l_I.Master_ID=m.ID)
join det_l_II d_l_II on (d_l_II.Master_ID=m.ID) and (d_l_II.det_l_I_ID=d_l_I.ID)
order by m.ID, d_l_I.ID, d_l_II.ID
";

/*
						cmd.CommandText=@"
select
m.*,
d_l_I.*,
d_l_II.*
from
master m
join det_l_I d_l_I on (d_l_I.Master_ID=m.ID)
join det_l_II d_l_II on (d_l_II.Master_ID=d_l_I.Master_ID) and (d_l_II.det_l_I_ID=d_l_I.ID)
order by m.ID, d_l_I.ID, d_l_II.ID
";
*/

						if(da==null)
							da=new OleDbDataAdapter(cmd);
						else
							da.SelectCommand=cmd;

						if(tmpDataTable==null)
							tmpDataTable=new DataTable();
						else
							tmpDataTable.Reset();

						da.Fill(tmpDataTable);
						tmpDataTable.Reset();

						conn.Close();
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
				#if TEST_DBF_BY_ODBC
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

				if(fstr_out_866!=null)
					fstr_out_866.Close();
			}
			return(Result);
		}

		static void ShowStru(DataTable t, StreamWriter f)
		{
			f.WriteLine();
			foreach(DataColumn col in t.Columns)
				f.WriteLine(col.ColumnName+": DataType=\""+col.DataType.ToString()+"\"");
		}

		public static string CP1251ToCP866(string aInpStr)
		{
			byte[]
				asciiBytes=System.Text.Encoding.GetEncoding(1251).GetBytes(aInpStr);

			for(int i=0; i<asciiBytes.Length; ++i)
			{
				switch(asciiBytes[i])
				{
					case 0x0a5 :
					{
						asciiBytes[i]=0x0c3; // 0x0a5 (165) -> 0x0c3 (195) ¥ -> Ã
						break;
					}
					case 0x0b4 :
					{
						asciiBytes[i]=0x0e3; // 0x0b4 (180) -> 0x0e3 (227) ´ -> ã
						break;	
					}
					case 0x0b2 :
					{
						asciiBytes[i]=0x049; // 0x0b2 (178) -> 0x049 (73) ² -> LATIN LETTER I
						break;	
					}
					case 0x0b3 :
					{
						asciiBytes[i]=0x069; // 0x0b3 (179) -> 0x069 (105) ³ -> LATIN LETTER i
						break;	
					}
				}
			}

			byte[]
				cp866Bytes=System.Text.Encoding.Convert(System.Text.Encoding.GetEncoding(1251),System.Text.Encoding.GetEncoding(866),asciiBytes);

			char[]
				cp866Chars=new char[System.Text.Encoding.GetEncoding(866).GetCharCount(cp866Bytes,0,cp866Bytes.Length)];

			System.Text.Encoding.GetEncoding(866).GetChars(cp866Bytes,0,cp866Bytes.Length,cp866Chars,0);
			return(new string(cp866Chars));				
		}
		//---------------------------------------------------------------------------
	}
}