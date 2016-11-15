#define TEST_DOCX
//#define TEST_BOOKMARK_BY_BOOKMARKS_COLLECTION

using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace WordTale
{
	class WordTale
	{
		[STAThread]
		static void Main(string[] args)
		{
			object
				MSWord=null,
				Documents=null,
				Document=null,
				Bookmarks=null,
				Bookmark=null,
				Range=null;

			try
			{
				try
				{
					string
						ExcelIDStr="Word.Application",
						CurrentDirectory=System.IO.Directory.GetCurrentDirectory();

					CurrentDirectory=CurrentDirectory.Substring(0,CurrentDirectory.LastIndexOf("bin",CurrentDirectory.Length-1));

					string
						InputFileName=CurrentDirectory+
                            #if TEST_DOCX
                                "Word_tst.docx"
                            #else
                                "Word_tst.doc"
                            #endif
                        ,
                        OutputFileName=CurrentDirectory+
                            #if TEST_DOCX
                                "Word_tst_out.docx"
                            #else
                                "Word_tst_out.doc"
                            #endif
                        ;

					try
					{
						MSWord=Marshal.GetActiveObject(ExcelIDStr);
					}
					catch(COMException eException)
					{
						if(eException.ErrorCode==-2147221021)
						{
							Type
								MSWordType=Type.GetTypeFromProgID(ExcelIDStr); 
							
							MSWord=Activator.CreateInstance(MSWordType);
						}
						else
							throw;
					}

					MSWord.GetType().InvokeMember("Visible",BindingFlags.SetProperty,null,MSWord,new object[]{true});
					MSWord.GetType().InvokeMember("DisplayAlerts",BindingFlags.SetProperty,null,MSWord,new object[]{false});
					
					Documents=MSWord.GetType().InvokeMember("Documents",BindingFlags.GetProperty,null,MSWord,null);

					Document=Documents.GetType().InvokeMember("Open",BindingFlags.InvokeMethod,null,Documents,new object[]{InputFileName});

					Bookmarks=Document.GetType().InvokeMember("Bookmarks",BindingFlags.GetProperty,null,Document,null);
                    Range = Bookmarks.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, Bookmarks, null);
					
					if((int)Range>0)
					{
						Range=Bookmarks.GetType().InvokeMember("Exists",BindingFlags.InvokeMethod,null,Bookmarks,new object[]{"MyBookmark"});

						if((bool)Range)
						{
							#if TEST_BOOKMARK_BY_BOOKMARKS_COLLECTION
								Bookmark=Bookmarks.GetType().InvokeMember("Item",BindingFlags.InvokeMethod,null,Bookmarks,new object[]{"MyBookmark"});
								// ||
								//Bookmark=Bookmarks.GetType().InvokeMember("Item",BindingFlags.InvokeMethod,null,Bookmarks,new object[]{1});
								Range=Bookmark.GetType().InvokeMember("Name",BindingFlags.GetProperty,null,Bookmark,null);
								Bookmark.GetType().InvokeMember("Select",BindingFlags.InvokeMethod,null,Bookmark,null);
								Range=MSWord.GetType().InvokeMember("Selection",BindingFlags.GetProperty,null,MSWord,null);
							#else
								Range=MSWord.GetType().InvokeMember("Selection",BindingFlags.GetProperty,null,MSWord,null);
								Range.GetType().InvokeMember("GoTo",BindingFlags.InvokeMethod,null,Range,new object[]{/*What*/ 0xFFFFFFFF /*wdGoToBookmark*/, /*Which*/ Type.Missing, /*Count*/ Type.Missing, /*Name*/ "MyBookmark"});
							#endif

							Range.GetType().InvokeMember("Text",BindingFlags.SetProperty,null,Range,new object[]{"1234567890"});
						}
					}

				    Document.GetType().InvokeMember("SaveAs", BindingFlags.InvokeMethod, null, Document,new object[] {OutputFileName});
					Document.GetType().InvokeMember("Close",BindingFlags.InvokeMethod,null,Document,null);
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
				if(Range!=null)
				{
					Marshal.ReleaseComObject(Range);
					Range=null;
				}

				if(Bookmark!=null)
				{
					Marshal.ReleaseComObject(Bookmark);
					Bookmark=null;
				}

				if(Bookmarks!=null)
				{
					Marshal.ReleaseComObject(Bookmarks);
					Bookmarks=null;
				}

				if(Document!=null)
				{
					Marshal.ReleaseComObject(Document);
					Document=null;
				}

				if(Documents!=null)
				{
					Marshal.ReleaseComObject(Documents);
					Documents=null;
				}

				if(MSWord!=null)
				{
					MSWord.GetType().InvokeMember("Quit",BindingFlags.InvokeMethod,null,MSWord,null);
					Marshal.ReleaseComObject(MSWord);
					MSWord=null;
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
