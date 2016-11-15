using System;
using System.Web;
using System.Web.UI.WebControls;

namespace AnyTestII
{
	public partial class TestUpdatePanelForm : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			LabelIsPostBack.Text = DateTime.Now.ToLongTimeString();
		}

		protected void Button_Click(object sender, EventArgs e)
		{
			Button
				tmpButton;

			if ((tmpButton = sender as Button) == null)
				return;

			Label
				tmpLabel = null;

			switch (tmpButton.ID)
			{
				case "UpdatePanelButton":
				{
					tmpLabel = UpdatePanelLabelInfo;
					break;
				}
				case "Button1":
				{
					tmpLabel = LabelInfo;
					break;
				}
				default:
				{
					throw new Exception("Unknown sender: \"" + tmpButton.ID + "\"");
				}
			}

			if (tmpLabel != null)
				tmpLabel.Text = DateTime.Now.ToLongTimeString();
		}
	}
}
