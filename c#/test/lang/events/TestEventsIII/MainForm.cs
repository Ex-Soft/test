using System;
using System.Windows.Forms;

namespace TestEventsIII
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnDoIt.Click += new EventHandler(btnDoIt_Click);
        }

        void btnDoIt_Click(object sender, EventArgs e)
        {
            MessageBox.Show("OnClick");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            btnDoIt.Click -= new EventHandler(btnDoIt_Click);
        }

    }
}
