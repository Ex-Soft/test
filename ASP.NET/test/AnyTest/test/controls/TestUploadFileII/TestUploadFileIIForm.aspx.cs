using System;
using System.IO;
using System.Web;

namespace AnyTest
{
	public partial class TestUploadFileIIForm : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if(Request.Form.Count>0)
            {
                string[]
                    FormKeys = Request.Form.AllKeys;

                for (int i = 0; i < FormKeys.Length; ++i)
                {
                    string
                        tmpString = string.Format("Form[{0}]=\"{1}\"", FormKeys[i], Request.Form[FormKeys[i]]);
                }
            }

            if (Request.Files.Count > 0)
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
        }
	}
}
