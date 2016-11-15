using System;
using System.Data;
using System.Web;
using System.Web.SessionState;
using Jayrock.Json;

namespace ExtJSV
{
	public class DataSourceHandler : IHttpHandler, IRequiresSessionState
	{
		const string
			DataTableSessionSignature = "DataTable";

		public void ProcessRequest(HttpContext context)
		{
			context.Response.CacheControl = "no-cache";
			context.Response.AppendHeader("Pragma", "no-cache");
			context.Response.Expires = -1;
			context.Response.ContentType = "application/json";

			JsonObject
				RootJsonObject = DataTableToJson(GetData(context));

			JsonTextWriter
				tmpJsonTextWriter = new JsonTextWriter(context.Response.Output);

			RootJsonObject.Export(tmpJsonTextWriter);
			tmpJsonTextWriter.Flush();
			tmpJsonTextWriter.Close();
		}

		public static DataTable GetData(HttpContext context)
		{
			DataTable
				tmpDataTable;

			if ((tmpDataTable = (DataTable)context.Session[DataTableSessionSignature]) == null)
			{
				context.Session[DataTableSessionSignature] = tmpDataTable = new DataTable();

				DataColumn
					tmpDataColumn;

				tmpDataColumn = tmpDataTable.Columns.Add("Id", typeof(long));
				tmpDataColumn.AllowDBNull = false;
				tmpDataColumn.Unique = true;
				tmpDataColumn.AutoIncrement = true;
				tmpDataColumn.AutoIncrementSeed = -1;
				tmpDataColumn.AutoIncrementStep = -1;
				tmpDataTable.Columns.Add("Name", typeof(string));
				tmpDataTable.Columns.Add("Salary", typeof(decimal));
				//tmpDataTable.Columns.Add("BirthDate", typeof(DateTime));
				tmpDataTable.PrimaryKey = new DataColumn[] { tmpDataTable.Columns["Id"] };

				DataRow
					tmpDataRow;

				tmpDataRow = tmpDataTable.NewRow();
				tmpDataRow["Name"] = "Ленин Владимир Ильич";
				tmpDataRow["Salary"] = 100;
				//tmpDataRow["BirthDate"] = new DateTime(1870, 4, 22);
				tmpDataTable.Rows.Add(tmpDataRow);

				tmpDataRow = tmpDataTable.NewRow();
				tmpDataRow["Name"] = "Сталин Иосиф Виссарионович";
				tmpDataRow["Salary"] = 1000;
				//tmpDataRow["BirthDate"] = new DateTime(1878, 12, 18);
				tmpDataTable.Rows.Add(tmpDataRow);

				tmpDataRow = tmpDataTable.NewRow();
				tmpDataRow["Name"] = "Хрущев Никита Сергеевич";
				tmpDataRow["Salary"] = 100;
				//tmpDataRow["BirthDate"] = new DateTime(1894, 4, 17);
				tmpDataTable.Rows.Add(tmpDataRow);
			}

			return tmpDataTable;
		}

		JsonObject DataTableToJson(DataTable tmpDataTable)
		{
			JsonObject
				RootJsonObject = new JsonObject();

			JsonArray
				tmpJsonArray=new JsonArray();

			foreach (DataRow r in tmpDataTable.Rows)
			{
				JsonObject
					tmpJsonObject = new JsonObject();

				foreach (DataColumn c in tmpDataTable.Columns)
					tmpJsonObject.Accumulate(c.ColumnName, !r.IsNull(c.ColumnName) ? r[c.ColumnName] : null);

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
