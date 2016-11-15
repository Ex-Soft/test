// http://ftplib.codeplex.com/

using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FtpLib;

namespace TestFTPLib
{
    public partial class MainForm : Form
    {
        FtpConnection _ftp;

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
        }

        private void BtnConnectClick(object sender, EventArgs e)
        {
            if(_ftp==null)
                _ftp = new FtpConnection(tbServer.Text, tbUserName.Text, tbPassword.Text);

            _ftp.Open();
            _ftp.Login();

            SetButtonsEnabledDisabled(true);
        }

        private void BtnDisconnectClick(object sender, EventArgs e)
        {
            SetButtonsEnabledDisabled(false);

            _ftp.Close();
            _ftp = null;
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            if(_ftp!=null)
                _ftp.Close();
        }

        private void BtnGetCurrentDirectoryClick(object sender, EventArgs e)
        {
            tbCurrentDirectory.Text = _ftp.GetCurrentDirectory();
        }

        private void BtnSetCurrentDirectoryClick(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tbCurrentDirectory.Text))
                return;

            _ftp.SetCurrentDirectory(tbCurrentDirectory.Text);

            lbDirectories.Items.Clear();
            lbFiles.Items.Clear();
        }

        private void BtnGetDirectoriesClick(object sender, EventArgs e)
        {
            FtpDirectoryInfo[] ftpDirectoryInfos = _ftp.GetDirectories();

            lbDirectories.Items.Clear();
            lbDirectories.Items.AddRange(ftpDirectoryInfos.OrderBy(di => di.Name).Select(di => (object)di.Name).ToArray());
        }

        private void BtnGetFilesClick(object sender, EventArgs e)
        {
            FtpFileInfo[] ftpFileInfos = _ftp.GetFiles();
            
            lbFiles.Items.Clear();
            lbFiles.Items.AddRange(ftpFileInfos.OrderBy(fi => fi.Name).Select(fi => (object)fi.Name).ToArray());
        }

        private void BtnDownloadClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbDownloadFileName.Text))
                return;

            _ftp.GetFile(tbDownloadFileName.Text, Path.Combine(_directoryDownload, tbDownloadFileName.Text), false);
        }

        private void BtnUploadClick(object sender, EventArgs e)
        {
            using (var uploadFile = new OpenFileDialog { Multiselect = false, InitialDirectory = _directoryUpload })
            {
                if(uploadFile.ShowDialog() == DialogResult.OK)
                    _ftp.PutFile(uploadFile.FileName);
            }
        }

        void SetButtonsEnabledDisabled(bool enabled)
        {
            btnDisconnect.Enabled = btnGetCurrentDirectory.Enabled = btnSetCurrentDirectory.Enabled = btnGetDirectories.Enabled = btnGetFiles.Enabled = btnDownload.Enabled = btnUpload.Enabled = enabled;
            btnConnect.Enabled = !enabled;
        }
    }
}
