using LessonProject.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LessonProject.Areas.Default.Controllers
{
    public class FileController : DefaultController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload(HttpPostedFileWrapper qqfile)
        {
            var extension = Path.GetExtension(qqfile.FileName);
            if (!string.IsNullOrWhiteSpace(extension))
            {
                var mimeType = Config.MimeTypes.FirstOrDefault(p => string.Compare(p.Extension, extension, 0) == 0);

                //если изображение
                if (mimeType != null && PreviewCreator.SupportMimeType(mimeType.Name))
                {
                    //тут сохраняем в файл
                    var filePath = Path.Combine("/Content/files", Path.GetFileName(qqfile.FileName));

                    qqfile.SaveAs(Server.MapPath(filePath));

                    var filePreviewPath = Path.Combine("/Content/files/previews", Path.GetFileName(qqfile.FileName));
                    var previewIconSize = Config.IconSizes.FirstOrDefault(c => c.Name == "AvatarSize");
                    if (previewIconSize != null)
                    {
                        PreviewCreator.CreateAndSavePreview(qqfile.InputStream, new Size(previewIconSize.Width, previewIconSize.Height), Server.MapPath(filePreviewPath));
                    }

                    return Json(new
                    {
                        success = true,
                        result = "error",
                        data = new
                        {
                            filePath,
                            filePreviewPath
                        }
                    });
                }
            }
            return Json(new { error = "Нужно загрузить изображение", success = false });
        }

        public ActionResult Export(string uri)
        {

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);
            webRequest.Method = "GET";
            webRequest.KeepAlive = false;
            webRequest.PreAuthenticate = false;
            webRequest.Timeout = 1000;
            var response = webRequest.GetResponse();

            var stream = response.GetResponseStream();
            var previewIconSize = Config.IconSizes.FirstOrDefault(c => c.Name == "AvatarSize");
            var filePreviewPath = Path.Combine("/Content/files/previews", Guid.NewGuid().ToString("N") + ".jpg");
                   
            if (previewIconSize != null)
            {
                PreviewCreator.CreateAndSavePreview(stream, new Size(previewIconSize.Width, previewIconSize.Height), Server.MapPath(filePreviewPath));
            }

            return Content("OK");
        }
    }

}