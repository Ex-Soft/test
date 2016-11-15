using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.Script.Serialization;

namespace TestExtAjaxClass
{
    public class SmthHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Request.InputStream.Seek(0, SeekOrigin.Begin);
            var streamReader = new StreamReader(context.Request.InputStream, Encoding.UTF8);
            string request = streamReader.ReadToEnd().Trim();
            bool async;
            string sleepStr;
            int sleep = 0;

            bool.TryParse(context.Request.Params["async"], out async);
            if (!string.IsNullOrWhiteSpace(sleepStr = context.Request.Params["sleep"]))
                int.TryParse(sleepStr, out sleep);

            Show(context.Request.QueryString);
            Show(context.Request.Form);
            Show(context.Request.Params);

            if(!async)
                System.Threading.Thread.Sleep(sleep);

            var javaScriptSerializer = new JavaScriptSerializer();
            string response = javaScriptSerializer.Serialize(new SmthHandlerResponse { success = true });

            context.Response.Clear();
            context.Response.ClearHeaders();
            context.Response.ClearContent();
            context.Response.CacheControl = "no-cache";
            context.Response.Expires = -1;
            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.Charset = "utf=8";
            context.Response.ContentEncoding = Encoding.UTF8;
            byte[] bytes = context.Response.ContentEncoding.GetBytes(response);
            context.Response.AddHeader("Content-Length", bytes.Length.ToString());
            context.Response.Write(response);
            context.Response.Flush();
            context.Response.Close();
            context.Response.End();
        }

        public bool IsReusable
        {
            get { return false; }
        }

        void Show(NameValueCollection coll)
        {
            string
                tmpString;

            string[]
                arr1 = coll.AllKeys,
                arr2;

            int
                loop1,
                loop2;

            for (loop1 = 0; loop1 < arr1.Length; ++loop1)
            {
                tmpString = HttpUtility.HtmlEncode(arr1[loop1]);
                arr2 = coll.GetValues(arr1[loop1]);
                if (arr2 != null)
                    for (loop2 = 0; loop2 < arr2.Length; ++loop2)
                        tmpString = HttpUtility.HtmlEncode(arr2[loop2]);
            }
        }
    }
}