using System.Windows.Forms;

namespace TestScrollInTab
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            checkBoxAnchorBottom.Checked = groupControl3.Anchor.HasFlag(AnchorStyles.Bottom);
        }

        private void CheckBoxAnchorBottomCheckedChanged(object sender, System.EventArgs e)
        {
            if (checkBoxAnchorBottom.Checked)
            {
                if (!groupControl3.Anchor.HasFlag(AnchorStyles.Bottom))
                    groupControl3.Anchor |= AnchorStyles.Bottom;
            }
            else
            {
                if (groupControl3.Anchor.HasFlag(AnchorStyles.Bottom))
                    groupControl3.Anchor ^= AnchorStyles.Bottom;
            }
        }
    }
}
