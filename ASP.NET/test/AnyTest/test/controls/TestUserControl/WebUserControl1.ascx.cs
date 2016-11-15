using System;

namespace AnyTest
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Log.Log.WriteToLog(string.Format("WebUserControl1.Page_Load() (IsPostBack: {0})", IsPostBack.ToString().ToLower()), true);
        }
    }
}