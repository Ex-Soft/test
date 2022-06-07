//#define TEST_DOWNLOAD

using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using static System.Console;

namespace TestHttpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();

            try
            {
                #if TEST_DOWNLOAD
                string
                    currentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location,
                    url = "http://st-drive.systtech.ru/9b8568edde3f4cbb9e375101a0f396f4";

                if (currentDirectory.IndexOf("bin") != -1)
                    currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));

                string
                    fileName = Path.Combine(currentDirectory, "resources.jpg"),
                    message;

                WriteLine(message = $"Downloading \"{url}\" starting...");
                Debug.WriteLine(message);

                HttpStatusCode statusCode;
                var response = client.GetAsync(url).Result;
                if ((statusCode = response.StatusCode) == HttpStatusCode.OK)
                {
                    byte[] content;
                    if ((content = response.Content.ReadAsByteArrayAsync().Result) != null)
                    {
                        if (File.Exists(fileName))
                            File.Delete(fileName);

                        File.WriteAllBytes(fileName, content);
                    }
                    else
                    {
                        WriteLine(message = $"Response stream is null (\"{url}\")");
                        Debug.WriteLine(message);
                    }
                }

                WriteLine(message = $"Downloading \"{url}\" finished with statusCode \"{statusCode}\" ({(int)statusCode})");
                Debug.WriteLine(message);
                #endif
            }
            catch (HttpRequestException eException)
            {
                WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
            catch (WebException eException)
            {
                WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
            catch (Exception eException)
            {
                WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
            finally
            {
                client?.Dispose();
            }
        }
    }
}
