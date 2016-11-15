#define TEST_BOOKMARK
#define TEST_BOOKMARK_BY_BOOKMARKS_COLLECTION

using System;
using System.IO;
using System.Runtime.InteropServices;
using Word;

namespace WordEarly
{
	/// <summary>
	/// Summary description for WordEarly.
	/// </summary>
	class WordEarly
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			object
				oMissing=Type.Missing; //System.Reflection.Missing.Value;

			Word.Application
				WordApp=null;

			Word.Document
				Document=null;

			Word.Table
				Table=null;

			string
				CurrentDirectory=System.IO.Directory.GetCurrentDirectory(),
				tmpString;

			CurrentDirectory=CurrentDirectory.Substring(0,CurrentDirectory.LastIndexOf("bin",CurrentDirectory.Length-1));

			object
				InputFileName,
				OutputFileName,
				tmpObject;

			try
			{
				try
				{
					try
					{
						WordApp=(Word.Application)Marshal.GetActiveObject("Word.Application");
					}
					catch(COMException eException)
					{
						if(eException.ErrorCode==-2147221021)
							WordApp=new Word.Application();
					}

					WordApp.Visible=true;

					#if TEST_BOOKMARK
						InputFileName=CurrentDirectory+"Word_tst.doc";
						Document=WordApp.Documents.Open(ref InputFileName, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
						if(Document.Bookmarks.Count>0)
						{
							tmpString="MyBookmark";
							if(Document.Bookmarks.Exists(tmpString))
							{
								tmpObject=tmpString;

								#if TEST_BOOKMARK_BY_BOOKMARKS_COLLECTION
									Document.Bookmarks.Item(ref tmpObject).Select();
								#else
									object
										What=Word.WdGoToItem.wdGoToBookmark;

									WordApp.Selection.GoTo(/*What*/ ref What, /*Which*/ ref oMissing, /*Count*/ ref oMissing, /*Name*/ ref tmpObject);
								#endif

								WordApp.Selection.Text="1234567890";
							}
						}
						OutputFileName=CurrentDirectory+"Word_tst_out.doc";
						if(File.Exists(OutputFileName.ToString()))
							File.Delete(OutputFileName.ToString());

						Document.SaveAs(ref OutputFileName,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing);
						Document.Close(ref oMissing,ref oMissing,ref oMissing);
					#endif

					Document=WordApp.Documents.Add(ref oMissing,ref oMissing);

					int
						index=0,
						rows=3,
						columns=2;

					Table=Document.Tables.Add(WordApp.Selection.Range,rows+1,columns);
					Table.Range.ParagraphFormat.Alignment=Word.WdParagraphAlignment.wdAlignParagraphCenter;
					Table.Range.Bold=1;
					for(int i=0; i<columns; i++)
						Table.Cell(0,i+1).Range.InsertAfter(i.ToString());
					for(int j=1; j<=rows; j++)
					{
						Table.Rows.Item(j+1).Range.ParagraphFormat.Alignment=Word.WdParagraphAlignment.wdAlignParagraphLeft;
						Table.Rows.Item(j+1).Range.Bold=0;
						for(int i=0; i<columns; i++)
						{
							Table.Cell(j+1,i+1).Range.InsertAfter(index.ToString());
							index++;
						}
					}

					OutputFileName=CurrentDirectory+"test_out.doc";
					if(File.Exists(OutputFileName.ToString()))
						File.Delete(OutputFileName.ToString());

					Document.SaveAs(ref OutputFileName,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing);
					Document.Close(ref oMissing,ref oMissing,ref oMissing);
				}
				catch(COMException eException)
				{
					string
						tmp=eException.GetType().FullName+Environment.NewLine+"ErrorCode: "+eException.ErrorCode+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace;

					Console.WriteLine(tmp);
				}
				catch(ArgumentException eException)
				{
					string
						tmp=eException.GetType().FullName+Environment.NewLine+"ParamName: "+eException.ParamName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace;

					Console.WriteLine(tmp);
				}
				catch(Exception eException)
				{
					string
						tmp=eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace;

					Console.WriteLine(tmp);
				}
			}
			finally
			{
				if(Table!=null)
				{
					Marshal.ReleaseComObject(Table);
					Table=null;
				}
				if(Document!=null)
				{
					Marshal.ReleaseComObject(Document);
					Document=null;
				}
				if(WordApp!=null)
				{
					WordApp.Quit(ref oMissing,ref oMissing,ref oMissing);
					Marshal.ReleaseComObject(WordApp);
					WordApp=null;
				}
				GC.Collect();
				GC.WaitForPendingFinalizers();
				GC.Collect();
				GC.GetTotalMemory(true);
				//GC.SuppressFinalize(this);
			}
		}
	}
}
