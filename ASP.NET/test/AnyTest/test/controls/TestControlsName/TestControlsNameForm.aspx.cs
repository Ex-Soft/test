using System;

namespace AnyTest
{
    public partial class TestControlsNameForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnClickSubmit(object source, EventArgs args)
        {
            string
                name1 = "HtmlInput1[]",
                value1 = Request.Form[name1] ?? "null",
                name2 = "HtmlInput2[]",
                value2 = Request.Form[name2] ?? "null";

            LabelInfo1.Text = value1;
            LabelInfo2.Text = value2;
        }
    }
}