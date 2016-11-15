#define USE_PAGE_INIT
//#define USE_PAGE_LOAD

using System;
using System.Data;
using System.Web.UI.WebControls;

namespace AnyTest
{
	/// <summary>
	/// Summary description for DropDownListForm.
	/// </summary>
	public class DropDownListForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropDownListTest;
		protected System.Web.UI.WebControls.Label LabelDropDownListTestSelectedIndex;
		protected System.Web.UI.WebControls.Label LabelDropDownListTestSelectedValue;
		protected System.Web.UI.WebControls.Label LabelRequestFormDropDownListTestID;
		protected System.Web.UI.WebControls.Button ButtonSubmit;
		protected System.Web.UI.WebControls.DropDownList DropDownListDynamic;
		protected System.Web.UI.WebControls.Label LabelDropDownListDynamicSelectedIndex;
		protected System.Web.UI.WebControls.Label LabelDropDownListDynamicSelectedValue;
		protected System.Web.UI.WebControls.Label LabelRequestFormDropDownListDynamicID;
		protected System.Web.UI.WebControls.DropDownList DropDownListDynamicII;
		protected System.Web.UI.WebControls.Label LabelDropDownListDynamicIISelectedIndex;
		protected System.Web.UI.WebControls.Label LabelDropDownListDynamicIISelectedValue;
		protected System.Web.UI.WebControls.Label LabelRequestFormDropDownListDynamicIIID;
		protected System.Web.UI.WebControls.DropDownList DropDownListDynamicIII;
		protected System.Web.UI.WebControls.Label LabelDropDownListDynamicIIISelectedIndex;
		protected System.Web.UI.WebControls.Label LabelDropDownListDynamicIIISelectedValue;
		protected System.Web.UI.WebControls.Label LabelRequestFormDropDownListDynamicIIIID;
		protected System.Web.UI.WebControls.DropDownList DropDownListParent;
		protected System.Web.UI.WebControls.DropDownList DropDownListChild;
		
		DataTable
			tbl=null;

		private void Page_Init(object sender, System.EventArgs e)
		{
			string
				tmpString=string.Empty;

			System.Web.UI.WebControls.DropDownList
				tmpDropDownList;

			if((tmpDropDownList=sender as System.Web.UI.WebControls.DropDownList)!=null)
				tmpString=tmpDropDownList.ID;

			if(e!=System.EventArgs.Empty)
				tmpString="Yes!";

			string[]
				tmpStrings;

			if((tmpStrings=Request.Form.GetValues("__EVENTTARGET"))!=null)
			{
				tmpString=string.Empty;
				for(int i=0; i<tmpStrings.Length; ++i)
				{
					if(tmpString!=string.Empty)
						tmpString+=Environment.NewLine;
					tmpString+=tmpStrings[i];
				}
			}

			if(!IsPostBack)
			{
				if(tbl==null)
				{
					tbl=new DataTable();
					tbl.Columns.Add("Value",typeof(long));
					tbl.Columns.Add("Text",typeof(string));
					if(tbl.PrimaryKey.Length==0)
						tbl.PrimaryKey=new DataColumn[]{tbl.Columns["Value"]};

					DataRow
						tmpDataRow;

					long
						tmpLong=2147485000; // int min=-2,147,483,648 int max=2,147,483,647

					for(int i=0; i<10; ++i)
					{
						tmpDataRow=tbl.NewRow();
						tmpDataRow["Value"]=Convert.ToString(tmpLong);
						tmpDataRow["Text"]=Convert.ToString(tmpLong++);
						tbl.Rows.Add(tmpDataRow);
					}
				}

				Session["DataTable"]=tbl;

				#if USE_PAGE_INIT
					DropDownListBind();
				#endif

				DropDownListParent.Items.Add(new ListItem("1","1"));
				DropDownListParent.Items.Add(new ListItem("2","2"));
				DropDownListParent.Items.Add(new ListItem("3","3"));
			}
			else
			{
				tbl=(DataTable)Session["DataTable"];
			}

			if(IsPostBack)
			{
				tmpString=string.Empty;
				for(int i=0; i<DropDownListChild.Items.Count; ++i)
				{
					if(tmpString!=string.Empty)
						tmpString+=", ";
					tmpString+=DropDownListChild.Items[i].Value;
				}
			}

			FillDropDownListChild(IsPostBack ? Request.Form.GetValues(DropDownListParent.ID)[0] : DropDownListParent.SelectedValue);

			if(IsPostBack)
			{
				tmpString=string.Empty;
				for(int i=0; i<DropDownListChild.Items.Count; ++i)
				{
					if(tmpString!=string.Empty)
						tmpString+=", ";
					tmpString+=DropDownListChild.Items[i].Value;
				}

				tmpString=Request.Form.GetValues(DropDownListChild.ID)[0];
				DropDownListChild.SelectedValue=tmpString;
			}
		}
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			string
				tmpString=string.Empty;

			System.Web.UI.WebControls.DropDownList
				tmpDropDownList;

			if((tmpDropDownList=sender as System.Web.UI.WebControls.DropDownList)!=null)
				tmpString=tmpDropDownList.ID;

			if(e!=System.EventArgs.Empty)
				tmpString="Yes!";

			if(!IsPostBack)
			{
#if USE_PAGE_LOAD
					DropDownListBind();
#endif

				DropDownListDynamicII.Items.Add(new ListItem("0","0"));
				DropDownListDynamicII.Items.Add(new ListItem("1","1"));
				DropDownListDynamicII.Items.Add(new ListItem("2","2"));
				DropDownListDynamicII.Items.Add(new ListItem("3","3"));
				DropDownListDynamicII.Items.Add(new ListItem("4","4"));
				DropDownListDynamicII.Items.Add(new ListItem("5","5"));
				DropDownListDynamicII.SelectedValue="5";

				DropDownListDynamicIII.Items.Add(new ListItem("0","0"));
				DropDownListDynamicIII.Items.Add(new ListItem("1","1"));
				DropDownListDynamicIII.Items.Add(new ListItem("2","2"));
				DropDownListDynamicIII.SelectedValue="1";
			}
			else
			{
				DropDownListDynamicShow();
				DropDownListDynamicIIShow();
				DropDownListDynamicIIIShow();
			}
		}

		private void DropDownListBind()
		{
			DropDownListTest.DataSource=tbl;
			DropDownListTest.DataValueField="Value";
			DropDownListTest.DataTextField="Text";
			DropDownListTest.DataBind();

			DropDownListDynamic.DataSource=tbl;
			DropDownListDynamic.DataValueField="Value";
			DropDownListDynamic.DataTextField="Text";
			DropDownListDynamic.DataBind();
		}

		private void DropDownListDynamicShow()
		{
			LabelDropDownListDynamicSelectedIndex.Text=Convert.ToString(DropDownListDynamic.SelectedIndex);
			LabelDropDownListDynamicSelectedValue.Text=DropDownListDynamic.SelectedValue;
			LabelRequestFormDropDownListDynamicID.Text=Request.Form.GetValues(DropDownListDynamic.ID)[0];
		}
		//---------------------------------------------------------------------------

		private void DropDownListDynamicIIShow()
		{
			LabelDropDownListDynamicIISelectedIndex.Text=Convert.ToString(DropDownListDynamicII.SelectedIndex);
			LabelDropDownListDynamicIISelectedValue.Text=DropDownListDynamicII.SelectedValue;
			LabelRequestFormDropDownListDynamicIIID.Text=Request.Form.GetValues(DropDownListDynamicII.ID)[0];
		}
		//---------------------------------------------------------------------------

		private void DropDownListDynamicIIIShow()
		{
			LabelDropDownListDynamicIIISelectedIndex.Text=Convert.ToString(DropDownListDynamicIII.SelectedIndex);
			LabelDropDownListDynamicIIISelectedValue.Text=DropDownListDynamicIII.SelectedValue;
			LabelRequestFormDropDownListDynamicIIIID.Text=Request.Form.GetValues(DropDownListDynamicIII.ID)[0];
		}
		//---------------------------------------------------------------------------

		void FillDropDownListChild(string ValueParent)
		{
			for(int i=1; i<5; ++i)
				DropDownListChild.Items.Add(new ListItem((Convert.ToInt32(ValueParent)*11*i).ToString(),(Convert.ToInt32(ValueParent)*11*i).ToString()));
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
			this.DropDownListParent.SelectedIndexChanged += new EventHandler(DropDownListParent_SelectedIndexChanged);
			this.DropDownListTest.SelectedIndexChanged += new System.EventHandler(this.DropDownListTest_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);
			this.Init += new System.EventHandler(this.Page_Init);

		}
		#endregion

		private void DropDownListTest_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			LabelDropDownListTestSelectedIndex.Text=Convert.ToString(DropDownListTest.SelectedIndex);
			LabelDropDownListTestSelectedValue.Text=DropDownListTest.SelectedValue;
			LabelRequestFormDropDownListTestID.Text=Request.Form.GetValues(DropDownListTest.ID)[0];
		}
		//---------------------------------------------------------------------------

		private void DropDownListParent_SelectedIndexChanged(object sender, EventArgs e)
		{
			string
				tmpString=DropDownListParent.SelectedValue;

			tmpString+=DropDownListChild.SelectedValue;
		}
	}
}
