using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Text;
using System.Web.UI;

namespace AnyTest
{
	/// <summary>
	/// Summary description for TestPrintMainForm.
	/// </summary>
	public class TestPrintMainForm : System.Web.UI.Page
	{
		string
			DocumentFileName=string.Empty,
			TestPrintMainFormDataTablePrintDataSessionSignature="TestPrintMainFormDataTablePrintDataSession";

		long
			Id=long.MinValue;

		DataTable
			PrintData=null;

		private void Page_Load(object sender, System.EventArgs e)
		{
			string
				DocumentIdStr,
				IdStr;

			if((DocumentIdStr=Global.GetQueryStringValueFromRequest(Request,"DocumentId"))==string.Empty
				|| (IdStr=Global.GetQueryStringValueFromRequest(Request,"Id"))==string.Empty)
				return;

			long
				DocumentId=long.MinValue;

			try
			{
				DocumentId=Convert.ToInt64(DocumentIdStr);
				Id=Convert.ToInt64(IdStr);
			}
			catch(Exception eException)
			{
				throw(new Exception(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace));
			}

			switch(DocumentId)
			{
				case 1 :
				{
					DocumentFileName="Document1.html";
					break;	
				}
				case 2 :
				{
					DocumentFileName="Document2.html";
					break;	
				}
				default :
				{
					throw(new Exception("Unknown \"DocumentId\": "+DocumentId));
				}
			}

			if((PrintData=(DataTable)Session[TestPrintMainFormDataTablePrintDataSessionSignature])==null)
			{
				Session[TestPrintMainFormDataTablePrintDataSessionSignature]=PrintData=new DataTable();

				PrintData.Columns.Add("Name",typeof(string));
				PrintData.Columns.Add("Value",typeof(string));
				PrintData.Columns.Add("Index",typeof(int));
			}

			if(PrintData.Rows.Count==0)
				FillPrintData(PrintData,Id);
			else
			{
				string
					tmpString;

				foreach(DataRow row in PrintData.Rows)
					if((tmpString=Global.GetFormValueFromRequest(Request,Convert.ToString(row["Name"])))!=string.Empty)
						row["Value"]=tmpString;
				
			}
		}
		//---------------------------------------------------------------------------

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
			StreamReader
				sr=null;

			try
			{
				try
				{
					string
						HtmlFileName=Server.MapPath(null)+Path.DirectorySeparatorChar+DocumentFileName;

					if(!File.Exists(HtmlFileName))
						throw(new Exception("The file \""+HtmlFileName+"\" doesn't exist"));

					sr=new StreamReader(HtmlFileName);

					string
						tmpString;

					StringBuilder
						outString=new StringBuilder();

					while((tmpString=sr.ReadLine())!=null)
					{
						if(tmpString.IndexOf("<head")!=-1)
							tmpString+=Environment.NewLine+"\t\t<script src=\""+MakeDataJSFile(DocumentFileName,Id,PrintData)+"?"+DateTime.Now.Ticks+"\" type=\"text/javascript\"></script>";
						outString.Append(tmpString+Environment.NewLine);
					}

					sr.Close();
					sr=null;

					writer.Write(outString.ToString());
				}
				catch(Exception eException)
				{
					throw(new Exception(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace));
				}
			}
			finally
			{
				if(sr!=null)
					sr.Close();
			}
		}
		//---------------------------------------------------------------------------

		string MakeDataJSFile(string DocumentFileName, long Id, DataTable aDataTable)
		{
			string
				DataJSFileName=Path.GetFileNameWithoutExtension(DocumentFileName)+"_"+Id+".js",
				CtrlsValuesArraySignature="CtrlsValues";

			StreamWriter
				OutputFile=null;

			try
			{
				lock(typeof(StreamWriter))
				{
					if((OutputFile=new StreamWriter(Server.MapPath(null)+Path.DirectorySeparatorChar+DataJSFileName,false,System.Text.Encoding.GetEncoding(1251)))!=null && OutputFile.BaseStream!=null && OutputFile.BaseStream.CanWrite)
					{
						if(!OutputFile.AutoFlush)
							OutputFile.AutoFlush=true;

						OutputFile.WriteLine("var");
						OutputFile.WriteLine("\t"+CtrlsValuesArraySignature+"=new Array();");
						OutputFile.WriteLine();

						string
							FieldNameName="Name",
							Name,
							FieldName,
							Value;

						Hashtable
							OutputTablesValues=new Hashtable();

						foreach(DataRow row in aDataTable.Rows)
						{
							if(row.IsNull(FieldNameName)
								|| (Name=Convert.ToString(row[FieldNameName]).Trim())==string.Empty)
								continue;

							FieldName="Value";
							Value = !row.IsNull(FieldName) ? Convert.ToString(row[FieldName]).Replace("\\","\\\\").Replace("'","\\'").Replace("\"","\\\"") : string.Empty;

							FieldName="Index";
							if(!row.IsNull(FieldName))
							{
								if(!OutputTablesValues.ContainsKey(Name))
									OutputTablesValues.Add(Name,new Hashtable());
								(OutputTablesValues[Name] as Hashtable)[Convert.ToInt32(row[FieldName])]=Value;
							}
							else
								OutputFile.WriteLine(CtrlsValuesArraySignature+"[\""+Name+"\"]=\""+Value+"\";");
						}

						IDictionaryEnumerator
							eName=OutputTablesValues.GetEnumerator(),
							eIndex;

						while(eName.MoveNext())
						{
							OutputFile.WriteLine(CtrlsValuesArraySignature+"[\""+eName.Key+"\"]={Values:new Array()};");
							eIndex=(eName.Value as Hashtable).GetEnumerator();
							while(eIndex.MoveNext())
								OutputFile.WriteLine(CtrlsValuesArraySignature+"[\""+eName.Key+"\"].Values["+eIndex.Key+"]=\""+eIndex.Value+"\";");
						}

						OutputFile.Close();
						OutputFile=null;
					}
				} 
			}
			finally
			{
				if(OutputFile!=null)
					OutputFile.Close(); 	
			}

			return(DataJSFileName);
		}
		//---------------------------------------------------------------------------

		void FillPrintData(DataTable aDataTable, long aId)
		{
			DataRow
				tmpDataRow;

			tmpDataRow=aDataTable.NewRow();
			tmpDataRow["Name"]="SpanLine1";
			tmpDataRow["Value"]="SpanLine1 for \""+DocumentFileName+"\" from \"Id\": "+aId;
			aDataTable.Rows.Add(tmpDataRow);

			tmpDataRow=aDataTable.NewRow();
			tmpDataRow["Name"]="SpanLine2";
			tmpDataRow["Value"]="SpanLine2 for \""+DocumentFileName+"\" from \"Id\": "+aId;
			aDataTable.Rows.Add(tmpDataRow);

			tmpDataRow=aDataTable.NewRow();
			tmpDataRow["Name"]="SpanLine3";
			tmpDataRow["Value"]="SpanLine3 for \""+DocumentFileName+"\" from \"Id\": "+aId+" /\\'\"";
			aDataTable.Rows.Add(tmpDataRow);

			tmpDataRow=aDataTable.NewRow();
			tmpDataRow["Name"]="FIO";
			tmpDataRow["Value"]="Ленин Владимир Ильич";
			tmpDataRow["Index"]=0;
			aDataTable.Rows.Add(tmpDataRow);
			tmpDataRow=aDataTable.NewRow();
			tmpDataRow["Name"]="DR";
			tmpDataRow["Value"]="22.04.1870";
			tmpDataRow["Index"]=0;
			aDataTable.Rows.Add(tmpDataRow);
			tmpDataRow=aDataTable.NewRow();
			tmpDataRow["Name"]="Salary";
			tmpDataRow["Value"]="1,000.00";
			tmpDataRow["Index"]=0;
			aDataTable.Rows.Add(tmpDataRow);

			tmpDataRow=aDataTable.NewRow();
			tmpDataRow["Name"]="FIO";
			tmpDataRow["Value"]="Сталин Иосиф Виссарионович";
			tmpDataRow["Index"]=1;
			aDataTable.Rows.Add(tmpDataRow);
			tmpDataRow=aDataTable.NewRow();
			tmpDataRow["Name"]="DR";
			tmpDataRow["Value"]="18.12.1878";
			tmpDataRow["Index"]=1;
			aDataTable.Rows.Add(tmpDataRow);
			tmpDataRow=aDataTable.NewRow();
			tmpDataRow["Name"]="Salary";
			tmpDataRow["Value"]="300.00";
			tmpDataRow["Index"]=1;
			aDataTable.Rows.Add(tmpDataRow);

			tmpDataRow=aDataTable.NewRow();
			tmpDataRow["Name"]="FIO";
			tmpDataRow["Value"]="Хрущев Никита Сергеевич";
			tmpDataRow["Index"]=2;
			aDataTable.Rows.Add(tmpDataRow);
			tmpDataRow=aDataTable.NewRow();
			tmpDataRow["Name"]="DR";
			tmpDataRow["Value"]="17.04.1894";
			tmpDataRow["Index"]=2;
			aDataTable.Rows.Add(tmpDataRow);
			tmpDataRow=aDataTable.NewRow();
			tmpDataRow["Name"]="Salary";
			tmpDataRow["Value"]="3,000.00";
			tmpDataRow["Index"]=2;
			aDataTable.Rows.Add(tmpDataRow);

			tmpDataRow=aDataTable.NewRow();
			tmpDataRow["Name"]="FIO2";
			tmpDataRow["Value"]="Ленин Владимир Ильич";
			tmpDataRow["Index"]=0;
			aDataTable.Rows.Add(tmpDataRow);
			tmpDataRow=aDataTable.NewRow();
			tmpDataRow["Name"]="Department";
			tmpDataRow["Value"]="ВКП(б)";
			tmpDataRow["Index"]=0;
			aDataTable.Rows.Add(tmpDataRow);

			tmpDataRow=aDataTable.NewRow();
			tmpDataRow["Name"]="FIO2";
			tmpDataRow["Value"]="Сталин Иосиф Виссарионович";
			tmpDataRow["Index"]=1;
			aDataTable.Rows.Add(tmpDataRow);
			tmpDataRow=aDataTable.NewRow();
			tmpDataRow["Name"]="Department";
			tmpDataRow["Value"]="КПСС";
			tmpDataRow["Index"]=1;
			aDataTable.Rows.Add(tmpDataRow);

			switch(aId)
			{
				case 2 :
				{
					tmpDataRow=aDataTable.NewRow();
					tmpDataRow["Name"]="InputLine4";
					aDataTable.Rows.Add(tmpDataRow);

					tmpDataRow=aDataTable.NewRow();
					tmpDataRow["Name"]="InputLine5";
					aDataTable.Rows.Add(tmpDataRow);

					tmpDataRow=aDataTable.NewRow();
					tmpDataRow["Name"]="InputLine6";
					aDataTable.Rows.Add(tmpDataRow);

					break;
				}
			}
		}
		//---------------------------------------------------------------------------
	}
}