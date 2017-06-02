using System;
using System.Drawing;
using System.Net;

namespace TestDEControls
{
    class Misc
    {
        public const string UriProtocol = "http";

        public static Image LoadPictureByUri(string pictureFileName, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (!string.IsNullOrWhiteSpace(pictureFileName))
                pictureFileName = pictureFileName.Trim();

            if (string.IsNullOrWhiteSpace(pictureFileName))
                return null;

            if (!pictureFileName.ToLower().StartsWith(UriProtocol))
            {
                errorMessage = string.Format("Invalid url: \"{0}\"", pictureFileName);
                return null;
            }

            Image picture = null;
            var statusCode = HttpStatusCode.InternalServerError;

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(pictureFileName);
                var response = (HttpWebResponse)request.GetResponse();

                if ((statusCode = response.StatusCode) == HttpStatusCode.OK)
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                            picture = new Bitmap(Image.FromStream(responseStream));
                        else
                            errorMessage = string.Format("Response stream is null (\"{0}\")", pictureFileName);
                    }
                }
                else
                    errorMessage = response.StatusDescription;
            }
            catch (WebException e)
            {
                HttpWebResponse response;

                if ((response = e.Response as HttpWebResponse) != null)
                    statusCode = response.StatusCode;

                errorMessage = e.Message;
            }
            catch (Exception e)
            {
                errorMessage = string.Format("{0}: \"{1}\"\r\n(\"{2}\")", e.GetType().Name, e.Message, pictureFileName);
            }

            return picture;
        }
    }
}
