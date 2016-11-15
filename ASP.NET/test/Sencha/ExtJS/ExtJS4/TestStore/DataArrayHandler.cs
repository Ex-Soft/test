using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.SessionState;
using Jayrock.Json;

namespace TestStore
{
    public class DataArrayHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Clear();
            context.Response.ClearHeaders();
            context.Response.ClearContent();
            context.Response.CacheControl = "no-cache";
            context.Response.Expires = -1;
            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.Charset = "utf=8";
            context.Response.ContentEncoding = Encoding.UTF8;

            JsonObject
                jsonRootObject = new JsonObject(new Dictionary<string, object>
                                                    {
                                                        { "success", true},
                                                        { "data", new JsonObject(new Dictionary<string, object>
                                                                                     {
                                                                                         { "fieldList", "id, name"},
                                                                                         { "data", new JsonArray(new JsonArray[] {
                                                                                             new JsonArray(new object[] { "Record# 1", 1}),
                                                                                             new JsonArray(new object[] { "Record# 2", 2}),
                                                                                             new JsonArray(new object[] { "Record# 3", 3}),
                                                                                             new JsonArray(new object[] { "Record# 4", 4})
                                                                                         }) }
                                                                                     }) }
                                                    });

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