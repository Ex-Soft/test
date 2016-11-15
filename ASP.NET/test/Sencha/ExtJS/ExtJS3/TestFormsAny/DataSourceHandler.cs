using System.Data;
using System.Web;
using Jayrock.Json;

namespace TestFormsAny
{
	public class DataSourceHandler : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			string
				query = context.Request.Form["query"];

			context.Response.CacheControl = "no-cache";
			context.Response.Expires = -1;
			context.Response.ContentType = "application/json";

			JsonObject
				RootJsonObject = null;

			JsonTextWriter
				tmpJsonTextWriter = new JsonTextWriter(context.Response.Output);

			RootJsonObject = DataTableToJson(GetData());

			RootJsonObject.Export(tmpJsonTextWriter);
			tmpJsonTextWriter.Flush();
			tmpJsonTextWriter.Close();
		}

		public static DataTable GetData()
		{
			DataTable
				tmpDataTable = new DataTable();

			tmpDataTable.Columns.Add("ID",typeof(int));
			tmpDataTable.Columns.Add("VAL", typeof(string));

			DataRow
				tmpDataRow;

			tmpDataRow = tmpDataTable.NewRow();
			tmpDataRow["ID"] = 1;
			tmpDataRow["VAL"] = "#1";
			tmpDataTable.Rows.Add(tmpDataRow);

			tmpDataRow = tmpDataTable.NewRow();
			tmpDataRow["ID"] = 2;
			tmpDataRow["VAL"] = "#2";
			tmpDataTable.Rows.Add(tmpDataRow);

			tmpDataRow = tmpDataTable.NewRow();
			tmpDataRow["ID"] = 3;
			tmpDataRow["VAL"] = "#3";
			tmpDataTable.Rows.Add(tmpDataRow);

			return tmpDataTable;
		}

		JsonObject DataTableToJson(DataTable tmpDataTable)
		{
			JsonObject
				RootJsonObject = new JsonObject();

			JsonArray
				tmpJsonArray = new JsonArray();

			DataRow
				tmpDataRow;

			for (int i = 0; i < tmpDataTable.Rows.Count; ++i)
			{
				tmpDataRow = tmpDataTable.Rows[i];

				JsonObject
					tmpJsonObject = new JsonObject();

				foreach (DataColumn c in tmpDataTable.Columns)
					tmpJsonObject.Accumulate(c.ColumnName, !tmpDataRow.IsNull(c.ColumnName) ? tmpDataRow[c.ColumnName] : null);

				tmpJsonArray.Add(tmpJsonObject);
			}

			RootJsonObject.Accumulate("success", true);
			RootJsonObject.Accumulate("count", tmpDataTable.Rows.Count);
			RootJsonObject.Accumulate("rows", tmpJsonArray);

			return RootJsonObject;
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
