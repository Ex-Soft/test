using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Threading;

namespace AnyTest
{
	public class AnyTestSmlForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label LabelDone;
		protected System.Web.UI.WebControls.Button ButtonTestTransaction;
		protected System.Web.UI.WebControls.Button ButtonTestExecuteNonQuery;
		protected System.Web.UI.WebControls.Button ButtonDownloadImageFromBLOB;
	
		string
			ConnectionString;

		private void Page_Init(object sender, System.EventArgs e)
		{
			if(((ConnectionString=ConfigurationSettings.AppSettings["MyConnectionString"])==null)
				|| ConnectionString==string.Empty)
				throw(new Exception("ConfigurationSettings.AppSettings[\"MyConnectionString\"] is absent or empty"));

			if(!IsPostBack)
			{
				string
					LogFileName=System.Web.HttpContext.Current.Server.MapPath(null)+Path.DirectorySeparatorChar+"Log.log";

				if(File.Exists(LogFileName))
					File.Delete(LogFileName);
			}
		}
		//---------------------------------------------------------------------------

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(IsPostBack)
			{
				LabelDone.Text="Done!";
			}
		}
		//---------------------------------------------------------------------------

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ButtonDownloadImageFromBLOB.Click+=new EventHandler(ButtonDownloadImageFromBLOB_Click);
			this.ButtonTestTransaction.Click+=new EventHandler(ButtonTestTransaction_Click);
			this.ButtonTestExecuteNonQuery.Click+=new EventHandler(ButtonTestExecuteNonQuery_Click);
			this.Load += new System.EventHandler(this.Page_Load);
			this.Init += new System.EventHandler(this.Page_Init);

		}
		#endregion

		private void ButtonTestTransaction_Click(object sender, EventArgs e)
		{
			OleDbConnection
				connection=null;

			OleDbTransaction
				transaction=null;

			string
				MethodName="ButtonTestTransaction_Click";

			try
			{
				try
				{
					connection=new OleDbConnection(ConnectionString);
					connection.Open();
					
					transaction=connection.BeginTransaction(IsolationLevel.ReadCommitted);

					OleDbCommand
						cmd=connection.CreateCommand();

					cmd.Transaction=transaction;

					cmd.CommandType=CommandType.Text;
					cmd.CommandText="select @@spid";

					object
						tmpObject;

					int
						spid=int.MinValue;

					if((tmpObject=cmd.ExecuteScalar())!=null)
						Log.Log.WriteToLog("AnyTestSmlForm::"+MethodName+"() @@spid="+(spid=Convert.ToInt32(tmpObject)),true);

					cmd.CommandText="select tran_name from master..sysprocesses where spid="+spid;
					if((tmpObject=cmd.ExecuteScalar())!=null)
						Log.Log.WriteToLog("AnyTestSmlForm::"+MethodName+"() tran_name="+Convert.ToString(tmpObject),true);

					Log.Log.WriteToLog("AnyTestSmlForm::"+MethodName+"() Sleep started...",true);
					Thread.Sleep(20*1000);
					Log.Log.WriteToLog("AnyTestSmlForm::"+MethodName+"() Sleep finished",true);

					cmd.CommandText=@"
select
T1.*,
T2.*,
T3.*
from 
T1 T1
left outer join T2 T2 on (T2.Id=T1.Id)
left outer join T3 T3 on (T3.Id=T1.Id)
";
					
					DataTable
						tmpDataTable=new DataTable();

					OleDbDataAdapter
						da=new OleDbDataAdapter(cmd);

					Log.Log.WriteToLog("AnyTestSmlForm::"+MethodName+"() OleDbDataAdapter.Fill(DataTable) started...",true);
					da.Fill(tmpDataTable);
					Log.Log.WriteToLog("AnyTestSmlForm::"+MethodName+"() OleDbDataAdapter.Fill(DataTable) finished (RecordCount="+tmpDataTable.Rows.Count+")",true);

					Log.Log.WriteToLog("AnyTestSmlForm::"+MethodName+"() OleDbTransaction.Commit() started...",true);
					transaction.Commit();
					Log.Log.WriteToLog("AnyTestSmlForm::"+MethodName+"() OleDbTransaction.Commit() finished",true);
					transaction=null;
				}
				catch (OleDbException eException)
				{
					throw(new Exception(eException.GetType().FullName+Environment.NewLine+"ErrorCode: "+eException.ErrorCode.ToString()+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace: "+Environment.NewLine+eException.StackTrace));
				}
				catch(Exception eException)
				{
					throw(new Exception(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace));
				}
			}
			finally
			{
				if(transaction!=null)
				{
					try
					{
						Log.Log.WriteToLog("AnyTestSmlForm::"+MethodName+"() OleDbTransaction.Rollback() started...",true);
						transaction.Rollback();
						Log.Log.WriteToLog("AnyTestSmlForm::"+MethodName+"() OleDbTransaction.Rollback() finished",true);
					}
					catch
					{
						;
					}
				}

				if(connection!=null && connection.State==ConnectionState.Open)
				{
					Log.Log.WriteToLog("AnyTestSmlForm::"+MethodName+"() OleDbConnection.Close() started...",true);
					connection.Close();
					Log.Log.WriteToLog("AnyTestSmlForm::"+MethodName+"() OleDbConnection.Close() finished",true);
				}
			}
		}
		//---------------------------------------------------------------------------

		private void ButtonTestExecuteNonQuery_Click(object sender, EventArgs e)
		{
			OleDbConnection
				connection=null;

			OleDbTransaction
				transaction=null;

			string
				MethodName="ButtonTestExecuteNonQuery_Click";

			try
			{
				try
				{
					connection=new OleDbConnection(ConnectionString);
					connection.Open();
					
					transaction=connection.BeginTransaction(IsolationLevel.ReadCommitted);

					OleDbCommand
						cmd=connection.CreateCommand();

					cmd.Transaction=transaction;

					cmd.CommandType=CommandType.Text;
					cmd.CommandText="select @@spid";

					object
						tmpObject;

					int
						spid=int.MinValue;

					if((tmpObject=cmd.ExecuteScalar())!=null)
						Log.Log.WriteToLog("AnyTestSmlForm::"+MethodName+"() @@spid="+(spid=Convert.ToInt32(tmpObject)),true);

					cmd.CommandText="select tran_name from master..sysprocesses where spid="+spid;
					if((tmpObject=cmd.ExecuteScalar())!=null)
						Log.Log.WriteToLog("AnyTestSmlForm::"+MethodName+"() tran_name="+Convert.ToString(tmpObject),true);

					cmd.CommandText=@"
select
T1.*,
T2.*,
T3.*
from 
T1 T1
left outer join T2 T2 on (T2.Id=T1.Id)
left outer join T3 T3 on (T3.Id=T1.Id)
";
					
					Log.Log.WriteToLog("AnyTestSmlForm::"+MethodName+"() OleDbCommand.ExecuteNonQuery() started...",true);
					cmd.ExecuteNonQuery();
					Log.Log.WriteToLog("AnyTestSmlForm::"+MethodName+"() OleDbCommand.ExecuteNonQuery() finished",true);

					Log.Log.WriteToLog("AnyTestSmlForm::"+MethodName+"() OleDbTransaction.Commit() started...",true);
					transaction.Commit();
					Log.Log.WriteToLog("AnyTestSmlForm::"+MethodName+"() OleDbTransaction.Commit() finished",true);
					transaction=null;
				}
				catch (OleDbException eException)
				{
					throw(new Exception(eException.GetType().FullName+Environment.NewLine+"ErrorCode: "+eException.ErrorCode.ToString()+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace: "+Environment.NewLine+eException.StackTrace));
				}
				catch(Exception eException)
				{
					throw(new Exception(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace));
				}
			}
			finally
			{
				if(transaction!=null)
				{
					try
					{
						Log.Log.WriteToLog("AnyTestSmlForm::"+MethodName+"() OleDbTransaction.Rollback() started...",true);
						transaction.Rollback();
						Log.Log.WriteToLog("AnyTestSmlForm::"+MethodName+"() OleDbTransaction.Rollback() finished",true);
					}
					catch
					{
						;
					}
				}

				if(connection!=null && connection.State==ConnectionState.Open)
				{
					Log.Log.WriteToLog("AnyTestSmlForm::"+MethodName+"() OleDbConnection.Close() started...",true);
					connection.Close();
					Log.Log.WriteToLog("AnyTestSmlForm::"+MethodName+"() OleDbConnection.Close() finished",true);
				}
			}
		}
		//---------------------------------------------------------------------------

		private void ButtonDownloadImageFromBLOB_Click(object sender, EventArgs e)
		{
			OleDbConnection
				connection=null;

			OleDbDataReader
				rdr=null;

			string
				MethodName="ButtonDownloadImageFromBLOB_Click";

			try
			{
				try
				{
					connection=new OleDbConnection(ConnectionString);
					connection.Open();

					OleDbCommand
						cmd=connection.CreateCommand();

					cmd.CommandType=CommandType.Text;
					cmd.CommandText="select * from TestTypes";
					rdr=cmd.ExecuteReader();

					do
					{
						if(rdr.HasRows)
						{
							while(rdr.Read())
							{
								Response.Clear();
								Response.ContentType="application/octet-stream";
								Response.AddHeader("Content-Disposition","attachment; filename=FromBlob.bmp");
								//Response.Flush();
								Response.BinaryWrite((byte[])rdr["FImage"]);
								Response.End(); // http://www.sql.ru/forum/actualthread.aspx?bid=19&tid=610998
							}
						}
					}while(rdr.NextResult());
					rdr.Close();
				}
				catch (OleDbException eException)
				{
					throw(new Exception(eException.GetType().FullName+Environment.NewLine+"ErrorCode: "+eException.ErrorCode.ToString()+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace: "+Environment.NewLine+eException.StackTrace));
				}
				catch(Exception eException)
				{
					throw(new Exception(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace));
				}
			}
			finally
			{
				if(rdr!=null && !rdr.IsClosed)
					rdr.Close();

				if(connection!=null && connection.State==ConnectionState.Open)
				{
					Log.Log.WriteToLog("AnyTestSmlForm::"+MethodName+"() OleDbConnection.Close() started...",true);
					connection.Close();
					Log.Log.WriteToLog("AnyTestSmlForm::"+MethodName+"() OleDbConnection.Close() finished",true);
				}
			}
		}
	}
}
