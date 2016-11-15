using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.WebControls;

namespace AnyTest
{
	public class DataGridEventsForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGridWEvents;

		const string
			DataGridEventsFormDataSessionSignature="DataGridEventsFormDataSession";

		DataTable
			Staff;
	
		string
			PageName="DataGridEventsForm::",
			TextBoxSignature="TextBoxID";

		private void Page_Init(object sender, System.EventArgs e)
		{
			Log.Log.WriteToLog(PageName+"Page_Init (IsPostBack=\""+IsPostBack.ToString().ToLower()+"\")",true);

			/*
			if(IsPostBack)
			{
				string
					tmpString=string.Empty;

				TextBox
					tmpTextBox;

				foreach(DataGridItem item in DataGridWEvents.Items)
				{
					if((tmpTextBox=(item.FindControl(TextBoxSignature) as TextBox))==null)
						continue;

					if(tmpString!=string.Empty)
						tmpString+=Environment.NewLine;

					tmpString+=tmpTextBox.Text;
				}
			}
			*/
		}
		//---------------------------------------------------------------------------

		private void Page_Load(object sender, System.EventArgs e)
		{
			Log.Log.WriteToLog(PageName+"Page_Load (IsPostBack=\""+IsPostBack.ToString().ToLower()+"\")",true);

			if(!IsPostBack)
			{
				if(Session[DataGridEventsFormDataSessionSignature]!=null)
					Session.Remove(DataGridEventsFormDataSessionSignature);
			}
			else
			{
				string
					tmpString=string.Empty;

				TextBox
					tmpTextBox;

				foreach(DataGridItem item in DataGridWEvents.Items)
				{
					if((tmpTextBox=(item.FindControl(TextBoxSignature) as TextBox))==null)
						continue;

					if(tmpString!=string.Empty)
						tmpString+=Environment.NewLine;

					tmpString+=tmpTextBox.Text;
				}
			}

			if((Staff=(DataTable)Session[DataGridEventsFormDataSessionSignature])==null)
			{
				Session[DataGridEventsFormDataSessionSignature]=Staff=new DataTable();
				FillDataTable(Staff);
				DataGridBind();
			}
		}
		//---------------------------------------------------------------------------

		void FillDataTable(DataTable aDataTable)
		{
			string
				ConnectionString=ConfigurationSettings.AppSettings["MyConnectionString"];

			if(ConnectionString==null || ConnectionString==string.Empty)
				return;

			OleDbConnection
				connection=null;

			try
			{
				try
				{
					connection=new OleDbConnection(ConnectionString);
					connection.Open();

					OleDbDataAdapter
						da=new OleDbDataAdapter("select * from Staff order by ID",connection);

					aDataTable.Reset();
					da.Fill(aDataTable);

					connection.Close();
				}
				catch(Exception eException)
				{
					throw(new Exception(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace));
				}
			}
			finally
			{
				if(connection!=null && connection.State==ConnectionState.Open)
					connection.Close();
			}
		}
		//---------------------------------------------------------------------------

		void DataGridBind()
		{
			DataGridWEvents.DataSource=Staff.DefaultView;
			DataGridWEvents.DataBind();
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
			this.DataGridWEvents.DataBinding += new EventHandler(DataGridWEvents_DataBinding);
			this.DataGridWEvents.ItemCreated += new DataGridItemEventHandler(DataGridWEvents_ItemCreated);
			this.DataGridWEvents.ItemDataBound += new DataGridItemEventHandler(DataGridWEvents_ItemDataBound);
			this.DataBinding += new EventHandler(DataGridEventsForm_DataBinding);
			this.PreRender += new EventHandler(DataGridEventsForm_PreRender);
			this.Unload += new EventHandler(DataGridEventsForm_Unload);
			this.Error += new EventHandler(DataGridEventsForm_Error);
			this.AbortTransaction += new EventHandler(DataGridEventsForm_AbortTransaction);
			this.CommitTransaction += new EventHandler(DataGridEventsForm_CommitTransaction);
			this.Disposed += new EventHandler(DataGridEventsForm_Disposed);
			this.Load += new System.EventHandler(this.Page_Load);
			this.Init += new System.EventHandler(this.Page_Init);

		}
		#endregion

		private void DataGridWEvents_DataBinding(object sender, EventArgs e)
		{
			Log.Log.WriteToLog(PageName+"DataGridWEvents_DataBinding (IsPostBack=\""+IsPostBack.ToString().ToLower()+"\")",true);
		}
		//---------------------------------------------------------------------------

		private void DataGridWEvents_ItemCreated(object sender, DataGridItemEventArgs e)
		{
			Log.Log.WriteToLog(PageName+"DataGridWEvents_ItemCreated (IsPostBack=\""+IsPostBack.ToString().ToLower()+"\")",true);

			DataGrid
				tmpDataGrid;

			if((tmpDataGrid=sender as DataGrid)==null)
				return;

			if(e.Item.ItemType!=ListItemType.Item
				&& e.Item.ItemType!=ListItemType.AlternatingItem)
				return;

			TextBox
				tmpTextBox;

			if((tmpTextBox=e.Item.FindControl(TextBoxSignature) as TextBox)==null)
				return;

			DataRowView
				tmpDataRowView;
						
			if((tmpDataRowView=e.Item.DataItem as DataRowView)!=null)
			{
				tmpTextBox.Text=Convert.ToString(tmpDataRowView.Row["ID"]);
			}
		}
		//---------------------------------------------------------------------------

		private void DataGridWEvents_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
			Log.Log.WriteToLog(PageName+"DataGridWEvents_ItemDataBound (IsPostBack=\""+IsPostBack.ToString().ToLower()+"\")",true);
		}
		//---------------------------------------------------------------------------

		private void DataGridEventsForm_DataBinding(object sender, EventArgs e)
		{
			Log.Log.WriteToLog(PageName+"DataGridEventsForm_DataBinding (IsPostBack=\""+IsPostBack.ToString().ToLower()+"\")",true);
		}
		//---------------------------------------------------------------------------

		private void DataGridEventsForm_PreRender(object sender, EventArgs e)
		{
			Log.Log.WriteToLog(PageName+"DataGridEventsForm_PreRender (IsPostBack=\""+IsPostBack.ToString().ToLower()+"\")",true);
		}
		//---------------------------------------------------------------------------

		private void DataGridEventsForm_Unload(object sender, EventArgs e)
		{
			Log.Log.WriteToLog(PageName+"DataGridEventsForm_Unload (IsPostBack=\""+IsPostBack.ToString().ToLower()+"\")",true);
		}
		//---------------------------------------------------------------------------

		private void DataGridEventsForm_Error(object sender, EventArgs e)
		{
			Log.Log.WriteToLog(PageName+"DataGridEventsForm_Error (IsPostBack=\""+IsPostBack.ToString().ToLower()+"\")",true);
		}
		//---------------------------------------------------------------------------

		private void DataGridEventsForm_AbortTransaction(object sender, EventArgs e)
		{
			Log.Log.WriteToLog(PageName+"DataGridEventsForm_AbortTransaction (IsPostBack=\""+IsPostBack.ToString().ToLower()+"\")",true);
		}
		//---------------------------------------------------------------------------

		private void DataGridEventsForm_CommitTransaction(object sender, EventArgs e)
		{
			Log.Log.WriteToLog(PageName+"DataGridEventsForm_AbortTransaction (IsPostBack=\""+IsPostBack.ToString().ToLower()+"\")",true);
		}
		//---------------------------------------------------------------------------

		private void DataGridEventsForm_Disposed(object sender, EventArgs e)
		{
			Log.Log.WriteToLog(PageName+"DataGridEventsForm_AbortTransaction (IsPostBack=\""+IsPostBack.ToString().ToLower()+"\")",true);
		}
		//---------------------------------------------------------------------------
	}
}
