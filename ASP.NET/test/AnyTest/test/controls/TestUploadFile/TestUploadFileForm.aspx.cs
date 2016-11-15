using System;
using System.Web;

namespace AnyTest
{
	public partial class TestUploadFileForm : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void ButtonSubmit_Click(object sender, EventArgs e)
		{
			HttpPostedFile
                file;

			for (int i = 0; i < Request.Files.Count; ++i)
				file = Request.Files[i];

			string[]
				Files=Request.Files.AllKeys;

			for(int ii=0; ii<Files.Length; ++ii)
			{
				file = Request.Files[Files[ii]];
				file = Request.Files[ii];
			}

			LabelInfo.Text = string.Empty;

			if (HtmlInputFile1.PostedFile.ContentLength != 0)
			{
				LabelInfo.Text += "&lt;input type=\"file\"&gt;<br />";
				LabelInfo.Text += "FileName: \"" + HtmlInputFile1.PostedFile.FileName + "\"<br />";
				LabelInfo.Text += "ContentType: \"" + HtmlInputFile1.PostedFile.ContentType + "\"<br />";
				LabelInfo.Text += "ContentLength: \"" + HtmlInputFile1.PostedFile.ContentLength + "\"<br />";
			}

			if (FileUpload1.HasFile)
			{
				if (!string.IsNullOrEmpty(LabelInfo.Text))
					LabelInfo.Text += "<hr />";

				LabelInfo.Text += "&lt;asp:FileUpload&gt;<br />";
				LabelInfo.Text += "FileName: \"" + FileUpload1.FileName + "\"<br />";
				LabelInfo.Text += "PostedFile.FileName: \"" + FileUpload1.PostedFile.FileName + "\"<br />";
				LabelInfo.Text += "PostedFile.ContentType: \"" + FileUpload1.PostedFile.ContentType + "\"<br />";
				LabelInfo.Text += "PostedFile.ContentLength: \"" + FileUpload1.PostedFile.ContentLength + "\"<br />";
			}
		}
	}
}
