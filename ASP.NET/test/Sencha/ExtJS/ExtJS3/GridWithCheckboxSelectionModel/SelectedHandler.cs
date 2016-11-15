using System;
using System.Collections.Generic;
using System.Web;
using Jayrock.Json;

namespace GridWithCheckboxSelectionModel
{
	public class SelectedHandler : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			context.Response.CacheControl = "no-cache";
			context.Response.Expires = -1;
			context.Response.ContentType = "application/json";

			JsonObject
				JsonObject = null;

			JsonArray
				JsonArray = null;

			string
				xaction = context.Request.Form["xaction"];

			if (xaction != null)
				xaction = xaction.Trim().ToLower();
			else
				xaction = string.Empty;

			try
			{
				switch (xaction)
				{
					case "read":
					{
						JsonArray = new JsonArray(new int[] { 1, 3, 5 });

						break;
					}
					case "update":
					{
						string[]
							selectedArray = context.Request.Form.GetValues("selected"),
							_selectedArray_;

						string
							selectedStr = context.Request.Form["selected"];

						_selectedArray_ = selectedStr.Split(new char[] { ',' });

						List<int>
							SelectedList = new List<int>();

						for(int i=0; i<selectedArray.Length; ++i)
						{
							int
								tmpInt;

							if (int.TryParse(selectedArray[i], out tmpInt))
								SelectedList.Add(tmpInt);
						}

						JsonObject = new JsonObject(new Dictionary<string, object> { { "success", true } });

						break;
					}
					default:
					{
						throw new Exception("Unknown xaction: \"" + xaction + "\"");
					}
				}
			}
			catch (Exception eException)
			{
				JsonObject = new JsonObject(new Dictionary<string, object> { { "success", false }, { "message", eException.Message } });
			}

			JsonTextWriter
				tmpJsonTextWriter = new JsonTextWriter(context.Response.Output);

			if (JsonArray != null)
				JsonArray.Export(tmpJsonTextWriter);
			else if (JsonObject != null)
				JsonObject.Export(tmpJsonTextWriter);

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
