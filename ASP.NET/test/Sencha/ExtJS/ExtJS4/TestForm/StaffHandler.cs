using System.Collections.Generic;
using System.Text;
using System.Web;
using Jayrock.Json;

namespace TestForm
{
    public class StaffHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            JsonObject
                jsonRootObject =  new JsonObject(new Dictionary<string, object>
                                                    {
                                                        { "success", true },
                                                        { "total", 3 },
                                                        { "rows", new JsonArray(new JsonObject[] {
                                                            new JsonObject(new Dictionary<string, object> { { "id", 1 }, { "name", "Record# 1" } }),
                                                            new JsonObject(new Dictionary<string, object> { { "id", 2 }, { "name", "Record# 2" } }),
                                                            new JsonObject(new Dictionary<string, object> { { "id", 3 }, { "name", "Record# 3" } })
                                                        })}
                                                    });

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