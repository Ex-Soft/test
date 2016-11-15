using System;
using System.IO;
using System.Net;
using System.Threading;

namespace DDoS
{
    public class DDoSThread : IDisposable
    {
        ulong
            id,
            numberOfCycles,
            failed;

        string
            url;

        Thread
            thread;

        bool
            disposed;

        StreamWriter
            file;

   		public DDoSThread(ulong id, string url, ulong numberOfCycles, bool isBackground)
		{
			this.disposed = false;

            this.id = id;
   		    this.url = url;
   		    this.numberOfCycles = numberOfCycles;
   		    this.failed = 0;

			thread = new Thread(new ThreadStart(this.run));
			thread.Name = string.Format("Thread# {0}", id);
			thread.IsBackground = isBackground;

            string
                fileName = string.Format("{0}.txt", thread.Name);

            if (File.Exists(fileName))
                File.Delete(fileName);

            try
            {
                file = new StreamWriter(fileName, true, System.Text.Encoding.UTF8);
            }
            catch
            {
                GC.SuppressFinalize(this);
                throw;
            }

            if (!file.AutoFlush)
                file.AutoFlush = true;

			thread.Start();
		}

        public void run()
        {
            file.WriteLine("{0}\tThread Id: {1} started...", DateTime.Now.ToString("HH:mm:ss.fffffff"), thread.Name);

            for (ulong i = 0; i < numberOfCycles; ++i)
                request(i);

                file.WriteLine("{0}\tThread Id: {1} finished (failed: {2})", DateTime.Now.ToString("HH:mm:ss.fffffff"), thread.Name, failed);
        }

        public void request(ulong i)
        {
            file.WriteLine("{0}\trequest# {1} started...", DateTime.Now.ToString("HH:mm:ss.fffffff"), i);

            HttpWebRequest
                webRequest;

            HttpWebResponse
                webResponse = null;

            StreamReader
                streamReader;

            webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "GET";
            try
            {
                webResponse = (HttpWebResponse)webRequest.GetResponse();
                streamReader = new StreamReader(webResponse.GetResponseStream());

                string
                    response = streamReader.ReadToEnd();

                streamReader.Close();
                webResponse.Close();

                file.WriteLine("Connection: {0}, StatusCode: {1}", webResponse.Headers["Connection"], webResponse.StatusCode.ToString());
            }
            catch (Exception eException)
            {
                if(webResponse!=null)
                    file.WriteLine("Connection: {0}, StatusCode: {1}", webResponse.Headers["Connection"], webResponse.StatusCode.ToString());

                file.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                failed++;
            }

            file.WriteLine("{0}\trequest# {1} finished", DateTime.Now.ToString("HH:mm:ss.fffffff"), i);
        }

        public bool IsAlive
        {
            get { return thread != null ? thread.IsAlive : false; }
        }

        public ThreadState ThreadState
        {
            get { return thread != null ? thread.ThreadState : ThreadState.Unstarted; }
        }

   		~DDoSThread()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					if (file != null)
						file.Dispose();
				}
				disposed = true;
			}
		}
    }
}
