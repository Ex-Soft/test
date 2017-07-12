using System;
using System.Xml;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.XtraEditors.DXErrorProvider;

namespace TestXPO.Db
{
    [Persistent("TestTable4Types")]
    public class TestTable4Types : XPCustomObject, IDXDataErrorInfo
    {
        long
            _id;

        string
            _fVarChar,
            _fNVarChar;

        DateTime?
            _fDate,
            _fDateTime;

        XmlDocument
            _doc;

        public TestTable4Types(Session session) : base(session)
        {
        }

        [Key(true)]
        [Persistent("Id")]
        [DisplayName("ID")]
        public long Id
        {
            get { return _id; }
            set { SetPropertyValue("Id", ref _id, value); }
        }

        public string FVarChar
        {
            get { return _fVarChar; }
            set { SetPropertyValue("FVarChar", ref _fVarChar, value); }
        }

        public string FNVarChar
        {
            get { return _fNVarChar; }
            set { SetPropertyValue("FNVarChar", ref _fNVarChar, value); }
        }

        public DateTime? FDate
        {
            get { return _fDate; }
            set { SetPropertyValue("FDate", ref _fDate, value); }
        }

        public DateTime? FDateTime
        {
            get { return _fDateTime; }
            set { SetPropertyValue("FDateTime", ref _fDateTime, value); }
        }

        [Persistent("FXml")]
        [DisplayName("Xml")]
        [ValueConverter(typeof(XmlConverter))]
        public XmlDocument Doc
        {
            get { return _doc; }
            set { SetPropertyValue("Doc", ref _doc, value); }
        }

        [Persistent("FVarBinary_28")]
        public byte[] VarBinary28
        {
            get { return GetPropertyValue<byte[]>("VarBinary28"); }
            set { SetPropertyValue("VarBinary28", value); }
        }

        public void GetError(ErrorInfo info)
        {
            if (info != null
                && !string.IsNullOrWhiteSpace(info.ErrorText))
                throw new NotImplementedException();
        }

        public void GetPropertyError(string propertyName, ErrorInfo info)
        {
            if (info != null
               && !string.IsNullOrWhiteSpace(info.ErrorText))
                throw new NotImplementedException();
        }
    }

    // https://documentation.devexpress.com/#XPO/clsDevExpressXpoValueConverterAttributetopic

    public class XmlConverter : ValueConverter
    {
        public override object ConvertToStorageType(object value)
        {
            XmlDocument doc;

            return (doc = value as XmlDocument) != null ? doc.InnerXml : null;
        }

        public override object ConvertFromStorageType(object value)
        {
            string valueStr;

            if (value == null || Convert.IsDBNull(value) || (valueStr = Convert.ToString(value).Trim()).Length == 0)
                return null;

            XmlDocument doc = new XmlDocument();

            try
            {
                doc.LoadXml(valueStr);
            }
            catch
            {
                doc = null;
            }

            return doc;
        }

        public override Type StorageType
        {
            get { return typeof(string); }
        }
    }
}
