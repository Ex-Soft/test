using System;
using System.Web.UI.WebControls;

namespace AnyTest2_1
{
	public partial class TestEnableEventValidationForm : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if(!IsPostBack)
			{
				for(int i=0; i<5; ++i)
					DropDownListVictim.Items.Add(new ListItem(i.ToString(),i.ToString()));
			}
		}

		protected void ButtonSubmit_Click(object sender, EventArgs e)
		{
			LabelInfo.Text = "SelectedIndex=" + DropDownListVictim.SelectedIndex + " SelectedValue=" + DropDownListVictim.SelectedValue;
		}
	}
}
