using System;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;

namespace AnyTestII
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
					ms = new MemoryStream();

				string
					FileName = "TestImage.jpg";

				ResizeImageClass.ScaleBySize(Image.FromFile(context.Server.MapPath(null) + Path.DirectorySeparatorChar + FileName), Convert.ToInt32(Scale)).Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

				byte[]
					buffer = ms.ToArray();

				ms.Close();

				if (!string.IsNullOrEmpty(context.Request.QueryString["fromiframe"]))
				{
					context.Response.AddHeader("Content-disposition", "attachment; filename=" + FileName);
					context.Response.ContentType = "application/octet-stream";
				}
				else
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
