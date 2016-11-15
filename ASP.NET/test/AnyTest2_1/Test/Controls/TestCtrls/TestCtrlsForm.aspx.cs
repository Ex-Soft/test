using System;
using System.Text;
using System.Web.UI;

namespace AnyTest2_1
{
	public partial class TestCtrlsForm : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			StringBuilder
				jsb = new StringBuilder();

			jsb.AppendLine("function button1_click_function () {");
			jsb.AppendLine(Page.ClientScript.GetPostBackEventReference(Button1, "") + ";");
			jsb.AppendLine("}");

			Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "key", jsb.ToString(), true);

			if(IsPostBack)
			{
				if(Request.Params.GetValues("__VIEWSTATE")!=null)
				{
					string 
						Value = Request.Params.GetValues("__VIEWSTATE")[0];

					byte[]
						stringBytes = Convert.FromBase64String(Value);

					string
						decodeViewState = System.Text.Encoding.ASCII.GetString(stringBytes);

					string
						tmpString = "SmthPahe.aspx?strparam=" + Server.UrlEncode("Это параметр <> ~!@#$%^&*()_+,./");

					tmpString = Server.UrlDecode(tmpString);
				}
			}
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			Button1.Click += Button1_Click;
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			Label1.Text = ((Control)sender).ID;
		}

		protected override void Render(HtmlTextWriter writer)
		{
			Page.ClientScript.RegisterForEventValidation(Button1.ID, "");
			base.Render(writer);
		}

		protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
		{
			//
		}
	}
}
