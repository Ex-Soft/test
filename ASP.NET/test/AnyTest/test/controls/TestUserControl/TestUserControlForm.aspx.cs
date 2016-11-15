using System;

namespace AnyTest
{
    public partial class TestUserControlForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Log.Log.WriteToLog(string.Format("TestUserControlForm.Page_Load() (IsPostBack: {0})", IsPostBack.ToString().ToLower()), true);
        }
    }
}
