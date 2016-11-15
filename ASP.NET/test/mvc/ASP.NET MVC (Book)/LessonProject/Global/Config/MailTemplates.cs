using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace LessonProject.Global.Config
{

    public class MailTemplateConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("mailTemplates")]
        public MailTemplatesCollection MailTemplates
        {
            get
            {
                return this["mailTemplates"] as MailTemplatesCollection;
            }
        }
    }

    public class MailTemplatesCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new MailTemplate();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MailTemplate)element).Name;
        }
    }

    public class MailTemplate : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get
            {
                return this["name"] as string;
            }
        }

        [ConfigurationProperty("subject", IsRequired = true)]
        public string Subject
        {
            get
            {
                return this["subject"] as string;
            }
        }

        [ConfigurationProperty("template", IsRequired = true)]
        public string Template
        {
            get
            {
                return this["template"] as string;
            }
        }
    }
}