using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.SessionState;
using Jayrock.Json;
using log4net;

namespace TestCookies
{
	public class AjaxRequestHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
			string
				CookieSignature = "AjaxRequestHandler",
				SessionSignature = "TestCookies";

			ShowCookiesRequest();

			HttpCookie
				c;

			if ((c = HttpContext.Current.Request.Cookies[CookieSignature]) == null)
				c = new HttpCookie(CookieSignature);

			c.Expires = DateTime.Now.AddYears(1);

			string[]
				keys = c.Values.AllKeys;

			string
				tmpString;

			foreach (string s in keys)
				tmpString = "[" + (!string.IsNullOrEmpty(s) ? s : "null") + "]=\"" + c.Values[s] + "\"";

			if (c.Values["Value2"] != null)
			{
				int
					a = HttpContext.Current.Session[SessionSignature] != null ? (int)HttpContext.Current.Session[SessionSignature] : 0;

				c.Values["Value3"] = a.ToString();

				HttpContext.Current.Session[SessionSignature] = ++a;
			}

			c.Values["Value1"] = DateTime.Now.ToString("o");

			if (c.Values["Value2"] == null)
				c.Values["Value2"] = "Value2";

			HttpContext.Current.Response.Cookies.Set(c);
			//HttpContext.Current.Response.Cookies.Add(c);

			context.Response.CacheControl = "no-cache";
			context.Response.Expires = -1;
			context.Response.ContentType = "application/json";

			JsonObject
				RootJsonObject = new JsonObject(new Dictionary<string, object> { { "success", false } });

			JsonTextWriter
				tmpJsonTextWriter = new JsonTextWriter(context.Response.Output);

			RootJsonObject.Export(tmpJsonTextWriter);
			tmpJsonTextWriter.Flush();
			tmpJsonTextWriter.Close();
			
			ShowCookiesResponse();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

		public static void ShowCookiesRequest()
		{
			ShowCookies(HttpContext.Current.Request.Cookies, "Request");
		}

		public static void ShowCookiesResponse()
		{
			ShowCookies(HttpContext.Current.Response.Cookies, "Response");
		}

		public static void ShowCookies(HttpCookieCollection cs, string Prefix)
		{
			ILog
				log = LogManager.GetLogger("System");

			log.Info("----------");

			NameObjectCollectionBase.KeysCollection
				keys = cs.Keys;

			string
				tmpString;

			HttpCookie
				c;

			foreach (string key in keys)
			{
				tmpString = Prefix + " Cookies[\"" + key + "\"]=\"" + cs[key].Value + "\"";

				log.Info(tmpString);

				c = cs[key];
			}

			log.Info("SessionID=\"" + HttpContext.Current.Session.SessionID + "\"");
		}
    }
}
