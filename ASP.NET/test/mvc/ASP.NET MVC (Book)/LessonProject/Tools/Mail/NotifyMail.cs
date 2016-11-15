using LessonProject.App_Start;
using LessonProject.Global.Config;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LessonProject.Tools.Mail
{

    public static class NotifyMail
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

        public static void SendNotify(string templateName, string email,
            Func<string, string> subject,
            Func<string, string> body)
        {
            var template = Config.MailTemplates.FirstOrDefault(p => string.Compare(p.Name, templateName, true) == 0);
            if (template == null)
            {
                PreStartApp.logger.Error("Can't find template (" + templateName + ")");
            }
            else
            {
                MailSender.SendMail(email,
                    subject.Invoke(template.Subject),
                    body.Invoke(template.Template));
            }
        }
    }
}