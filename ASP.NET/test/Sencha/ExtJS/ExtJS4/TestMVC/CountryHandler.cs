using System.IO;
using System.Text;
using System.Web;
using System.Xml;

namespace TestMVC
{
    public class CountryHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Clear();
            context.Response.ClearHeaders();
            context.Response.ClearContent();
            context.Response.CacheControl = "no-cache";
            context.Response.Expires = -1;
            context.Response.ContentType = "text/xml; charset=utf-8";
            context.Response.Charset="utf=8";
            context.Response.ContentEncoding = Encoding.UTF8;

            System.Threading.Thread.Sleep(5000);

            var xml = new XmlDocument();
            xml.Load(context.Server.MapPath(null) + Path.DirectorySeparatorChar + "Country.xml");
            var writer = new XmlTextWriter(context.Response.OutputStream, context.Response.ContentEncoding);
            xml.WriteContentTo(writer);
            writer.Close();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}