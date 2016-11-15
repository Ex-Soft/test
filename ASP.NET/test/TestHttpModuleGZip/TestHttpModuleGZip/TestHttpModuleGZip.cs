using System;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Web;

namespace TestHttpModuleGZip
{
    public class TestHttpModuleGZip : IHttpModule
    {
    	const string
			GZIP = "gzip",
			DEFLATE = "deflate",
			PageName = "TestHttpModuleGZip.html";

        public void Dispose()
        {}

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
			HttpApplication
				app = (HttpApplication)sender;

        	HttpResponse
        		response = app.Context.Response;

        	string
        		encodings,
				currentEncoding,
				key;

			if(!app.Context.Request.Path.Contains(PageName)
				|| app.Context.Request["HTTP_X_MICROSOFTAJAX"] != null
				|| (encodings = app.Context.Request.Headers.Get("Accept-Encoding")) == null
				|| (currentEncoding = encodings.ToLower().Contains(GZIP) ? GZIP : ((encodings.ToLower().Contains(DEFLATE)) ? DEFLATE : string.Empty))==string.Empty)
				return;
			
			//response.Filter = new GZipStream(response.Filter, CompressionMode.Compress);
			response.AppendHeader("Content-Encoding", currentEncoding);
			//response.CacheControl = "no-cache";

			key=currentEncoding + "_" + Path.GetFileName(app.Context.Request.Url.LocalPath);

			byte[]
				tmpArray;

			if (app.Context.Cache[key] == null)
			{
				HttpWebRequest
					tmpRequest = (HttpWebRequest)WebRequest.Create(app.Context.Request.Url.OriginalString);

				using (HttpWebResponse tmpResponse = tmpRequest.GetResponse() as HttpWebResponse)
				{
					Stream
						responseStream = tmpResponse.GetResponseStream();

					using (MemoryStream ms = CompressResponse(responseStream, app, key))
					{
						tmpArray = ms.ToArray();
						app.Context.Cache.Insert(key, tmpArray);
					}
				}
			}
			else
				tmpArray = (byte[])app.Context.Cache[key];

			response.BinaryWrite(tmpArray);
			response.End();
        }

		private static MemoryStream CompressResponse(Stream responseStream, HttpApplication app, string key)
		{
			MemoryStream
				dataStream = new MemoryStream();

			StreamCopy(responseStream, dataStream);
			responseStream.Dispose();

			byte[]
				buffer = dataStream.ToArray();

			dataStream.Dispose();

			MemoryStream
				ms = new MemoryStream();

			Stream
				compress = null;

			compress = new GZipStream(ms, CompressionMode.Compress);
			compress.Write(buffer, 0, buffer.Length);
			compress.Dispose();

			return ms;
		}

		private static void StreamCopy(Stream input, Stream output)
		{
			byte[]
				buffer = new byte[2048];

			int
				read;

			do
			{
				read = input.Read(buffer, 0, buffer.Length);
				output.Write(buffer, 0, read);
			} while (read > 0);
		}
    }
}