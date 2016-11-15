#define TEST_SERVICE_API
//#define TEST_HTTP_REQUEST_POST_BINARY
#define TEST_HTTP_REQUEST_GET_BINARY
//#define TEST_KS
//#define TEST_HTTP_REQUEST
//#define TEST_HTTP_REQUEST_GET
//#define WITH_PROXY
//#define WITH_AUTHENTICATION

using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.IO;
using System.Xml;
using System.Drawing;
using System.Drawing.Imaging;

namespace TestWebRequest
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
                #if TEST_HTTP_REQUEST_POST_BINARY
                    PostBinary();
                #endif

                #if TEST_HTTP_REQUEST_GET_BINARY
                    GetBinary();
                #endif

                #if TEST_HTTP_REQUEST_GET
                    string
                        strURL = "http://www.google.com.ua/",
                        strHTML;

                    HttpWebRequest
                        objWebRequest;

                    HttpWebResponse
                        objWebResponse;

                    StreamReader
                        streamReader;

                    StreamWriter
                        OutputFile;

                    strURL = "http://www.sql.ru/forum/actualthread.aspx?bid=34&tid=531725&pg=1";
                    objWebRequest = (HttpWebRequest)WebRequest.Create(strURL);
                    objWebRequest.Method = "GET";
                    try
                    {
                        objWebResponse = (HttpWebResponse)objWebRequest.GetResponse();
                        streamReader = new StreamReader(objWebResponse.GetResponseStream());
                        strHTML = streamReader.ReadToEnd();
                        OutputFile = new StreamWriter("PageSource.html", false, System.Text.Encoding.GetEncoding(1251));
                        OutputFile.Write(strHTML);
                        OutputFile.Close();
                        streamReader.Close();
                        objWebResponse.Close();
                    }
                    catch (WebException eException)
                    {
                        Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                    }

                    objWebRequest.Abort();
                #endif

				#if TEST_HTTP_REQUEST
					HttpWebRequest
                        request = (HttpWebRequest)WebRequest.Create("http://cast.radiogroup.com.ua:8000/jamfm");

                    //request.Credentials = CredentialCache.DefaultCredentials;
					request.Proxy = new WebProxy("proxy.softline.main", 3249);
					request.Proxy.Credentials = new NetworkCredential("nozhenko", "", "softline");

					HttpWebResponse
						response = (HttpWebResponse)request.GetResponse();

                    StreamReader
                        StreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);

                    string
                        tmpString = StreamReader.ReadToEnd().Trim();
				#endif

                #if TEST_KS
					HttpWebRequest
                        request = (HttpWebRequest)WebRequest.Create("http://sdp1.cpa.net.ua:8080/cpa2/receiver");

					request.Proxy = new WebProxy("dit-tmg.mc.gcf", 3128);
					request.Proxy.Credentials = new NetworkCredential("nozhenko-i", "", "mc");
                    request.ContentType = "text/xml";
                    request.Method = "POST";
                    request.Headers.Add(HttpRequestHeader.Authorization, "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes("entry:password")));

                    string
                        msg = @"<?xml version=""1.0"" encoding=""UTF-8""?><message bearer=""SMS""><sn>101987</sn><sin>380672467979</sin><body content-type=""text/plain"">Test Тест</body></message>";

                    XmlDocument
                        doc = new XmlDocument();

                    doc.LoadXml(msg);

                    byte[]
                        bytes = System.Text.Encoding.UTF8.GetBytes(doc.InnerXml);

                    request.ContentLength = bytes.Length;

                    Stream
                        os = request.GetRequestStream();

                    os.Write(bytes, 0, bytes.Length);
                    os.Close();

					HttpWebResponse
						response = (HttpWebResponse)request.GetResponse();

                    StreamReader
                        StreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);

                    string
                        tmpString = StreamReader.ReadToEnd().Trim();

                    doc = new XmlDocument();
                    doc.LoadXml(tmpString);

                    XmlNodeList
                        status = doc.GetElementsByTagName("status");
                #endif

            }
			catch (Exception eException)
			{
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
			}

            Console.ReadLine();
		}

        #if TEST_HTTP_REQUEST_GET_BINARY
            static void GetBinary()
            {
                try
                {
                    string
                        currentDirectory = Directory.GetCurrentDirectory(),
                        //fileName = "TestImageII.jpg",
                        //fileName = "4C2D55E440AA44D9AB21161048F307AC.jpg",
                        fileName = "4C2D55E440AA44D9AB21161048F307AE.jpg",
                        //url = "http://bash.org.ru/";
                        //url = "http://nozhenko-s8k/DocNet/DnLists/IncomingDocs/00000000000000002.pdf";
                        url = "http://89.249.23.82:88/api/image";

                    currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));

                    #if TEST_SERVICE_API
                        url += "/" + Path.GetFileNameWithoutExtension(fileName);
                    #endif

                    HttpWebRequest
                        request = (HttpWebRequest)WebRequest.Create(url);

                    #if WITH_PROXY
                        request.Proxy = new WebProxy("proxy.softline.main", 3249);
                        request.Proxy.Credentials = new NetworkCredential("nozhenko", "", "softline");
                    #endif

                    #if WITH_AUTHENTICATION
                        request.Credentials = CredentialCache.DefaultCredentials; // new NetworkCredential("nozhenko", "");
                    #endif

                    HttpWebResponse
                        response = (HttpWebResponse)request.GetResponse();

                    Console.WriteLine("StatusCode: {0} ({1}) StatusDescription: \"{2}\"", response.StatusCode, (int)response.StatusCode, response.StatusDescription);

                    Stream
                        responseStream = response.GetResponseStream();

                    MemoryStream
                        memoryStream = new MemoryStream();

                    int
                        count = 0;

                    byte[]
                        result,
                        buffer=new byte[4096];

                    do
                    {
                        count = responseStream.Read(buffer, 0, buffer.Length);
                        memoryStream.Write(buffer, 0, count);
                    } while (count != 0);

                    result = memoryStream.ToArray();

                    if(File.Exists(fileName = Path.Combine(currentDirectory, string.Format("{0}_{1}_{2}", Path.GetFileNameWithoutExtension(fileName), "get", Path.GetExtension(fileName)))))
                        File.Delete(fileName);

                    BinaryWriter
                        binaryWriter=new BinaryWriter(new FileStream(fileName, FileMode.Create, FileAccess.Write));

                    binaryWriter.Write(result);
                    binaryWriter.Close();
                }
                catch (Exception eException)
                {
                    Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                }
            }
        #endif

        #if TEST_HTTP_REQUEST_POST_BINARY
            static void PostBinary()
            {
                string
                    currentDirectory = Directory.GetCurrentDirectory(),
                    //fileName = "TestImageII.jpg",
                    //fileName = "4C2D55E440AA44D9AB21161048F307AC.jpg",
                    fileName = "4C2D55E440AA44D9AB21161048F307AE.jpg",
                    //url = "http://localhost:1549/test/controls/TestUploadFileII/TestUploadFileIIForm.aspx",
                    url = "http://89.249.23.82:88/api/image",
                    //contentType = "image/png";
                    contentType = "image/jpeg";

                currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));

                fileName = Path.Combine(currentDirectory, fileName);

                //RFC1867

                NameValueCollection
                    nvc = new NameValueCollection { { "HtmlInput1", "HtmlInput1Value" }, { "HtmlInput2", "HtmlInput2Value" } };
                    //nvc = new NameValueCollection { { "__VIEWSTATE", "/wEPDwUKMTc2MTg4NDc4NmRkHpNhKPGyGuhBzOewLlepjNADAm0=" } };

                //HttpUploadFile(url, fileName, "File1", contentType, nvc);
                //HttpUploadFileII(url, fileName, "File1", contentType, nvc);
                
                HttpStatusCode
                    httpStatusCode;

                byte[]
                    fileContent = File.ReadAllBytes(fileName);

                HttpUploadFile(url+Path.AltDirectorySeparatorChar+Path.GetFileNameWithoutExtension(fileName), Path.GetFileName(fileName), fileContent, contentType, "POST", out httpStatusCode);
                
            }

            public static void HttpUploadFile(string url, string file, string paramName, string contentType, NameValueCollection nvc)
            {
                try
                {
                    string
                        boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");

                    byte[]
                        boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

                    #if TEST_SERVICE_API
                        url += "/" + Path.GetFileNameWithoutExtension(file);
                    #endif

                    HttpWebRequest
                        request = (HttpWebRequest) WebRequest.Create(url);

                    request.ContentType = "multipart/form-data; boundary=" + boundary;
                    request.Method = "POST";
                    request.KeepAlive = true;
                    request.Credentials = System.Net.CredentialCache.DefaultCredentials;

                    Stream
                        requestStream = request.GetRequestStream();

                    string
                        formDataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";

                    foreach (string key in nvc.Keys)
                    {
                        requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);

                        string
                            formItem = string.Format(formDataTemplate, key, nvc[key]);

                        byte[]
                            formItemBytes = Encoding.UTF8.GetBytes(formItem);

                        requestStream.Write(formItemBytes, 0, formItemBytes.Length);
                    }
                    requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);

                    string
                        headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n",
                        header = string.Format(headerTemplate, paramName, Path.GetFileName(file), contentType);

                    byte[]
                        headerBytes = Encoding.UTF8.GetBytes(header);

                    requestStream.Write(headerBytes, 0, headerBytes.Length);

                    FileStream
                        fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);

                    byte[]
                        buffer = new byte[4096];

                    int
                        bytesRead = 0;

                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                        requestStream.Write(buffer, 0, bytesRead);
                    fileStream.Close();

                    byte[]
                        trailer = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");

                    requestStream.Write(trailer, 0, trailer.Length);
                    requestStream.Close();

                    HttpWebResponse
                        response = (HttpWebResponse) request.GetResponse();

                    Console.WriteLine("StatusCode: {0} ({1}) StatusDescription: \"{2}\"", response.StatusCode, (int)response.StatusCode, response.StatusDescription);

                    Stream
                        responseStream = response.GetResponseStream();

                    StreamReader
                        streamReader = new StreamReader(responseStream);

                    string
                        result = streamReader.ReadToEnd().Trim();
                    
                    response.Close();

                    Console.WriteLine(result);
                }
                catch (Exception eException)
                {
                    Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                }
            }

            public static void HttpUploadFileII(string url, string file, string paramName, string contentType, NameValueCollection nvc)
            {
                try
                {
                    MemoryStream
                        ms = new MemoryStream();

                    string
                        boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");

                    byte[]
                        boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

                    string
                        formDataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";

                    foreach (string key in nvc.Keys)
                    {
                        ms.Write(boundaryBytes, 0, boundaryBytes.Length);

                        string
                            formItem = string.Format(formDataTemplate, key, nvc[key]);

                        byte[]
                            formItemBytes = Encoding.UTF8.GetBytes(formItem);

                        ms.Write(formItemBytes, 0, formItemBytes.Length);
                    }
                    ms.Write(boundaryBytes, 0, boundaryBytes.Length);

                    string
                        headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n",
                        header = string.Format(headerTemplate, paramName, file, contentType);

                    byte[]
                        headerBytes = Encoding.UTF8.GetBytes(header);

                    ms.Write(headerBytes, 0, headerBytes.Length);

                    FileStream
                        fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);

                    byte[]
                        buffer = new byte[4096];

                    int
                        bytesRead = 0;

                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                        ms.Write(buffer, 0, bytesRead);
                    fileStream.Close();

                    byte[]
                        trailer = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");

                    ms.Write(trailer, 0, trailer.Length);

                    byte[]
                        bytesRequest = ms.ToArray();

                    BinaryWriter
                        binaryWriter = new BinaryWriter(new FileStream("request.txt", FileMode.Create, FileAccess.Write));

                    binaryWriter.Write(bytesRequest);
                    binaryWriter.Close();

                    HttpWebRequest
                        request = (HttpWebRequest)WebRequest.Create(url);

                    request.ContentType = "multipart/form-data; boundary=" + boundary;
                    request.Method = "POST";
                    request.ContentLength = bytesRequest.Length;
                    request.KeepAlive = true;
                    request.Credentials = System.Net.CredentialCache.DefaultCredentials;

                    Stream
                        requestStream = request.GetRequestStream();

                    requestStream.Write(bytesRequest, 0, bytesRequest.Length);
                    requestStream.Close();

                    HttpWebResponse
                        response = (HttpWebResponse)request.GetResponse();

                    Stream
                        responseStream = response.GetResponseStream();

                    StreamReader
                        streamReader = new StreamReader(responseStream);

                    string
                        result = streamReader.ReadToEnd().Trim();

                    response.Close();

                    Console.WriteLine(result);
                }
                catch (Exception eException)
                {
                    Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                }
            }

            public static bool HttpUploadFile(string url, string fileName, byte[] fileContent, string contentType, string method, out HttpStatusCode statusCode)
            {
                statusCode = HttpStatusCode.OK;

                var result = true;

                try
                {
                    string
                        boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x"),
                        headerTemplate = "Content-Disposition: form-data; name=\"File\"; filename=\"{0}\"\r\nContent-Type: {1}\r\n\r\n",
                        header = string.Format(headerTemplate, Path.GetFileName(fileName), contentType);

                    var request = (HttpWebRequest)WebRequest.Create(url);

                    request.ContentType = "multipart/form-data; boundary=" + boundary;
                    request.Method = method;
                    request.KeepAlive = true;
                    request.Credentials = CredentialCache.DefaultCredentials;

                    var requestStream = request.GetRequestStream();
                    var bytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");

                    requestStream.Write(bytes, 0, bytes.Length);
                    bytes = Encoding.UTF8.GetBytes(header);
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Write(fileContent, 0, fileContent.Length);
                    bytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Close();

                    var response = (HttpWebResponse)request.GetResponse();

                    statusCode = response.StatusCode;

                    response.Close();
                }
                catch (Exception eException)
                {
                    result = false;
                    Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                }

                return result;
            }
        #endif

        public static byte[] ImageToByteArray(Image imageIn)
        {
            if (imageIn == null)
                return null;

            var ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }
	}
}
