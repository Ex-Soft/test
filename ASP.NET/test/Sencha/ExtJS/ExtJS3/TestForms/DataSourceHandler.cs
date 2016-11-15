using System;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Web;
using Jayrock.Json;

namespace TestForms
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

			RootJsonObject = DataTableToJson(GetData(query));

			RootJsonObject.Export(tmpJsonTextWriter);
			tmpJsonTextWriter.Flush();
			tmpJsonTextWriter.Close();
		}

		public static DataTable GetData(string query)
		{
			DataTable
				tmpDataTable = new DataTable();

			string
				ConnectionString,
				KeyName = "OracleConnectionStringName",
				KeyValue;

			if (string.IsNullOrEmpty(KeyValue = ConfigurationManager.AppSettings[KeyName]))
				throw (new Exception("Can't find \"" + KeyName + "\""));

			if (string.IsNullOrEmpty(ConnectionString = ConfigurationManager.ConnectionStrings[KeyValue].ConnectionString))
				throw (new Exception("Can't find \"" + KeyValue + "\""));

			using (OracleConnection Connection = new OracleConnection(ConnectionString))
			{
				Connection.Open();

				OracleCommand
					Command = Connection.CreateCommand();

				Command.CommandType = CommandType.Text;
				if (!string.IsNullOrEmpty(query))
				{
					Command.CommandText = "select k_id as id, k_name as val from typhoon.tbl_kontragents where k_name like :q order by k_name";
					Command.Parameters.Add("q", OracleType.NVarChar).Value = query + "%";
				}
				else
					Command.CommandText = "select k_id as id, k_name as val from typhoon.tbl_kontragents order by k_name";

				OracleDataAdapter
					da = new OracleDataAdapter(Command);

				da.Fill(tmpDataTable);
			}

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

		void UpdateRow(JsonObject tmpJsonObject, string IdProperty, DataTable tmpDataTable)
		{
			DataRow
				tmpDataRow;

			if ((tmpDataRow = tmpDataTable.Rows.Find(Convert.ToInt64(tmpJsonObject[IdProperty]))) == null)
				return;

			foreach (string Name in tmpJsonObject.Names)
			{
				if (Name == IdProperty)
					continue;

				tmpDataRow[Name] = tmpJsonObject[Name];
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
