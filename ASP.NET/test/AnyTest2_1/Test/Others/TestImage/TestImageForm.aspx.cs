using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace AnyTest2_1
{
	public partial class TestImageForm : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			ImageTest.ImageUrl = "TestResizeImageHandler.ashx?scale=" + HtmlInputHiddenScale.Value;
		}
	}

	public class ResizeImageClass
	{
		public static Bitmap ScaleBySize(Image Img, int Scale)
		{
			int
				destWidth=Img.Width*Scale/100,
				destHeight=Img.Height*Scale/100;

			Bitmap
				bm = new Bitmap(destWidth, destHeight, PixelFormat.Format24bppRgb);

			bm.SetResolution(Img.HorizontalResolution,Img.VerticalResolution);

			Graphics
				gr = Graphics.FromImage(bm);

			gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
			gr.DrawImage(Img, new Rectangle(0, 0, destWidth, destHeight), new Rectangle(0, 0, Img.Width, Img.Height), GraphicsUnit.Pixel);

			Img.Dispose();

			return (bm);
		}
	}
}