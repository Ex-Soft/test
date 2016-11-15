using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;

namespace AnyTest
{
	public class TestCustomPagingForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGridWCuctomPaging;

		const string
			TestCustomPagingFormDataSessionSignature="TestCustomPagingFormDataSession";

		DataTable
			Staff;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				if(Session[TestCustomPagingFormDataSessionSignature]!=null)
					Session.Remove(TestCustomPagingFormDataSessionSignature);
			}

			if((Staff=(DataTable)Session[TestCustomPagingFormDataSessionSignature])==null)
			{
				Session[TestCustomPagingFormDataSessionSignature]=Staff=new DataTable();
				FillDataTable(Staff);
				DataGridWCuctomPaging.VirtualItemCount=Staff.Rows.Count;
				DataGridBind();
			}
		}

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

		void DataGridBind()
		{
			Staff.DefaultView.RowFilter="not ((ID<="+DataGridWCuctomPaging.CurrentPageIndex*DataGridWCuctomPaging.PageSize+") or (ID>="+((DataGridWCuctomPaging.CurrentPageIndex+1)*DataGridWCuctomPaging.PageSize+1)+"))";
			DataGridWCuctomPaging.DataSource=Staff.DefaultView;
			DataGridWCuctomPaging.DataBind();
		}

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
			this.DataGridWCuctomPaging.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(DataGridWCuctomPaging_PageIndexChanged); 
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

		private void DataGridWCuctomPaging_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridWCuctomPaging.CurrentPageIndex=e.NewPageIndex;
			DataGridBind();
		}
	}
}
