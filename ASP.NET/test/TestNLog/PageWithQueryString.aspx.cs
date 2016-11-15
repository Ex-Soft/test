using System;

namespace TestNLog
{
    public partial class PageWithQueryString : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblQueryString.Text = Request.QueryString["queryString"];

            Global.Logger.Trace("Page_Load");

            lblTextBox1Text.Text = Request.Form["TextBox1"] ?? "null";

            _Default.ShowRequestData(Request, lblRequestData);
        }

        protected void BtnSubmitClick(object sender, EventArgs e)
        {
            TextBox1.Text += TextBox1.Text;
        }
    }
}