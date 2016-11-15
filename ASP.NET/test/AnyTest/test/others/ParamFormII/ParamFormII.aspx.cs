using System;

namespace AnyTest
{
    public partial class ParamFormII : System.Web.UI.Page
    {
        protected bool
            tmpBool = true;

        protected string
            tmpString = string.Empty;

        protected string tmpStringII
        {
            get
            {
                return string.Empty;
            }
        }

        protected bool tmpBoolII
        {
            get
            {
                return true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
			DataBind(); // !!! specially 4 <%# %> !!!

            if (!IsPostBack)
            {
                LabelURIInfo.Text += Server.MapPath(null) + "\"<br/>";
                LabelURIInfo.Text += Server.MapPath("~") + "\"<br/>";
                LabelURIInfo.Text += "ApplicationPath=\"" + Request.ApplicationPath + "\"<br/>";
                LabelURIInfo.Text += "AppRelativeCurrentExecutionFilePath=\"" + Request.AppRelativeCurrentExecutionFilePath + "\"<br/>";
                LabelURIInfo.Text += "CurrentExecutionFilePath=\"" + Request.CurrentExecutionFilePath + "\"<br/>";
                LabelURIInfo.Text += "FilePath=\"" + Request.FilePath + "\"<br/>";
                LabelURIInfo.Text += "Path=\"" + Request.Path + "\"<br/>";
                LabelURIInfo.Text += "PathInfo=\"" + Request.PathInfo + "\"<br/>";
                LabelURIInfo.Text += "PhysicalApplicationPath=\"" + Request.PhysicalApplicationPath + "\"<br/>";
                LabelURIInfo.Text += "PhysicalPath=\"" + Request.PhysicalPath + "\"<br/>";
                LabelURIInfo.Text += "QueryString=\"" + Request.QueryString + "\"<br/>";
                LabelURIInfo.Text += "RawUrl=\"" + Request.RawUrl + "\"<br/>";
                LabelURIInfo.Text += "Url.AbsolutePath=\"" + Request.Url.AbsolutePath + "\"<br/>";
                LabelURIInfo.Text += "Url.AbsoluteUri=\"" + Request.Url.AbsoluteUri + "\"<br/>";
                LabelURIInfo.Text += "Url.Authority=\"" + Request.Url.Authority + "\"<br/>";
                LabelURIInfo.Text += "Url.DnsSafeHost=\"" + Request.Url.DnsSafeHost + "\"<br/>";
                LabelURIInfo.Text += "Url.Fragment=\"" + Request.Url.Fragment + "\"<br/>";
                LabelURIInfo.Text += "Url.Host=\"" + Request.Url.Host + "\"<br/>";
                LabelURIInfo.Text += "Url.HostNameType=\"" + Request.Url.HostNameType + "\"<br/>";
                LabelURIInfo.Text += "Url.LocalPath=\"" + Request.Url.LocalPath + "\"<br/>";
                LabelURIInfo.Text += "Url.OriginalString=\"" + Request.Url.OriginalString + "\"<br/>";
                LabelURIInfo.Text += "Url.PathAndQuery=\"" + Request.Url.PathAndQuery + "\"<br/>";
                LabelURIInfo.Text += "Url.Port=\"" + Request.Url.Port + "\"<br/>";
                LabelURIInfo.Text += "Url.Query=\"" + Request.Url.Query + "\"<br/>";
                LabelURIInfo.Text += "Url.Scheme=\"" + Request.Url.Scheme + "\"<br/>";

                string[]
                    StringArray = Request.Url.Segments;

                for (int i = 0; i < StringArray.Length; ++i)
                    LabelURIInfo.Text += "Url.Segments[" + i + "]=\"" + StringArray[i] + "\"<br/>";

                LabelURIInfo.Text += "Url.UserEscaped=\"" + Request.Url.UserEscaped + "\"<br/>";
                LabelURIInfo.Text += "Url.UserInfo=\"" + Request.Url.UserInfo + "\"<br/>";

                Uri
                    tmpUri = new Uri("http://www.contoso.com/title/index.htm?param1key=param1keyvalue&param2key=param2keyvalue&param3key=param3keyvalue");

                StringArray = tmpUri.Segments;
                LabelURIInfo.Text += "<hr/>";
                for (int i = 0; i < StringArray.Length; ++i)
                    LabelURIInfo.Text += "Url.Segments[" + i + "]=\"" + StringArray[i] + "\"<br/>";


                StringArray = Request.Headers.AllKeys;
                LabelURIInfo.Text += "<hr/>";
                foreach (string s in StringArray)
                    LabelURIInfo.Text += "Request.Headers[" + s + "]=\"" + Request.Headers[s] + "\"<br/>";

            }
        }
    }
}
