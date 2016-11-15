using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace LessonProject.Global.Config
{
    public class SmsSetting : ConfigurationSection
    {
        [ConfigurationProperty("apiKey", IsRequired = true)]
        public string APIKey
        {
            get
            {
                return this["apiKey"] as string;
            }
            set
            {
                this["apiKey"] = value;
            }
        }

        [ConfigurationProperty("sender", IsRequired = true)]
        public string Sender
        {
            get
            {
                return this["sender"] as string;
            }
            set
            {
                this["sender"] = value;
            }
        }

        [ConfigurationProperty("templateUri", IsRequired = true)]
        public string TemplateUri
        {
            get
            {
                return this["templateUri"] as string;
            }
            set
            {
                this["templateUri"] = value;
            }
        }
    }
}