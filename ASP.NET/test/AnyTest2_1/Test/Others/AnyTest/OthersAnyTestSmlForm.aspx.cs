using System;
using System.Threading;
using System.Web.UI;

namespace AnyTest2_1
{
	public partial class OthersAnyTestSmlForm : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				TextBoxWCS.Attributes.Add("onkeydown", "alert('onkeydown')");
				//ButtonDisabled.Attributes.Add("onclick", "alert('onclick')");
				ButtonDisabled.Attributes.Add("onclick", "alert('onclick');this.disabled=true");
			}
			else
			{
				Thread.Sleep(5000);
			}

			string
				scriptString = "<script type=\"text/javascript\">\n<!--\n";

			scriptString += "function OnLoad(){alert('OnLoad()');}";
			scriptString += "\n// -->\n";
			scriptString += "<";
			scriptString += "/";
			scriptString += "script>";

			if (!ClientScript.IsStartupScriptRegistered(GetType(), "Startup"))
				ClientScript.RegisterStartupScript(GetType(), "Startup", scriptString, false);
		}

		protected void ButtonDisabled_Click(object sender, EventArgs e)
		{
			Response.Write("<script type=\"text/javascript\">\n<!--\n");
			Response.Write("alert('ButtonDisabled_Click');");
			Response.Write("\n// -->\n</script>"); 
		}

		protected void HtmlInputCheckBox_ServerChange(object sender, EventArgs e)
		{
			Response.Write("<script type=\"text/javascript\">\n<!--\n");
			Response.Write("alert('HtmlInputCheckBox_ServerChange');");
			Response.Write("\n// -->\n</script>"); 
		}
	}
}
