using System;
using System.IO;
using System.IO.Compression;
using System.Web;

namespace TestHttpModuleGZipOverride
{
    public class TestHttpModuleGZipOverride : IHttpModule
    {
    	const string
			GZIP = "gzip",
			DEFLATE = "deflate",
			PageName = "TestHttpModuleGZipOverride.html";

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
				|| (currentEncoding = encodings.ToLower().Contains(GZIP) ? GZIP : ((encodings.ToLower().Contains(DEFLATE)) ? DEFLATE : string.Empty)) == string.Empty)
				return;

			response.AppendHeader("Content-Encoding", currentEncoding);
			response.CacheControl = "no-cache";

			if (app.Context.Cache[key = currentEncoding + "_" + app.Context.Request.Url.Segments[app.Context.Request.Url.Segments.Length-1]] != null)
			{
				byte[]
					tmpArray = (byte[])app.Context.Cache[key];

				response.BinaryWrite(tmpArray);
				response.End();
			}
			else
				response.Filter = new MyStream(response.Filter, CompressionMode.Compress, app, key);
        }
    }

	public class MyStream : Stream
	{
		Stream
			_stream;

		CompressionMode
			_mode;

		HttpApplication
			_app;

		string
			_key;

		public MyStream(Stream stream, CompressionMode mode, HttpApplication app, string key)
		{
			this._stream = stream;
			this._mode = mode;
			this._app = app;
			this._key = key;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return _stream.Read(buffer, offset, count);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			byte[]
				bufferToWrite = buffer;

			if (_mode == CompressionMode.Compress)
			{
				using (MemoryStream ms = new MemoryStream())
				{
					using (GZipStream tmpGZipStream = new GZipStream(ms, CompressionMode.Compress, false))
					{
						tmpGZipStream.Write(buffer, 0, count);
					}
					_app.Context.Cache.Insert(_key,bufferToWrite=ms.ToArray());
				}
			}

			_stream.Write(bufferToWrite, offset, bufferToWrite.Length);
		}

		public override void SetLength(long value)
		{
			throw new NotImplementedException("NotSupported");
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException("NotSupported");
		}

		public override void Flush()
		{
			if (this._stream == null)
			{
				throw new ObjectDisposedException(null, "ObjectDisposed_StreamClosed");
			}
		}

		public override long Position
		{
			get
			{
				throw new NotSupportedException("NotSupported");
			}
			set
			{
				throw new NotSupportedException("NotSupported");
			}
		}

		public override long Length
		{
			get
			{
				throw new NotSupportedException("NotSupported");
			}
		}

		public override bool CanWrite
		{
			get
			{
				if (this._stream == null)
				{
					return false;
				}
				return ((this._mode == CompressionMode.Compress) && this._stream.CanWrite);
			}
		}

		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		public override bool CanRead
		{
			get
			{
				if (this._stream == null)
				{
					return false;
				}
				return ((this._mode == CompressionMode.Decompress) && this._stream.CanRead);
			}
		}
	}
}