using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestException
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSyncClick(object sender, EventArgs e)
        {
            var result = LoadSync("http://www.google.com.ua", "GET");
            Debug.WriteLine(result);
        }

        int LoadSync(string uri, string method)
        {
            var content = string.Empty;

            /*try
            {
                var request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = method;

                using (var response = (HttpWebResponse)request.GetResponse())
                using (var streamResponse = response.GetResponseStream())
                using (var streamResponse = response.GetResponseStream())
                using (var streamReader = new StreamReader(streamResponse))
                {
                    content = streamReader.ReadToEnd();
                }
            }
            catch (Exception eException)
            {
                Debug.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }*/

            return content.Length;
        }

        private async void btnAsyncClick(object sender, EventArgs e)
        {
            int result;
            Task<int> task;

            try
            {
                //result = await LoadAsync("http://www.google.com.u_a", "GET");

                task = LoadAsync("http://www.google.com.u_a", "GET");
                result = await task;

                Debug.WriteLine(result);
            }
            catch (Exception eException)
            {
                Debug.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }

        async Task<int> LoadAsync(string uri, string method)
        {
            var content = string.Empty;

            //try
            {
                var request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = method;

                using (var response = (HttpWebResponse)await request.GetResponseAsync())
                using (var streamResponse = response.GetResponseStream())
                using (var streamReader = new StreamReader(streamResponse))
                {
                    content = await streamReader.ReadToEndAsync();
                }
            }
            //catch (Exception eException)
            //{
            //    Debug.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            //}

            return content.Length;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            var factory = new TaskFactory(uiScheduler);
            try
            {
                await factory.StartNew(() => MethodWithException1())
                    .ContinueWith(t => MethodWithException2(), uiScheduler)
                    .ContinueWith(t => MethodWithException3(), uiScheduler);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("catch (Exception ex)");
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
        private void MethodWithException1()
        {
            throw new Exception("Tadam# 1!!!");
        }
        private void MethodWithException2()
        {
            throw new Exception("Tadam#2 !!!");
        }
        private void MethodWithException3()
        {
            throw new Exception("Tadam# 3!!!");
        }
    }
}
