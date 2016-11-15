using ActionMailer.Net.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LessonProject.Areas.Default.Controllers
{
    public class MailController : MailerBase
    {
        public EmailResult Subscription(string message, string email)
        {
            To.Add(email);
            Subject = "Рассылка";
            MessageEncoding = Encoding.UTF8;
            return Email("Subscription", message);
        }

    }
}
