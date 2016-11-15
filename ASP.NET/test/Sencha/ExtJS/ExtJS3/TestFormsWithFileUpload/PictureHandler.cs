using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;
using Jayrock.Json;

namespace TestFormsWithFileUpload
{
	public class PictureHandler : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
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
				Act,
				Id = context.Request.Form["id"],
				FileName=string.Empty;

			switch (Act = context.Request.Form["act"])
			{
				case "getPicture" :
				{
					FileName = "./img/27265.gif";

					//context.Response.ContentType = "text/html";
					context.Response.ContentType = "application/json";

					JsonObject
						RootJsonObject = new JsonObject(new Dictionary<string, object> { { "success", true }, { "data", new Dictionary<string, object> { { "contactId", "contact id" }, { "file", FileName } } } });

					JsonTextWriter
						tmpJsonTextWriter = new JsonTextWriter(context.Response.Output);

					RootJsonObject.Export(tmpJsonTextWriter);
					tmpJsonTextWriter.Flush();
					tmpJsonTextWriter.Close();

					break;
				}
				case "setPicture" :
				{
					if (context.Request.Files.Count != 0)
					{
                        string
                            DestDir;

                        if (!Directory.Exists(DestDir = context.Server.MapPath(null) + Path.DirectorySeparatorChar + "download"))
                            Directory.CreateDirectory(DestDir);

						if (File.Exists(FileName = DestDir + Path.DirectorySeparatorChar + Path.GetFileName(context.Request.Files[0].FileName)))
							File.Delete(FileName);

						byte[]
							Img = new byte[context.Request.Files[0].ContentLength];

						context.Request.Files[0].InputStream.Read(Img, 0, Img.Length);

						FileStream
							fs = new FileStream(FileName, FileMode.Create);

						fs.Write(Img, 0, Img.Length);
						fs.Close();

						FileName = "./download/" + Path.GetFileName(context.Request.Files[0].FileName);

						context.Response.ContentType = "text/html";
						context.Response.Write("<html><body><textarea>{ \"success\": \"true\", \"data\": { \"contactId\": \"contact id\", \"file\": \""+FileName+"\" } }</textarea></body></html>");
						context.Response.Flush();
					}

					break;
				}
				default :
				{
					throw(new Exception("Unknown act=\""+Act+"\""));
				}
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
