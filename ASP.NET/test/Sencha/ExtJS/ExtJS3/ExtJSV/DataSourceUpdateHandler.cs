using System;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.SessionState;
using Jayrock.Json;

namespace ExtJSV
{
	public class DataSourceUpdateHandler : IHttpHandler, IRequiresSessionState
	{
		public void ProcessRequest(HttpContext context)
		{
			DataTable
				tmpDataTable = DataSourceHandler.GetData(context);

			string
				Action=context.Request.Form["action"],
				Message = "Form"+Environment.NewLine;

			NameValueCollection
				coll = context.Request.Form;

			String[]
				arr1 = coll.AllKeys;
			
			for (int loop1 = 0; loop1 < arr1.Length; loop1++)
			{
				Message += "Key: " + context.Server.HtmlEncode(arr1[loop1]) + Environment.NewLine;

				String[]
					arr2 = coll.GetValues(arr1[loop1]);

				for (int loop2 = 0; loop2 < arr2.Length; loop2++)
				{
					Message += "Value " + loop2 + ": " + context.Server.HtmlEncode(arr2[loop2]) + Environment.NewLine;
				}
			}

			DataRow
				tmpDataRow;

			switch (Action)
			{
				case "insert":
				{
					tmpDataRow = tmpDataTable.NewRow();
					tmpDataTable.Rows.Add(tmpDataRow);

					JsonObject
						tmpJsonObject = new JsonObject();

					tmpJsonObject.Accumulate("Id", tmpDataRow["Id"]);

					JsonTextWriter
						tmpJsonTextWriter = new JsonTextWriter(context.Response.Output);

					tmpJsonObject.Export(tmpJsonTextWriter);
					tmpJsonTextWriter.Flush();
					tmpJsonTextWriter.Close();

					break;
				}
				case "delete":
				{
					string[]
						Ids = context.Request.Form.GetValues("id");

					foreach (string Id in Ids)
					{
						if ((tmpDataRow = tmpDataTable.Rows.Find(Convert.ToInt64(Id))) != null)
							tmpDataRow.Delete();
					}

					break;
				}
				case "update":
				{
					string[]
						Ids = context.Request.Form.GetValues("id"),
						FieldNames=context.Request.Form.GetValues("field"),
						Values = context.Request.Form.GetValues("value");

					for (int i = 0; i < Values.Length; ++i)
					{
						Values[i] = context.Server.HtmlEncode(Values[i]);
					}


					foreach (string Id in Ids)
					{
						if ((tmpDataRow = tmpDataTable.Rows.Find(Convert.ToInt64(Id))) != null)
							tmpDataRow[FieldNames[0]]=Values[0];
					}

					break;
				}
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
