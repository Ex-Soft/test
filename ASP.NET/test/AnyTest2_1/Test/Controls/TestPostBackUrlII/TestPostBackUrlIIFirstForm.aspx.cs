using System;
using System.Web.UI.WebControls;

namespace AnyTest2_1
{
    public partial class TestPostBackUrlIIFirstForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(PreviousPage!=null)
            {
                TextBox
                    tmpTextBox;

                Label1.Text = (tmpTextBox = PreviousPage.FindControl(TestPostBackUrlIISecondForm.TextBoxID) as TextBox) != null ? tmpTextBox.Text : "null";

                string
                    JSString = MainForm.StrBeginJS + "if(opener){alert('opener');opener.location.reload();close();}" + MainForm.StrEndJS;

                if (!ClientScript.IsStartupScriptRegistered("OnLoad"))
                    ClientScript.RegisterStartupScript(this.GetType(), "OnLoad", JSString);
            }
        }
    }
}
