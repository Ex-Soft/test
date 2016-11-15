using System;
using System.Web;
using System.Web.UI.WebControls;

namespace TestNLog
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            const string cookieSignature = "RequestCookie";
            
            var cookie = new HttpCookie(cookieSignature);
            cookie.Value = "TestRequestCookie";
            cookie.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Set(cookie);

            Global.Logger.Trace("Page_Load");

            System.Security.Principal.IPrincipal
                usr = HttpContext.Current.User;

            LabelInfo.Text = "AuthenticationType: \"" + usr.Identity.AuthenticationType + "\" IsAuthenticated: " + usr.Identity.IsAuthenticated.ToString().ToLower() + " Name: \"" + usr.Identity.Name + "\"";

            lblTextBox1Text.Text = Request.Form["TextBox1"] ?? "null";

            ShowRequestData(Request, lblRequestData);
        }

        protected void BtnSubmitClick(object sender, EventArgs e)
        {
            TextBox1.Text += TextBox1.Text;
        }

        public static void ShowRequestData(HttpRequest request, Label lbl)
        {
            lbl.Text = string.Empty;

            foreach (var key in request.ServerVariables.AllKeys)
            {
                if (!string.IsNullOrWhiteSpace(lbl.Text))
                    lbl.Text += "<br/>";

                lbl.Text += string.Format("ServerVariables[\"{0}\"] = \"{1}\"", key, request.ServerVariables[key]);
            }

            lbl.Text += "<hr/>";

            foreach (var key in request.QueryString.AllKeys)
            {
                if (!string.IsNullOrWhiteSpace(lbl.Text))
                    lbl.Text += "<br/>";

                lbl.Text += string.Format("QueryString[\"{0}\"] = \"{1}\"", key, request.QueryString[key]);
            }

            lbl.Text += "<hr/>";

            foreach (var key in request.Form.AllKeys)
            {
                if (!string.IsNullOrWhiteSpace(lbl.Text))
                    lbl.Text += "<br/>";

                lbl.Text += string.Format("Form[\"{0}\"] = \"{1}\"", key, request.Form[key]);
            }

            lbl.Text += "<hr/>";

            foreach (var key in request.Cookies.AllKeys)
            {
                if (!string.IsNullOrWhiteSpace(lbl.Text))
                    lbl.Text += "<br/>";

                lbl.Text += string.Format("Cookies[\"{0}\"] = {{ Name: \"{1}\", Value: \"{2}\", Expires: {3}}}", key, request.Cookies[key].Name, request.Cookies[key].Value, request.Cookies[key].Expires);
            }
        }
    }
}
