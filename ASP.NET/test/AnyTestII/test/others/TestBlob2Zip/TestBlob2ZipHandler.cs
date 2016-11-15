using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Checksums;

namespace AnyTestII
{
	public class TestBlob2ZipHandler : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			context.Response.CacheControl = "no-cache";
			context.Response.Expires = -1;
			context.Response.ClearHeaders();
			context.Response.ClearContent();

			SqlConnection
				conn = null;

			SqlDataReader
				rdr = null;

			MemoryStream
				ms = null;

			ZipOutputStream
				os = null;

			try
			{
				try
				{
					string
						ConnectionString = "server=alpha_web;Initial Catalog=pretensionsav;User Id=sa;Pwd=developer";

					long
						Id = 39788;

					conn = new SqlConnection(ConnectionString);
					conn.Open();

					SqlCommand
						cmd = conn.CreateCommand();

					cmd.CommandType = CommandType.Text;
					cmd.CommandText = "select * from attachments where pretensionid=@pretensionid";
					cmd.Parameters.Add("@pretensionid", SqlDbType.BigInt).Value = Id;

					rdr = cmd.ExecuteReader();
					if (rdr.HasRows)
					{
						ms = new MemoryStream();
						os = new ZipOutputStream(ms);
						os.SetLevel(9);

						if (ZipConstants.DefaultCodePage != 866)
							ZipConstants.DefaultCodePage = 866;

						Crc32
							crc = new Crc32();

						while (rdr.Read())
						{
							byte[]
								Blob = (byte[])rdr["FileData"];

							ZipEntry
								entry = new ZipEntry((string)rdr["FileName"]);

							crc.Reset();
							crc.Update(Blob);
							entry.Crc = crc.Value;
							os.PutNextEntry(entry);
							os.Write(Blob, 0, Blob.Length);
						}
						os.Finish();
						context.Response.AddHeader("Content-disposition", "attachment; filename=pret_" + Id + ".zip");
						context.Response.ContentType = "application/octet-stream";
						context.Response.OutputStream.Write(ms.ToArray(), 0, (int)ms.Length);
						os.Close();
					}
					else
						context.Response.Write("<html><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /><title>Прикрепленные файлы</title></head><body><h1 style=\"text-align: center; \">Прикрепленные файлы - отсутствуют</h1></body></html>");

					rdr.Close();
					conn.Close();
				}
				catch (Exception eException)
				{
					context.Response.Write(eException.Message);
				}
			}
			finally
			{
				if (os != null && os.CanWrite)
					os.Close();

				if (ms != null && ms.CanWrite)
					ms.Close();

				if (rdr != null && !rdr.IsClosed)
					rdr.Close();

				if (conn != null && conn.State == ConnectionState.Open)
					conn.Close();
			}
		}

		public bool IsReusable
		{
			get { return false; }
		}
	}
}
