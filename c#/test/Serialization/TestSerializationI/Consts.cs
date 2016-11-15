using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace TestSerializationI
{
    [DataContract]
    public class Consts
    {
        [XmlElementAttribute("Const")]
        public Const[] Const;
    }

    [DataContract]
    [Serializable]
    public class Const
    {
        [XmlAttribute("name")]
        public string AttributeName;

        [XmlAttribute("type")]
        public string AttributeType;

        public ConstName Name;
        public ConstValue Value;

        public Const() : this(null, null, string.Empty, string.Empty)
        {
            System.Diagnostics.Debug.WriteLine("Const.Const()");
        }

        public Const(Const obj) : this(obj.Name, obj.Value, obj.AttributeName, obj.AttributeType)
        {
            System.Diagnostics.Debug.WriteLine("Const.Const(Const)");
        }

        public Const(ConstName name = null, ConstValue value = null, string attributeName = "", string attributeType = "")
        {
            System.Diagnostics.Debug.WriteLine("Const.Const(ConstName, ConstValue, string, string)");
            Name = name != null ? new ConstName(name) : null;
            Value = value != null ? new ConstValue(value) : null;
            AttributeName = attributeName;
            AttributeType = attributeType;
        }
    }

    [DataContract]
    [Serializable]
    public class ConstName
    {
        [XmlTextAttribute]
        public string Name;

        [XmlAttribute("type")]
        public string Type;

        public ConstName() : this(string.Empty, string.Empty)
        {
            System.Diagnostics.Debug.WriteLine("ConstName.ConstName()");
        }

        public ConstName(ConstName obj) : this(obj.Name, obj.Type)
        {
            System.Diagnostics.Debug.WriteLine("ConstName.ConstName(ConstName)");
        }

        public ConstName(string name="", string type="")
        {
            System.Diagnostics.Debug.WriteLine("ConstName.ConstName(string, string)");
            Name = name;
            Type = type;
        }
    }

    [DataContract]
    [Serializable]
    public class ConstValue
    {
        [XmlTextAttribute]
        public string Value;

        [XmlAttribute("min")]
        public string Min;

        [XmlAttribute("max")]
        public string Max;

        [XmlAttribute("readOnly")]
        public bool ReadOnly;

        public ConstValue() : this(string.Empty, string.Empty, string.Empty, false)
        {
            System.Diagnostics.Debug.WriteLine("ConstValue.ConstValue()");
        }

        public ConstValue(ConstValue obj) : this(obj.Value, obj.Min, obj.Max, obj.ReadOnly)
        {
            System.Diagnostics.Debug.WriteLine("ConstValue.ConstValue(ConstValue)");
        }

        public ConstValue(string value="", string min="", string max="", bool readOnly=false)
        {
            System.Diagnostics.Debug.WriteLine("ConstValue.ConstValue(string, string, string, string)");
            Value = value;
            Min = min;
            Max = max;
            ReadOnly = readOnly;
        }
    }
}
