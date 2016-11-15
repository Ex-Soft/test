// http://netftp.codeplex.com/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Net.FtpClient;

namespace TestFTPClient
{
    public partial class MainForm : Form
    {
        FtpClient _ftp;

        readonly string
            _directoryDownload,
            _directoryUpload;

        public MainForm()
        {
            InitializeComponent();

            _ftp = null;

            string
                currentDirectory = Directory.GetCurrentDirectory();

            if(!Directory.Exists(currentDirectory = Path.Combine(currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1)), "ftproot")))
                Directory.CreateDirectory(currentDirectory);

            if (!Directory.Exists(_directoryDownload = Path.Combine(currentDirectory, "download")))
                Directory.CreateDirectory(_directoryDownload);

            if (!Directory.Exists(_directoryUpload = Path.Combine(currentDirectory, "upload")))
                Directory.CreateDirectory(_directoryUpload);

            /*
            tbServer.Text = "ftp.planorama.com";
            tbUserName.Text = "tmp25";
            tbPassword.Text = "posqnz8";
            tbSrcDir.Text = string.Empty;
            tbDestDir.Text = "Russian Alcohol - Pilot January/upload";
            */
        }

        private void BtnConnectClick(object sender, EventArgs e)
        {
            if (_ftp == null)
                _ftp = new FtpClient { Host = tbServer.Text, Credentials = new NetworkCredential(tbUserName.Text, tbPassword.Text) };

            _ftp.Connect();

            SetButtonsEnabledDisabled(true);
        }

        private void BtnDisconnectClick(object sender, EventArgs e)
        {
            SetButtonsEnabledDisabled(false);

            _ftp.Disconnect();
            _ftp = null;
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            if(_ftp!=null && _ftp.IsConnected)
                _ftp.Disconnect();
        }

        private void BtnGetCurrentDirectoryClick(object sender, EventArgs e)
        {
            tbCurrentDirectory.Text = _ftp.GetWorkingDirectory();
        }

        private void BtnSetCurrentDirectoryClick(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tbCurrentDirectory.Text))
                return;

            _ftp.SetWorkingDirectory(tbCurrentDirectory.Text);

            lbDirectories.Items.Clear();
            lbFiles.Items.Clear();
        }

        private void BtnGetDirectoriesClick(object sender, EventArgs e)
        {
            FtpListItem[] ftpDirectoryInfos = _ftp.GetListing();

            lbDirectories.Items.Clear();
            lbDirectories.Items.AddRange(ftpDirectoryInfos.Where(di => di.Type == FtpFileSystemObjectType.Directory).OrderBy(di => di.Name).Select(di => (object)di.Name).ToArray());
        }

        private void BtnGetFilesClick(object sender, EventArgs e)
        {
            FtpListItem[] ftpFileInfos = _ftp.GetListing();
            
            lbFiles.Items.Clear();
            lbFiles.Items.AddRange(ftpFileInfos.Where(fi => fi.Type == FtpFileSystemObjectType.File).OrderBy(fi => fi.Name).Select(fi => (object)fi.Name).ToArray());
        }

        private void BtnDownloadClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbDownloadFileName.Text))
                return;

            using (var istream = _ftp.OpenRead(tbDownloadFileName.Text, FtpDataType.Binary, 0))
            {
                const int bufferSize = 0x0ffff;

                var fileName = Path.Combine(_directoryDownload, tbDownloadFileName.Text);

                if(File.Exists(fileName))
                    File.Delete(fileName);

                var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                var bw = new BinaryWriter(fs);

                var buffer = new byte[bufferSize];
                int n;

                do
                {
                    n = istream.Read(buffer, 0, buffer.Length);

                    if (n > 0)
                        bw.Write(buffer, 0, n);
                } while (n > 0);

                bw.Close();
            }
        }

        private void BtnUploadClick(object sender, EventArgs e)
        {
            using (var uploadFile = new OpenFileDialog { Multiselect = false, InitialDirectory = _directoryUpload })
            {
                if (uploadFile.ShowDialog() == DialogResult.OK)
                {
                    using (Stream istream = new FileStream(uploadFile.FileName, FileMode.Open, FileAccess.Read), ostream = _ftp.OpenWrite(Path.GetFileName(uploadFile.FileName), FtpDataType.Binary))
                    {
                        const int bufferSize = 0x0ffff;

                        var buffer = new byte[bufferSize];
                        int n;

                        while ((n = istream.Read(buffer, 0, buffer.Length)) > 0)
                            ostream.Write(buffer, 0, n);

                        ostream.Close();
                        istream.Close();
                    }
                }
            }
        }

        void SetButtonsEnabledDisabled(bool enabled)
        {
            btnDisconnect.Enabled = btnGetCurrentDirectory.Enabled = btnSetCurrentDirectory.Enabled = btnGetDirectories.Enabled = btnGetFiles.Enabled = btnDownload.Enabled = btnUpload.Enabled = btnRename.Enabled = enabled;
            btnConnect.Enabled = !enabled;
        }

        private void BtnRenameClick(object sender, EventArgs e)
        {
            string
                srcDir = tbSrcDir.Text,
                destDir = tbDestDir.Text;

            List<string>
                src = _ftp.GetListing(srcDir).Where(fi => fi.Type == FtpFileSystemObjectType.File).OrderBy(fi => fi.Name).Select(fi => fi.Name).ToList(),
                dest = _ftp.GetListing(destDir).Where(fi => fi.Type == FtpFileSystemObjectType.File).OrderBy(fi => fi.Name).Select(fi => fi.Name).ToList();

            src.ForEach(f =>
                {
                    if (dest.IndexOf(f) == -1)
                        _ftp.Rename((!string.IsNullOrWhiteSpace(srcDir) ? srcDir + "/" : string.Empty) + f, destDir + "/" + f);
                });
        }
    }
}
