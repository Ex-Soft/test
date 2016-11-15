using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace LessonProject.Global.Config
{
    public class MimeTypesConfigSection : ConfigurationSection
    {

        [ConfigurationProperty("mimeTypes")]
        public MimeTypesCollection MimeTypes
        {
            get
            {
                return this["mimeTypes"] as MimeTypesCollection;
            }
        }
    }

    public class MimeTypesCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new MimeType();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MimeType)element).Extension;
        }
    }

    public class MimeType : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get
            {
                return this["name"] as string;
            }
        }

        [ConfigurationProperty("resource", IsRequired = true)]
        public string Resource
        {
            get
            {
                return this["resource"] as string;
            }
        }

        [ConfigurationProperty("extension", IsRequired = true, IsKey = true)]
        public string Extension
        {
            get
            {
                return this["extension"] as string;
            }
        }

        [ConfigurationProperty("small", IsRequired = true)]
        public string Small
        {
            get
            {
                return this["small"] as string;
            }
        }
    }
}