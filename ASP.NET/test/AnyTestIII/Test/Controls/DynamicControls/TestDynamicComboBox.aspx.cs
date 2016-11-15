using System;
using System.Web.UI.WebControls;

namespace AnyTest
{
	public class TestDynamicComboBox : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlForm TestDynamicComboBoxForm;
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.WebControls.Label LabelInfo;
	
		string
			DynamicDropDownListSignature="TestDropDownList";

		private void Page_Init(object sender, System.EventArgs e)
		{
			DynamicControlsDS
				DS=new DynamicControlsDS();

			System.Web.UI.WebControls.DropDownList
				tmpDropDownList;

			tmpDropDownList=new DropDownList();
			tmpDropDownList.ID=DynamicDropDownListSignature;
			
			tmpDropDownList.DataSource=DS.Tables["TestTable"];
			tmpDropDownList.DataValueField="Id";
			tmpDropDownList.DataTextField="Description";
			tmpDropDownList.DataBind();

			TestDynamicComboBoxForm.Controls.Add(tmpDropDownList);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
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
			this.Load += new System.EventHandler(this.Page_Load);
			this.Init += new System.EventHandler(this.Page_Init);

		}
		#endregion

		private void btnSubmit_Click(object sender, EventArgs e)
		{
			System.Web.UI.WebControls.DropDownList
				tmpDropDownList;

			if((tmpDropDownList=FindControl(DynamicDropDownListSignature) as System.Web.UI.WebControls.DropDownList)!=null)
				LabelInfo.Text=tmpDropDownList.SelectedValue;
		}
	}
}
