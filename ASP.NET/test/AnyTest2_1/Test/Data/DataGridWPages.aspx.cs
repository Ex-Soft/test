using System;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.WebControls;

namespace AnyTest2_1
{
	public class DataGridWPagesForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid MyDataGridInit;
		protected System.Web.UI.WebControls.DataGrid MyDataGridLoad;
		protected System.Web.UI.WebControls.DataGrid MyDataGridDynamic;
		protected System.Web.UI.WebControls.DataGrid MyDataGridDynamic2;

		DataSet
			ds=null;

		string
			SessionId="DataGridWPagesFormDS",
			connstring=(string)System.Web.HttpContext.Current.Application["connectionString"],
			CheckBoxSignature="tmpCheckBox",
			CheckedFieldName="Checked";

		void Page_Init(Object sender, EventArgs e)
		{
			if((ds=(DataSet)Session[SessionId])==null)
			{
				ds=new DataSet();
				ds.Tables.Add("TableStatic");
				ds.Tables.Add("TableDynamic");
				ds.Tables["TableDynamic"].Columns.Add(CheckedFieldName,typeof(bool));
				ds.Tables.Add("TableDynamic2");
				ds.Tables["TableDynamic2"].Columns.Add(CheckedFieldName,typeof(bool));
				Session[SessionId]=ds;

				OleDbConnection
					connection=new OleDbConnection(connstring);
      
				OleDbDataAdapter
					da=new OleDbDataAdapter("select * from books order by title, number",connection);
              
				da.Fill(ds.Tables["TableStatic"]);
				da.Fill(ds.Tables["TableDynamic"]);
				ds.Tables["TableDynamic"].PrimaryKey=new DataColumn[]{ds.Tables["TableDynamic"].Columns["Id"]};
				da.Fill(ds.Tables["TableDynamic2"]);
				ds.Tables["TableDynamic2"].PrimaryKey=new DataColumn[]{ds.Tables["TableDynamic2"].Columns["Id"]};
			}

			MyDataGridInit.DataSource=ds.Tables["TableStatic"];
			MyDataGridInit.DataBind();

			MyDataGridDynamic.DataSource=ds.Tables["TableDynamic"];
			MyDataGridDynamic.DataBind();
		}

		void Page_Load(Object sender, EventArgs e)
		{
			MyDataGridLoad.DataSource=ds.Tables["TableStatic"];
			MyDataGridLoad.DataBind();

			MyDataGridDynamic2.DataSource=ds.Tables["TableDynamic2"];
			if(!IsPostBack)
				MyDataGridDynamic2.DataBind();
			
			if(IsPostBack)
			{
				CheckBox
					tmpCheckBox;

				int
					tmpInt;

				DataRow
					tmpDataRow;

				foreach(DataGridItem item in MyDataGridDynamic.Items)
				{
					if((tmpCheckBox=(item.FindControl(CheckBoxSignature) as CheckBox))==null)
						continue;

					if((tmpDataRow=ds.Tables["TableDynamic"].Rows.Find(tmpInt=Convert.ToInt32(MyDataGridDynamic.DataKeys[item.ItemIndex])))!=null)
					{
						if(tmpDataRow.IsNull(CheckedFieldName) || Convert.ToBoolean(tmpDataRow[CheckedFieldName])!=tmpCheckBox.Checked)
							tmpDataRow[CheckedFieldName]=tmpCheckBox.Checked;
					}
					else
						throw(new Exception("Unknown ID: '"+tmpInt+"'"));
				}

				foreach(DataGridItem item in MyDataGridDynamic2.Items)
				{
					if((tmpCheckBox=(item.FindControl(CheckBoxSignature) as CheckBox))==null)
						continue;

					if((tmpDataRow=ds.Tables["TableDynamic2"].Rows.Find(tmpInt=Convert.ToInt32(MyDataGridDynamic2.DataKeys[item.ItemIndex])))!=null)
					{
						if(tmpDataRow.IsNull(CheckedFieldName) || Convert.ToBoolean(tmpDataRow[CheckedFieldName])!=tmpCheckBox.Checked)
							tmpDataRow[CheckedFieldName]=tmpCheckBox.Checked;
					}
					else
						throw(new Exception("Unknown ID: '"+tmpInt+"'"));
				}
			}
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
			this.MyDataGridDynamic2.ItemDataBound += new DataGridItemEventHandler(DataGrid_ItemDataBound);
			this.MyDataGridDynamic.ItemDataBound += new DataGridItemEventHandler(DataGrid_ItemDataBound);
			this.MyDataGridDynamic2.PageIndexChanged += new DataGridPageChangedEventHandler(DataGrid_PageIndexChanged);
			this.MyDataGridDynamic.PageIndexChanged += new DataGridPageChangedEventHandler(DataGrid_PageIndexChanged);
			this.MyDataGridLoad.PageIndexChanged += new DataGridPageChangedEventHandler(DataGrid_PageIndexChanged);
			this.MyDataGridInit.PageIndexChanged += new DataGridPageChangedEventHandler(DataGrid_PageIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);
			this.Init += new System.EventHandler(this.Page_Init);

		}
		#endregion

		private void DataGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			DataGrid
				tmpDataGrid;

			if((tmpDataGrid=source as DataGrid)==null)
				return;

			tmpDataGrid.CurrentPageIndex=e.NewPageIndex;
			tmpDataGrid.DataBind();
		}

		private void DataGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
			if(e.Item.ItemType!=ListItemType.Item
				&& e.Item.ItemType!=ListItemType.AlternatingItem)
				return;

			bool
				tmpBool = !(e.Item.DataItem as System.Data.DataRowView).Row.IsNull(CheckedFieldName) ? Convert.ToBoolean((e.Item.DataItem as System.Data.DataRowView).Row[CheckedFieldName]) : false;

			//bool
			//	tmpBool = ((System.Data.DataRowView)e.Item.DataItem).Row.IsNull(CheckedFieldName) ? Convert.ToBoolean(((System.Data.DataRowView)e.Item.DataItem).Row[CheckedFieldName]) : false;

			CheckBox
				tmpCheckBox;

			if((tmpCheckBox=e.Item.Cells[4].FindControl(CheckBoxSignature) as CheckBox)!=null
				&& tmpCheckBox.Checked!=tmpBool)
				tmpCheckBox.Checked=tmpBool;
		}
	}
}