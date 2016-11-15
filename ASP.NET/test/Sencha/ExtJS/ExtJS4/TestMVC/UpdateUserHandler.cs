using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace TestMVC
{
    public class UpdateUserHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string
                tmpString = context.Request.GetJSON();

            JavaScriptSerializer
                javaScriptSerializer = new JavaScriptSerializer();

            User
                user = javaScriptSerializer.Deserialize<User>(tmpString);

            context.Response.Clear();
            context.Response.ClearHeaders();
            context.Response.ClearContent();
            context.Response.CacheControl = "no-cache";
            context.Response.Expires = -1;
            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.Charset="utf=8";
            context.Response.ContentEncoding = Encoding.UTF8;

            StoreResponse
                storeResponse = new StoreResponse() { success = true, message = "Message", users = new User[] { new User() { id = 1, email = "email (from Update)", name = "name (from Update)" } } };

            tmpString = javaScriptSerializer.Serialize(storeResponse);

            byte[]
                byteArray = Encoding.UTF8.GetBytes(tmpString);

            //context.Response.OutputStream.Write(byteArray, 0, byteArray.Length);
            //context.Response.Write(storeResponse); // TestMVC.StoreResponse
            context.Response.Write(tmpString);

            context.Response.Flush();
            context.Response.Close();
            context.Response.End();
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