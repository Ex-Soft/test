using System;
using System.Data.SqlClient;
using System.Data.OracleClient;

namespace TestConnection
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length == 2)
			{
				Console.WriteLine("SQL server: \"{0}\"", args[0]);
				Console.WriteLine("ConnectionString: \"{0}\"", args[1]);

				string
					SQLServer;

				switch(SQLServer=args[0].Trim().ToLower())
				{
					case "oracle":
					{
						using (OracleConnection conn = new OracleConnection(args[1]))
						{
							try
							{
								conn.Open();
								Console.WriteLine("xConnection.State=\"{0}\"", conn.State);
							}
							catch (Exception eException)
							{
								Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
							}
						}

						break;
					}
					case "mssql":
					{
						using (SqlConnection conn = new SqlConnection(args[1]))
						{
							try
							{
								conn.Open();
								Console.WriteLine("xConnection.State=\"{0}\"", conn.State);
							}
							catch (Exception eException)
							{
								Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
							}
						}

						break;
					}
					default:
					{
						Console.WriteLine("Unknown SQL server: \"{0}\"", SQLServer);
						break;
					}
				}
			}
		}
	}
}
