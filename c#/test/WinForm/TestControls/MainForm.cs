using System.Windows.Forms;

namespace TestControls
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            linkLabel1.Links.Add(new LinkLabel.Link { LinkData = "http://www.google.com/" });
        }

        void LinkLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel linkLabel;
            string url;

            if ((linkLabel = sender as LinkLabel) == null
                || e == null
                || e.Link == null
                || (url = e.Link.LinkData as string) == null)
                return;

            System.Diagnostics.Process.Start(url);
        }
    }
}
