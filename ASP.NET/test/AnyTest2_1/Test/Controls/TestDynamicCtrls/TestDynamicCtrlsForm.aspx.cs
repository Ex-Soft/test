using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnyTest2_1
{
	public partial class TestDynamicCtrlsForm : System.Web.UI.Page
	{
		string
			DynamicTextBoxSignature = "DynamicTextBox1",
			DynamicButtonSignature = "DynamicButton1";

		protected void Page_Init(object sender, EventArgs e)
		{
			TextBox
				tmpTextBox=new TextBox();

			tmpTextBox.ID = DynamicTextBoxSignature;
			PlaceHolderTextBox.Controls.Add(tmpTextBox);
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			String
				arrName = "MyArray",
				arrValue = "\"1\", \"2\", \"text\"";

			ClientScriptManager
				cs = Page.ClientScript;

			cs.RegisterArrayDeclaration(arrName, arrValue);

			TextBox
				tmpTextBox;

			if((tmpTextBox=PlaceHolderTextBox.FindControl(DynamicTextBoxSignature) as TextBox)!=null)
			{
				LabelInfo.Text = "\"" + tmpTextBox.Text + "\" Page_Load IsPostBack=\"" + IsPostBack.ToString().ToLower() + "\"";
			}

			Button
				tmpButton=new Button();

			tmpButton.ID = DynamicButtonSignature;
			tmpButton.Text = DynamicButtonSignature;
			tmpButton.Click += new EventHandler(DynamicButton_Click);
			PlaceHolderTextBox.Controls.Add(tmpButton);
		}

		protected void DynamicButton_Click(object sender, EventArgs e)
		{
			TextBox
				tmpTextBox;

			if ((tmpTextBox = PlaceHolderTextBox.FindControl(DynamicTextBoxSignature) as TextBox) != null)
			{
				tmpTextBox.Text = "CCC";
			}

			LabelInfo.Text += " DynamicButton_Click";
		}

		protected void ButtonSubmit_Click(object sender, EventArgs e)
		{
			TextBox
				tmpTextBox;

			if ((tmpTextBox = PlaceHolderTextBox.FindControl(DynamicTextBoxSignature) as TextBox) != null)
			{
				tmpTextBox.Text = "BBB";
			}

			LabelInfo.Text += " ButtonSubmit_Click";
		}
	}
}
