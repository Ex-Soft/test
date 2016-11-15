#define WITH_ADD_HANDLER

using System;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DataTableEvents
{
	/// <summary>
	/// Summary description for MainForm.
	/// </summary>
	public class MainForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Literal LiteralBeginJS;
		protected System.Web.UI.WebControls.Literal LiteralJS;
		protected System.Web.UI.WebControls.Literal LiteralEndJS;
		protected System.Web.UI.WebControls.DataGrid DataGridWithPages;
		protected System.Web.UI.WebControls.TextBox TextBoxMasterTableValue;
		protected System.Web.UI.WebControls.DataGrid DataGridMasterTable;
		protected System.Web.UI.WebControls.TextBox TextBoxDetailTableId;
		protected System.Web.UI.WebControls.TextBox TextBoxDetailTableSubId;
		protected System.Web.UI.WebControls.TextBox TextBoxDetailTableValue;
		protected System.Web.UI.WebControls.Button btnDetailTableValueSave;
		protected System.Web.UI.WebControls.DataGrid DataGridDetailTable;
		protected System.Web.UI.WebControls.TextBox TextBoxMasterTableOldId;
		protected System.Web.UI.WebControls.TextBox TextBoxMasterTableNewId;
		protected System.Web.UI.WebControls.Button btnMasterTableIdChanged;
		protected System.Web.UI.WebControls.TextBox TextBoxCustomMasterTableMasterId;
		protected System.Web.UI.WebControls.Button btnCustomMasterTableMasterIdSave;
		protected System.Web.UI.WebControls.DataGrid DataGridCustomMasterTable;
		protected System.Web.UI.WebControls.Button btnMasterTableRefresh;
		protected System.Web.UI.WebControls.Button btnDetailTableRefresh;
		protected System.Web.UI.WebControls.Button btnCustomMasterTableRefresh;
		protected System.Web.UI.WebControls.Label LabelRowCount;
		protected System.Web.UI.WebControls.Button btnMasterTableValueSave;
		
		delegate void RefreshTable();

		private string
			ArrayName="a";

		protected string
			RadioButtonChoiceIdSignature="RadioButtonChoice",
			RadioButtonChoiceNameSignature="RadioButtonChoice";

		private void Page_Init(object sender, System.EventArgs e)
		{
			//	
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			MainDS
				MainDataSet=null;

			if((MainDataSet=(MainDS)Session["MainDS"])==null)
			{
				MainDataSet=new MainDS();
				Session.Add("MainDS",MainDataSet);
			}

			CustomDS
				CustomDataSet=null;

			if((CustomDataSet=(CustomDS)Session["CustomDS"])==null)
			{
				CustomDataSet=new CustomDS();
				Session.Add("CustomDS",CustomDataSet);
			}

			LiteralBeginJS.Text="\n<SCRIPT TYPE=\"text/javascript\">\n<!--\n";
			LiteralJS.Text="var "+ArrayName+"=new Array();";
			LiteralEndJS.Text="\n// -->\n</SCRIPT>";

			if(!IsPostBack)
			{
				DataGridWithPagesBind();
			}
		}

		private void BindMainDSMasterTable()
		{
			DataGridMasterTable.DataSource=((MainDS)Session["MainDS"]).Tables["MasterTable"];
			DataGridMasterTable.DataBind();
		}

		private void BindMainDSDetailTable()
		{
			DataGridDetailTable.DataSource=((MainDS)Session["MainDS"]).Tables["DetailTable"];
			DataGridDetailTable.DataBind();
		}

		private void BindCustomDSCustomMasterTable()
		{
			DataGridCustomMasterTable.DataSource=((CustomDS)Session["CustomDS"]).Tables["CustomMasterTable"];
			DataGridCustomMasterTable.DataBind();
		}

		private void DataGridWithPagesBind()
		{
			DataGridWithPages.DataSource=((MainDS)Session["MainDS"]).Tables["TablesWithPages"];
			DataGridWithPages.DataBind();
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
			this.DataGridWithPages.Unload += new System.EventHandler(this.DataGridWithPages_Unload);
			this.DataGridWithPages.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridWithPages_ItemCreated);
			this.DataGridWithPages.Init += new System.EventHandler(this.DataGridWithPages_Init);
			this.DataGridWithPages.Disposed += new System.EventHandler(this.DataGridWithPages_Disposed);
			this.DataGridWithPages.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridWithPages_PageIndexChanged);
			this.DataGridWithPages.PreRender += new System.EventHandler(this.DataGridWithPages_PreRender);
			this.DataGridWithPages.DataBinding += new System.EventHandler(this.DataGridWithPages_DataBinding);
			this.DataGridWithPages.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridWithPages_ItemDataBound);
			this.DataGridWithPages.Load += new System.EventHandler(this.DataGridWithPages_Load);
			this.btnMasterTableValueSave.Click += new System.EventHandler(this.btnMasterTableValueSave_Click);
			this.DataGridMasterTable.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridMasterTable_ItemCreated);
			this.DataGridMasterTable.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridMasterTable_ItemCommand);
			this.DataGridMasterTable.DataBinding += new System.EventHandler(this.DataGridMasterTable_DataBinding);
			this.DataGridMasterTable.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridMasterTable_ItemDataBound);
			this.btnMasterTableRefresh.Click += new System.EventHandler(this.btnTableRefresh_Click);
			this.btnMasterTableIdChanged.Click += new System.EventHandler(this.btnMasterTableIdChanged_Click);
			this.btnDetailTableValueSave.Click += new System.EventHandler(this.btnDetailTableValueSave_Click);
			this.btnDetailTableRefresh.Click += new System.EventHandler(this.btnTableRefresh_Click);
			this.btnCustomMasterTableMasterIdSave.Click += new System.EventHandler(this.btnCustomMasterTableMasterIdSave_Click);
			this.btnCustomMasterTableRefresh.Click += new System.EventHandler(this.btnTableRefresh_Click);
			this.Unload += new System.EventHandler(this.MainForm_Unload);
			this.Load += new System.EventHandler(this.Page_Load);
			this.Init += new System.EventHandler(this.Page_Init);
			this.PreRender += new System.EventHandler(this.MainForm_PreRender);
			this.DataBinding += new System.EventHandler(this.MainForm_DataBinding);

		}
		#endregion

		private void btnMasterTableValueSave_Click(object sender, System.EventArgs e)
		{
			string
				Value=TextBoxMasterTableValue.Text.Trim();

			if(Value.Length==0)
				return;

			MainDS
				DS=(MainDS)Session["MainDS"];

			DataRow
				row;

			row=DS.Tables["MasterTable"].NewRow();
			row["Value"]=Value;
			DS.Tables["MasterTable"].Rows.Add(row);
			BindMainDSMasterTable();
		}

		private void btnDetailTableValueSave_Click(object sender, System.EventArgs e)
		{
			string
				Value=TextBoxDetailTableValue.Text.Trim();

			if(Value.Length==0)
				return;

			MainDS
				DS=(MainDS)Session["MainDS"];

			DataRow
				row;

			row=DS.Tables["DetailTable"].NewRow();
			row["Id"]=Convert.ToInt32(TextBoxDetailTableId.Text);
			row["SubId"]=Convert.ToInt32(TextBoxDetailTableSubId.Text);
			row["Value"]=Value;
			DS.Tables["DetailTable"].Rows.Add(row);
			BindMainDSDetailTable();
		}

		private void btnMasterTableIdChanged_Click(object sender, System.EventArgs e)
		{
			if(TextBoxMasterTableOldId.Text.Trim().Length!=0
				&& TextBoxMasterTableNewId.Text.Trim().Length!=0)
				ChangeId(Convert.ToInt32(TextBoxMasterTableOldId.Text),Convert.ToInt32(TextBoxMasterTableNewId.Text));
		}

		private void btnCustomMasterTableMasterIdSave_Click(object sender, System.EventArgs e)
		{
			string
				Value=TextBoxCustomMasterTableMasterId.Text.Trim();

			if(Value.Length==0)
				return;

			CustomDS
				DS=(CustomDS)Session["CustomDS"];

			DataRow
				row;

			row=DS.Tables["CustomMasterTable"].NewRow();
			row["MasterId"]=Convert.ToInt32(Value);
			DS.Tables["CustomMasterTable"].Rows.Add(row);
			BindCustomDSCustomMasterTable();
		}

		private void btnTableRefresh_Click(object sender, System.EventArgs e)
		{
			System.Web.UI.WebControls.Button
				tmpBtn=sender as System.Web.UI.WebControls.Button;

			if(tmpBtn!=null)
			{
				RefreshTable
					f;

				switch(tmpBtn.ID)
				{
					case "btnMasterTableRefresh" :
					{
						f=new RefreshTable(BindMainDSMasterTable);
						break;
					}
					case "btnDetailTableRefresh" :
					{
						f=new RefreshTable(BindMainDSDetailTable);
						break;
					}
					case "btnCustomMasterTableRefresh" :
					{
						f=new RefreshTable(BindCustomDSCustomMasterTable);
						break;
					}
					default :
					{
						f=null;
						break;	
					}
				}
				if(f!=null)
					f();
			}
		}

		private void DataGridMasterTable_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			;
		}

		private void DataGridMasterTable_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemIndex==-1
				&& e.Item.ItemType==ListItemType.Header)
				/*e.Item.Attributes.Add("onmouseover","alert('!!!')")*/;

			//if(e.Item.Controls.Count>0)
			//	e.Item.Controls[0].Visible=false;
			// ||
			//e.Item.Cells[0].Visible=false;

			string
				FullName="";

			if(e.Item.ItemType==ListItemType.Item
				|| e.Item.ItemType==ListItemType.AlternatingItem)
			{
				if(FullName.Length!=0)
					FullName+=" ";
				FullName+="UniqueID: "+e.Item.Cells[2].Controls[1].UniqueID;
				//e.Item.Cells[2].Controls[1].ID="TextBoxMainDSNewIdValue"+e.Item.ItemIndex;
			}
		}

		private void DataGridMasterTable_DataBinding(object sender, System.EventArgs e)
		{
			;
		}

		private void DataGridMasterTable_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName=="ChangeId")
			{
				TextBox
					tmpTextBox=null;

				if(((tmpTextBox=e.Item.Cells[2].Controls[1] as TextBox)!=null)
					&& tmpTextBox.Text.Trim().Length!=0)
					ChangeId(Convert.ToInt32(e.Item.Cells[0].Text),Convert.ToInt32(tmpTextBox.Text));
			}
		}

		private void ChangeId(int OldId, int NewId)
		{
			DataTable
				tbl=((MainDS)Session["MainDS"]).Tables["MasterTable"];

			DataRow
				row;

			if((row=tbl.Rows.Find(OldId))!=null)
			{
				#if !WITH_ADD_HANDLER
					lock(CustomDS.ChangedTable)
				#endif
				{
					#if !WITH_ADD_HANDLER
						if(!((bool)Application["WithCascadeError"]))
						{
							CustomDS.ChangedTable=((CustomDS)Session["CustomDS"]).Tables["CustomMasterTable"];
						}
					#endif
					LabelRowCount.Text=Convert.ToString(
					#if WITH_ADD_HANDLER
						((CustomDS)Session["CustomDS"]).Tables["CustomMasterTable"].Rows.Count
					#else
						CustomDS.ChangedTable.Rows.Count
					#endif
					);
					#if WITH_ADD_HANDLER
						((CustomDS)Session["CustomDS"]).AddCascadeHandler(tbl);
					#else
						tbl.ColumnChanged+=new DataColumnChangeEventHandler(CustomDS.CascadeTable);
					#endif
					row["Id"]=NewId;
					#if WITH_ADD_HANDLER
						((CustomDS)Session["CustomDS"]).DelCascadeHandler(tbl);
					#else
						tbl.ColumnChanged-=new DataColumnChangeEventHandler(CustomDS.CascadeTable);
					#endif
				}
				BindMainDSMasterTable();
				BindMainDSDetailTable();
				BindCustomDSCustomMasterTable();
			}
		}

		private void DataGridWithPages_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridWithPages.CurrentPageIndex=e.NewPageIndex;
			DataGridWithPagesBind();
		}

		private void DataGridWithPages_DataBinding(object sender, System.EventArgs e)
		{
			; // ???
		}

		private void DataGridWithPages_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			string
				tmpString;

			if(e.Item.ItemType==ListItemType.Item
				|| e.Item.ItemType==ListItemType.AlternatingItem)
			{
				tmpString=e.Item.Cells[0].Text; // ==string.Empty
				e.Item.Cells[0].Attributes.Add("title","hint");
			}		
		}

		private void DataGridWithPages_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Item
				|| e.Item.ItemType==ListItemType.AlternatingItem)
			{
				LiteralJS.Text+=ArrayName+"["+Convert.ToInt32(e.Item.Cells[0].Text)+"]="+Convert.ToInt32(e.Item.Cells[1].Text)+";";
				e.Item.Cells[1].Attributes.Add("title","hinthint");

				object
					o;

				for(int i=0; i<e.Item.Cells[2].Controls.Count; ++i)
				{
					o=e.Item.Cells[2].Controls[i];
				}

				o=e.Item.Cells[2].FindControl(RadioButtonChoiceIdSignature+"1");
				if(o!=null)
					;

				HtmlInputRadioButton
					tmpHtmlInputRadioButton=new HtmlInputRadioButton();

				tmpHtmlInputRadioButton.ID=RadioButtonChoiceIdSignature+Convert.ToString((e.Item.DataItem as System.Data.DataRowView).Row["Id"])+"_"+Convert.ToString((e.Item.DataItem as System.Data.DataRowView).Row["Id"]);
				tmpHtmlInputRadioButton.Name=RadioButtonChoiceNameSignature+"_";
				tmpHtmlInputRadioButton.Value=Convert.ToString((e.Item.DataItem as System.Data.DataRowView).Row["Id"]);
				e.Item.Cells[3].Controls.Add(tmpHtmlInputRadioButton);
			}		
		}

		private void DataGridWithPages_Load(object sender, System.EventArgs e)
		{
		
		}

		private void DataGridWithPages_PreRender(object sender, System.EventArgs e)
		{
			object
				o=DataGridWithPages.FindControl(RadioButtonChoiceIdSignature+"1");

			if(o!=null)
				;
		}

		private void DataGridWithPages_Unload(object sender, System.EventArgs e)
		{
			object
				o=DataGridWithPages.FindControl(RadioButtonChoiceIdSignature+"1");

			if(o!=null)
				;
		}

		private void DataGridWithPages_Disposed(object sender, System.EventArgs e)
		{
		
		}

		private void DataGridWithPages_Init(object sender, System.EventArgs e)
		{
		
		}

		private void MainForm_DataBinding(object sender, System.EventArgs e)
		{
			object
				o=DataGridWithPages.FindControl(RadioButtonChoiceIdSignature+"1");

			if(o!=null)
				;
		}

		private void MainForm_PreRender(object sender, System.EventArgs e)
		{
			object
				o=DataGridWithPages.FindControl(RadioButtonChoiceIdSignature+"1");

			if(o!=null)
				;
		}

		private void MainForm_Unload(object sender, System.EventArgs e)
		{
			object
				o=DataGridWithPages.FindControl(RadioButtonChoiceIdSignature+"1");

			if(o!=null)
				;
		}
	}
}
