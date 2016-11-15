// http://stackoverflow.com/questions/329033/what-is-the-difference-between-currentculture-and-currentuiculture-properties-of
// http://www.siao2.com/2007/01/11/1449754.aspx

using System;
using System.Threading;
using System.Windows.Forms;

namespace TestCultureWinForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnDoItClick(object sender, EventArgs e)
        {
            var culture = Thread.CurrentThread.CurrentCulture;
            var uiCulture = Thread.CurrentThread.CurrentUICulture;
        }
    }
}
