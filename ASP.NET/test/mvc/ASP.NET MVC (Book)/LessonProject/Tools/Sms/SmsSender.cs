using LessonProject.App_Start;
using LessonProject.Global.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LessonProject.Tools.Sms
{
    public static class SmsSender
    {
        private static IConfig _config;

        public static IConfig Config
        {
            get
            {
                if (_config == null)
                {
                    _config = (DependencyResolver.Current).GetService<IConfig>();

                }
                return _config;
            }
        }

        public static string SendSms(string phone, string text)
        {
            if (!string.IsNullOrWhiteSpace(Config.SmsSetting.APIKey))
            {
                return GetRequest(phone, Config.SmsSetting.Sender, text);
            }
            else
            {
                PreStartApp.logger.Debug("Sms \t Phone: {0} Body: {1}", phone, text);
                return "Success";
            }
        }

        private static string GetRequest(string phone, string sender, string text)
        {
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(Config.SmsSetting.TemplateUri);
                /// important, otherwise the service can't desirialse your request properly
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.Method = "POST";
                webRequest.KeepAlive = false;
                webRequest.PreAuthenticate = false;

                string postData = "format=json&api_key=" + Config.SmsSetting.APIKey + "&phone=" + phone
                    + "&sender=" + sender + "&text=" + HttpUtility.UrlEncode(text);
                var ascii = new ASCIIEncoding();
                byte[] byteArray = ascii.GetBytes(postData);
                webRequest.ContentLength = byteArray.Length;
                Stream dataStream = webRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse webResponse = webRequest.GetResponse();

                Stream responceStream = webResponse.GetResponseStream();
                Encoding enc = System.Text.Encoding.UTF8;
                StreamReader loResponseStream = new
                        StreamReader(webResponse.GetResponseStream(), enc);

                string Response = loResponseStream.ReadToEnd();
                return Response;
            }
            catch (Exception ex)
            {
                PreStartApp.logger.ErrorException("Ошибка при отправке SMS", ex);
                return "Ошибка при отправке SMS";
            }
        }
    }
}