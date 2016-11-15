using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using Jayrock.Json;

namespace TestCookies
{
    public class DataHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
			context.Response.CacheControl = "no-cache";
			context.Response.Expires = -1;
			context.Response.ContentType = "application/json";

			string
				startStr = context.Request.Form["start"],
				limitStr = context.Request.Form["limit"];

			int
				start = 0,
				limit = int.MaxValue;

			if (!int.TryParse(startStr, out start))
				start = 0;

			if (!int.TryParse(limitStr, out limit))
				limit = int.MaxValue;

			JsonObject
				RootJsonObject = null;

			try
			{
				RootJsonObject = GetData(start, limit);
			}
			catch (Exception eException)
			{
				RootJsonObject = new JsonObject(new Dictionary<string, object> { { "success", false }, { "message", eException.Message } });
			}

			JsonTextWriter
				tmpJsonTextWriter = new JsonTextWriter(context.Response.Output);

			RootJsonObject.Export(tmpJsonTextWriter);
			tmpJsonTextWriter.Flush();
			tmpJsonTextWriter.Close();
        }

		string GetConnectionString()
		{
			string
				KeyName = "MSSQLConnectionStringName",
				KeyValue,
				ConnectionString;

			if (string.IsNullOrEmpty(KeyValue = ConfigurationManager.AppSettings[KeyName]))
				throw (new Exception("Can't find \"" + KeyName + "\""));

			if (ConfigurationManager.ConnectionStrings[KeyValue]==null || string.IsNullOrEmpty(ConnectionString = ConfigurationManager.ConnectionStrings[KeyValue].ConnectionString))
				throw (new Exception("Can't find \"" + KeyValue + "\""));

			return ConnectionString;
		}

		int GetCount()
		{
			int
				Count = 0;

			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				conn.Open();

				SqlCommand
					cmd = conn.CreateCommand();

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "select count(*) from Staff";

				object
					tmpObject;

				if ((tmpObject = cmd.ExecuteScalar()) != null && !Convert.IsDBNull(tmpObject))
					Count = (int)tmpObject;
			}

			return Count;
		}

		JsonObject GetData(int start, int limit)
		{
			JsonObject
				tmpJsonObject = new JsonObject();

			JsonArray
				tmpJsonArray = new JsonArray();

			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				conn.Open();

				SqlCommand
					cmd = conn.CreateCommand();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetStaffPage";
				SqlCommandBuilder.DeriveParameters(cmd);
				cmd.Parameters["@start"].Value = start;
				cmd.Parameters["@limit"].Value = limit;

				using (SqlDataReader r = cmd.ExecuteReader())
				{
					if (r.HasRows)
					{
						int
							idx = r.GetOrdinal("BirthDate");

						while (r.Read())
							tmpJsonArray.Add(new JsonObject(new Dictionary<string, object> { { "Id", r["Id"] }, { "Name", r["Name"] }, { "Salary", r["Salary"] }, { "Dep", r["Dep"] }, { "BirthDate", r["BirthDate"] } }));
					}
				}
			}

			tmpJsonObject.Accumulate("success", true);
			tmpJsonObject.Accumulate("count", GetCount());
			tmpJsonObject.Accumulate("rows", tmpJsonArray);

			return tmpJsonObject;
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
