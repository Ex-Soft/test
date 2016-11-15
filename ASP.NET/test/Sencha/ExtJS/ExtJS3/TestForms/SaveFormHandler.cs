using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Web;
using Jayrock.Json;

namespace TestForms
{
	public class SaveFormHandler : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			NameObjectCollectionBase.KeysCollection
				keys = context.Request.Form.Keys;

			string
				tmpString=string.Empty;

			foreach (string key in keys)
			{
				if (tmpString != string.Empty)
					tmpString += ", ";
				tmpString += "Form[\"" + key + "\"]=\"" + context.Request.Form[key] + "\"";
			}

			context.Response.CacheControl = "no-cache";
			context.Response.Expires = -1;
			context.Response.ContentType = "application/json";

			JsonObject
				RootJsonObject = new JsonObject(new Dictionary<string, object> { { "success", false }, { "errors", new JsonObject(new Dictionary<string, object> { { "title", "Sounds like a Chick Flick" } }) }, { "errormsg", "That movie title sounds like a chick flick." } });

			JsonTextWriter
				tmpJsonTextWriter = new JsonTextWriter(context.Response.Output);

			RootJsonObject.Export(tmpJsonTextWriter);
			tmpJsonTextWriter.Flush();
			tmpJsonTextWriter.Close();

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
