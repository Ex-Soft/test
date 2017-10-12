using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using DevExpress.Xpo;
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
            get { return GetPropertyValue<long>(nameof(Id)); }
            set { SetPropertyValue(nameof(Id), value); }
        }

        [Persistent("FVarBinary_Max")]
        public byte[] FVarBinaryMax
        {
            get { return GetPropertyValue<byte[]>(nameof(FVarBinaryMax)); }
            set { SetPropertyValue(nameof(FVarBinaryMax), value); }
        }

        private Image _image;

        [Delayed, NonPersistent]
        public Image Image
        {
            get { return _image ?? (_image = ByteArrayToImage(FVarBinaryMax)); }
            set { if (!IsLoading) FVarBinaryMax = ImageToByteArray(value); }
        }

        public static Image ByteArrayToImage(byte[] array)
        {
            bool? arrayIsImage;

            return ByteArrayToImage(array, out arrayIsImage);
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
            info.ErrorType = ErrorType.Critical;
            info.ErrorText = propertyName;
        }

        public void GetError(ErrorInfo info)
        {
            var propertyInfo = new ErrorInfo();
            GetPropertyError(nameof(Image), propertyInfo);

            //if (propertyInfo.ErrorType == ErrorType.Critical)
            //{
            //    info.ErrorType = propertyInfo.ErrorType;
            //    info.ErrorText = propertyInfo.ErrorText;
            //}
        }
    }
}
