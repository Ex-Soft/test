using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using Jayrock.Json;

namespace ExtJSI
{
	/// <summary>
	/// Summary description for $codebehindclassname$
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	public class HttpHandlerData : IHttpHandler, IReadOnlySessionState
	{

		public void ProcessRequest(HttpContext context)
		{
			string
				nodeStr = context.Request.Form["node"];

			context.Response.ContentType = "application/json";
			//context.Response.Write("[{\"text\" : \"Audi\", \"id\": 100, \"leaf\" : false, \"cls\" : \"folder\", \"children\" : [{\"text\" : \"A3\", \"id\": 1000, \"leaf\" : false, \"cls\" : \"folder\", \"children\" : [{\"text\" : \"Fuel Economy\", \"id\" : \"100000\", \"leaf\" : true, \"cls\" : \"file\"},{\"text\" : \"Invoice\", \"id\" : \"100001\", \"leaf\" : true, \"cls\" : \"file\"},{\"text\" : \"MSRP\", \"id\" : \"100002\", \"leaf\" : true, \"cls\" : \"file\"},{\"text\" : \"Options\", \"id\" : \"100003\", \"leaf\" : true, \"cls\" : \"file\"},{\"text\" : \"Specifications\", \"id\" : \"100004\", \"leaf\" : true, \"cls\" : \"file\"}]}]}, {\"text\" : \"BMW\", \"id\": 200, \"leaf\" : false, \"cls\" : \"folder\", \"children\" : []}]");

			int
				node=0;

			List<string>
				list = new List<string>();

			bool
				HasChild=false;

			if (Int32.TryParse(nodeStr, out node))
			{
				switch (node)
				{
					case 1:
					{
						list.Add("A3");
						list.Add("A4");
						list.Add("A6");
						list.Add("A8");

						HasChild = true;

						break;
					}
					case 2:
					{
						list.Add("M");
						list.Add("M3");
						list.Add("M5");
						list.Add("M6");

						HasChild = true;

						break;
					}
					default:
					{
						list.Add("Fuel Economy");
						list.Add("Invoice");
						list.Add("MSRP");
						list.Add("Options");
						list.Add("Specifications");

						break;
					}
				}
			}
			else
			{
				list.Add("Audi");
				list.Add("BMW");

				HasChild = true;
			}

			JsonArray
				tmpJsonArraj = new JsonArray();

			for(int i=0; i<list.Count; ++i)
			{
				JsonObject
					tmpJsonObject = new JsonObject();

				tmpJsonObject.Accumulate("id", node*10+i+1);
				tmpJsonObject.Accumulate("text", list[i]);
				tmpJsonObject.Accumulate("leaf", !HasChild);
				tmpJsonObject.Accumulate("cls", HasChild ? "folder" : "file");

				tmpJsonObject.Accumulate("checked", i == 1);

				tmpJsonArraj.Add(tmpJsonObject);
			}

			JsonTextWriter
				tmpJsonTextWriter = new JsonTextWriter(context.Response.Output);

			tmpJsonArraj.Export(tmpJsonTextWriter);

			context.Response.Flush();
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
