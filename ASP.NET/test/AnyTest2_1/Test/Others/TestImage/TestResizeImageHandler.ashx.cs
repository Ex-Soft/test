using System;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;

namespace AnyTest2_1
{
	/// <summary>
	/// Summary description for $codebehindclassname$
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	public class TestResizeImageHandler : IHttpHandler, IReadOnlySessionState
	{

		public void ProcessRequest(HttpContext context)
		{
			string
				Scale;

			if (!string.IsNullOrEmpty(Scale = HttpUtility.HtmlEncode(context.Request.QueryString["scale"])))
			{
				MemoryStream
					ms=new MemoryStream();

				ResizeImageClass.ScaleBySize(Image.FromFile(context.Server.MapPath(null) + Path.DirectorySeparatorChar + "TestImage.jpg"), Convert.ToInt32(Scale)).Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

				byte[]
					buffer = ms.ToArray();

				ms.Close();

				context.Response.ContentType = "image/jpeg";
				context.Response.OutputStream.Write(buffer, 0, buffer.Length);
				
				context.Response.Flush();
				context.Response.End();
			}
		}

		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
	}
}
