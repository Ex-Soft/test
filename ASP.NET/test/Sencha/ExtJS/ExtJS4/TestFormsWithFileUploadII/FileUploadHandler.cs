using System.Collections.Specialized;
using System.Text;
using System.Web;
using System.IO;

namespace TestFormsWithFileUploadII
{
	public class FileUploadHandler : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
            System.Threading.Thread.Sleep(5000);

            string
                tmpString;

            context.Request.InputStream.Seek(0, SeekOrigin.Begin);
            var streamReader = new StreamReader(context.Request.InputStream, Encoding.UTF8);
            tmpString = streamReader.ReadToEnd().Trim();

			context.Response.CacheControl = "no-cache";
			context.Response.Expires = -1;

			NameObjectCollectionBase.KeysCollection
				keys = context.Request.Form.Keys;

		    tmpString = string.Empty;

			foreach (string key in keys)
			{
				if (tmpString != string.Empty)
					tmpString += ", ";
				tmpString += "Form[\"" + key + "\"]=\"" + context.Request.Form[key] + "\"";
			}

			string
				id = context.Request.Form["id"],
				fileName=string.Empty;

			if (context.Request.Files.Count != 0)
			{
				string
					destDir;

                if (!Directory.Exists(destDir = context.Server.MapPath(null) + Path.DirectorySeparatorChar + "download"))
                    Directory.CreateDirectory(destDir);

				if (File.Exists(fileName = destDir + Path.DirectorySeparatorChar + Path.GetFileName(context.Request.Files[0].FileName)))
					File.Delete(fileName);

				byte[]
					file = new byte[context.Request.Files[0].ContentLength];

				context.Request.Files[0].InputStream.Read(file, 0, file.Length);

				FileStream
					fs = new FileStream(fileName, FileMode.Create);

				fs.Write(file, 0, file.Length);
				fs.Close();

				fileName = "./download/" + Path.GetFileName(context.Request.Files[0].FileName);

				context.Response.ContentType = "text/html";
				context.Response.Write("<html><body><textarea>{ \"success\": \"true\", \"data\": { \"contactId\": \"contact id\", \"file\": \""+fileName+"\" } }</textarea></body></html>");
				context.Response.Flush();
			}
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
