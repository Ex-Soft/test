using System;
using System.Web;

namespace TestGridSimple
{
    public class Handler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            /*context.Response.Clear();
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
            context.Response.End();*/
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}