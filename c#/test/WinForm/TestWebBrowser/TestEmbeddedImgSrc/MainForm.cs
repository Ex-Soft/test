using System;
using System.IO;
using System.Windows.Forms;

namespace TestEmbeddedImgSrc
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnLoadClick(object sender, EventArgs e)
        {
            var html = string.Format("<html><body><h1>Test Embedded IMG src</h1><div>{0}</div><div>{1}</div><div>{2}</div></body></html>", GetImg("png.png", "png"), GetImg("gif.gif", "gif"), GetImg("jpg.jpg", "jpeg"));

            SetDocument(html);
        }

        void SetDocument(string value)
        {
            if (webBrowser.Document == null)
                webBrowser.DocumentText = value;
            else
            {
                webBrowser.Document.OpenNew(false);
                webBrowser.Document.Write(value);
            }
        }

        static string GetImg(string fileName, string mediaType)
        {
            string
                   currentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location,
                   fullFileName;

            if (currentDirectory.IndexOf("bin") != -1)
                currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));

            return File.Exists(fullFileName = Path.Combine(currentDirectory, fileName)) ? string.Format("<img src=\"data:image/{0};base64,{1}\" alt=\"{2}\" title=\"{2}\"/>", mediaType, Convert.ToBase64String(File.ReadAllBytes(fullFileName)), fileName) : string.Empty;
        }
    }
}
