using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Web.UI;
using System.Xml;

namespace AnyTest
{
	public class ReportXSLT : System.Web.UI.Page
	{
		DataSet
			ds=new DataSet();

		private void Page_Load(object sender, System.EventArgs e)
		{
			string
				connstring=ConfigurationSettings.AppSettings["MyConnectionString"];

			if(connstring!=null && connstring.Length>0)
			{
				try
				{
					using(OleDbConnection con=new OleDbConnection(connstring))
					{
						con.Open();

						using(OleDbCommand cmd=con.CreateCommand())
						{
							cmd.CommandType=CommandType.StoredProcedure;
							cmd.CommandText="sp_Staff_Report";

							using(OleDbDataAdapter da=new OleDbDataAdapter(cmd))
								da.Fill(ds);
						}
					}
				}
				catch(Exception eException)
				{
					throw(new Exception(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace));
				}
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

		protected override void Render(HtmlTextWriter writer)
		{
			Response.CacheControl="no-cache";
			Response.AppendHeader("Pragma","no-cache");
			Response.Expires=-1;

			Response.AppendHeader("Content-type","text/xml");

			XmlDocument
				doc=new XmlDocument();

			XmlNode
				node=doc.CreateXmlDeclaration("1.0","windows-1251",null),
				nnode=null,
				nnnode=null;

			doc.AppendChild(node);

			XmlProcessingInstruction
				pi=doc.CreateProcessingInstruction("xml-stylesheet","type=\"text/xsl\" href=\"data.xsl\"");

			doc.AppendChild(pi);

			node=doc.CreateElement("StaffReport");
			doc.AppendChild(node);

			DataTable
				tmpDataTable=ds.Tables[0];

			string
				FieldName;

			if(tmpDataTable.Rows.Count>0)
			{
				FieldName="ReportName";
				node=doc.CreateElement(FieldName);
				if(!tmpDataTable.Rows[0].IsNull(FieldName))
					node.AppendChild(doc.CreateTextNode(Convert.ToString(tmpDataTable.Rows[0][FieldName])));
				doc.DocumentElement.AppendChild(node);

				FieldName="ReportNo";
				node=doc.CreateElement(FieldName);
				if(!tmpDataTable.Rows[0].IsNull(FieldName))
					node.AppendChild(doc.CreateTextNode(Convert.ToString(tmpDataTable.Rows[0][FieldName])));
				doc.DocumentElement.AppendChild(node);

				FieldName="ReportDate";
				node=doc.CreateElement(FieldName);
				if(!tmpDataTable.Rows[0].IsNull(FieldName))
					node.AppendChild(doc.CreateTextNode(Convert.ToDateTime(tmpDataTable.Rows[0][FieldName]).ToString("yyyy.MM.dd")));
				doc.DocumentElement.AppendChild(node);

				int
					DepNew=int.MinValue,
					DepOld=int.MinValue;

				node=doc.CreateElement("Staff");
				tmpDataTable=ds.Tables[1];
				foreach(DataRow row in tmpDataTable.Rows)
				{
					FieldName="Dep";
					if(!row.IsNull(FieldName))
					{
						DepNew=Convert.ToInt32(row[FieldName]);
						if(DepOld!=DepNew)
						{
							DepOld=DepNew;

							nnode=doc.CreateElement(FieldName);
							nnode.Attributes.Append(doc.CreateAttribute(FieldName+"No"));
							nnode.Attributes[FieldName+"No"].Value=Convert.ToString(DepOld);
							node.AppendChild(nnode);
						}
					}

					FieldName="Name";
					nnnode=doc.CreateElement(FieldName);
					if(!row.IsNull(FieldName))
						nnnode.AppendChild(doc.CreateTextNode(Convert.ToString(row[FieldName])));

					FieldName="Salary";
					if(!row.IsNull(FieldName))
					{
						nnnode.Attributes.Append(doc.CreateAttribute(FieldName));
						nnnode.Attributes[FieldName].Value=Convert.ToString(row[FieldName]);
					}

					FieldName="BirthDate";
					if(!row.IsNull(FieldName))
					{
						nnnode.Attributes.Append(doc.CreateAttribute(FieldName));
						nnnode.Attributes[FieldName].Value=Convert.ToDateTime(row[FieldName]).ToString("yyyy.MM.dd");
					}
					nnode.AppendChild(nnnode);
				}
				doc.DocumentElement.AppendChild(node);
			}

			if(File.Exists(FieldName=Server.MapPath(null)+Path.DirectorySeparatorChar+"data.xml"))
				File.Delete(FieldName);
			doc.Save(FieldName);

			XmlTextWriter
				w=new XmlTextWriter(writer);

			doc.WriteContentTo(w);
			w.Flush();

		}
	}
}
