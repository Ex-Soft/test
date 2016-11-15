using System;
using System.Web;
using System.Web.SessionState;

namespace TestCookies
{
	public class DataHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
			string
				SessionSignature = "AAA";

			if (HttpContext.Current.Session[SessionSignature] == null)
				HttpContext.Current.Session[SessionSignature] = 10;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
