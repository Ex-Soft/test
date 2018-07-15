// https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/enabling-cross-origin-requests-in-web-api

using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;

namespace TestCookies.Controllers
{
    [RoutePrefix("api/default")]
    [EnableCors(origins: "http://localhost", headers: "*", methods: "*", SupportsCredentials = true)]
    public class DefaultController : ApiController
    {
        public HttpResponseMessage GetSmth()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);

            var cookies = Request.Headers.GetCookies();
            var result = "";
            foreach (var cookie in cookies)
            {
                if (result.Length != 0)
                    result += ", ";

                result += $"{GetCookiesValues(cookie.Cookies)}";
            }

            response.Content = new StringContent($"[{result}]", Encoding.UTF8);

            var dtNow = DateTime.Now;

            var nv = new NameValueCollection();
            nv["sid"] = "12345";
            nv["token"] = "abcdef";
            nv["theme"] = "dark blue";
            var sessionCookie1 = new CookieHeaderValue("sessionCookie1", nv);
            var sessionCookie2 = new CookieHeaderValue("sessionCookie2", $"sessionCookie2{dtNow.Ticks}");
            var sessionCookie3 = new CookieHeaderValue("sessionCookie3", $"sessionCookie3{dtNow.Ticks}");
            var expiredCookie1 = new CookieHeaderValue("expiredCookie1", $"expiredCookie1{dtNow.Ticks}");
            expiredCookie1.Expires = dtNow.AddDays(7);
            var expiredCookie2 = new CookieHeaderValue("expiredCookie2", $"expiredCookie2{dtNow.Ticks}");
            expiredCookie2.Expires = dtNow.AddDays(14);

            response.Headers.AddCookies(new CookieHeaderValue[] { sessionCookie1, sessionCookie2, sessionCookie3, expiredCookie1, expiredCookie2 });

            return response;
        }

        string GetCookiesValues(Collection<CookieState> cookiesStates)
        {
            var result = "";

            foreach (var item in cookiesStates)
            {
                if (result.Length != 0)
                {
                    result += ", ";
                }

                result += $"{{\"{item.Name}\": {(item.Values.Count > 1 ? $"{{{GetCookieValues(item.Values)}}}" : $"\"{item.Value}\"")}}}";
            }

            return result;
        }

        string GetCookieValues(NameValueCollection values)
        {
            var result = "";

            foreach(var key in values.AllKeys)
            {
                if (result.Length != 0)
                {
                    result += ", ";
                }

                result += $"\"{key}\": \"{values[key]}\"";
            }

            return result;
        }

        string GetCookieValues2(NameValueCollection values)
        {
            var result = "";

            for (var i = 0; i < values.Count; ++i)
            {
                if (result.Length != 0)
                {
                    result += ", ";
                }

                result += $"\"{values.GetKey(i)}\": \"{values.Get(i)}\"";
            }

            return result;
        }
    }
}
