using System;

namespace CheckValid
{
	/// <summary>
	/// Summary description for IFrameStandalone.
	/// </summary>
	public class IFrameStandalone : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Literal VarDef;
		protected System.Web.UI.WebControls.TextBox IFrameStandaloneTextBox1;
		protected System.Web.UI.WebControls.TextBox IFrameStandaloneTextBox2;
		protected System.Web.UI.WebControls.Label IFrameStandaloneTextBox1Value;
		protected System.Web.UI.WebControls.Label IFrameStandaloneTextBox2Value;
		protected System.Web.UI.WebControls.Label IFrameStandaloneTextBox3Value;
		protected System.Web.UI.WebControls.Label LabelInfo;
		protected System.Web.UI.WebControls.TextBox IFrameStandaloneTextBox3;
		
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
				StrVarInit+=ArrayNameCheckElement+"[0]={Id:\""+IFrameStandaloneTextBox1.ID+"\",Required:true,typeofStore:\"int\"}";

				if(StrVarInit.Length!=0)
					StrVarInit+=";";
				StrVarInit+=ArrayNameCheckElement+"[1]={Id:\""+IFrameStandaloneTextBox3.ID+"\",Required:true,typeofStore:\"double\"}";

				if(StrVarInit.Length!=0)
					StrVarInit+=";";
				StrVarInit+=NameInvalidColor+"=\""+InvalidColorValue+"\"";
				
				StrVarDef="var "+StrVarDef+";";
				StrVarInit+=";";
				VarDef.Text=StrBeginJS+StrVarDef+StrVarInit+StrEndJS;
			}
			else
			{
				IFrameStandaloneTextBox1Value.Text="\""+IFrameStandaloneTextBox1.Text+"\"";
				IFrameStandaloneTextBox2Value.Text="\""+IFrameStandaloneTextBox2.Text+"\"";
				IFrameStandaloneTextBox3Value.Text="\""+IFrameStandaloneTextBox3.Text+"\"";
				LabelInfo.Text="Input1=\""+IFrameStandaloneTextBox1.Text+"\" "+"Input2=\""+IFrameStandaloneTextBox2.Text+"\" "+"Input3=\""+IFrameStandaloneTextBox3.Text+"\" (from server)";
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
