using System;
using System.Web.UI.WebControls;

namespace AnyTest2_1
{
    public partial class SecondForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                TextBox
                    tmpTextBox;

                LabelSecondForm.Text=(tmpTextBox = PreviousPage.FindControl(FirstForm.TextBoxID) as TextBox) != null ? tmpTextBox.Text : "null";
            }
        }
    }
}
