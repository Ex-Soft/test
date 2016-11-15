using System;
using System.IO;
using System.Xml;
using System.Text;

namespace TestEncoding
{
	class Program
	{
		static void Main(string[] args)
		{
			XmlDocument
				docEn = CreateXml(false),
				docRu = CreateXml(true);

			int
				docEnLength = docEn.InnerXml.Length,
				docRuLength = docRu.InnerXml.Length;

			byte[]
				bytesEnUTF8 = System.Text.Encoding.UTF8.GetBytes(docEn.InnerXml), // 61
				bytesRuUTF8 = System.Text.Encoding.UTF8.GetBytes(docRu.InnerXml), // 65
				bytesEnASCII = System.Text.Encoding.ASCII.GetBytes(docEn.InnerXml), // 61
				bytesRuASCII = System.Text.Encoding.ASCII.GetBytes(docRu.InnerXml); // 61

			Write(bytesEnUTF8, docEn, "en_utf8");
			Write(bytesEnASCII, docEn, "en_1251");
			Write(bytesRuUTF8, docRu, "ru_utf8");
			Write(bytesRuASCII, docRu, "ru_1251");
		}

		static void Write(byte[] bytes, XmlDocument doc, string FileNamePrefix)
		{
			string
				FileName;

			FileStream
				fs;

			XmlTextWriter
				xtw;

			FileName = FileNamePrefix + ".xml";
			fs = new FileStream(FileName, FileMode.Create, FileAccess.Write);
			fs.Write(bytes, 0, bytes.Length);
			fs.Close();

			FileName = FileNamePrefix + "_.xml";
			fs = new FileStream(FileName, FileMode.Create, FileAccess.Write);
			xtw = new XmlTextWriter(fs, Encoding.UTF8); // add BOM (Byte-Order-Mark): EF BB BF (UTF-8) at the begin of file
			doc.WriteContentTo(xtw);
			xtw.Flush();
			fs.Close();

			FileName = FileNamePrefix + "__.xml";
			fs = new FileStream(FileName, FileMode.Create, FileAccess.Write);
			xtw = new XmlTextWriter(fs, Encoding.GetEncoding(1251)); // add BOM (Byte-Order-Mark): EF BB BF (UTF-8) at the begin of file
			doc.WriteContentTo(xtw);
			xtw.Flush();
			fs.Close();
		}

		static XmlDocument CreateXml(bool WithCyrillic)
		{
			XmlDocument
				doc = new XmlDocument();

			XmlNode
				node = doc.CreateXmlDeclaration("1.0", "utf-8", null);

			doc.AppendChild(node);
			node = doc.CreateElement("message");
			doc.AppendChild(node);
			node.AppendChild(doc.CreateTextNode(WithCyrillic ? "Тест" : "Test"));

			return doc;
		}
	}
}
