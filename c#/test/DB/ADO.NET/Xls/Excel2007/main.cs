using System;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace Excel2007
{
	class Program
	{
		static void Main(string[] args)
		{
			StreamWriter
				fstr_out = null;

			string
				tmpString = "log.log";

			OleDbConnection
				conn = null;

			OleDbCommand
				cmd = null;

			OleDbDataAdapter
				da = null;

			DataTable
				tmpDataTable = null;

			try
			{
				try
				{
					fstr_out = new StreamWriter(tmpString, false, System.Text.Encoding.GetEncoding(1251));
					fstr_out.AutoFlush = true;

					//tmpString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Directory.GetCurrentDirectory() + "\\..\\..\\test.xlsx" + ";Extended Properties=\"Excel 8.0;HDR=No;MAXSCANROWS=0;IMEX=1\"";
					//tmpString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Directory.GetCurrentDirectory() + "\\..\\..\\test.xlsx" + ";Extended Properties=\"Excel 12.0 Xml;HDR=No;MAXSCANROWS=0;IMEX=1\"";
					//tmpString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Directory.GetCurrentDirectory() + "\\..\\..\\test.xls" + ";Extended Properties=\"Excel 12.0 Xml;HDR=No;MAXSCANROWS=0;IMEX=1\"";
                    tmpString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Directory.GetCurrentDirectory() + "\\..\\..\\TestTypes.xlsx" + ";Extended Properties=\"Excel 12.0 Xml;HDR=Yes;MAXSCANROWS=0;IMEX=1\"";

					conn = new OleDbConnection(tmpString);
					conn.Open();

					if (tmpDataTable == null)
						tmpDataTable = new DataTable();
					else
						tmpDataTable.Reset();

					tmpDataTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
					foreach (DataRow r in tmpDataTable.Rows)
						fstr_out.WriteLine(r["TABLE_CATALOG"].ToString() + "\t" + r["TABLE_SCHEMA"].ToString() + "\t" + r["TABLE_NAME"].ToString() + "\t" + r["TABLE_TYPE"].ToString() + "\t" + r["TABLE_GUID"].ToString() + "\t" + r["DESCRIPTION"].ToString() + "\t" + r["TABLE_PROPID"].ToString() + "\t" + r["DATE_CREATED"].ToString() + "\t" + r["DATE_MODIFIED"].ToString());

					if (tmpDataTable.Rows.Count != 0
						&& !tmpDataTable.Rows[0].IsNull("TABLE_NAME"))
					{
						tmpString = "select * from [" + tmpDataTable.Rows[0]["TABLE_NAME"] + "]";
						cmd = new OleDbCommand(tmpString, conn);
						tmpDataTable.Reset();
						if (da == null)
							da = new OleDbDataAdapter(cmd);
						da.Fill(tmpDataTable);
						foreach (DataRow r in tmpDataTable.Rows)
						{
							foreach (DataColumn c in tmpDataTable.Columns)
								fstr_out.Write(!r.IsNull(c.ColumnName) ? r[c.ColumnName].ToString() + "\t" : "null\t");

							fstr_out.WriteLine();
						}
					}

					conn.Close();
				}
				catch (Exception eException)
				{
					fstr_out.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
				}
			}
			finally
			{
				if (conn != null && conn.State == System.Data.ConnectionState.Open)
					conn.Close();

				if (fstr_out != null)
					fstr_out.Close();
			}
		}
	}
}
