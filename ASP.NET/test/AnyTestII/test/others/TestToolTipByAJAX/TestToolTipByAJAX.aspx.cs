using System;

namespace AnyTestII
{
	public partial class TestToolTipByAJAXForm : System.Web.UI.Page
	{
		public const string
			TestToolTipByAJAXFormDataSessionSignature = "TestToolTipByAJAXFormDataSession";

		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session[TestToolTipByAJAXFormDataSessionSignature] == null)
				Session[TestToolTipByAJAXFormDataSessionSignature] = DateTime.Now;
		}
	}
}
