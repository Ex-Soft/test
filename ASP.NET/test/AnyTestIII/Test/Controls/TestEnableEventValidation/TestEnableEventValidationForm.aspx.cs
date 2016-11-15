using System;
using System.Web.UI.WebControls;

namespace AnyTest
{
	public class TestEnableEventValidationForm : System.Web.UI.Page
	{
		protected DropDownList DropDownListVictim;
		protected Button ButtonSubmit;
		protected Label LabelInfo;
	
		private void Page_Load(object sender, EventArgs e)
		{
			if(!IsPostBack)
			{
				for(int i=0; i<5; ++i)
					DropDownListVictim.Items.Add(new ListItem(i.ToString(),i.ToString()));
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
			this.ButtonSubmit.Click+=new EventHandler(ButtonSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ButtonSubmit_Click(object sender, EventArgs e)
		{
			LabelInfo.Text="SelectedIndex="+DropDownListVictim.SelectedIndex+" SelectedValue="+DropDownListVictim.SelectedValue;
		}
	}
}