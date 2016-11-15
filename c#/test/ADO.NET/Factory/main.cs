using System;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace TestFactory
{
	class TestFactory
	{
		static void Main(string[] args)
		{
			string
				ProviderName = ConfigurationManager.AppSettings["Provider"];

			if(string.IsNullOrEmpty(ProviderName))
				return;

			ProviderName = ConfigurationManager.AppSettings[ProviderName];

			if (string.IsNullOrEmpty(ProviderName))
				return;

			DbConnection
				con = null;

			DbDataReader
				dr = null;

			try
			{
				try
				{
					DbProviderFactory
						provider = DbProviderFactories.GetFactory(ProviderName);

					con = provider.CreateConnection();
					
					DbConnectionStringBuilder
						csb = provider.CreateConnectionStringBuilder();

					if (!string.IsNullOrEmpty(ConfigurationManager.ConnectionStrings[ProviderName].ProviderName))
						csb.Add("Provider", ConfigurationManager.ConnectionStrings[ProviderName].ProviderName);

					con.ConnectionString = csb.ConnectionString + (!string.IsNullOrEmpty(csb.ConnectionString) ? ";" : "") + ConfigurationManager.ConnectionStrings[ProviderName].ConnectionString;

					con.Open();

					DbCommand
						cmd = con.CreateCommand();

					cmd.CommandType = CommandType.Text;
					cmd.CommandText = "select * from TESTCHAR";
					
					dr = cmd.ExecuteReader();
					if(dr.HasRows)
						Console.WriteLine("oB!");
					dr.Close();

					DbDataAdapter
						da = provider.CreateDataAdapter();

					DataTable
						tmpDataTable=new DataTable();

					da.SelectCommand = cmd;
					da.Fill(tmpDataTable);
					Console.WriteLine(tmpDataTable.Rows.Count);

					da.SelectCommand.CommandText = "select * from \"sp_Staff_Dep\" (?)";

					DbParameter
						param = provider.CreateParameter();

					param.ParameterName = "@DEPART";
					param.DbType = DbType.Int32;
					param.Direction = ParameterDirection.Input;
					param.Value = 1;
					da.SelectCommand.Parameters.Add(param);

					tmpDataTable.Reset();
					da.Fill(tmpDataTable);

					DbCommandBuilder
						cb = provider.CreateCommandBuilder();

					da.SelectCommand.Parameters.Clear();
					da.SelectCommand.CommandType = CommandType.StoredProcedure;
					da.SelectCommand.CommandText = "sp_Staff_Dep";

					con.Close();
				}
				catch (Exception eException)
				{
					Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
				}
			}
			finally
			{
				if(dr!=null && !dr.IsClosed)
					dr.Close();

				if(con!=null && con.State==ConnectionState.Open)
					con.Close();
			}
		}
	}
}
