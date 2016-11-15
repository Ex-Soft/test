//http://www.mazsoft.com/blog/post/2008/04/30/Code-sample-for-using-iTextSharp-PDF-library.aspx
//http://www.dotnetspider.com/resources/4257-Write-Pdf-file-document-using-itextsharp-DLL.aspx
//http://kuujinbo.info/cs/itext_img_hdr.aspx
using System;
using System.Web;

namespace TestiTextSharp
{
	public partial class _Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			SendOutPDF(new CustomReports().CreatePDF("Title: Sample 1"));
		}

		protected void SendOutPDF(System.IO.MemoryStream PDFData)
		{
			// Clear response content & headers
			Response.Clear();
			Response.ClearContent();
			Response.ClearHeaders();
			Response.ContentType = "application/pdf";
			Response.Charset = string.Empty;
			Response.Cache.SetCacheability(System.Web.HttpCacheability.Public);
			Response.AddHeader("Content-Disposition", "attachment; filename=" + Title.Replace(" ", "").Replace(":", "-") + ".pdf");
			Response.OutputStream.Write(PDFData.GetBuffer(), 0, PDFData.GetBuffer().Length);
			Response.OutputStream.Flush();
			Response.OutputStream.Close();
			Response.End();
		} 
	}
}
