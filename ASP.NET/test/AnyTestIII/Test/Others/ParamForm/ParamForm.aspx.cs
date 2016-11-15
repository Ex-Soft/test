using System;
using System.Web;

namespace AnyTest
{
	/// <summary>
	/// Summary description for ParamForm.
	/// </summary>
	public class ParamForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label ParagraphRequest;

		protected string
			testStr1="This is test string# 1",
			testStr2="This is test string# 2";

		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Write("Response.Write#1<br>");
			ParagraphRequest.Text="";
			ParagraphRequest.Text+="Request.ApplicationPath: \""+Request.ApplicationPath+"\"<br>";

			HttpBrowserCapabilities
				bc = Request.Browser;

			ParagraphRequest.Text+="<br>";
			ParagraphRequest.Text+="Browser Capabilities:<br>";
			ParagraphRequest.Text+="Type = " + bc.Type + "<br>";
			ParagraphRequest.Text+="Name = " + bc.Browser + "<br>";
			ParagraphRequest.Text+="Version = " + bc.Version + "<br>";
			ParagraphRequest.Text+="Major Version = " + bc.MajorVersion + "<br>";
			ParagraphRequest.Text+="Minor Version = " + bc.MinorVersion + "<br>";
			ParagraphRequest.Text+="Platform = " + bc.Platform + "<br>";
			ParagraphRequest.Text+="Is Beta = " + bc.Beta + "<br>";
			ParagraphRequest.Text+="Is Crawler = " + bc.Crawler + "<br>";
			ParagraphRequest.Text+="Is AOL = " + bc.AOL + "<br>";
			ParagraphRequest.Text+="Is Win16 = " + bc.Win16 + "<br>";
			ParagraphRequest.Text+="Is Win32 = " + bc.Win32 + "<br>";
			ParagraphRequest.Text+="Supports Frames = " + bc.Frames + "<br>";
			ParagraphRequest.Text+="Supports Tables = " + bc.Tables + "<br>";
			ParagraphRequest.Text+="Supports Cookies = " + bc.Cookies + "<br>";
			ParagraphRequest.Text+="Supports VB Script = " + bc.VBScript + "<br>";
			ParagraphRequest.Text+="Supports JavaScript = " + bc.JavaScript + "<br>";
			ParagraphRequest.Text+="Supports Java Applets = " + bc.JavaApplets + "<br>";
			ParagraphRequest.Text+="Supports ActiveX Controls = " + bc.ActiveXControls + "<br>";
			ParagraphRequest.Text+="CDF = " + bc.CDF + "<br>";
			ParagraphRequest.Text+="W3CDomVersion = " + bc.W3CDomVersion + "<br>";
			ParagraphRequest.Text+="<br>";

			ParagraphRequest.Text+="Request.CurrentExecutionFilePath: \""+Request.CurrentExecutionFilePath+"\"<br>";
			ParagraphRequest.Text+="Request.FilePath: \""+Request.FilePath+"\"<br>";
			ParagraphRequest.Text+="Request.HttpMethod: \""+Request.HttpMethod+"\"<br>";
			ParagraphRequest.Text+="Request.IsAuthenticated: \""+Request.IsAuthenticated+"\"<br>";
			ParagraphRequest.Text+="Request.IsSecureConnection: \""+Request.IsSecureConnection+"\"<br>";

			string[]
				array1,
				array2;

			int
				i,
				ii;

			ParagraphRequest.Text+="<br>";
			ParagraphRequest.Text+="Request.Params.Count: \""+Request.Params.Count+"\"<br>";
			array1=Request.Params.AllKeys;
			for(i=0; i<array1.Length; ++i)
			{
				ParagraphRequest.Text+="Key ["+Convert.ToString(i)+"]="+Server.HtmlEncode(array1[i])+"<br>";
				array2=Request.Params.GetValues(array1[i]);
				for(ii=0; ii<array2.Length; ++ii)
					ParagraphRequest.Text+="Value ["+Convert.ToString(ii)+"]="+Server.HtmlEncode(array2[ii])+"<br>";
			}
			ParagraphRequest.Text+="<br>";

			ParagraphRequest.Text+="Request.Path: \""+Request.Path+"\"<br>";
			ParagraphRequest.Text+="Request.PathInfo: \""+Request.PathInfo+"\"<br>";
			ParagraphRequest.Text+="Request.PhysicalApplicationPath: \""+Request.PhysicalApplicationPath+"\"<br>";
			ParagraphRequest.Text+="Request.PhysicalPath: \""+Request.PhysicalPath+"\"<br>";

			ParagraphRequest.Text+="<br>";
			ParagraphRequest.Text+="Request.QueryString.Count: \""+Request.QueryString.Count+"\"<br>";
			
			array1=Request.QueryString.AllKeys;
			for(i=0; i<array1.Length; ++i)
			{
				ParagraphRequest.Text+="Key ["+Convert.ToString(i)+"]="+Server.HtmlEncode(array1[i])+"<br>";
				array2=Request.QueryString.GetValues(array1[i]);
				for(ii=0; ii<array2.Length; ++ii)
					ParagraphRequest.Text+="Value ["+Convert.ToString(ii)+"]="+Server.HtmlEncode(array2[ii])+" ("+array2[ii]+")<br>";
			}
			ParagraphRequest.Text+="<br>";

			ParagraphRequest.Text+="Request.RawUrl: \""+Request.RawUrl+"\"<br>";
			ParagraphRequest.Text+="Request.RequestType: \""+Request.RequestType+"\"<br>";

			ParagraphRequest.Text+="<br>";
			ParagraphRequest.Text+="Request.ServerVariables.Count: \""+Request.ServerVariables.Count+"\"<br>";

			array1=Request.ServerVariables.AllKeys;
			for(i=0; i<array1.Length; ++i)
			{
				ParagraphRequest.Text+="Key ["+Convert.ToString(i)+"]="+Server.HtmlEncode(array1[i])+"<br>";
				array2=Request.ServerVariables.GetValues(array1[i]);
				for(ii=0; ii<array2.Length; ++ii)
					ParagraphRequest.Text+="Value ["+Convert.ToString(ii)+"]="+Server.HtmlEncode(array2[ii])+"<br>";
			}
			ParagraphRequest.Text+="<br>";

			ParagraphRequest.Text+="Request.Url.AbsolutePath: \""+Request.Url.AbsolutePath+"\"<br>";
			ParagraphRequest.Text+="Request.Url.AbsoluteUri: \""+Request.Url.AbsoluteUri+"\"<br>";
			ParagraphRequest.Text+="Request.Url.Authority: \""+Request.Url.Authority+"\"<br>";
			ParagraphRequest.Text+="Request.Url.Fragment: \""+Request.Url.Fragment+"\"<br>";
			ParagraphRequest.Text+="Request.Url.Host: \""+Request.Url.Host+"\"<br>";
			ParagraphRequest.Text+="Request.Url.HostNameType: \""+Request.Url.HostNameType+"\"<br>";
			ParagraphRequest.Text+="Request.Url.LocalPath: \""+Request.Url.LocalPath+"\"<br>";
			ParagraphRequest.Text+="Request.Url.PathAndQuery: \""+Request.Url.PathAndQuery+"\"<br>";

			string
				tmpString=Server.UrlDecode(Request.Url.PathAndQuery);

			tmpString=HttpUtility.UrlDecode(Request.Url.PathAndQuery);

			ParagraphRequest.Text+="Request.Url.Query: \""+Request.Url.Query+"\"<br>";
			ParagraphRequest.Text+="Request.Url.Scheme: \""+Request.Url.Scheme+"\"<br>";
			array1=Request.Url.Segments;
			for(i=0; i<array1.Length; ++i)
				ParagraphRequest.Text+="Request.Url.Segments ["+Convert.ToString(i)+"]="+array1[i]+"<br>";
			ParagraphRequest.Text+="Request.Url.UserEscaped: \""+Request.Url.UserEscaped.ToString()+"\"<br>";
			ParagraphRequest.Text+="Request.Url.UserInfo: \""+Request.Url.UserInfo+"\"<br>";

			if(Request.UrlReferrer!=null)
			{
				ParagraphRequest.Text+="<br>";
				ParagraphRequest.Text+="Request.UrlReferrer.AbsolutePath: \""+Request.UrlReferrer.AbsolutePath+"\"<br>";
				ParagraphRequest.Text+="Request.UrlReferrer.AbsoluteUri: \""+Request.UrlReferrer.AbsoluteUri+"\"<br>";
				ParagraphRequest.Text+="Request.UrlReferrer.Authority: \""+Request.UrlReferrer.Authority+"\"<br>";
				ParagraphRequest.Text+="Request.UrlReferrer.Fragment: \""+Request.UrlReferrer.Fragment+"\"<br>";
				ParagraphRequest.Text+="Request.UrlReferrer.Host: \""+Request.UrlReferrer.Host+"\"<br>";
				ParagraphRequest.Text+="Request.UrlReferrer.HostNameType: \""+Request.UrlReferrer.HostNameType+"\"<br>";
				ParagraphRequest.Text+="Request.UrlReferrer.LocalPath: \""+Request.UrlReferrer.LocalPath+"\"<br>";
				ParagraphRequest.Text+="Request.UrlReferrer.PathAndQuery: \""+Request.UrlReferrer.PathAndQuery+"\"<br>";
				ParagraphRequest.Text+="Request.UrlReferrer.Query: \""+Request.UrlReferrer.Query+"\"<br>";
				ParagraphRequest.Text+="Request.UrlReferrer.Scheme: \""+Request.UrlReferrer.Scheme+"\"<br>";
				array1=Request.UrlReferrer.Segments;
				for(i=0; i<array1.Length; ++i)
					ParagraphRequest.Text+="Request.UrlReferrer.Segments ["+Convert.ToString(i)+"]="+array1[i]+"<br>";
				ParagraphRequest.Text+="Request.UrlReferrer.UserEscaped: \""+Request.UrlReferrer.UserEscaped.ToString()+"\"<br>";
				ParagraphRequest.Text+="Request.UrlReferrer.UserInfo: \""+Request.UrlReferrer.UserInfo+"\"<br>";
			}

			ParagraphRequest.Text+="<br>";
			ParagraphRequest.Text+="Request.UserAgent: \""+Request.UserAgent+"\"<br>";
			ParagraphRequest.Text+="Request.UserHostAddress: \""+Request.UserHostAddress+"\"<br>";
			ParagraphRequest.Text+="Request.UserHostName: \""+Request.UserHostName+"\"<br>";

			ParagraphRequest.Text+="<br>";
			ParagraphRequest.Text+="Request.UserLanguages.Length: \""+Request.UserLanguages.Length+"\"<br>";
			array1=Request.UserLanguages;
			for(i=0; i<array1.Length; ++i)
				ParagraphRequest.Text+="User Language ["+Convert.ToString(i)+"]="+array1[i]+"<br>";
			ParagraphRequest.Text+="<br>";

			ParagraphRequest.Text+="IsPostBack="+IsPostBack.ToString().ToLower();

			Response.Write("Response.Write#2<br>");

			if(!IsPostBack)
			{
				
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
