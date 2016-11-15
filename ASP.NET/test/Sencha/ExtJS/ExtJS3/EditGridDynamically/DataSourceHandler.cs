using System;
using System.Data;
using System.Web;
using System.Web.SessionState;
using Jayrock.Json;
using Jayrock.Json.Conversion;

namespace EditGridDynamically
{
	public class DataSourceHandler : IHttpHandler, IRequiresSessionState
	{
		const string
			DataTableSessionSignature = "DataTable",
			IdPropertyName="Id";

		public void ProcessRequest(HttpContext context)
		{
			context.Response.CacheControl = "no-cache";
			context.Response.Expires = -1;
			context.Response.ContentType = "application/json";

			JsonObject
				RootJsonObject=null;

			string
				Action = context.Request.Form["xaction"];

			switch (Action)
			{
				case "read":
				{
					RootJsonObject = DataTableToJson(GetData(context));

					string
						firstStr = context.Request.Form["first"];

					if (!string.IsNullOrEmpty(firstStr) && firstStr.Trim().ToLower() == "true")
						RootJsonObject.Accumulate("metaData", GetMetaDataJson());

					break;
				}
				case "update":
				{
					DataTable
						tmpDataTable = GetData(context);

					object
						tmpObject=JsonConvert.Import(context.Request.Form["rows"]);

					if (tmpObject is JsonArray)
					{
						JsonArray
							tmpJsonArray = (JsonArray)tmpObject;

						for (int i = 0; i < tmpJsonArray.Count; ++i)
							UpdateRow((JsonObject)tmpJsonArray[i], IdPropertyName, tmpDataTable);
					}
					else if (tmpObject is JsonObject)
						UpdateRow((JsonObject)tmpObject, IdPropertyName, tmpDataTable);

					RootJsonObject = new JsonObject();
					RootJsonObject.Accumulate("success",true);
					RootJsonObject.Accumulate("message", "200OK");
					RootJsonObject.Accumulate("msg", "200OK");

					break;
				}
				default:
				{
					throw new Exception("Unknown \"xaction\"=\"" + Action + "\"");
				}
			}

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
				tmpDataTable.Columns.Add("BirthDate", typeof(DateTime));
				tmpDataTable.Columns.Add("Checked", typeof(bool));
				tmpDataTable.PrimaryKey = new DataColumn[] { tmpDataTable.Columns["Id"] };

				DataRow
					tmpDataRow;

				tmpDataRow = tmpDataTable.NewRow();
				tmpDataRow["Name"] = "Ленин Владимир Ильич";
				tmpDataRow["Salary"] = 100;
				tmpDataRow["BirthDate"] = new DateTime(1870, 4, 22);
				tmpDataRow["Checked"] = true;
				tmpDataTable.Rows.Add(tmpDataRow);

				tmpDataRow = tmpDataTable.NewRow();
				tmpDataRow["Name"] = "Сталин Иосиф Виссарионович";
				tmpDataRow["Salary"] = 1000;
				tmpDataRow["BirthDate"] = new DateTime(1878, 12, 18);
				tmpDataTable.Rows.Add(tmpDataRow);

				tmpDataRow = tmpDataTable.NewRow();
				tmpDataRow["Name"] = "Хрущев Никита Сергеевич";
				tmpDataRow["Salary"] = 100;
				tmpDataRow["BirthDate"] = new DateTime(1894, 4, 17);
				tmpDataTable.Rows.Add(tmpDataRow);

				tmpDataRow = tmpDataTable.NewRow();
				tmpDataRow["Name"] = "Брежнев Леонид Ильич";
				tmpDataRow["Salary"] = 1000;
				tmpDataRow["BirthDate"] = new DateTime(1906, 12, 19);
				tmpDataTable.Rows.Add(tmpDataRow);

				tmpDataRow = tmpDataTable.NewRow();
				tmpDataRow["Name"] = "Андропов  Юрий Владимрович";
				tmpDataRow["Salary"] = 1000;
				tmpDataRow["BirthDate"] = new DateTime(1914, 6, 15);
				tmpDataTable.Rows.Add(tmpDataRow);

				tmpDataRow = tmpDataTable.NewRow();
				tmpDataRow["Name"] = "Черненко Константин Устинович";
				tmpDataRow["Salary"] = 1000;
				tmpDataRow["BirthDate"] = new DateTime(1911, 9, 24);
				tmpDataTable.Rows.Add(tmpDataRow);

				tmpDataRow = tmpDataTable.NewRow();
				tmpDataRow["Name"] = "Горбачёв Михаил Сергеевич";
				tmpDataRow["Salary"] = 1000;
				tmpDataRow["BirthDate"] = new DateTime(1931, 3, 2);
				tmpDataTable.Rows.Add(tmpDataRow);

				tmpDataRow = tmpDataTable.NewRow();
				tmpDataRow["Name"] = "Кравчук Леонид Макарович";
				tmpDataRow["Salary"] = 1000;
				tmpDataRow["BirthDate"] = new DateTime(1934, 1, 10);
				tmpDataTable.Rows.Add(tmpDataRow);

				tmpDataRow = tmpDataTable.NewRow();
				tmpDataRow["Name"] = "Кучма Леонид Данилович";
				tmpDataRow["Salary"] = 1000;
				tmpDataRow["BirthDate"] = new DateTime(1938, 8, 9);
				tmpDataTable.Rows.Add(tmpDataRow);

				tmpDataRow = tmpDataTable.NewRow();
				tmpDataRow["Name"] = "Ющенко Виктор Андреевич";
				tmpDataRow["Salary"] = 1000;
				tmpDataRow["BirthDate"] = new DateTime(1954, 2, 23);
				tmpDataTable.Rows.Add(tmpDataRow);

				tmpDataRow = tmpDataTable.NewRow();
				tmpDataRow["Name"] = "Янукович Виктор Федорович";
				tmpDataRow["Salary"] = 1000;
				tmpDataRow["BirthDate"] = new DateTime(1950, 7, 9);
				tmpDataTable.Rows.Add(tmpDataRow);
			}

			return tmpDataTable;
		}

		JsonObject GetMetaDataJson()
		{
			JsonObject
				MetaDataJsonObject = new JsonObject();

			JsonArray
				MetaDataJsonArray = new JsonArray();

			MetaDataJsonArray.Add(new JsonObject(new string[] { "name", "type" }, new object[] { "Id", "int" }));
			MetaDataJsonArray.Add(new JsonObject(new string[] { "name", "type" }, new object[] { "Name", "string" }));
			MetaDataJsonArray.Add(new JsonObject(new string[] { "name", "type" }, new object[] { "Salary", "float" }));
			MetaDataJsonArray.Add(new JsonObject(new string[] { "name", "type", "dateFormat" }, new object[] { "BirthDate", "date", "c" }));
			MetaDataJsonArray.Add(new JsonObject(new string[] { "name", "type" }, new object[] { "Checked", "boolean" }));
			MetaDataJsonObject.Accumulate("idProperty", "Id");
			MetaDataJsonObject.Accumulate("root", "rows");
			MetaDataJsonObject.Accumulate("totalProperty", "count");
			MetaDataJsonObject.Accumulate("successProperty", "success");
			MetaDataJsonObject.Accumulate("fields", MetaDataJsonArray);

			return MetaDataJsonObject;
		}

		JsonObject DataTableToJson(DataTable tmpDataTable)
		{
			JsonObject
				RootJsonObject = new JsonObject();

			JsonArray
				DataJsonArray=new JsonArray();
			
			DataRow
				tmpDataRow;

			for (int i=0; i < tmpDataTable.Rows.Count; ++i)
			{
				tmpDataRow = tmpDataTable.Rows[i];

				JsonObject
					tmpJsonObject = new JsonObject();

				foreach (DataColumn c in tmpDataTable.Columns)
					tmpJsonObject.Accumulate(c.ColumnName, !tmpDataRow.IsNull(c.ColumnName) ? tmpDataRow[c.ColumnName] : null);

				DataJsonArray.Add(tmpJsonObject);
			}

			RootJsonObject.Accumulate("success", true);
			RootJsonObject.Accumulate("count", tmpDataTable.Rows.Count);
			RootJsonObject.Accumulate("rows", DataJsonArray);

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
