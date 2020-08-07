//#define TEST_NULL //http://blogs.msdn.com/b/aconrad/archive/2005/02/28/381859.aspx
//#define TEST_NLS_NUMERIC_CHARACTERS
//#define CAST_VS_CONVERT
//#define TEST_TYPES
//#define TEST_DBMS_OUTPUT
//#define TEST_CLOB
//#define TEST_EXECUTE_SCALAR
//#define TEST_FUNCTION
#define GET_STORED_PROCEDURE_PARAMETERS
//#define TEST_SEND_E_MAIL
//#define TEST_STORED_PROCEDURE_IN_CIRCLE
//#define TEST_SELECT
//#define TEST_PARAMETERS
//#define TEST_MULTI_STATEMENTS
//#define TEST_STORED_PROCEDURE
//#define TEST_SELECTED_STORED_PROCEDURE
//#define TEST_BLOB
//#define TEST_BLOB_SAVE
//#define TEST_BLOB_SAVE_BY_SP

using System;
using System.IO;
using System.Data;
using System.Data.OracleClient;

namespace OracleOracle
{
	class Program
	{
		#if TEST_TYPES
			enum Enum4TestTypes : long
			{
				Unknown,
				First,
				Second,
				Third
			}
		#endif

		static void Main(string[] args)
		{
			StreamWriter
				fstr_out = null; 

			OracleConnection
				conn = null;

			OracleCommand
				cmd=null;

			OracleDataAdapter
				da=null;

			OracleDataReader
				rdr = null;

			OracleTransaction
				tr = null;

			DataTable
				tmpDataTable = null;

			object
				tmpObject;

			string
				FieldName,
				tmpString;

			long
				tmpLong;

			int
				tmpInt,
				i;

			bool
				tmpBool;

			DateTime
				tmpDateTime;

			try
			{
				try
				{
					fstr_out = new StreamWriter("log.log", false, System.Text.Encoding.GetEncoding(1251));
					fstr_out.AutoFlush = true;

					string
						ConnectionString = "User ID=corp_yk_user;Password=google;Data Source=sm";
						//ConnectionString = "User ID=aspnetuser;Password=aspnet;Data Source=ASM";
						//ConnectionString = "User ID=sqlpretension;Password=impression;Data Source=SM";

					conn = new OracleConnection(ConnectionString);
					#if TEST_DBMS_OUTPUT
						conn.StateChange += new StateChangeEventHandler(conn_StateChange);
						conn.InfoMessage += new OracleInfoMessageEventHandler(conn_InfoMessage);
					#endif
					conn.Open();

					#if TEST_NULL
						if (cmd == null)
							cmd = conn.CreateCommand();

						cmd.CommandType = CommandType.Text;
						cmd.CommandText = "select * from testtabletypes";

						rdr=cmd.ExecuteReader();
						do
						{
							if (rdr.HasRows)
							{
								int
									idx = rdr.GetOrdinal(FieldName = "FINT");

								while (rdr.Read())
								{
									tmpInt = !rdr.IsDBNull(idx) ? Convert.ToInt32(rdr[idx]) : int.MinValue;
									tmpInt = rdr[idx] != DBNull.Value ? Convert.ToInt32(rdr[idx]) : int.MaxValue;
									tmpInt = !rdr[idx].Equals(DBNull.Value) ? Convert.ToInt32(rdr[idx]) : int.MinValue;
									tmpInt = !Convert.IsDBNull(rdr[idx]) ? Convert.ToInt32(rdr[idx]) : int.MaxValue;
								}
							}
						} while (rdr.NextResult());
						rdr.Close();

						if (da == null)
							da = new OracleDataAdapter();
						da.SelectCommand = cmd;

						if (tmpDataTable == null)
							tmpDataTable = new DataTable();
						else
							tmpDataTable.Reset();

						da.Fill(tmpDataTable);

						foreach (DataRow r in tmpDataTable.Rows)
						{
							tmpInt = !r.IsNull(FieldName = "FINT") ? Convert.ToInt32(r[FieldName]) : int.MinValue;
							tmpInt = r[FieldName] != DBNull.Value ? Convert.ToInt32(r[FieldName]) : int.MaxValue;
							tmpInt = !r[FieldName].Equals(DBNull.Value) ? Convert.ToInt32(r[FieldName]) : int.MinValue;
							tmpInt = !Convert.IsDBNull(r[FieldName]) ? Convert.ToInt32(r[FieldName]) : int.MaxValue;
						}
					#endif

					#if TEST_NLS_NUMERIC_CHARACTERS
						if (cmd == null)
							cmd = conn.CreateCommand();

						cmd.CommandType = CommandType.Text;
						cmd.CommandText = "select cast('0,123' as number(10,6)) from dual";
						tmpObject = cmd.ExecuteScalar();
					#endif

					#if CAST_VS_CONVERT
						if (cmd == null)
							cmd = conn.CreateCommand();

						cmd.CommandType = CommandType.Text;
						cmd.CommandText = "select count(*) from dual";

						try
						{
							tmpInt = (int)cmd.ExecuteScalar();
						}
						catch (Exception eException)
						{
							Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
						}

						tmpObject = cmd.ExecuteScalar(); // decimal
						tmpInt = Convert.ToInt32(tmpObject);

						tmpObject = cmd.ExecuteOracleScalar(); // OracleNumber

						OracleNumber
							tmpOracleNumber = (OracleNumber)tmpObject;
					#endif

					#if TEST_TYPES
						if (cmd == null)
							cmd = conn.CreateCommand();

						cmd.CommandType = CommandType.Text;

						tmpDateTime = DateTime.Now;

						cmd.CommandText = @"
update
  testtabletypes
set
  ftimestamp=:ftimestamp_in,
  ftimestamp_w_tz=:ftimestamp_w_tz_in,
  ftimestamp_w_l_tz=:ftimestamp_w_l_tz_in
";
						cmd.Parameters.Clear();
						cmd.Parameters.Add("ftimestamp_in", OracleType.Timestamp).Value = tmpDateTime;
						cmd.Parameters.Add("ftimestamp_w_tz_in", OracleType.TimestampWithTZ).Value = tmpDateTime;
						cmd.Parameters.Add("ftimestamp_w_l_tz_in", OracleType.TimestampLocal).Value = tmpDateTime;
						tmpInt=cmd.ExecuteNonQuery();

						cmd.Parameters.Clear();
						cmd.CommandText = "select * from TestTableTypes";

						if (da == null)
							da = new OracleDataAdapter();
						da.SelectCommand = cmd;

						if (tmpDataTable == null)
							tmpDataTable = new DataTable();
						else
							tmpDataTable.Reset();

						da.Fill(tmpDataTable);

						if (tmpDataTable.Rows.Count > 0)
						{
							tmpObject = tmpDataTable.Rows[0]["FNumber_Asterisk_0"];
							if(!Convert.IsDBNull(tmpObject)) // System.InvalidCastException: Object cannot be cast from DBNull to other types.
								tmpBool = Convert.ToBoolean(tmpObject);
						}

						cmd.CommandType = CommandType.StoredProcedure;
						cmd.CommandText = "UpdateTestTableTypes";
						OracleCommandBuilder.DeriveParameters(cmd);
						cmd.Parameters["ID_IN"].Value = 1;
						//cmd.Parameters["FCLOB_IN"].Value = new string('я', 2001); //"CLOB";
						//cmd.Parameters["FNCLOB_IN"].Value = new string('я', 2001); //"NCLOB";
						//cmd.Parameters["FSMALLINT_IN"].Value = false;
						//cmd.Parameters["FINT_IN"].Value = Enum4TestTypes.Second;
						cmd.ExecuteNonQuery();
					#endif

					#if TEST_DBMS_OUTPUT
						if (cmd == null)
							cmd = conn.CreateCommand();

						cmd.CommandType = CommandType.StoredProcedure;
						cmd.CommandText = "TestProcedureWithDBMSOutput";
						OracleCommandBuilder.DeriveParameters(cmd);
						cmd.ExecuteNonQuery();
					#endif

					#if TEST_CLOB
						if (cmd == null)
							cmd = conn.CreateCommand();

						//tmpString = "<P style=\"FONT-SIZE: large\" align=center>Спасибо, что пользуетесь нашей системой заказов!</P><P style=\"FONT-SIZE: large\" align=center>С 3 декабря изменился интерфейс \"онлайн заказов\" для клиентов компании.</P><P style=\"FONT-SIZE: large\" align=center>Просьба о всех пожеланиях и возможных проблемах сообщать на эл. адрес <A href=\"mailto:garnik-a@mtr.com.ua\">garnik-a@mtr.com.ua</A></P><P>Для создания заказа воспользуйтесь пунктом меню \"Каталог товаров\", либо загрузите заказ из <IMG src=\"http://corp.mtr.com.ua/OrdersApp/images/excel.gif\"> Excel через меню \"Загрузить заказ\"</P><P>Более подробно о том, как делать заказы и пользоваться системой вы можете почитать в <A href=\"http://corp.mtr.com.ua/OrdersApp/client/manual/help%20b2b.doc\">документации</A>.</P><P align=center><B>Уважаемые партнёры:</B></P><P align=center>Не упустите возможность закупить продукцию «Медиа Трейдинг» по очень хорошим ценам.</P><P align=center>Только раз в неделю, каждую пятницу, мы предлагаем специальные цены на несколько позиций из своего ассортимента. Размер партии может быть любой. Условие только одно: <B>Полная оплата закупки в тот же день*.</B><BR><BR>Способ оплаты может быть любой.<BR><SPAN style=\"COLOR: rgb(255,0,0); FONT-WEIGHT: bold\">ВНИМАНИЕ: АССОРТИМЕНТ ТОВАРОВ ОБНОВЛЯЕТСЯ КАЖДЫЙ ЧЕТВЕРГ В 16:00.</SPAN><BR></P><P><B>*Пояснение к условию:</B><BR>Вы можете получить товар по объявленной цене при условии оплаты в этот же день.<BR>Это значит, что нужно <B>«принести» (любым способом: безнал, предоплата) деньги в офис или представительство компании с 9:00 до 17:00 пятницы.</B> При этом <B>у Вас не должно быть вообще никаких задолженностей перед компанией, <U>независимо от размеров и срока давности</U>. Баланс либо нулевой, либо плюс.</B><BR><B><U>Без подтверждения оплаты товар отгружен не будет!</U></B><BR><BR>В случае, если товара нет на складе представительства, заказ будет доставлен с центрального склада ближайшей отгрузкой.</P><p align=\"center\"><b><br></b></p><p align=\"center\"><b><br></b></p><p align=\"center\"><b><br></b></p>";
						//tmpString = new string('я', 2000);
						tmpString = new string('я', 2001);
						//tmpString = new string('я', 3000);
						//tmpString = new string('я', 3999);
						//tmpString = new string('я', 4000);
						//tmpString = new string('я', 4001);
						//tmpString = new string('я', 0x0ffff);

						cmd.CommandType = CommandType.Text;
						cmd.CommandText = "update TestTableTypes set FClob = :FClob, FNClob = :FNClob";
						//cmd.Parameters.Add(":FClob", OracleType.Clob).Value = tmpString;
						//cmd.Parameters.Add(":FNClob", OracleType.NClob).Value = tmpString;
						//cmd.Parameters.AddWithValue(":FClob", tmpString);
						//cmd.Parameters.AddWithValue(":FNClob", tmpString);

						OracleParameter
							p;

						p = new OracleParameter();
						p.ParameterName = ":FClob";
						p.DbType = DbType.String;
						p.Value = tmpString;
						cmd.Parameters.Add(p);

						p = new OracleParameter();
						p.ParameterName = ":FNClob";
						p.DbType = DbType.String;
						p.Value = tmpString;
						cmd.Parameters.Add(p);

						tmpInt=cmd.ExecuteNonQuery();
					#endif

					#if TEST_EXECUTE_SCALAR
						if (cmd == null)
							cmd = conn.CreateCommand();

						cmd.CommandType = CommandType.Text;
						cmd.CommandText = "select count(*) from user_objects";
						tmpObject = cmd.ExecuteScalar();
						// tmpInt=(int)tmpObject; // Wrong!!!
						tmpInt = Convert.ToInt32(tmpObject);
					#endif

					#if TEST_FUNCTION
						if (cmd == null)
							cmd = conn.CreateCommand();

						cmd.CommandType = CommandType.StoredProcedure;
						cmd.CommandText = "get_actions_count";
						OracleCommandBuilder.DeriveParameters(cmd);
						cmd.Parameters["application_id_in"].Value = 128;
						cmd.Parameters["date_actual"].Value = new DateTime(1900, 1, 1);
						tmpObject = cmd.ExecuteNonQuery();
						tmpInt = Convert.ToInt32(cmd.Parameters["return_value"].Value);

						cmd.CommandText = "get_zonder_duration";
						OracleCommandBuilder.DeriveParameters(cmd);
						cmd.Parameters["volume_in"].Value = 0.1;
						tmpObject = cmd.ExecuteNonQuery();
						tmpInt = Convert.ToInt32(cmd.Parameters["return_value"].Value);
					#endif

					#if GET_STORED_PROCEDURE_PARAMETERS
						if (cmd == null)
							cmd = conn.CreateCommand();

						cmd.CommandType = CommandType.StoredProcedure;
						cmd.CommandText = "typhoon.utilfunctions.updategextra"; // "typhoon.Utilization_Util.ImportUtilization"; //"typhoon.pkg_claim.get_doc_status"; // "typhoon.movegoodstoresrevforinetf"; //"typhoon.setdocpropvalue"; // "typhoon.GET_URL_OPENDOC"; //"typhoon.HO_Utils.makeDocument";
						OracleCommandBuilder.DeriveParameters(cmd);
						Console.WriteLine(cmd.CommandText);
						for (int ii = 0; ii < cmd.Parameters.Count; ++ii)
							Console.WriteLine("ParameterName: " + cmd.Parameters[ii].ParameterName + " OracleType: " + cmd.Parameters[ii].OracleType.ToString() + " Direction: " + cmd.Parameters[ii].Direction.ToString());
						Console.ReadLine();
					#endif

					#if TEST_SEND_E_MAIL
						if (cmd == null)
							cmd = conn.CreateCommand();

						cmd.CommandType = CommandType.StoredProcedure;
						cmd.CommandText = "typhoon.mail_task_util.sendmail"; //"typhoon.mail_task_util.sendmail2";
						OracleCommandBuilder.DeriveParameters(cmd);
						cmd.Parameters["M_SENDER"].Value = "support@foxtrot.com.ua"; //"nozhenko-i@foxtrot.com.ua"; // "scherbakov-o@foxtrot.com.ua"
						cmd.Parameters["M_RECIPIENT"].Value = "nozhenko-i@foxtrot.com.ua; 4others@ua.fm"; // "4others@ua.fm";
						cmd.Parameters["M_SUBJECT"].Value = "Тест e-mail посредством оракула";
						cmd.Parameters["M_MESSAGE"].Value = "<p><center><img src=\"http://b2b.mtr.com.ua/images/logo.gif\" /></center></p><p><center><b>Дистрибуция Медиа Продукции</b></center></p><p>Тест e-mail посредством оракула <a href=\"http://google.com/\">google.com</a></p>";
						//cmd.Parameters["M_CC_RECIPIENT"].Value = DBNull.Value;
						//cmd.Parameters["M_BCC_RECIPIENT"].Value = DBNull.Value;
						cmd.Parameters["M_ADDRDELIM"].Value = ";";
						cmd.ExecuteNonQuery();
					#endif

					#if TEST_STORED_PROCEDURE_IN_CIRCLE
						if (cmd == null)
							cmd = conn.CreateCommand();

						cmd.CommandType = CommandType.StoredProcedure;
						cmd.CommandText = "TableWithSequenceSave";
						OracleCommandBuilder.DeriveParameters(cmd);

						for (i = 0; i < 10; ++i)
						{
							cmd.Parameters["id_cur"].Value = 0;
							cmd.Parameters["val_new"].Value = i;
							cmd.ExecuteNonQuery();
							tmpInt = Convert.ToInt32(cmd.Parameters["id_new"].Value);
						}
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
							cmd.CommandText = "update TableWithBLOB set FBlob=:FBlob where Id=:Id";
							cmd.Parameters.Clear();
							cmd.Parameters.Add("Id", OracleType.Number).Value = 1;
							cmd.Parameters.Add("FBlob", OracleType.Blob);
							fs = new FileStream("xpfirewall.bmp", FileMode.Open, FileAccess.Read);
							Blob = new byte[fs.Length];
							fs.Read(Blob, 0, Blob.Length);
							fs.Close();
							cmd.Parameters["FBlob"].Value = Blob;
							tmpInt = cmd.ExecuteNonQuery();
						#endif

						#if TEST_BLOB_SAVE_BY_SP
							// http://support.microsoft.com/default.aspx?scid=kb;en-us;322796
							fs = new FileStream("xpfirewall.bmp", FileMode.Open, FileAccess.Read);
							Blob = new byte[fs.Length];
							fs.Read(Blob, 0, Blob.Length);
							fs.Close();

							cmd.Transaction = conn.BeginTransaction();

							cmd.CommandType = CommandType.Text;
							cmd.CommandText = "declare xx blob; begin dbms_lob.createtemporary(xx, false, 0); :tempblob := xx; end;";
							cmd.Parameters.Clear();
							cmd.Parameters.Add(new OracleParameter("tempblob", OracleType.Blob)).Direction = ParameterDirection.Output;
							cmd.ExecuteNonQuery();

							OracleLob
								tmpOracleLob;

							tmpOracleLob = (OracleLob)cmd.Parameters["tempblob"].Value;
							tmpOracleLob.BeginBatch(OracleLobOpenMode.ReadWrite);
							tmpOracleLob.Write(Blob, 0, Blob.Length);
							tmpOracleLob.EndBatch();

							cmd.CommandType = CommandType.StoredProcedure;
							cmd.CommandText = "TableWithBLOBSave";
							OracleCommandBuilder.DeriveParameters(cmd);
							cmd.Parameters["ID_IN"].Value = 2;
							cmd.Parameters["FBLOB_IN"].Value = tmpOracleLob;
							tmpInt = cmd.ExecuteNonQuery();

							cmd.Transaction.Commit();

							cmd.CommandType = CommandType.Text;
						#endif

						cmd.CommandText = "select * from TableWithBLOB";
						cmd.Parameters.Clear();
						rdr = cmd.ExecuteReader();

						do
						{
							if (rdr.HasRows)
							{
								for (int i = 0; i < rdr.FieldCount; ++i)
									fstr_out.WriteLine(rdr.GetName(i) + " GetDataTypeName(): \"" + rdr.GetDataTypeName(i) + "\" GetFieldType(): \"" + rdr.GetFieldType(i) + "\"");

								tmpInt = rdr.GetOrdinal("FBlob");

								while (rdr.Read())
								{
									tmpString = "FromBlob.bmp";
									if (File.Exists(tmpString))
										File.Delete(tmpString);

									Blob = (byte[])rdr["FBlob"];
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

					#if TEST_SELECT
/*						if (cmd == null)
							cmd = conn.CreateCommand();

						cmd.CommandType=CommandType.Text;
						cmd.CommandText = @"
select
  ew.ew_id as ""Id"",
  ew.ew_name as ""Description""
from
  typhoon.tbl_extra_what ew
where
  (ew.ew_fs=typhoon.get_parent_cfo(:cfo))
  and (coalesce(ew.ew_is_closed,0)=0)
order by ew.ew_id
";
					
						cmd.Parameters.Clear();
						cmd.Parameters.Add("cfo", OracleType.Number).Value = 150140;

						if (da == null)
							da = new OracleDataAdapter();
						da.SelectCommand = cmd;
						if (tmpDataTable == null)
							tmpDataTable = new DataTable();
						else
							tmpDataTable.Reset();
						da.Fill(tmpDataTable);

*/						/*
						tmpObject = cmd.ExecuteScalar();
						if (tmpObject != null && !Convert.IsDBNull(tmpObject))
							tmpLong = Convert.ToInt64(tmpObject);
						*/

						if (cmd == null)
							cmd = conn.CreateCommand();

						cmd.CommandType = CommandType.Text;
						cmd.CommandText="select * from tmp_docs_badrows";
						cmd.Parameters.Clear();

						if (da == null)
							da = new OracleDataAdapter();
						da.SelectCommand = cmd;

						if (tmpDataTable == null)
							tmpDataTable = new DataTable();
						else
							tmpDataTable.Reset();

						da.Fill(tmpDataTable);
						if (tmpDataTable.PrimaryKey == null)
							tmpDataTable.PrimaryKey = new DataColumn[] { tmpDataTable.Columns["doc_id"], tmpDataTable.Columns["g_id"] }; 
					#endif

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

					#if TEST_STORED_PROCEDURE
						if (cmd == null)
							cmd = conn.CreateCommand();

						cmd.CommandType = CommandType.StoredProcedure;
						cmd.CommandText = "typhoon.GET_URL_OPENDOC";
						OracleCommandBuilder.DeriveParameters(cmd);

						cmd.Parameters["P_DOCID"].Value = 33711025;
						cmd.Parameters["P_FULLHTMLCODE"].Value = DBNull.Value;
						cmd.ExecuteNonQuery();
						tmpString = Convert.ToString(cmd.Parameters["RETURN_VALUE"].Value);
					#endif

					#if TEST_MULTI_STATEMENTS
						if (cmd == null)
							cmd = conn.CreateCommand();
						cmd.CommandType = CommandType.Text;
						//cmd.CommandText = "alter session set NLS_TERRITORY = 'CIS';alter session set NLS_SORT = 'RUSSIAN';alter session set NLS_NUMERIC_CHARACTERS = '.,'";
						cmd.CommandText = "begin execute immediate 'alter session set NLS_TERRITORY = ''CIS'''; execute immediate 'alter session set NLS_SORT = ''RUSSIAN'''; execute immediate 'alter session set NLS_NUMERIC_CHARACTERS = ''.,'''; end;";
						cmd.ExecuteNonQuery();
					#endif

					#if TEST_PARAMETERS
						if (cmd == null)
							cmd = conn.CreateCommand();

						cmd.CommandType = CommandType.Text;
						cmd.CommandText = "select * from dual where :a=:b";
						cmd.Parameters.Add("a", OracleType.Int32).Value = 1;
						cmd.Parameters.Add("b", OracleType.Int32).Value = 1;
						//cmd.Parameters.Add("c", OracleType.Int32).Value = 2;
						tmpObject = cmd.ExecuteScalar();

						cmd.Parameters.Clear();
						cmd.CommandText = "select k_id as id, k_name as val from typhoon.tbl_kontragents where k_name like :q order by k_name";
						tmpString = "FOTO";
						cmd.Parameters.Add("q", OracleType.NVarChar).Value = tmpString + "%";
						if (da == null)
							da = new OracleDataAdapter();
						da.SelectCommand = cmd;
						if (tmpDataTable == null)
							tmpDataTable = new DataTable();
						else
							tmpDataTable.Reset();
						da.Fill(tmpDataTable);

						cmd.Parameters.Clear();
						cmd.CommandText = @"
select
  hoty_id,
  param_name,
  param_value
from
  order_params
where
  (hoty_id = :hoty_id)
";
						cmd.Parameters.Add("hoty_id", OracleType.Number).Value = 2219;
						if (da == null)
							da = new OracleDataAdapter();
						da.SelectCommand = cmd;
						if (tmpDataTable == null)
							tmpDataTable = new DataTable();
						else
							tmpDataTable.Reset();
						da.Fill(tmpDataTable);
						FieldName = "param_name";
						foreach (DataRow r in tmpDataTable.Rows)
						{
							Console.WriteLine(!r.IsNull(FieldName) ? Convert.ToString(r[FieldName]).ToString() : "null");
						}
					#endif
				}
				catch (Exception eException)
				{
					Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
				}
			}
			finally
			{
				if (rdr != null && !rdr.IsClosed)
					rdr.Close();

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
