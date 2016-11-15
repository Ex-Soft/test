using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.IO;
using Jayrock.Json;

namespace TestForms
{
	public class DataSource2Handler : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			string
				query = context.Request.Form["query"],
				FileName=context.Server.MapPath(null)+Path.DirectorySeparatorChar+"log.log";

			lock (typeof(StreamWriter))
			{
				StreamWriter
					OutputFile = new StreamWriter(FileName, true, System.Text.Encoding.GetEncoding(1251));

				if (OutputFile != null && OutputFile.BaseStream != null && OutputFile.BaseStream.CanWrite)
				{
					if (!OutputFile.AutoFlush)
						OutputFile.AutoFlush = true;

					if (OutputFile.BaseStream.Position != 0)
						OutputFile.Write(System.Environment.NewLine);

					OutputFile.Write(System.DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fffffff tt") + '\t' + "DataSource2Handler");
				}

				if (OutputFile != null)
					OutputFile.Close();
			}

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
				KeyName = "MSSQLConnectionStringName",
				KeyValue;

			if (string.IsNullOrEmpty(KeyValue = ConfigurationManager.AppSettings[KeyName]))
				throw (new Exception("Can't find \"" + KeyName + "\""));

			if (string.IsNullOrEmpty(ConnectionString = ConfigurationManager.ConnectionStrings[KeyValue].ConnectionString))
				throw (new Exception("Can't find \"" + KeyValue + "\""));

			using (SqlConnection Connection = new SqlConnection(ConnectionString))
			{
				Connection.Open();

				SqlCommand
					Command = Connection.CreateCommand();

				Command.CommandType = CommandType.Text;
				Command.CommandText = "select STATUS_ID as ID, STATUS_NAME as VAL from tbl_status";

				SqlDataAdapter
					da = new SqlDataAdapter(Command);

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
