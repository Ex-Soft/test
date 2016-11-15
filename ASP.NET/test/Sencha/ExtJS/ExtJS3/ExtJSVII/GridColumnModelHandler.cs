using System.Web;
using System.Web.SessionState;
using Jayrock.Json;

namespace ExtJSVII
{
	public class GridColumnModelHandler : IHttpHandler, IReadOnlySessionState
	{
		public void ProcessRequest(HttpContext context)
		{
			context.Response.CacheControl = "no-cache";
			context.Response.Expires = -1;
			context.Response.ContentType = "application/json";

			JsonArray
				RootJsonArray=new JsonArray();

			RootJsonArray.Add(new JsonObject(new string[] { "dataIndex", "type", "header", "width", "sortable", "hidden" }, new object[] { "Id", "int", "ID", 30, true, true }));
			RootJsonArray.Add(new JsonObject(new string[] { "id", "dataIndex", "type", "header", "width", "sortable" }, new object[] { "ColNameAutoExpand", "Name", "string", "Name", 180, true }));
			RootJsonArray.Add(new JsonObject(new string[] { "id", "dataIndex", "type", "header", "width", "sortable", "align" }, new object[] { "ColSalaryEdit", "Salary", "float", "Salary", 75, true, "center" }));
			RootJsonArray.Add(new JsonObject(new string[] { "id", "dataIndex", "type", "header", "width", "sortable", "align" }, new object[] { "ColBirthDateEdit", "BirthDate", "date", "BirthDate", 100, true, "center" }));
			RootJsonArray.Add(new JsonObject(new string[] { "id", "dataIndex", "type", "header", "width", "sortable", "align" }, new object[] { "ColCheckedEdit", "Checked", "boolean", "Checked", 50, true, "center" }));

			JsonTextWriter
				tmpJsonTextWriter = new JsonTextWriter(context.Response.Output);

			RootJsonArray.Export(tmpJsonTextWriter);
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
