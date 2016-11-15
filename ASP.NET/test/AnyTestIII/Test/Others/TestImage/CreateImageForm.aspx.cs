using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;

namespace AnyTest
{
	public class CreateImageForm : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			string
				FileNameBase="xpfirewall",
				FileExtBase=".bmp",
				FileNameSrc=FileNameBase+FileExtBase,
				FileNameOut=FileNameBase+"_out"+FileExtBase,
				FileName;

			ImageFormat
				iFormat=ImageFormat.Jpeg;

			if(!File.Exists(FileName=Server.MapPath(null)+Path.DirectorySeparatorChar+FileNameSrc))
				return;

			Bitmap
				oImage=new Bitmap(FileName);

			Graphics
				oGraphics=Graphics.FromImage(oImage);

			oGraphics.TextRenderingHint=TextRenderingHint.AntiAliasGridFit;

			Font
				font=new Font("Verdana",50,FontStyle.Regular);

			SolidBrush
				text=new SolidBrush(Color.Red);

			PointF
				pointF=new PointF(100,100);

			oGraphics.DrawString("Igor",font,text,pointF);

			if(File.Exists(FileName=Server.MapPath(null)+Path.DirectorySeparatorChar+FileNameOut))
				File.Delete(FileName);
			oImage.Save(FileName);

			Response.Clear();
			Response.ContentType="image/jpeg";
			oImage.Save(Response.OutputStream,iFormat);
			Response.Flush();
			Response.End();
			oGraphics.Dispose();
			oImage.Dispose();
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
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
