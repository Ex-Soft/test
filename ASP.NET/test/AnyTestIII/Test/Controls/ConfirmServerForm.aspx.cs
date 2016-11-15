using System;

namespace AnyTest
{
	public class ConfirmServerForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Literal LiteralConfirm;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HiddenConfirmResult;
		protected System.Web.UI.WebControls.Button ButtonSubmit;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				string
					scriptString="<script type=\"text/javascript\">\n<!--\n";

				scriptString+="var ConfirmStr=null;";
				scriptString+="\n// -->\n";
				scriptString+="<";
				scriptString+="/";
				scriptString+="script>";

				LiteralConfirm.Text=scriptString;
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

		private void ButtonSubmit_Click(object sender, EventArgs e)
		{
			bool
				IsDublicat=true;

			if(IsDublicat)
			{
				string
					scriptString="<script type=\"text/javascript\">\n<!--\n";

				scriptString+="var ConfirmStr='Submit?';";
				scriptString+="\n// -->\n";
				scriptString+="<";
				scriptString+="/";
				scriptString+="script>";

				LiteralConfirm.Text=scriptString;
			}
		}
	}
}
