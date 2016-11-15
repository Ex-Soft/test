using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.WebControls;

namespace AnyTest
{
	public class DynamicGridFormII : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DynamicDataGrid1;

		DataTable
			tmpDataTable=null;

		string
			DynamicGridFormIIDataTableSessionSignature="DynamicGridFormIIDataTable";

		private void Page_Init(object sender, System.EventArgs e)
		{
			if((tmpDataTable=(DataTable)Session[DynamicGridFormIIDataTableSessionSignature])==null)
				Session[DynamicGridFormIIDataTableSessionSignature]=tmpDataTable=new DataTable();

			if(!IsPostBack)
			{
				FillDataTable(tmpDataTable);
			}

			BoundColumn
				tmpBoundColumn=new BoundColumn();

			tmpBoundColumn.HeaderText="Name";
			tmpBoundColumn.DataField="Name";
			DynamicDataGrid1.Columns.Add(tmpBoundColumn);

			tmpBoundColumn=new BoundColumn();
			tmpBoundColumn.HeaderText="Button";
			DynamicDataGrid1.Columns.Add(tmpBoundColumn);

			DynamicDataGrid1.DataSource=tmpDataTable;

			DynamicDataGrid1.ItemCreated+=new DataGridItemEventHandler(DynamicDataGrid1_ItemCreated);
		}
		//---------------------------------------------------------------------------

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				DynamicDataGrid1.DataBind();
			}
		}
		//---------------------------------------------------------------------------

		private bool FillDataTable(DataTable t)
		{
			bool
				IsFill=false;

			OleDbConnection
				conn=null;

			try
			{
				try
				{
					string
						SQLText=ConfigurationSettings.AppSettings["MyConnectionString"];

					if(SQLText==string.Empty)
						throw(new Exception("ConfigurationSettings.AppSettings[\"MyConnectionString\"] is empty"));

					conn=new OleDbConnection(SQLText);
					conn.Open();
					SQLText="select * from staff";

					OleDbCommand
						cmd=new OleDbCommand(SQLText,conn);

					OleDbDataAdapter
						da=new OleDbDataAdapter(cmd);

					da.Fill(t);

					IsFill=true;
				}
				catch (OleDbException eException)
				{
					throw(new Exception("ErrorCode: "+eException.ErrorCode.ToString()+"\nMessage: "+eException.Message+"\nStackTrace: "+eException.StackTrace));
				}
				catch(OutOfMemoryException eException)
				{
					throw(new Exception("Message: "+eException.Message+"\nStackTrace: "+eException.StackTrace));
				}
				catch(Exception eException)
				{
					throw(new Exception("Message: "+eException.Message+"\nStackTrace: "+eException.StackTrace));
				}
			}
			finally
			{
				if(conn!=null && conn.State==System.Data.ConnectionState.Open)
					conn.Close();
			}

			return(IsFill);
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
			this.DynamicDataGrid1.PageIndexChanged += new DataGridPageChangedEventHandler(DynamicDataGrid1_PageIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);
			this.Init += new System.EventHandler(this.Page_Init);
		}
		#endregion

		private void DynamicDataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			DynamicDataGrid1.CurrentPageIndex=e.NewPageIndex;
			DynamicDataGrid1.DataBind();
		}
		//---------------------------------------------------------------------------

		private void DynamicDataGrid1_ItemCreated(object sender, DataGridItemEventArgs e)
		{
			if(e.Item.ItemType!=ListItemType.Item
				&& e.Item.ItemType!=ListItemType.AlternatingItem)
				return;

			Button
				tmpButton=new Button();

			tmpButton.Text="Kill";
			tmpButton.CommandName="Kill";
			tmpButton.CommandArgument=e.Item.Cells[1].Text;
			tmpButton.Command+=new CommandEventHandler(Button_Command);
			e.Item.Cells[e.Item.Cells.Count-1].Controls.Add(tmpButton);
		}
		//---------------------------------------------------------------------------

		private void Button_Command(object sender, CommandEventArgs e)
		{
			Button
				tmpButton;

			if((tmpButton=sender as Button)!=null)
				tmpButton.Text+=tmpButton.Text;
		}
		//---------------------------------------------------------------------------
	}
}
