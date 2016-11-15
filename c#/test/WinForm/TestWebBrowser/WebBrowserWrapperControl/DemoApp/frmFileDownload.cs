using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DemoApp
{
    public partial class frmFileDownload : Form
    {
        public frmFileDownload()
        {
            InitializeComponent();
        }

        public bool NotifyEndDownload
        {
            get
            {
                return tsNotifyEndDownload.Checked;
            }
        }

        private struct DLIDS
        {
            public string BrowserName;
            public int DlUid;
            public long FileSize;
            public bool DlDone;

            public DLIDS(string browsername_, int dluid_, long filesize_)
            {
                BrowserName = browsername_;
                DlUid = dluid_;
                FileSize = filesize_;
                DlDone = false;
            }
        }
        private int m_TotalDownloads = 0;
        private void UpdateThisText(bool add)
        {
            if (add)
                m_TotalDownloads++;
            else
                m_TotalDownloads--;
            this.Text = "< " + m_TotalDownloads.ToString() + " > File Downloads";
        }

        public void AddDownloadItem(string browsername, int uDlId, string FromUrl, string ToPath, long filesize)
        {
            ListViewItem item = new ListViewItem();
            item.SubItems[0].Text = FromUrl;    //0 URL
            item.SubItems.Add(ToPath);          //1 Local file
            item.SubItems.Add("Downloading");   //2 Status
            item.SubItems.Add("0");             //3 Bytes Received
            DLIDS id = new DLIDS(browsername, uDlId, filesize);
            item.Tag = id;
            lvDownloads.Items.Add(item);

            UpdateThisText(true);
        }

        public void UpdateDownloadItem(string browsername, int uDlId, long progress, long progressmax)
        {
            DLIDS id = new DLIDS();
            foreach (ListViewItem item in lvDownloads.Items)
            {
                id = (DLIDS)item.Tag;
                if ((id.DlUid == uDlId) &&
                    (id.BrowserName == browsername))
                {
                    if (progress > 0)
                    {
                        //if (id.FileSize > 0)
                        //{
                        //    long tmp = (progress * 100) / id.FileSize;
                        //    item.SubItems[3].Text = tmp.ToString() + "%";
                        //}
                        //else
                        //{
                            //last progress will contain actual file size
                            item.SubItems[3].Text = progress.ToString();
                        //}
                    }
                    return;
                }
            }
        }

        public void DeleteDownloadItem(string browsername, int uDlId, string Msg)
        {
            DLIDS id = new DLIDS();
            ListViewItem delitem = null;
            foreach (ListViewItem item in lvDownloads.Items)
            {
                id = (DLIDS)item.Tag;
                if ((id.DlUid == uDlId) &&
                    (id.BrowserName == browsername))
                {
                    id.DlDone = true;
                    delitem = item;
                    break;
                }
            }

            //Here rather than deleting a dl, we can mark it as downloaded
            //and keep a log of the dls
            if (delitem != null)
            {
                delitem.SubItems[2].Text = Msg;
                if (Msg == "completed")
                    delitem.BackColor = Color.LightGreen;
                else
                    delitem.BackColor = Color.LightPink;
                //lvDownloads.Items.Remove(delitem);
                UpdateThisText(false);
                if (NotifyEndDownload)
                    MessageBox.Show(this, "Finished downloading\r\n" + delitem.SubItems[0].Text + "\r\nTO:\r\n" + delitem.SubItems[1].Text);
            }
        }

        private void frmFileDownload_Load(object sender, EventArgs e)
        {
            this.Icon = AllForms.BitmapToIcon(45);
        }

        private void frmFileDownload_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == tsStopDownload.Name)
            {
                if (lvDownloads.SelectedItems.Count > 0)
                {
                    ListViewItem item = lvDownloads.SelectedItems[0];
                    if( (item != null) && (this.Owner != null) )
                    {
                        DLIDS id = (DLIDS)item.Tag;
                        ((frmMain)this.Owner).StopFileDownload(id.BrowserName, id.DlUid);
                    }
                }
            }
            else if (e.ClickedItem.Name == tsCloseDownload.Name)
            {
                this.Hide();
            }
            else if (e.ClickedItem.Name == tsBtnRemoveCompleted.Name)
            {
                try
                {
                    DLIDS id = new DLIDS();
                    for (int i = lvDownloads.Items.Count - 1; i > -1; i--)
                    {
                        id = (DLIDS)lvDownloads.Items[i].Tag;
                        if (id.DlDone)
                            lvDownloads.Items.RemoveAt(i);
                    }
                }
                catch (Exception ee)
                {
                    AllForms.m_frmLog.AppendToLog(this.Name +  "_toolStrip1_ItemClicked_tsBtnRemoveCompleted\r\n" + ee.ToString());
                }
            }
        }
    }
}