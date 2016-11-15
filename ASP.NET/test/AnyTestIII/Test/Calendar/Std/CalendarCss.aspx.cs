using System;

namespace AnyTest
{
	public class CalendarCss : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Calendar Calendar1;
		protected System.Web.UI.WebControls.TextBox TextBoxSetDate;
		protected System.Web.UI.WebControls.Button ButtonSetDate;

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
			this.ButtonSetDate.Click += new EventHandler(ButtonSetDate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ButtonSetDate_Click(object sender, EventArgs e)
		{
			string
				tmpString;

			DateTime
				tmpDateTime = (tmpString=TextBoxSetDate.Text.Trim())!=string.Empty ? Convert.ToDateTime(tmpString) : DateTime.MinValue;

			Calendar1.SelectedDate=tmpDateTime;
		}
	}
}
