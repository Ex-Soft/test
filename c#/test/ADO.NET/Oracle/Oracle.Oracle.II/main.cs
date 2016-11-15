using System;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;

namespace OracleOracleII
{
	class Program
	{
		static void Main(string[] args)
		{
			OracleConnection
				conn = null;

			try
			{
				string
					connectionString = ConfigurationManager.ConnectionStrings["System.Data.OracleClient"].ConnectionString;

				if(string.IsNullOrEmpty(connectionString))
					return;

				conn = new OracleConnection(connectionString);
				try
				{
					Console.Write("Open...");
					conn.Open();
					Console.WriteLine("Ok!");
				}
				catch (Exception eException)
				{
					Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
				}
			}
			finally
			{
				if (conn != null && conn.State == ConnectionState.Open)
					conn.Close();
			}
		}
	}
}
