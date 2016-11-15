using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page
{

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        if (User.Identity == null)
            Response.Redirect("~/Login.aspx");
        if (!User.Identity.IsAuthenticated)
            Response.Redirect("~/Login.aspx");
    }

    protected void Impersonate(object sender, EventArgs e)
    {

        UserImpersonation.ImpersonateUser("Alice", "~/Deimpersonate.aspx");
        Response.Redirect("~/Default.aspx");
    }
}
