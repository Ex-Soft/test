using System.Collections.Generic;
using System.Text;
using System.Web;
using Jayrock.Json;

namespace TestForm
{
    public class Form1Handler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string
                xaction;

            JsonObject
                jsonRootObject = null;

            switch(xaction = !string.IsNullOrWhiteSpace(xaction = context.Request.Params["xaction"]) ? xaction.Trim().ToLower() : "load")
            {
                case "load":
                    {
                        jsonRootObject = new JsonObject(new Dictionary<string, object>
                                                    {
                                                        { "success", true },
                                                        { "data", new JsonObject(new Dictionary<string, object>
                                                                                     {
                                                                                         { "TextField", "TextField"}
                                                                                     }) }
                                                    });

                        break;
                    }
            }

            context.Response.Clear();
            context.Response.ClearHeaders();
            context.Response.ClearContent();
            context.Response.CacheControl = "no-cache";
            context.Response.Expires = -1;
            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.Charset = "utf=8";
            context.Response.ContentEncoding = Encoding.UTF8;

            JsonTextWriter
                tmpJsonTextWriter = new JsonTextWriter(context.Response.Output);

            jsonRootObject.Export(tmpJsonTextWriter);
            tmpJsonTextWriter.Flush();
            tmpJsonTextWriter.Close();
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}