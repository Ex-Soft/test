using System;
using System.IO;

using unoidl.com.sun.star.lang;
using unoidl.com.sun.star.text;
using unoidl.com.sun.star.uno;
using unoidl.com.sun.star.bridge;
using unoidl.com.sun.star.frame;
using unoidl.com.sun.star.util;

namespace WriterEarly
{
	class WriterEarly
	{
		[STAThread]
		static void Main()
		{
			XComponentContext
				localContext=uno.util.Bootstrap.bootstrap();

			XMultiServiceFactory
				ServiceManager=(XMultiServiceFactory)localContext.getServiceManager();

			XComponentLoader
				Desktop=(XComponentLoader)ServiceManager.createInstance("com.sun.star.frame.Desktop");

			XComponent
				Document=Desktop.loadComponentFromURL("private:factory/swriter","_blank",0,new unoidl.com.sun.star.beans.PropertyValue[0]);

			XText
				Text=((XTextDocument)Document).getText();
			
			Text.setString("Hello I'm the first text!");

			XTextCursor
				Cursor=Text.createTextCursor();

			Text.insertString(Cursor,"Line# 1\n",false);
			Text.insertString(Cursor,"Line# 2",false);

			XTextTable
				Table;

			if ((Table = (XTextTable)((XMultiServiceFactory)Document).createInstance("com.sun.star.text.TextTable")) != null)
			{
				Table.initialize(2,2);
				Text.insertTextContent(Text.getEnd(),Table,false);
			}


			unoidl.com.sun.star.beans.PropertyValue[]
				Params=new unoidl.com.sun.star.beans.PropertyValue[2];

			unoidl.com.sun.star.beans.PropertyValue
				Param = new unoidl.com.sun.star.beans.PropertyValue();

			Param.Name = "FilterName";
			Param.Value = new uno.Any("writer_pdf_Export");
			Params[0]=Param;

			Param = new unoidl.com.sun.star.beans.PropertyValue();
			Param.Name = "CompressionMode";
			Param.Value = new uno.Any("1");
			Params[1] = Param;

			string
				CurrentDirectory = System.IO.Directory.GetCurrentDirectory(),
				DocumentDestName;

			CurrentDirectory = CurrentDirectory.Substring(0, CurrentDirectory.LastIndexOf("bin", CurrentDirectory.Length - 1)); 

			if (File.Exists(DocumentDestName = (CurrentDirectory + "test_out.pdf")))
				File.Delete(DocumentDestName);

			DocumentDestName = DocumentDestName.Replace(Path.DirectorySeparatorChar, '/').Replace("#", "%23");

			((XStorable)Document).storeToURL("file:///" + DocumentDestName, Params);
			((XCloseable)Document).close(true);
		}
	}
}
