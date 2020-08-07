using System;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace TestXls
{
	class TestXls
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

			OleDbDataAdapter
				da=null;

			DataTable
				tmpDataTable=null;

			try
			{
				try
				{
					fstr_out=new StreamWriter(tmpString,false,System.Text.Encoding.GetEncoding(1251));
					fstr_out.AutoFlush=true;

					tmpString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+Directory.GetCurrentDirectory()+"\\..\\..\\test.xls"+";Extended Properties='Excel 8.0;HDR=No;IMEX=1'";

// The possible settings of IMEX are: 
// 0 is Export mode
// 1 is Import mode
// 2 is Linked mode (full update capabilities)

					conn=new OleDbConnection(tmpString);
					conn.Open();
                    
					if(tmpDataTable==null)
						tmpDataTable=new DataTable();
					else
						tmpDataTable.Reset();
					tmpDataTable=conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,new object[]{null, null, null, "TABLE"});

					//tmpString="select * from [Ëèñò1$]";
					//tmpString="select * from [Ëèñò1$A1:B10]";
					//tmpString="select * from [Ëèñò1$A:B]";
					//tmpString="select * from [Ëèñò1$A:A]";
					tmpString="select `Ëèñò1$`.`1`,`Ëèñò1$`.`2` from [Ëèñò1$]";

					//tmpString="select * from [Ëèñò1$A,B]"; // The Microsoft Jet database engine could not find the object 'Ëèñò1$A,B'.  Make sure the object exists and that you spell its name and the path name correctly.
					//tmpString="select * from [Ëèñò1$F1,F2]"; // --"--
					//tmpString="select * from [Ëèñò1$A]"; // --"--
					cmd=new OleDbCommand(tmpString,conn);
					tmpDataTable.Reset();
					if(da==null)
						da=new OleDbDataAdapter(cmd);
					da.Fill(tmpDataTable);
					cmd.CommandText="insert into [Ëèñò1$] (F3,F4) values (11,121)";
					cmd.ExecuteNonQuery();
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
				if(conn!=null && conn.State==System.Data.ConnectionState.Open)
					conn.Close();

				if(fstr_out!=null)
					fstr_out.Close();
			}
			return(Result);
		}
	}
}