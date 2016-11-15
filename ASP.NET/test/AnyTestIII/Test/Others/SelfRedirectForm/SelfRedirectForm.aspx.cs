using System;
using System.Data;
using System.Threading;
using System.Web.UI.WebControls;

namespace AnyTest
{
	public class SelfRedirectForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBoxId;
		protected System.Web.UI.WebControls.DropDownList DropDownListParam;
		protected System.Web.UI.WebControls.CheckBox CheckBoxendResponse;
		protected System.Web.UI.WebControls.Panel PanelParam;
		protected System.Web.UI.WebControls.Label LabelParam;
		protected System.Web.UI.WebControls.Label LabelId;
		protected System.Web.UI.WebControls.Label LabelName;
		protected System.Web.UI.WebControls.Label LabelEndResponse;

		DataTable
			dt;

		string
			SessionSignature="SelfRedirectFormData",
			SessionDSSignature="SelfRedirectFormDataDS";

		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(Session[SessionSignature]==null)
				{
					DataTableCreate();
					DataTableFill();
					Session[SessionSignature]=dt;
				}
				else
					dt=(DataTable)Session[SessionSignature];

				SelfRedirectFormDS
					DSOld=null,
					DSNew=null;

				if((DSOld=(SelfRedirectFormDS)Session[SessionDSSignature])==null)
				{
					DSOld=new SelfRedirectFormDS();
					Session.Add(SessionDSSignature,DSOld);
					DSOld.FillDataTable(true);
				}

				string[]
					ParamArray=Request.QueryString.GetValues("ID");

				string
					ParamValue=string.Empty;

				if(ParamArray!=null && ParamArray.Length>0)
					ParamValue=ParamArray[0];

				if(ParamValue!=string.Empty)
				{
					PanelParam.Visible=true;
					LabelParam.Text=ParamValue;
				}

				if(!IsPostBack)
				{
					FillDropDownList();
					if(ParamValue!=string.Empty)
						ShowRow(ParamValue);
				}
				else
				{
					switch(DropDownListParam.SelectedValue)
					{
						case "1" :
						{
							ShowRow(TextBoxId.Text);
							break;	
						}
						case "2" :
						{
							DSNew=new SelfRedirectFormDS();
							DSNew.FillDataTable(false);
							//Session[SessionDSSignature]=DSNew;
							DSOld=DSNew;

							string
								tmpString;

							if((tmpString=TextBoxId.Text.Trim())!=string.Empty)
							{
								long
									tmpLong;

								if((tmpLong=CopyRecord(Convert.ToInt64(tmpString)))!=long.MinValue)
								{
									Response.Redirect("SelfRedirectForm.aspx?ID="+tmpLong,CheckBoxendResponse.Checked);
									LabelEndResponse.Text=CheckBoxendResponse.Checked.ToString().ToLower();
								}
							}
							break;
						}
					}
				}
			}
			catch(ThreadAbortException eException)
			{
				throw(new Exception(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"ExceptionState:"+eException.ExceptionState+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace));
			}
			catch(Exception eException)
			{
				throw(new Exception(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace));
			}
		}
		//---------------------------------------------------------------------------

		private void FillDropDownList()
		{
			ListItem
				tmpListItem;

			tmpListItem=new ListItem("1st","1");
			DropDownListParam.Items.Add(tmpListItem);
			tmpListItem=new ListItem("2nd","2");
			DropDownListParam.Items.Add(tmpListItem);
		}
		//---------------------------------------------------------------------------

		private void DataTableCreate()
		{
			dt=new DataTable();
			
			DataColumn
				col;

			col=dt.Columns.Add("Id",typeof(long));
			col.AllowDBNull=false;
			col.Unique=true;
			col.AutoIncrement=true;
			col.AutoIncrementSeed=-1;
			col.AutoIncrementStep=-1;
			dt.Columns.Add("Name",typeof(string));
			dt.PrimaryKey=new DataColumn[]{dt.Columns["Id"]};
		}
		//---------------------------------------------------------------------------

		private void DataTableFill()
		{
			DataRow
				row;

			row=dt.NewRow();
			row["Id"]=1;
			row["Name"]="Ленин";
			dt.Rows.Add(row);

			row=dt.NewRow();
			row["Id"]=2;
			row["Name"]="Сталин";
			dt.Rows.Add(row);
			
			row=dt.NewRow();
			row["Id"]=3;
			row["Name"]="Хрущев";
			dt.Rows.Add(row);
		}
		//---------------------------------------------------------------------------

		private long CopyRecord(long Id)
		{
			long
				NewId=long.MinValue;

			DataRow
				RowSrc;

			if((RowSrc=dt.Rows.Find(Id))!=null)
			{
				DataRow
					RowDest;

				RowDest=dt.NewRow();
				foreach(DataColumn col in dt.Columns)
				{
					if(col.AutoIncrement)
						continue;
					RowDest[col.ColumnName]=RowSrc[col.ColumnName];
				}
				dt.Rows.Add(RowDest);
				NewId=Convert.ToInt64(RowDest["Id"]);
			}

			return(NewId);
		}
		//---------------------------------------------------------------------------

		private void ShowRow(string Id)
		{
			if((Id=Id.Trim())!=string.Empty)
				ShowRow(Convert.ToInt64(Id));
		}
		//---------------------------------------------------------------------------

		private void ShowRow(long Id)
		{
			DataRow
				row;

			if((row=dt.Rows.Find(Id))!=null)
			{
				LabelId.Text=Convert.ToString(Convert.ToInt64(row["Id"]));
				LabelName.Text=Convert.ToString(row["Name"]);
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
