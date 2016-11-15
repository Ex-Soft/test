using System;
using System.Net;
using Microsoft.Exchange.WebServices.Data;

namespace TestExchangeWebServices
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);

                service.TraceEnabled = true;
                service.TraceFlags = TraceFlags.All;

                service.Credentials = new WebCredentials("i.nozhenko@systtech.ru", "isn2013");
                service.UseDefaultCredentials = false;

                service.Url = new Uri("https://mail.systtech.ru/EWS/Exchange.asmx");

                //service. AutodiscoverUrl("i.nozhenko@systtech.ru", RedirectionUrlValidationCallback);

                //FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.Inbox, new ItemView(10));

                //foreach (Item item in findResults.Items)
                //{
                //    Console.WriteLine(item.Subject);
                //}

                var tasks = service.FindItems(WellKnownFolderName.Tasks, new ItemView(10));
                foreach (var task in tasks)
                {
                    Console.WriteLine(task.Subject);
                }

            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }

        static bool RedirectionUrlValidationCallback(string redirectionUrl)
        {
            // The default for the validation callback is to reject the URL.
            bool result = false;

            Uri redirectionUri = new Uri(redirectionUrl);

            // Validate the contents of the redirection URL. In this simple validation
            // callback, the redirection URL is considered valid if it is using HTTPS
            // to encrypt the authentication credentials. 
            if (redirectionUri.Scheme == "https")
            {
                result = true;
            }
            return result;
        }
    }
}
