using System;
using System.Web.UI.WebControls;

namespace CheckValid
{
	/// <summary>
	/// Summary description for MainForm.
	/// </summary>
	public class MainForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Literal VarDef;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.TextBox TextBox3;
		protected System.Web.UI.WebControls.TextBox TabPage3TextBox1;
		protected System.Web.UI.WebControls.TextBox TabPage3TextBox2;
		protected System.Web.UI.WebControls.TextBox TabPage3TextBox3;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.Label TextBox1Value;
		protected System.Web.UI.WebControls.Label TextBox2Value;
		protected System.Web.UI.WebControls.Label TextBox3Value;
		protected System.Web.UI.WebControls.Label DropDownListValue;
		protected System.Web.UI.WebControls.Label TabPage3TextBox1Value;
		protected System.Web.UI.WebControls.Label TabPage3TextBox2Value;
		protected System.Web.UI.WebControls.Label LabelInfo;
		protected System.Web.UI.WebControls.Button ButtonSubmit;
		protected System.Web.UI.WebControls.Label TabPage3TextBox3Value;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				const string
					StrBeginJS="\n<SCRIPT TYPE=\"text/javascript\">\n<!--\n",
					StrEndJS="\n// -->\n</SCRIPT>";

				string
					StrVarDef="",
					StrVarInit="",
					ArrayNameCheckElement="CheckElement",
					NameInvalidColor="InvalidColor",
					InvalidColorValue="rgb(255,191,191)";

				if(StrVarDef.Length!=0)
					StrVarDef+=",";
				StrVarDef+=ArrayNameCheckElement+"=new Array()";

				if(StrVarDef.Length!=0)
					StrVarDef+=",";
				StrVarDef+=NameInvalidColor;
				
				if(StrVarInit.Length!=0)
					StrVarInit+=";";
				StrVarInit+=ArrayNameCheckElement+"[0]={Id:\""+TextBox1.ID+"\",Required:true,typeofStore:\"int\"}";

				if(StrVarInit.Length!=0)
					StrVarInit+=";";
				StrVarInit+=ArrayNameCheckElement+"[1]={Id:\""+TextBox3.ID+"\",Required:true,typeofStore:\"double\"}";

				if(StrVarInit.Length!=0)
					StrVarInit+=";";
				StrVarInit+=ArrayNameCheckElement+"[2]={Id:\""+TabPage3TextBox1.ID+"\",Required:true,typeofStore:\"int\"}";

				if(StrVarInit.Length!=0)
					StrVarInit+=";";
				StrVarInit+=ArrayNameCheckElement+"[3]={Id:\""+TabPage3TextBox3.ID+"\",Required:true,typeofStore:\"double\"}";

				if(StrVarInit.Length!=0)
					StrVarInit+=";";
				StrVarInit+=ArrayNameCheckElement+"[4]={Id:\""+DropDownList1.ID+"\",Required:true}";

				if(StrVarInit.Length!=0)
					StrVarInit+=";";
				StrVarInit+=NameInvalidColor+"=\""+InvalidColorValue+"\"";

				StrVarDef="var "+StrVarDef+";";
				StrVarInit+=";";
				VarDef.Text=StrBeginJS+StrVarDef+StrVarInit+StrEndJS;
				
				ListItem
					tmp;
				
				tmp=new ListItem("1st","1");
				DropDownList1.Items.Add(tmp);
				tmp=new ListItem("2nd","2");
				DropDownList1.Items.Add(tmp);
				tmp=new ListItem("3rd","3");
				DropDownList1.Items.Add(tmp);
				tmp=new ListItem(" ");
				DropDownList1.Items.Insert(0,tmp);
			}
			else
			{
				TextBox1Value.Text="\""+TextBox1.Text+"\"";
				TextBox2Value.Text="\""+TextBox2.Text+"\"";
				TextBox3Value.Text="\""+TextBox3.Text+"\"";
				DropDownListValue.Text="\""+DropDownList1.Items[DropDownList1.SelectedIndex]+"\"";
				TabPage3TextBox1Value.Text="\""+TabPage3TextBox1.Text+"\"";
				TabPage3TextBox2Value.Text="\""+TabPage3TextBox2.Text+"\"";
				TabPage3TextBox3Value.Text="\""+TabPage3TextBox3.Text+"\"";
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
			this.ButtonSubmit.Click += new System.EventHandler(this.ButtonSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ButtonSubmit_Click(object sender, System.EventArgs e)
		{
			LabelInfo.Text="Hello!!! (from server) ;)";
		}
	}
}
