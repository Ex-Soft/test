using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace System.Web.Security
{

    /// <summary>
    /// The UserImpersonation class wraps the logic required to support user impersonation.
    /// </summary>
    public class UserImpersonation
    {

        /// <summary>
        /// Starts user impersonation by having the current user being logged in as the user which's username is specified.
        /// </summary>
        /// <param name="userName"></param>
        public static void ImpersonateUser(string userName)
        {
            ImpersonateUser(userName, string.Empty);
        }

        /// <summary>
        /// Starts user impersonation by having the current user being logged in as the user which's username is specified.
        /// When user impersonation is reverted, the user will be redirected to the location passed in returnUrl.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="returnUrl"></param>
        public static void ImpersonateUser(string userName, string returnUrl)
        {

            // Declare variables
            HttpContext context;
            FormsAuthenticationTicket authTicket;
            HttpCookie authCookie;
            string strSerializedData;

            // Check if a HttpContext is available and a user is currently logged in.
            context = HttpContext.Current;
            if (context == null)
                throw new InvalidOperationException("No HttpContext available. Unable to impersonate user.");
            if (context.User.Identity == null)
                throw new InvalidOperationException("No user is currently authenticated. Unable to impersonate user.");
            if (!context.User.Identity.IsAuthenticated)
                throw new InvalidOperationException("No user is currently authenticated. Unable to impersonate user.");

            // Store impersonation data in authentication ticket.
            strSerializedData = Serialize(context.User.Identity.Name, returnUrl);
            authCookie = FormsAuthentication.GetAuthCookie(userName, false);
            authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            authTicket = new FormsAuthenticationTicket(authTicket.Version, authTicket.Name, authTicket.IssueDate, authTicket.Expiration,
                authTicket.IsPersistent, strSerializedData, authTicket.CookiePath);
            authCookie.Value = FormsAuthentication.Encrypt(authTicket);
            context.Response.Cookies.Add(authCookie);
        }

        /// <summary>
        /// Reverts the user impersonation.
        /// </summary>
        public static void Deimpersonate()
        {
            Deimpersonate(true);
        }

        /// <summary>
        /// Reverts the user impersonation, optionally ignoring the previously set redirect url.
        /// </summary>
        /// <param name="redirect"></param>
        public static void Deimpersonate(bool redirect)
        {

            // Declare variables
            HttpContext context;
            FormsIdentity formsIdentity;
            string strUserName, strReturnUrl;

            // Check if a HttpContext is available and a user is currently logged in.
            context = HttpContext.Current;
            if (context == null)
                throw new InvalidOperationException("No HttpContext available. Unable to complete operation.");

            // Verify that a user is currently logged in.
            if (context.User.Identity == null)
                return;
            if (!context.User.Identity.IsAuthenticated)
                return;

            // Get data from auth ticket
            formsIdentity = (FormsIdentity)context.User.Identity;
            if (string.IsNullOrEmpty(formsIdentity.Ticket.UserData))
                return;
            if (!Deserialize(formsIdentity.Ticket.UserData, out strUserName, out strReturnUrl))
                return;

            // Set new auth cookie and redirect user if asked to do so.
            FormsAuthentication.SetAuthCookie(strUserName, false);
            if(!string.IsNullOrEmpty(strReturnUrl) && redirect)
                context.Response.Redirect(strReturnUrl);
        }

        /// <summary>
        /// Gets the user name of the user orgininally logged in as before impersonation started.
        /// </summary>
        public static string PrevUserName
        {
            get
            {

                // Declare variables
                HttpContext context;
                FormsIdentity formsIdentity;
                string strUserName, strReturnUrl;

                // Check if a HttpContext is available and a user is currently logged in.
                context = HttpContext.Current;
                if (context == null)
                    throw new InvalidOperationException("No HttpContext available. Unable to complete operation.");

                // Verify that a user is currently logged in.
                if (context.User.Identity == null)
                    return string.Empty;
                if (!context.User.Identity.IsAuthenticated)
                    return string.Empty;

                // Get data from auth ticket
                formsIdentity = (FormsIdentity)context.User.Identity;
                if (string.IsNullOrEmpty(formsIdentity.Ticket.UserData))
                    return string.Empty;
                if (!Deserialize(formsIdentity.Ticket.UserData, out strUserName, out strReturnUrl))
                    return string.Empty;

                return strUserName;
            }
        }

        /// <summary>
        /// Returns true if the current user is being impersonated.
        /// </summary>
        public static bool IsImpersonating
        {
            get
            {

                // Declare variables
                HttpContext context;
                FormsIdentity  formsIdentity;
                string strUserName, strReturnUrl;

                // Check if a HttpContext is available and a user is currently logged in.
                context = HttpContext.Current;
                if (context == null)
                    throw new InvalidOperationException("No HttpContext available. Unable to complete operation.");

                // Verify that a user is currently logged in.
                if (context.User.Identity == null)
                    return false;
                if (!context.User.Identity.IsAuthenticated)
                    return false;

                // Get data from auth ticket
                formsIdentity = (FormsIdentity)context.User.Identity;
                if (string.IsNullOrEmpty(formsIdentity.Ticket.UserData))
                    return false;
                return Deserialize(formsIdentity.Ticket.UserData, out strUserName, out strReturnUrl);
            }
        }

        /// <summary>
        /// Combines the username and return url in a single string seperating the values by a :-character.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        private static string Serialize(string userName, string returnUrl)
        {
            return string.Format("{0}:{1}", userName.Replace(":", "::"), returnUrl.Replace(":", "::"));
        }

        /// <summary>
        /// Reconstructs the username and return url from a serialized state.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="userName"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        private static bool Deserialize(string data, out string userName, out string returnUrl)
        {

            Regex splitRegex;
            string[] pieces;

            // Set default return values
            userName = null;
            returnUrl = null;

            // Attempt to deserialize data
            splitRegex = new Regex("(?<!:):(?!:)");
            pieces = splitRegex.Split(data);
            if (pieces.Length != 2)
                return false;

            // Set the return values
            userName = pieces[0].Replace("::", ":");
            returnUrl = pieces[1].Replace("::", ":");
            return true;
        }
    }

    
}
