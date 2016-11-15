using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Xml;

namespace DB2XMLA
{
	class DB2XMLA
	{
		static void Main()
		{
			DataSet
				ds=new DataSet("TestDataSet");

			DataSetFill(ds);

			DataRow
				row=ds.Tables[1].NewRow();

			row["ID"]=13;
			row["Name"]="Victim";
			row["Salary"]=111.11;
			ds.Tables[1].Rows.Add(row);

			string
				FileName="TestXML.xml";

			XmlDocument
				XmlDoc=DataSet2XmlDocument(ds,Path.ChangeExtension(FileName,"xsl"));

			if(File.Exists(FileName))
				File.Delete(FileName);

			XmlDoc.Save(FileName);
		}
		//---------------------------------------------------------------------------

		static void DataSetFill(DataSet ds)
		{
			string
				ConnectionString;

			if((ConnectionString=ConfigurationSettings.AppSettings["ConnectionString"])==null || ConnectionString==string.Empty)
				return;

			try
			{
				using(OleDbConnection con=new OleDbConnection(ConnectionString))
				{
					con.Open();

					using(OleDbCommand cmd=con.CreateCommand())
					{
						cmd.CommandType=CommandType.StoredProcedure;
						cmd.CommandText="sp_Staff_Report";

						using(OleDbDataAdapter da=new OleDbDataAdapter(cmd))
						{
							da.TableMappings.Add("Table","Main");
							da.TableMappings.Add("Table1","Contragent");
							da.Fill(ds);
						}
					}
				}
			}
			catch(Exception eException)
			{
				throw(new Exception(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine + eException.StackTrace));
			}
		}
		//---------------------------------------------------------------------------

		static XmlDocument DataSet2XmlDocument(DataSet ds, string XSLFileName)
		{
			XmlDocument
				doc=new XmlDocument();

			XmlNode
				node=doc.CreateXmlDeclaration("1.0","windows-1251",null);

			doc.AppendChild(node);

			if(XSLFileName!=null && XSLFileName!=string.Empty)
			{
				XmlProcessingInstruction
					pi=doc.CreateProcessingInstruction("xml-stylesheet","type=\"text/xsl\" href=\""+XSLFileName+"\"");

				doc.AppendChild(pi);
			}

			node=doc.CreateElement(ds.DataSetName);
			doc.AppendChild(node);

			DataTable
				tbl;

			for(int i=0; i<ds.Tables.Count; ++i)
			{
				tbl=ds.Tables[i];
				doc.DocumentElement.AppendChild(Table2XmlNode(doc,tbl));
			}

			return(doc);
		}
		//---------------------------------------------------------------------------

		static string Value2String(object Value)
		{
			string
				OutputString=string.Empty;

			switch(Type.GetTypeCode(Value.GetType()))
			{
				case TypeCode.DateTime :
				{
					OutputString=Convert.ToDateTime(Value).ToString("dd.MM.yyyy");
					break;
				}
				default :
				{
					OutputString=Value.ToString();
					break;
				}
			}

			return(OutputString);
		}
		//---------------------------------------------------------------------------

		static XmlAttribute Value2XmlAttribute(XmlDocument doc, string AttributeName, object AttributeValue)
		{
			XmlAttribute
				attribute=doc.CreateAttribute(AttributeName);

			attribute.Value=Value2String(AttributeValue);

			return(attribute);
		}
		//---------------------------------------------------------------------------

		static XmlNode Table2XmlNode(XmlDocument doc, DataTable tbl)
		{
			XmlNode
				node=doc.CreateElement(tbl.TableName);

			foreach(DataRow row in tbl.Rows)
				node.AppendChild(Row2XmlNode(doc,row));

			return(node);
		}
		//---------------------------------------------------------------------------

		static XmlNode Row2XmlNode(XmlDocument doc, DataRow row)
		{
			XmlNode
				node=doc.CreateElement("row");

			foreach(DataColumn col in row.Table.Columns)
				if(!row.IsNull(col.ColumnName))
					node.Attributes.Append(Value2XmlAttribute(doc,col.ColumnName,row[col.ColumnName]));

			return(node);
		}
		//---------------------------------------------------------------------------
	}
}