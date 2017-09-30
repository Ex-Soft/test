using System;
using System.Windows.Forms;

namespace TestWindow
{
    public partial class ModalForm : Form
    {
        public ModalForm()
        {
            InitializeComponent();
        }

        private void ModalFormFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = checkBoxCancel.Checked;
        }

        private void ButtonSetOkClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void ButtonSetNoneClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;
        }
    }
}
