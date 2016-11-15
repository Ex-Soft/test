using System;

namespace TestImpersonation
{
    public partial class MainForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.IsAuthenticated)
                LabelIsAuthenticated.Text = Context.User.Identity.Name;
        }
    }
}
