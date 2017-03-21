using System.Diagnostics;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;

namespace TestDE16WinApp
{
    public partial class TabControlForm1 : XtraForm
    {
        public TabControlForm1()
        {
            InitializeComponent();
        }

        private void xtraTabControl_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (radioGroup1.SelectedIndex != 0)
                return;

            SetPageEnabled(e.PrevPage, e.Page);
        }

        private void xtraTabControl_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if (radioGroup1.SelectedIndex != 1)
                return;

            SetPageEnabled(e.PrevPage, e.Page);
        }

        private void SetPageEnabled(XtraTabPage prevPage, XtraTabPage page)
        {
            if (prevPage == xtraTabPage6 && page == xtraTabPage4)
                xtraTabPage6.PageEnabled = false;
        }

        private void simpleButtonReset_Click(object sender, System.EventArgs e)
        {
            xtraTabPage6.PageEnabled = true;
        }

        private void simpleButtonDoIt_Click(object sender, System.EventArgs e)
        {
            Debug.WriteLine($"xtraTabControl.SelectedTabPageIndex={xtraTabControl.SelectedTabPageIndex}, xtraTabControl.SelectedTabPage.Text=\"{xtraTabControl.SelectedTabPage.Text}\"");
        }
    }
}
