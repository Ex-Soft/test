using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Web;
using Jayrock.Json;

namespace TestForms
{
	public class LoadFormHandler : IHttpHandler
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

			/*
			JsonObject
				RootJsonObject = new JsonObject(new Dictionary<string, object> {
					{ "success", false },
					{ "errorMessage", "errorMessage" }
				});
			*/
			
			JsonObject
				RootJsonObject = new JsonObject(new Dictionary<string, object> { { "success", true },
				{ "data", new JsonObject(new Dictionary<string, object> {
					{ "HiddenField1", 123456 },
					{ "NumberField", "123456" },
					{ "TextField", "dleiFtxeT" },
					{ "DateField", "17.06.2010" },
					{ "TimeField", "13:00" },
					{ "DateTimeField", new DateTime(2010,06,17,13,0,13).ToString("o") },
					{ "Radio", "Radio2" },
					{ "CheckBox", "1"},
					{ "TextArea", "TextArea" },
					{ "HtmlEditor", "HtmlEditor" },
					//{ "ComboBox1", "778" },
					//{ "ComboBox1", 778 },
					{ "ComboBox1HN", "FOTO  ГРAЧИ УЛЕТЕЛИ" }, // 778 
					//{ "ComboBox2", "800" },
					{ "ComboBox2HN", "FOTO  ГРАЧИ БЕЗНАЛИЧНЫЕ" }, // 800
					{ "ComboBox3HN", "9" },
					//{ "ComboBox4HN", "11" }
					{ "ComboBox4", 11 }
				}) } });

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
