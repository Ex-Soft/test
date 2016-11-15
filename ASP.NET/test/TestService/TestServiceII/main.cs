#define TEST_DOC_NET
//#define TEST_SMS_GATE

using System;
using System.Net;
using System.Text;
using System.IO;
using System.Xml;

namespace TestServiceII
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #if TEST_DOC_NET
                    TestDocNet();
                #endif

                #if TEST_SMS_GATE
                    TestSmsGate();
                #endif

                Console.WriteLine("oB!");
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
            Console.ReadLine();
        }

        #if TEST_DOC_NET
            static void TestDocNet()
            {
                try
                {
                    WebRequest
                        request = WebRequest.Create("http://nozhenko-s8k/DocNet/_layouts/DocNet/Service/ClientApi.asmx/GetDocumentSingInfo");

                    request.Method = "POST";
                    request.ContentType = "application/json; charset=utf-8";
                    request.Credentials = CredentialCache.DefaultCredentials;

                    System.DirectoryServices.AccountManagement.UserPrincipal
                        userPrincipal = System.DirectoryServices.AccountManagement.UserPrincipal.Current;

                    System.Security.Principal.WindowsIdentity
                        wi = System.Security.Principal.WindowsIdentity.GetCurrent();

                    System.Security.Principal.IPrincipal
                        iPrincipal = System.Threading.Thread.CurrentPrincipal;

                    string
                        userName = Environment.UserName,
                        userDomainName = Environment.UserDomainName;

                    string
                        postData = string.Format("{{ \"taskId\": {0}, \"user\": \"{1}\" }}", 1, wi.Name);

                    byte[]
                        byteArray = Encoding.UTF8.GetBytes(postData);

                    request.ContentLength = byteArray.Length;

                    Stream
                        dataStream = request.GetRequestStream();

                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();

                    WebResponse
                        response = request.GetResponse();

                    StreamReader
                        reader = new StreamReader(response.GetResponseStream());

                    string
                        result = reader.ReadToEnd().Trim();

                    reader.Close();
                    response.Close();
                }
                catch (Exception eException)
                {
                    Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                }
            }
        #endif

        #if TEST_SMS_GATE
            static void TestSmsGate()
            {
                try
                {
                    WebRequest
                        request = WebRequest.Create("http://sms.n3.com.ua/smsgateway.asmx/HeloWord");

                    request.ContentType = "text/xml";
                    request.Method = "POST";

                    request.Headers.Add(HttpRequestHeader.Authorization, "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes("sms-user:_KtybyUhfl_")));

                    request.ContentLength = 0;

                    WebResponse
                        response = request.GetResponse();

                    StreamReader
                        sr = new StreamReader(response.GetResponseStream());

                    string
                        result = sr.ReadToEnd().Trim();

                    XmlDocument
                        doc = new XmlDocument();

                    doc.LoadXml(result);

                    XmlNodeList
                        nodes = doc.GetElementsByTagName("string");

                    for (int i = 0; i < nodes.Count; ++i)
                        Console.WriteLine(nodes[i].FirstChild.Value);
                }
                catch (Exception eException)
                {
                    Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                }
            }
        #endif
    }
}
