using System;
using System.IO;
using System.Web;

namespace AnyTest
{
	/// <summary>
	/// Summary description for UploadFileForm.
	/// </summary>
	public class UploadFileForm : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlInputFile inpFileName;
		protected System.Web.UI.WebControls.TextBox inpDestPath;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnUpload;
		
		private void Page_Init(object sender, System.EventArgs e)
		{
			//
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			inpDestPath.Text=Server.MapPath(null)+Path.DirectorySeparatorChar+"dest";
		}

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
			this.btnUpload.ServerClick += new EventHandler(btnUpload_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);
			this.Init += new System.EventHandler(this.Page_Init);

		}
		#endregion

		private void btnUpload_ServerClick(object sender, EventArgs e)
		{
			HttpPostedFile
				f_ptr=inpFileName.PostedFile;

			int
				len=f_ptr.ContentLength;

			byte[]
				buff=new byte[len];

			f_ptr.InputStream.Read(buff,0,len);

			string
				FileName=inpDestPath.Text+Path.DirectorySeparatorChar+Path.GetFileName(f_ptr.FileName);

			FileStream
				f_local=new FileStream(FileName,FileMode.Create);

			f_local.Write(buff,0,len);

			f_local.Close();
		}
	}
}