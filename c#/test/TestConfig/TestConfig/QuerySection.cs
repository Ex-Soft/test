using System.Configuration;

namespace TestConfig
{
    public class QuerySection : ConfigurationSection
    {
        public const string SectionName = "querySection";
        private const string QueryTagName = "query";
        private const string ClausesCollectionName = "clauses";

        [ConfigurationProperty(QueryTagName)]
        public QueryElement Query { get { return (QueryElement)base[QueryTagName]; } }

        [ConfigurationProperty(ClausesCollectionName)]
        [ConfigurationCollection(typeof(ClausesCollection), AddItemName = "add")]
        public ClausesCollection Clauses { get { return (ClausesCollection)base[ClausesCollectionName]; } }
    }

    public class ClausesCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ClauseElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ClauseElement)element).Name;
        }
    }

    public class ClauseElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("condition", IsRequired = true)]
        public string Condition
        {
            get { return (string)this["condition"]; }
            set { this["condition"] = value; }
        }

        [ConfigurationProperty("type", IsRequired = false, DefaultValue = "String")]
        public string Type
        {
            get { return (string)this["type"]; }
            set { this["type"] = value; }
        }

        [ConfigurationProperty("operator", IsRequired = false, DefaultValue = "and")]
        public string Operator
        {
            get { return (string)this["operator"]; }
            set { this["operator"] = value; }
        }
    }

    public class QueryElement : ConfigurationElement
    {
        private static readonly ConfigurationPropertyCollection _properties;
        private static readonly ConfigurationProperty
            _propStatement,
            _propAttributeBool;

        static QueryElement()
        {
            _propStatement = new ConfigurationProperty("statement", typeof(string), string.Empty, ConfigurationPropertyOptions.IsRequired);
            _propAttributeBool = new ConfigurationProperty("attributeBool", typeof(bool), true);
            _properties = new ConfigurationPropertyCollection { _propStatement, _propAttributeBool};
        }

        internal QueryElement()
        {
        }

        public QueryElement(string statement, bool attributeBool)
        {
            base[_propStatement] = statement;
            base[_propAttributeBool] = attributeBool;
        }

        [ConfigurationProperty("statement", IsRequired = true, DefaultValue = "")]
        public string Statement
        {
            get
            {
                return (string)this[_propStatement];
            }
        }

        [ConfigurationProperty("attributeBool", DefaultValue = true)]
        public bool AttributeBool
        {
            get
            {
                return (bool)this[_propAttributeBool];
            }
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                return _properties;
            }
        }
    }
}
