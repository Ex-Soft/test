using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace ExtJSBigApp.Classes
{
	public class Staffs
	{
		public static List<Staff> GetPagedStaffList(int start, int limit)
		{
			List<Staff>
				tmpList = new List<Staff>();

			string
				connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

			if (string.IsNullOrEmpty(connectionString))
				return tmpList;

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				con.Open();

				SqlCommand
					cmd = con.CreateCommand();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetStaffPage";
				SqlCommandBuilder.DeriveParameters(cmd);
				cmd.Parameters["@start"].Value = start+1;
				cmd.Parameters["@limit"].Value = limit;

				using (SqlDataReader r = cmd.ExecuteReader())
				{
					if (r != null)
						while (r.Read())
							tmpList.Add(new Staff(r));
				}
			}

			return tmpList;
		}

		public static int GetPagedStaffListCount()
		{
			int
				Count = 0;
			string
				connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

			if (string.IsNullOrEmpty(connectionString))
				return Count;

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				con.Open();

				SqlCommand
					cmd = con.CreateCommand();

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "select count(*) from Staff";
				
				Count=(int)cmd.ExecuteScalar();
			}

			return Count;
		}
	}
}
