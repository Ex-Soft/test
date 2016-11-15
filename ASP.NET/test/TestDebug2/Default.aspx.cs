using System;

namespace TestDebug2
{
	public partial class _Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("Page_Load");
		}
	}
}
