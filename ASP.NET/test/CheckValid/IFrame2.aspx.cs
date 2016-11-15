using System;

namespace CheckValid
{
	/// <summary>
	/// Summary description for IFrame2.
	/// </summary>
	public class IFrame2 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Literal VarDef;
		protected System.Web.UI.WebControls.TextBox IFrame2TextBox1;
		protected System.Web.UI.WebControls.TextBox IFrame2TextBox2;
		protected System.Web.UI.WebControls.Label IFrame2TextBox1Value;
		protected System.Web.UI.WebControls.Label IFrame2TextBox2Value;
		protected System.Web.UI.WebControls.Label IFrame2TextBox3Value;
		protected System.Web.UI.WebControls.Label LabelInfo;
		protected System.Web.UI.WebControls.TextBox IFrame2TextBox3;	

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
				StrVarInit+=ArrayNameCheckElement+"[0]={Id:\""+IFrame2TextBox1.ID+"\",Required:true,typeofStore:\"int\"}";

				if(StrVarInit.Length!=0)
					StrVarInit+=";";
				StrVarInit+=ArrayNameCheckElement+"[1]={Id:\""+IFrame2TextBox3.ID+"\",Required:true,typeofStore:\"double\"}";

				if(StrVarInit.Length!=0)
					StrVarInit+=";";
				StrVarInit+=NameInvalidColor+"=\""+InvalidColorValue+"\"";
				
				StrVarDef="var "+StrVarDef+";";
				StrVarInit+=";";
				VarDef.Text=StrBeginJS+StrVarDef+StrVarInit+StrEndJS;
			}
			else
			{
				IFrame2TextBox1Value.Text="\""+IFrame2TextBox1.Text+"\"";
				IFrame2TextBox2Value.Text="\""+IFrame2TextBox2.Text+"\"";
				IFrame2TextBox3Value.Text="\""+IFrame2TextBox3.Text+"\"";
				LabelInfo.Text="Input1=\""+IFrame2TextBox1.Text+"\" "+"Input2=\""+IFrame2TextBox2.Text+"\" "+"Input3=\""+IFrame2TextBox3.Text+"\" (from server)";
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
