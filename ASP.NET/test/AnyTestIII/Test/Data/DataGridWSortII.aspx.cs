using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.WebControls;

namespace AnyTest
{
	public class DataGridWSortII : System.Web.UI.Page
	{
		protected DataGrid DataGrid1;

		string
			connectionString,
			SessionDataSetSignature="DataGridWSortIIDataSet",
			SessionDataGrid1SortSignature="DataGrid1Sort";

		DataSet
			DS=null;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if((connectionString=ConfigurationSettings.AppSettings["MyConnectionString"])==null
				|| connectionString==string.Empty)
			{
				Response.Write("ConfigurationSettings.AppSettings[\"MyConnectionString\"] is absent or empty");
				return;
			}

			if((DS=(DataSet)Session[SessionDataSetSignature])==null)
			{
				DS=new DataSet();
				Session[SessionDataSetSignature]=DS;
			}

			if(!IsPostBack)
				FillDS();

			SetDataSource(DataGrid1);
			DataGrid1.DataBind();
		}
		//---------------------------------------------------------------------------

		void FillDS()
		{
			OleDbConnection
				conn=null;

			try
			{
				try
				{
					conn=new OleDbConnection(connectionString);

					OleDbDataAdapter
						da=new OleDbDataAdapter("select * from Staff",conn);

					da.TableMappings.Add("Table","Staff");
					da.Fill(DS);

					DataTable
						tmpDataTable=DS.Tables["Staff"];

					if(tmpDataTable.PrimaryKey.Length==0)
						tmpDataTable.PrimaryKey=new DataColumn[]{tmpDataTable.Columns["ID"]};
				}
				catch (OleDbException eException)
				{
					Response.Write(eException.GetType().FullName+Environment.NewLine+"ErrorCode="+eException.ErrorCode.ToString()+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"Source: "+eException.Source+Environment.NewLine+"StackTrace: "+Environment.NewLine+eException.StackTrace+Environment.NewLine+"TargetSite: "+eException.TargetSite);
				}
				catch(Exception eException)
				{
					Response.Write(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace);
				}			
			}
			finally
			{
				if(conn!=null && conn.State==System.Data.ConnectionState.Open)
					conn.Close(); 
			}
		}
		//---------------------------------------------------------------------------

		void SetDataSource(DataGrid aDataGrid)
		{
			DataTable
				tmpDataTable=null;

			DataView
				tmpDataView=null;

			string
				Filter=string.Empty,
				ViewStateSortSignature=string.Empty;

			switch(aDataGrid.ID)
			{
				case "DataGrid1" :
				{
					tmpDataTable=DS.Tables["Staff"];
					ViewStateSortSignature=SessionDataGrid1SortSignature;
					break;
				}
			}

			tmpDataView=new DataView(tmpDataTable);
			tmpDataView.RowFilter=Filter;
			if(ViewState[ViewStateSortSignature]!=null)
				tmpDataView.Sort=(string)ViewState[ViewStateSortSignature];
			aDataGrid.DataSource=tmpDataView;
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
			this.DataGrid1.PageIndexChanged += new DataGridPageChangedEventHandler(DataGrid_PageIndexChanged);
			this.DataGrid1.SortCommand += new DataGridSortCommandEventHandler(DataGrid_SortCommand);
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

		private void DataGrid_SortCommand(object sender, DataGridSortCommandEventArgs e)
		{
			DataGrid
				tmpDataGrid;

			if((tmpDataGrid=sender as DataGrid)==null)
				return;

			string
				ViewStateSortSignature=string.Empty;

			switch(tmpDataGrid.ID)
			{
				case "DataGrid1" :
				{
					ViewStateSortSignature=SessionDataGrid1SortSignature;
					break;
				}
			}

			foreach(DataGridColumn column in tmpDataGrid.Columns)
			{
				column.HeaderText=column.HeaderText.Replace(" v","");
				column.HeaderText=column.HeaderText.Replace(" ^","");
				if(column.SortExpression==e.SortExpression
					|| column.SortExpression==e.SortExpression+" desc")
				{
					if(column.SortExpression.IndexOf(" desc")!=-1)
					{
						column.SortExpression=column.SortExpression.Replace(" desc","");
						column.HeaderText+=" ^";
					}
					else
					{
						column.SortExpression+=" desc";
						column.HeaderText+=" v";
					}

					ViewState[ViewStateSortSignature]=column.SortExpression;
				}
			}

			SetDataSource(tmpDataGrid);
			tmpDataGrid.DataBind();
		}
		//---------------------------------------------------------------------------

		private void DataGrid_PageIndexChanged(object sender, DataGridPageChangedEventArgs e)
		{
			DataGrid
				tmpDataGrid;

			if((tmpDataGrid=sender as DataGrid)==null)
				return;

			tmpDataGrid.CurrentPageIndex=e.NewPageIndex;
			tmpDataGrid.DataBind();
		}
		//---------------------------------------------------------------------------
	}
}
