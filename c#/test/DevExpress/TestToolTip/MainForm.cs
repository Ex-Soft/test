using DevExpress.Utils;
using DevExpress.XtraEditors;

namespace TestToolTip
{
    public partial class MainForm : XtraForm
    {
        ToolTipController _toolTipController;

        public MainForm()
        {
            InitializeComponent();

            //_toolTipController = new ToolTipController { ShowBeak = true };
            //_toolTipController = ToolTipController.DefaultController;
            //pictureEdit.ToolTipController = _toolTipController;
        }

        private void PictureEditMouseEnter(object sender, System.EventArgs e)
        {
            //_toolTipController.ShowHint("blah", pictureEdit, ToolTipLocation.RightBottom);
        }

        private void PictureEditMouseLeave(object sender, System.EventArgs e)
        {
            //_toolTipController.HideHint();
        }
    }
}
