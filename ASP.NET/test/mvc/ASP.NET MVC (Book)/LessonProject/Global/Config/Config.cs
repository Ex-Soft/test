using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace LessonProject.Global.Config
{
    public class Config : IConfig
    {
        public string Lang
        {
            get
            {
                return ConfigurationManager.AppSettings["Culture"] as string;
            }
        }

        public bool EnableMail
        {
            get
            {
                return bool.Parse(ConfigurationManager.AppSettings["EnableMail"]);
            }
        }

        public IQueryable<IconSize> IconSizes
        {
            get 
            {
                IconSizesConfigSection configInfo = (IconSizesConfigSection)ConfigurationManager.GetSection("iconConfig");
                return configInfo.IconSizes.OfType<IconSize>().AsQueryable<IconSize>(); 
                
            }
        }

        public IQueryable<MimeType> MimeTypes
        {
            get
            {
                MimeTypesConfigSection configInfo = (MimeTypesConfigSection)ConfigurationManager.GetSection("mimeConfig");
                return configInfo.MimeTypes.OfType<MimeType>().AsQueryable<MimeType>();
            }
        }

        public IQueryable<MailTemplate> MailTemplates
        {
            get
            {
                MailTemplateConfigSection configInfo = (MailTemplateConfigSection)ConfigurationManager.GetSection("mailTemplateConfig");
                return configInfo.MailTemplates.OfType<MailTemplate>().AsQueryable<MailTemplate>();
            }
        }

        public MailSetting MailSetting
        {
            get 
            { 
                return (MailSetting)ConfigurationManager.GetSection("mailConfig");
            }
        }


        public SmsSetting SmsSetting
        {
            get
            {
                return (SmsSetting)ConfigurationManager.GetSection("smsConfig");
            }
        }
    }
}