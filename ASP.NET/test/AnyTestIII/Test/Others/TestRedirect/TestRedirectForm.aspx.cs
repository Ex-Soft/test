using System;
using System.Text;
using System.Web;

namespace AnyTest
{
	public class TestRedirectForm : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(IsPostBack)
			{
				Response.Write(TableForm.StrBeginJS+"alert('oB!')"+TableForm.StrEndJS);

				string
					SrcString="один\r\nдва\r\nтри\r\nчетыре",
					ServerUrlEncodeString=Server.UrlEncode(SrcString),
					HttpUtilityUrlEncodeString=HttpUtility.UrlEncode(SrcString),
					HttpUtilityUrlEncodeUTF8String=HttpUtility.UrlEncode(SrcString,Encoding.UTF8),
					HttpUtilityUrlEncodeUnicodeString=HttpUtility.UrlEncode(SrcString,Encoding.Unicode),
					HttpUtilityUrlEncodeASCIIString=HttpUtility.UrlEncode(SrcString,Encoding.ASCII),
					JScriptGlobalObjectEscapeString=Microsoft.JScript.GlobalObject.escape(SrcString),
					tmpString;

				char[]
					CharArray=SrcString.ToCharArray();

				tmpString=string.Empty;
				for(int i=0; i<CharArray.Length; ++i)
					tmpString+="%u"+((int)CharArray[i]).ToString("x").PadLeft(4,'0');

				tmpString=string.Empty;
				foreach(char c in CharArray)
					tmpString+="%u"+((int)c).ToString("x").PadLeft(4,'0');

				tmpString=JScriptGlobalObjectEscapeString;

				Response.Redirect("TestRedirect.html?message="+tmpString);
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
