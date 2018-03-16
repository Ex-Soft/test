using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Xml;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.XtraEditors.DXErrorProvider;

namespace TestDB
{
    [Persistent("TestTable4Types")]
    public class TestTable4Types : XPCustomObject, IDXDataErrorInfo
    {
        public TestTable4Types(Session session) : base(session)
        {}

        [Key(true)]
        public long Id
        {
            get => GetPropertyValue<long>(nameof(Id));
            set => SetPropertyValue(nameof(Id), value);
        }

        public string FVarChar
        {
            get => GetPropertyValue<string>(nameof(FVarChar));
            set => SetPropertyValue(nameof(FVarChar), value);
        }

        public string FNVarChar
        {
            get => GetPropertyValue<string>(nameof(FNVarChar));
            set => SetPropertyValue(nameof(FNVarChar), value);
        }

        public DateTime? FDate
        {
            get => GetPropertyValue<DateTime?>(nameof(FDate));
            set => SetPropertyValue(nameof(FDate), value);
        }

        public DateTime? FDateTime
        {
            get => GetPropertyValue<DateTime?>(nameof(FDateTime));
            set => SetPropertyValue(nameof(FDateTime), value);
        }

        [Persistent("FXml")]
        [DisplayName("Xml")]
        [ValueConverter(typeof(XmlConverter))]
        public XmlDocument Doc
        {
            get => GetPropertyValue<XmlDocument>(nameof(Doc));
            set => SetPropertyValue(nameof(Doc), value);
        }

        [Persistent("FVarBinary_28")]
        public byte[] VarBinary28
        {
            get => GetPropertyValue<byte[]>(nameof(VarBinary28));
            set => SetPropertyValue(nameof(VarBinary28), value);
        }

        [Persistent("FVarBinary_28_Length")]
        public int? FVarBinary28Length
        {
            get => GetPropertyValue<int?>(nameof(FVarBinary28Length));
            set => SetPropertyValue(nameof(FVarBinary28Length), value);
        }

        [Persistent("FVarBinary_Max")]
        public byte[] FVarBinaryMax
        {
            get => GetPropertyValue<byte[]>(nameof(FVarBinaryMax));
            set => SetPropertyValue(nameof(FVarBinaryMax), value);
        }

        [Persistent("FVarBinary_Max_Length")]
        public int? FVarBinaryMaxLength
        {
            get => GetPropertyValue<int?>(nameof(FVarBinaryMaxLength));
            set => SetPropertyValue(nameof(FVarBinaryMaxLength), value);
        }

        private Image _image;

        [Delayed, NonPersistent]
        public Image Image
        {
            get => _image ?? (_image = ByteArrayToImage(FVarBinaryMax));
            set { if (!IsLoading) FVarBinaryMax = ImageToByteArray(value); }
        }

        public static Image ByteArrayToImage(byte[] array)
        {
            return ByteArrayToImage(array, out var arrayIsImage);
        }

        public static byte[] ImageToByteArray(Image imageIn)
        {
            if (imageIn == null)
                return null;

            byte[] array;

            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, ImageFormat.Jpeg);
                array = ms.ToArray();
            }

            return array;
        }

        public static Image ByteArrayToImage(byte[] array, out bool? arrayIsImage)
        {
            arrayIsImage = null;

            if (array == null || array.Length == 0)
                return null;

            Image image = null;

            using (var ms = new MemoryStream(array))
            {
                try
                {
                    image = new Bitmap(Image.FromStream(ms));
                    arrayIsImage = true;
                }
                catch (ArgumentException)
                {
                    image = null;
                    arrayIsImage = false;
                }
            }

            return image;
        }

        public void GetPropertyError(string propertyName, ErrorInfo info)
        {
            //info.ErrorType = ErrorType.Critical;
            //info.ErrorText = propertyName;
        }

        public void GetError(ErrorInfo info)
        {
            //var propertyInfo = new ErrorInfo();
            //GetPropertyError(nameof(Image), propertyInfo);

            //if (propertyInfo.ErrorType == ErrorType.Critical)
            //{
            //    info.ErrorType = propertyInfo.ErrorType;
            //    info.ErrorText = propertyInfo.ErrorText;
            //}
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

        public override Type StorageType => typeof(string);
    }
}
