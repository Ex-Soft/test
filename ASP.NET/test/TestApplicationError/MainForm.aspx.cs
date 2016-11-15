using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;

namespace TestApplicationError
{
	public class MainForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.RadioButtonList RadioTypeOperation;
		protected System.Web.UI.WebControls.TextBox TextBoxIdMaster;
		protected System.Web.UI.WebControls.TextBox TextBoxId;
		protected System.Web.UI.WebControls.TextBox TextBoxValue;
		protected System.Web.UI.WebControls.Button ButtonSave;
		protected System.Web.UI.WebControls.Label LabelInfo;
		protected System.Web.UI.WebControls.DataGrid DataGridDetailsTable;
		
		string
			ConnectionString;

		private void Page_Init(object sender, System.EventArgs e)
		{
			if(((ConnectionString=ConfigurationSettings.AppSettings["ConnectionString"])==null)
				|| ConnectionString==string.Empty)
				throw(new Exception("ConfigurationSettings.AppSettings[\"ConnectionString\"] is absent or empty"));

		}
		//---------------------------------------------------------------------------

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
				DataGridFill();
		}
		//---------------------------------------------------------------------------

		private void DataGridFill()
		{
			OleDbConnection
				connection=null;

			try
			{
				try
				{
					connection=new OleDbConnection(ConnectionString);

					OleDbDataAdapter
						da=new OleDbDataAdapter(@"
select *
from
DetailsTable
order by IdMaster, Id
"
						,connection);

					DataTable
						dt=new DataTable();

					da.Fill(dt);
					DataGridDetailsTable.DataSource=dt;
					DataGridDetailsTable.DataBind();	
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
				if(connection!=null && connection.State==ConnectionState.Open)
					connection.Close();
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
			this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);
			this.Init += new System.EventHandler(this.Page_Init);

		}
		#endregion

		private void ButtonSave_Click(object sender, EventArgs e)
		{
			byte
				IdMaster,
				Id;

			string
				Value=TextBoxValue.Text.Trim();

			try
			{
				IdMaster=Convert.ToByte(TextBoxIdMaster.Text);
			}
			catch(Exception eException)
			{
				throw(new Exception(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace));
			}

			try
			{
				Id=Convert.ToByte(TextBoxId.Text);
			}
			catch(Exception eException)
			{
				throw(new Exception(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace));
			}

			OleDbConnection
				connection=null;

			OleDbTransaction
				transaction=null;

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

					OleDbParameter
						tmpParameter;

					switch(RadioTypeOperation.SelectedValue)
					{
						case "insert" :
						{
							cmd.CommandText=@"
insert into DetailsTable
(IdMaster, Id, Value)
values
(?, ?, ?)";
							
							tmpParameter=new OleDbParameter("IdMaster",OleDbType.Numeric);
							tmpParameter.Direction=ParameterDirection.Input;
							cmd.Parameters.Add(tmpParameter);
							tmpParameter=new OleDbParameter("Id",OleDbType.Numeric);
							tmpParameter.Direction=ParameterDirection.Input;
							cmd.Parameters.Add(tmpParameter);
							tmpParameter=new OleDbParameter("Value",OleDbType.VarChar);
							tmpParameter.Direction=ParameterDirection.Input;
							cmd.Parameters.Add(tmpParameter);

							break;
						}
						case "update" :
						{
							cmd.CommandText=@"
update
DetailsTable
set
Value = ?
where
(IdMaster = ?)
and (Id = ?)";
							
							tmpParameter=new OleDbParameter("Value",OleDbType.VarChar);
							tmpParameter.Direction=ParameterDirection.Input;
							cmd.Parameters.Add(tmpParameter);
							tmpParameter=new OleDbParameter("IdMaster",OleDbType.Numeric);
							tmpParameter.Direction=ParameterDirection.Input;
							cmd.Parameters.Add(tmpParameter);
							tmpParameter=new OleDbParameter("Id",OleDbType.Numeric);
							tmpParameter.Direction=ParameterDirection.Input;
							cmd.Parameters.Add(tmpParameter);

							break;
						}
					}
					
					cmd.Parameters["IdMaster"].Value=IdMaster;
					cmd.Parameters["Id"].Value=Id;
					cmd.Parameters["Value"].Value=Value;
					cmd.ExecuteNonQuery();
					transaction.Commit();
					transaction=null;

					LabelInfo.Text=DateTime.Now.ToString()+" Done!";
					DataGridFill();
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
						transaction.Rollback();
					}
					catch
					{
						;
					}
				}

				if(connection!=null && connection.State==ConnectionState.Open)
					connection.Close();
			}
		}
		//---------------------------------------------------------------------------
	}
}
