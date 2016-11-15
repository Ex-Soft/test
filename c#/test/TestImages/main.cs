#define TEST_STREAM

using System;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace TestImages
{
    class Program
    {
        static void Main(string[] args)
        {
            string
                currentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location,
                inputFileName,
                outputFileName;

            if (currentDirectory.LastIndexOf("bin") > 0)
                currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));

            inputFileName =  Path.Combine(currentDirectory, "TestImageIII.jpg");

            if(!File.Exists(inputFileName))
                return;

            #if TEST_STREAM
                Stream memoryStream;

                if ((memoryStream = VaryQualityLevel(inputFileName, 50, 75)) != null)
                {
                    outputFileName = Path.Combine(currentDirectory, Path.GetFileNameWithoutExtension(inputFileName) + "_minor" + Path.GetExtension(inputFileName));

                    if(File.Exists(outputFileName))
                        File.Delete(outputFileName);

                    using (var fileStream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write))
                    {
                        memoryStream.Position = 0;
                        memoryStream.CopyTo(fileStream);
                    }
                }
            #endif

            outputFileName = Path.Combine(currentDirectory, "TestImageOut.jpg");

            byte[]
                bytes = File.ReadAllBytes(inputFileName);

            SqlBinary
                sqlBinaryIn = new SqlBinary(bytes),
                sqlBinaryOut;

            SqlInt32
                sqlInt32 = new SqlInt32(/*100*/);

            sqlBinaryOut = PatchImage(sqlBinaryIn, sqlInt32);

            File.WriteAllBytes(outputFileName, (byte[])sqlBinaryOut);
        }

        public static SqlBinary PatchImage(SqlBinary image, SqlInt32 maxSize)
        {
            SqlBinary result = new SqlBinary();

            if (image == null || image.IsNull)
                return result;

            Image tmpImage = null;

            using (var ms=new MemoryStream((byte[])image))
            {
                tmpImage = new Bitmap(Image.FromStream(ms));
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

            byte[]
                bytes;

            using (var ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Jpeg);
                bytes = ms.ToArray();
            }

            return bytes;
        }

        #if TEST_STREAM
            static Stream VaryQualityLevel(string path2get, int maxSize, int maxQuality)
            {
                Stream result = null;

                Image img1 = null;
                EncoderParameter myEncoderParameter = null;

                try
                {
                    using (var fs = new FileStream(path2get, FileMode.Open, FileAccess.Read))
                    {
                        img1 = new Bitmap(Image.FromStream(fs));
                    }

                    var jgpEncoder = GetEncoder(ImageFormat.Jpeg);
                    var myEncoder = Encoder.Quality;
                    var myEncoderParameters = new EncoderParameters(1);

                    myEncoderParameter = new EncoderParameter(myEncoder, 0L);
                    myEncoderParameters.Param[0] = myEncoderParameter;

                    int
                        width,
                        height;

                    if (img1.Width >= img1.Height && img1.Width > maxSize)
                    {
                        width = maxSize;
                        height = width * img1.Height / img1.Width;
                    }
                    else if (img1.Width < img1.Height && img1.Height > maxSize)
                    {
                        height = maxSize;
                        width = height * img1.Width / img1.Height;
                    }
                    else
                    {
                        width = img1.Width;
                        height = img1.Height;
                    }

                    using (var img2 = new Bitmap(width, height, img1.PixelFormat))
                    {
                        var rect = new Rectangle(0, 0, width, height);

                        using (var g2 = Graphics.FromImage(img2))
                        {
                            g2.DrawImage(img1, rect);
                        }

                        result = new MemoryStream();
                        img2.Save(result, jgpEncoder, myEncoderParameters);
                    }
                }
                finally
                {
                    if (myEncoderParameter != null)
                        myEncoderParameter.Dispose();

                    if (img1 != null)
                        img1.Dispose();
                }

                return result;
            }

            static ImageCodecInfo GetEncoder(ImageFormat format)
            {
                var codecs = ImageCodecInfo.GetImageDecoders();

                return codecs.FirstOrDefault(codec => codec.FormatID == format.Guid);
            }
        #endif
    }
}
