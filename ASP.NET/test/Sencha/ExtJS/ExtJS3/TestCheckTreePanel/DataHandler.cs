using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Web;
using Jayrock.Json;

namespace TestCheckTreePanel
{
	public class DataHandler : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			context.Response.CacheControl = "no-cache";
			context.Response.Expires = -1;
			context.Response.ContentType = "application/json";

			string
				cmd = context.Request.Form["cmd"];

			if (cmd != null)
				cmd = cmd.Trim().ToLower();
			else
				cmd = string.Empty;

			JsonObject
				JsonObject = null;

			JsonArray
				JsonArray = null;

			if (cmd == "load")
			{
				ulong
					RootId = 0UL;

				JsonObject
					tmpJsonObject = new JsonObject(new Dictionary<string, object> { { "id", RootId }, { "nodeID", RootId }, { "pnodeID", RootId }, { "text", "Select All" }, { "expanded", true } });

				JsonArray
					Children;

				tmpJsonObject.Accumulate("leaf", (Children = GetChildren(GetTree(), null, 1)) == null);
				if (Children != null)
				{
					for (int i = 0; i < Children.Count; ++i)
						((JsonObject)Children[i])["pnodeID"] = RootId;

					tmpJsonObject.Accumulate("children", Children);
				}

				JsonArray = new JsonArray(new JsonObject[] { tmpJsonObject });
			}

			JsonTextWriter
				tmpJsonTextWriter = new JsonTextWriter(context.Response.Output);


			if (JsonObject != null)
				JsonObject.Export(tmpJsonTextWriter);
			if (JsonArray != null)
				JsonArray.Export(tmpJsonTextWriter);

			tmpJsonTextWriter.Flush();
			tmpJsonTextWriter.Close();
		}

		JsonArray GetChildren(DataTable dt, ulong? ParentId, uint Level)
		{
			JsonArray
				JsonArray = null;

			DataRow[]
				DataRows = dt.Select((ParentId.HasValue ? "(PARENTID=" + ParentId.Value + ")" : "(PARENTID is null)") + " and (L=" + Level + ")");

			if (DataRows.Length == 0)
				return JsonArray;

			JsonArray = new JsonArray();

			foreach (DataRow row in DataRows)
			{
				ulong
					Id = Convert.ToUInt64(row["ID"]);

				JsonObject
					JsonObject = new JsonObject(new Dictionary<string, object> { { "id", Id }, { "nodeId", Id }, { "pnodeID", ParentId.HasValue ? (object)ParentId.Value : null }, { "text", row["VAL"] } });

				if (Id == 8)
					JsonObject.Accumulate("checked", true);

				JsonArray
					Children;

				JsonObject.Accumulate("leaf", (Children = GetChildren(dt, Id, Level + 1)) == null);
				if (Children != null)
					JsonObject.Accumulate("children", Children);

				JsonArray.Add(JsonObject);
			}

			return JsonArray;
		}

		string GetConnectionString()
		{
			string
				KeyName = "OracleConnectionStringName",
				KeyValue,
				ConnectionString;

			if (string.IsNullOrEmpty(KeyValue = ConfigurationManager.AppSettings[KeyName]))
				throw (new Exception("Can't find \"" + KeyName + "\""));

			if (ConfigurationManager.ConnectionStrings[KeyValue] == null || string.IsNullOrEmpty(ConnectionString = ConfigurationManager.ConnectionStrings[KeyValue].ConnectionString))
				throw (new Exception("Can't find \"" + KeyValue + "\""));

			return ConnectionString;
		}

		DataTable GetTree()
		{
			DataTable
				tmpDataTable = new DataTable();

			using (OracleDataAdapter da = new OracleDataAdapter(@"
select
  t.id,
  t.parentid,
  t.val,
  level as l
from
  TableWithHierarchy t
start with
  t.parentid is null
connect by
  prior t.id=t.parentid
", GetConnectionString()))
			{
				da.Fill(tmpDataTable);
			}

			return tmpDataTable;
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
