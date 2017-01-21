using System;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace TestAccess
{
	class TestAccess
	{
		[STAThread]
		public static int Main(string[] args)
		{
			int
				Result=-1;

			StreamWriter
				fstr_out=null;

			string
				tmpString="log.log";

			OleDbConnection
				conn=null;

			OleDbCommand
				cmd=null;

			OleDbDataReader
				rdr=null;

			try
			{
				try
				{
					fstr_out=new StreamWriter(tmpString,false,System.Text.Encoding.GetEncoding(1251));
					fstr_out.AutoFlush=true;

					//tmpString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\\Мои документы\\Jsic Veksel\\T4.mdb;Jet OLEDB:Database Password=3944";
					tmpString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\\Soft.src\\CBuilder\\Tests\\Access\\TestAccess.mdb;User Id=admin;Password=;";
					conn=new OleDbConnection(tmpString);
					conn.Open();
					fstr_out.WriteLine("ConnectionString: "+conn.ConnectionString);
					fstr_out.WriteLine("ConnectionTimeout: "+conn.ConnectionTimeout.ToString());
					fstr_out.WriteLine("Database: "+conn.Database);
					fstr_out.WriteLine("DataSource: "+conn.DataSource);
					fstr_out.WriteLine("Provider: "+conn.Provider);
					fstr_out.WriteLine("ServerVersion: "+conn.ServerVersion);
					fstr_out.WriteLine("State: "+conn.State.ToString());
					fstr_out.WriteLine();

					if(cmd==null)
						cmd=conn.CreateCommand();

					cmd.CommandType=CommandType.Text;
					cmd.CommandText="select sum(Mark) as SumSum from Examinations where Id=9";

					fstr_out.WriteLine("OleDbCommand.ExecuteReader(CommandBehavior.SchemaOnly)");
					rdr=cmd.ExecuteReader(CommandBehavior.SchemaOnly);
					fstr_out.WriteLine("OleDbDataReader.HasRows="+rdr.HasRows.ToString());
					for(int i=0; i<rdr.FieldCount; ++i)
					{
						fstr_out.WriteLine(rdr.GetName(i)+" "+rdr.GetDataTypeName(i)+" "+rdr.GetFieldType(i));
					}
					fstr_out.WriteLine();
					rdr.Close();

					rdr=cmd.ExecuteReader();
					rdr.Close();

					cmd.CommandText="select ?=sum(Mark) from Examinations where Id=9";
					cmd.Parameters.Add("SumSum",OleDbType.Double);
					cmd.Parameters["SumSum"].Direction=ParameterDirection.Output;

					rdr=cmd.ExecuteReader();
					rdr.Close();

					conn.Close();

					Result=0;
				}
				catch(Exception eException)
				{
					fstr_out.WriteLine(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace);
				} 			
			}
			finally
			{
				if(rdr!=null && !rdr.IsClosed)
					rdr.Close();

				if(conn!=null && conn.State==System.Data.ConnectionState.Open)
					conn.Close();

				if(fstr_out!=null)
					fstr_out.Close();
			}
			return(Result);
		}
	}
}