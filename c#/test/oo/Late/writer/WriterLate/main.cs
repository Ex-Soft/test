using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace WriterLate
{
	class WriterLate
	{
		[STAThread]
		static void Main()
		{
			const string
				ServiceManagerIDStr="com.sun.star.ServiceManager",
				DesktopIDStr="com.sun.star.frame.Desktop",
				PropertyValueIDStr="com.sun.star.beans.PropertyValue",
				TextTableIdStr="com.sun.star.text.TextTable";

			object
				ServiceManager=null,
				Desktop=null,
				Document=null,
				Param=null,
				Text=null,
				Cursor=null,
				Table=null;

			object[]
				arg;

			string
				CurrentDirectory=System.IO.Directory.GetCurrentDirectory();

			CurrentDirectory=CurrentDirectory.Substring(0,CurrentDirectory.LastIndexOf("bin",CurrentDirectory.Length-1));


			string
				DocumentSrcName=(CurrentDirectory+"Word_tst.doc").Replace(Path.DirectorySeparatorChar,'/');

			try
			{
				try
				{
					Type
						ServiceManagerType;

					if((ServiceManagerType=Type.GetTypeFromProgID(ServiceManagerIDStr))!=null)
					{
						try
						{
							if((ServiceManager=Activator.CreateInstance(ServiceManagerType))==null)
								throw(new Exception("Can't create instance of \""+ServiceManagerIDStr+"\""));
							if((Desktop=ServiceManager.GetType().InvokeMember("createInstance",BindingFlags.InvokeMethod,null,ServiceManager,new object[]{DesktopIDStr}))==null)
								throw(new Exception("Can't create instance of \""+DesktopIDStr+"\""));
						}
						catch(Exception eException)
						{
							throw(new Exception(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace));
						}
					}
					else
						throw(new Exception("Can't GetTypeFromProgID(\""+ServiceManagerIDStr+"\")"));

					if((Param=ServiceManager.GetType().InvokeMember("Bridge_GetStruct",BindingFlags.InvokeMethod,null,ServiceManager,new object[]{PropertyValueIDStr}))==null)
						throw(new Exception("Can't create instance of \""+PropertyValueIDStr+"\""));
					Param.GetType().InvokeMember("Name",BindingFlags.SetProperty,null,Param,new object[]{"Hidden"});
					Param.GetType().InvokeMember("Value",BindingFlags.SetProperty,null,Param,new object[]{false});

					arg=new object[]{Param};

					Document=Desktop.GetType().InvokeMember("LoadComponentFromURL",BindingFlags.InvokeMethod,null,Desktop,new object[]{"private:factory/swriter","_blank",0,arg});
					//Document=Desktop.GetType().InvokeMember("LoadComponentFromURL",BindingFlags.InvokeMethod,null,Desktop,new object[]{"file:///"+DocumentSrcName,"_blank",0,arg});
					
					Text=Document.GetType().InvokeMember("getText",BindingFlags.InvokeMethod,null,Document,null);
					Cursor=Text.GetType().InvokeMember("CreateTextCursor",BindingFlags.InvokeMethod,null,Text,null);
					Text.GetType().InvokeMember("insertString",BindingFlags.InvokeMethod,null,Text,new object[]{Cursor,"Line# 1\n",false});
					Text.GetType().InvokeMember("insertString",BindingFlags.InvokeMethod,null,Text,new object[]{Cursor,"Line# 2",false});

					if ((Table = Document.GetType().InvokeMember("createInstance", BindingFlags.InvokeMethod, null, Document, new object[] { TextTableIdStr })) != null)
					{
						Table.GetType().InvokeMember("initialize",BindingFlags.InvokeMethod,null,Table,new object[]{2,2});
						Param = Text.GetType().InvokeMember("getEnd", BindingFlags.InvokeMethod, null, Text, null);
						Text.GetType().InvokeMember("insertTextContent", BindingFlags.InvokeMethod, null, Text, new object[] { Param, Table, false });
					}

					arg = new object[2];

					if ((Param = ServiceManager.GetType().InvokeMember("Bridge_GetStruct", BindingFlags.InvokeMethod, null, ServiceManager, new object[] { PropertyValueIDStr })) == null)
						throw (new Exception("Can't create instance of \"" + PropertyValueIDStr + "\""));
					Param.GetType().InvokeMember("Name", BindingFlags.SetProperty, null, Param, new object[] { "FilterName" });
					Param.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Param, new object[] { "writer_pdf_Export" });

					arg[0] = Param;

					if ((Param = ServiceManager.GetType().InvokeMember("Bridge_GetStruct", BindingFlags.InvokeMethod, null, ServiceManager, new object[] { PropertyValueIDStr })) == null)
						throw (new Exception("Can't create instance of \"" + PropertyValueIDStr + "\""));
					Param.GetType().InvokeMember("Name", BindingFlags.SetProperty, null, Param, new object[] { "CompressionMode" });
					Param.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Param, new object[] { "1" });

					arg[1] = Param;

					string
						DocumentDestName;

					if(File.Exists(DocumentDestName = (CurrentDirectory + "test_out.pdf")))
						File.Delete(DocumentDestName);

					DocumentDestName = DocumentDestName.Replace(Path.DirectorySeparatorChar, '/').Replace("#","%23");
					Document.GetType().InvokeMember("storeToURL", BindingFlags.InvokeMethod, null, Document, new object[] { "file:///" + DocumentDestName, arg });

					Document.GetType().InvokeMember("close", BindingFlags.InvokeMethod, null, Document, new object[] { true });
				}
				catch(Exception eException)
				{
					throw(new Exception(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace));					
				}
			}
			finally
			{
				if(Table!=null)
				{
					Marshal.ReleaseComObject(Table);
					Table=null;
				}	
				if(Cursor!=null)
				{
					Marshal.ReleaseComObject(Cursor);
					Cursor=null;
				}	
				if(Text!=null)
				{
					Marshal.ReleaseComObject(Text);
					Text=null;
				}	
				if(Param!=null)
				{
					Marshal.ReleaseComObject(Param);
					Param=null;
				}	
				if(Document!=null)
				{
					Marshal.ReleaseComObject(Document);
					Document=null;
				}	
				if(Desktop!=null)
				{
					Desktop.GetType().InvokeMember("terminate",BindingFlags.InvokeMethod,null,Desktop,null);
					Marshal.ReleaseComObject(Desktop);
					Desktop=null;
				}	
				if(ServiceManager!=null)
				{
					Marshal.ReleaseComObject(ServiceManager);
					ServiceManager=null;
				}	
			}
		}
	}
}
