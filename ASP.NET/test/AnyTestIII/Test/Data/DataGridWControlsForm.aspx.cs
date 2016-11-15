using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnyTest
{
	public class DataGridWithControlsForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DGWCheckBox;
		protected System.Web.UI.WebControls.DataGrid DGWRadioButton;
		protected System.Web.UI.WebControls.Button btnSubmit;

		private DataTable
			dt=null;

		private string
			SessionId="tmpDataTable";

		private void Page_Init(object sender, System.EventArgs e)
		{
			//DGWRadioButton.Columns[4].HeaderText="Ô. È. Î. (<input type=\"checkbox\" id=\"CheckBoxHeader1\" name=\"CheckBoxHeader1\">)";
			OleDbConnection
				conn=null;

			try
			{
				try
				{
					if(dt==null)
					{
						if((dt=(DataTable)Session[SessionId])==null)
						{
							string
								connstring=ConfigurationSettings.AppSettings["MyConnectionString"];

							conn=new OleDbConnection(connstring);
							conn.Open();

							OleDbDataAdapter
								da=new OleDbDataAdapter("select * from Staff order by ID",conn);

							dt=new DataTable();
							da.Fill(dt);
							if(!dt.Columns.Contains("Checked"))
								dt.Columns.Add("Checked",typeof(bool));
							if(dt.PrimaryKey.Length==0)
								dt.PrimaryKey=new DataColumn[]{dt.Columns["ID"]};

							Session[SessionId]=dt;
						}
					}

					DGWCheckBox.DataSource=dt;
					DGWCheckBox.DataBind();
		
					foreach(DataRow r in dt.Rows)
						if(r.IsNull("Checked") || Convert.ToBoolean(r["Checked"])!=false)
							r["Checked"]=false;
					if(dt.Rows.Count>0)
						dt.Rows[0]["Checked"]=true;

					DGWRadioButton.DataSource=dt.DefaultView;
					DGWRadioButton.DataBind();
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
				if(conn!=null && conn.State==ConnectionState.Open)
					conn.Close(); 				
			}
		}
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			CheckBox
				tmpCheckBox;

			long
				Id;

			foreach(DataGridItem item in DGWCheckBox.Items)
			{
				if((tmpCheckBox=(item.FindControl("CheckBoxKill") as CheckBox))==null)
					continue;

				if(tmpCheckBox.Checked)
				{
					Id=Convert.ToInt64(DGWCheckBox.DataKeys[item.ItemIndex]);
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
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.DGWCheckBox.PageIndexChanged+=new DataGridPageChangedEventHandler(DGWCheckBox_PageIndexChanged);
			this.DGWCheckBox.ItemCreated+=new DataGridItemEventHandler(DGWCheckBox_ItemCreated);
			this.DGWRadioButton.ItemCreated+=new DataGridItemEventHandler(DGWRadioButton_ItemCreated);
			this.DGWRadioButton.DataBinding +=new EventHandler(DGWRadioButton_DataBinding);
			this.PreRender+=new EventHandler(DataGridWithControlsForm_PreRender);
			this.Load += new System.EventHandler(this.Page_Load);
			this.Init += new System.EventHandler(this.Page_Init);

		}
		#endregion

		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			CheckBox
				tmpCheckBox;

			long
				Id;

			foreach(DataGridItem item in DGWCheckBox.Items)
			{
				if((tmpCheckBox=(item.FindControl("CheckBoxKill") as CheckBox))==null)
					continue;

				if(tmpCheckBox.Checked)
				{
					Id=Convert.ToInt64(DGWCheckBox.DataKeys[item.ItemIndex]);
				}
			}
		}

		private void DGWRadioButton_DataBinding(object sender, EventArgs e)
		{
			DataGrid
				tmpDataGrid;

			if((tmpDataGrid=sender as DataGrid)==null)
				return;

			//tmpDataGrid.DataSource
		}

		private void DGWRadioButton_ItemCreated(object sender, DataGridItemEventArgs e)
		{
			DataGrid
				tmpDataGrid;

			if((tmpDataGrid=sender as DataGrid)==null)
				return;

			CheckBox
				tmpCheckBox;
			
			if(e.Item.ItemType==ListItemType.Header)
			{
				tmpCheckBox=new CheckBox();
				tmpCheckBox.ID="CheckBoxHeaderNo2";
				tmpCheckBox.Text="CheckBoxHeaderNo2";
				tmpCheckBox.TextAlign=TextAlign.Right;
				tmpCheckBox.AutoPostBack=true;
				e.Item.Cells[4].Controls.Add(tmpCheckBox);
			}
		}

		private void DataGridWithControlsForm_PreRender(object sender, EventArgs e)
		{
			DGWRadioButton.Columns[4].HeaderText="Ô. È. Î. (<input type=\"checkbox\" id=\"CheckBoxHeader1\" name=\"CheckBoxHeader1\">)";
		}

		private void DGWCheckBox_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			DGWCheckBox.CurrentPageIndex=e.NewPageIndex;
			if(DGWCheckBox.DataSource!=dt)
				DGWCheckBox.DataSource=dt;
			DGWCheckBox.DataBind();
		}

		private void DGWCheckBox_ItemCreated(object sender, DataGridItemEventArgs e)
		{
			DataGrid
				tmpDataGrid;

			if((tmpDataGrid=sender as DataGrid)==null)
				return;

			TableCell
				tmpTableCell;

			LinkButton
				tmpLinkButton;

			if(e.Item.ItemType==ListItemType.Pager)
			{
				for(int i=0; i<e.Item.Controls.Count; ++i)
				{
					if((tmpTableCell=e.Item.Controls[i] as TableCell)==null)
						continue;
					for(int ii=0; ii<tmpTableCell.Controls.Count; ++ii)
						if((tmpLinkButton=tmpTableCell.Controls[ii] as LinkButton)!=null)
							tmpLinkButton.Enabled=false;
				}
			}
		}
	}
}