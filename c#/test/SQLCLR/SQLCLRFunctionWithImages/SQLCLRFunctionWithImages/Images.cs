using System;
using System.Drawing;
using System.Data.SqlTypes;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.SqlServer.Server;

namespace TestSQLCLRFunction
{
    public class Images
    {
        [SqlFunction]
        public static SqlBinary PatchImage(SqlBinary image, SqlInt32 maxSize)
        {
            SqlBinary result = new SqlBinary();

            if (image == null || image.IsNull)
                return result;

            Image tmpImage = null;

            using (var ms=new MemoryStream((byte[])image))
            {
                tmpImage = new Bitmap(Image.FromStream(ms));  // http://csharp-tricks.blogspot.ch/2010/10/allgemeiner-fehler-in-gdi.html http://www.kerrywong.com/2007/11/15/understanding-a-generic-error-occurred-in-gdi-error/ https://support.microsoft.com/en-us/kb/814675
            }

            if (tmpImage == null)
                return result;

            if (!tmpImage.RawFormat.Equals(ImageFormat.Jpeg))
                tmpImage = _PatchImage_(tmpImage);

            if(!maxSize.IsNull && maxSize!=0)
            {
                int maxOriginalSize = tmpImage.Width >= tmpImage.Height ? tmpImage.Width : tmpImage.Height;

                if(maxOriginalSize > maxSize)
                    tmpImage = new Bitmap(tmpImage, GetNewImageSize(tmpImage.Size, tmpImage.Width>=tmpImage.Height ? (float)maxSize/tmpImage.Width : (float)maxSize/tmpImage.Height));
            }

            result = new SqlBinary(ImageToByteArray(tmpImage));

            return result;
        }

        static Image _PatchImage_(Image image)
        {
            var photoImage = new Bitmap(image.Width, image.Height, PixelFormat.Format24bppRgb);

            using (var graphics = Graphics.FromImage(photoImage))
            {
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(image, 0, 0, image.Width, image.Height);
            }

            return photoImage;
        }

        static Size GetNewImageSize(Size originalImageSize, float factor)
        {
            return new Size
            {
                Width = (int)Math.Floor(originalImageSize.Width * factor),
                Height = (int)Math.Floor(originalImageSize.Height * factor)
            };
        }

        static byte[] ImageToByteArray(Image image)
        {
            if (image == null)
                return null;

            byte[] result = null;

            using (var ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Jpeg);
                result = ms.ToArray();
            }

            return result;
        }
    }
}
