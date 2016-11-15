using System;
using System.Web;
using System.IO;

namespace AnyTestII
{
	public partial class TestUploadFileByAJAXUploadForm : System.Web.UI.Page
	{
		public const string
			StrBeginJS = "\n<script type=\"text/javascript\">\n<!--\n",
			StrEndJS = "\n// -->\n</script>";

		protected void Page_Load(object sender, EventArgs e)
		{
			bool
				Result;

			if (Result = Request.Files.Count > 0)
			{
				HttpFileCollection
					Files = Request.Files;

				string[]
					Keys = Files.AllKeys;

				for (int i = 0; i < Keys.Length; ++i)
				{
					if (Files[Keys[i]].ContentLength == 0)
						continue;

					string
						FileName = Server.MapPath(null) + Path.DirectorySeparatorChar + Path.GetFileName(Files[Keys[i]].FileName);

					if (File.Exists(FileName))
						File.Delete(FileName);

					Files[Keys[i]].SaveAs(FileName);
				}
			}

			System.Threading.Thread.Sleep(3000);

			Response.Write(StrBeginJS + "parent.stopUpload(" + Result.ToString().ToLower() + ");" + StrEndJS);
			Response.End();
		}
	}
}
