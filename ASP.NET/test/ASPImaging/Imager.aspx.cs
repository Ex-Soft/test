using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace ASPImaging
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class Imager : System.Web.UI.Page
	{
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			string strBasePath = Server.MapPath(".");

			if (Request.QueryString["type"]==null)
			{
				Bitmap objImage = new Bitmap(strBasePath + "\\images\\fruity.jpg");
				objImage.Save(Response.OutputStream,ImageFormat.Jpeg);
				objImage.Dispose();
			}
			else
			{
				if (Request.QueryString["type"].ToString()=="counter")
				{
					//counter
					Bitmap oCounter;
					Graphics oGraphics;

					oCounter = new Bitmap(23,15);
					oGraphics = Graphics.FromImage(oCounter);
		
					Bitmap objImage = new Bitmap(strBasePath + "\\images\\1.gif");
					oGraphics.DrawImage(objImage,0,0);
					objImage = new Bitmap(strBasePath + "\\images\\2.gif");
					oGraphics.DrawImage(objImage,11,0);
					oCounter.Save(Response.OutputStream,ImageFormat.Jpeg);
					objImage.Dispose();
					oCounter.Dispose();
				}
				else if (Request.QueryString["type"].ToString()=="zoom")
				{
					//zoom
					Bitmap oImg;
					System.Drawing.Image oI,oItemp;
					Graphics oGraphics;

					//using a bitmap .net for some reason is not able to scoop or zoom
					//portions of image.. but it works with the image class.. 
					// so we will load the image as a 'Image' rather than a bitmap.
					oI = System.Drawing.Image.FromFile(strBasePath + "\\images\\fruity.jpg");

					//zooming can be done two ways.
					////1. by keeping size constant and zooming a portion or a src REct of the image
					////2. or by creating a larger image of the original image
					///////Type 2. is as in example 3.
			
					/////zoom a portion
					oItemp=oI;
					oImg=new Bitmap(oI.Width,oI.Height,PixelFormat.Format24bppRgb);
					oGraphics = Graphics.FromImage(oImg);

					string XPos, YPos;
					string[] tempArrX=null;
					string[] tempArrY=null;

					XPos = Request.QueryString["x"].ToString();
					YPos = Request.QueryString["y"].ToString();

					if (XPos!=string.Empty && YPos!=string.Empty)
					{
						string delimStr = ",";
						char [] delimiter = delimStr.ToCharArray();

						tempArrX=XPos.Split(delimiter);
						tempArrY=YPos.Split(delimiter);

						//we store the x and y positions clicked everytime
						//by user in a hidden field. 
						//so if user clicks 3 times.. we enlarge the image thrice.
						//appropriately everytime at the portions user clicked.
						int iIndex;
						for(iIndex=0;iIndex<tempArrX.Length ;iIndex++)
						{
							//the logic followed here is.. 
							//get the portion around the click areaa..
							//60% of the size of actual image
							/////
							//enlarge this portion to the size of the image itself.

							//get the 60% area around the clik
							float iPortionWidth=(0.60f*oI.Width);
							float iPortionHeight=(0.60f*oI.Height);

							//calculate top x,y of the portion to enlarge.
							float iStartXpos = float.Parse(tempArrX[iIndex])-(iPortionWidth/2);
							float iStartYPos = float.Parse(tempArrY[iIndex])-(iPortionHeight/2);
							
							//set destination and source rectangle areas
							RectangleF desRect = new RectangleF(
								0,
								0,
								oI.Width,
								oI.Height);

							RectangleF sourceRect = new RectangleF(
								iStartXpos,
								iStartYPos,
								iPortionWidth,
								iPortionHeight);

							//get the portion of image(defined by sourceRect)
							//and enlarge it to desRect size...gives a zoom effect.
							////if image has high resolution.. effect will be good.
							oGraphics.DrawImage(oItemp,desRect,sourceRect,GraphicsUnit.Pixel);

							//copy the enlarged portion into oItemp 
							//so that further zooming operation uses this image.
							////this is to ensure that when image is enlarged multiple times
							////it doesnt enlarge from the original everytime.
							IntPtr hBitmap = oImg.GetHbitmap(Color.Blue);  //create pointer to bitmap
							oItemp=System.Drawing.Image.FromHbitmap(hBitmap);  //use pointer and load bitmap into oItemp
						}						
					}				
					//oGraphics = Graphics.FromImage(oImg);
					//oGraphics.DrawImage(oItemp,oI.Width, oI.Height);
					oImg.Save(Response.OutputStream,ImageFormat.Jpeg);
					oImg.Dispose();
					oI.Dispose();
					oItemp.Dispose();
				}
				else
				{
					//just zoom to a larger image.
					Bitmap oImg, oImgTemp;
					oImgTemp = new Bitmap(strBasePath + "\\images\\fruity.jpg");
					oImg = new Bitmap(oImgTemp,600,400);
					Graphics oGraphics;
					oGraphics = Graphics.FromImage(oImg);
					oImg.Save(Response.OutputStream,ImageFormat.Jpeg);
					oGraphics.DrawImage(oImg,0,0);
					oImgTemp.Dispose();
					oImg.Dispose();
				}
			}

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
