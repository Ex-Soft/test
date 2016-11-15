using System;
using System.Data;
using System.Data.OleDb;
using System.Web.Configuration;

namespace AnyTest2_1
{
	public class TestDataData
	{
		public static string GetConnectionString()
		{
			return ("Provider=" + WebConfigurationManager.ConnectionStrings["SybaseASEServer"].ProviderName + ";" + WebConfigurationManager.ConnectionStrings["SybaseASEServer"].ConnectionString);
		}

		public static DataTable GetStaff()
		{
			DataTable
				tmpDataTable=new DataTable();

			OleDbConnection
				connection = null;
			try
			{
				try
				{
					connection=new OleDbConnection(GetConnectionString());
					connection.Open();

					OleDbCommand
						cmd = connection.CreateCommand();

					cmd.CommandType = CommandType.Text;
					cmd.CommandText = "select * from staff order by id";

					OleDbDataAdapter
						da=new OleDbDataAdapter(cmd);

					da.Fill(tmpDataTable);
				}
				catch (Exception eException)
				{
					throw (new Exception(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace));
				} 
			}
			finally
			{
				if(connection!=null && connection.State==ConnectionState.Open)
					connection.Close();
			}

			return (tmpDataTable);
		}
	}
}
