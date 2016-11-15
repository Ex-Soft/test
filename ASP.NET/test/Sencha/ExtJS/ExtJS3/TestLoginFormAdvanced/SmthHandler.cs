using System.Collections.Generic;
using System.Web;

using Jayrock.Json;

namespace TestLoginFormAdvanced
{
	public class SmthHandler : Worker, IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			DoIt(context);
		}

		public bool IsReusable
		{
			get
			{
				return false;
			}
		}

		public override void ToDo(HttpContext context)
		{
			WriteToResponse(new JsonObject(new Dictionary<string, object> {
				{"success", true }
			}), context);
		}
	}
}
