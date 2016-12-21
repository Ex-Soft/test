using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TestCustomRepositoryItem.CustomIconTextEdit;

namespace TestCustomRepositoryItem
{
    public partial class MainForm : XtraForm
    {
        private readonly List<string> _listOfString = new List<string> { "1st", "2nd", "3rd" };
        private Binding _customButtonEditBinding;

        public List<string> ListOfString
        {
            get { return _listOfString; }
        }

        public MainForm()
        {
            InitializeComponent();

            //_customButtonEditBinding = customButtonEdit1.DataBindings.Add("EditValue", this, "ListOfString", true, DataSourceUpdateMode.OnPropertyChanged);
            //buttonEdit2.EditValue = "(c)";
        }

        private void customIconTextEdit1_Properties_OnIconSelection(object sender, OnIconSelectionEventArgs e)
        {
            CustomIconTextEdit.CustomIconTextEdit editor = sender as CustomIconTextEdit.CustomIconTextEdit;
            if (editor != null)
            {
                if (editor.Enabled)
                    if (editor.ContainsFocus)
                        e.ImageIndex = 0;
                    else
                        e.ImageIndex = 1;
                else
                    e.ImageIndex = 2;

            }
        }

        private void customIconTextEdit1_IconClick(object sender, MouseEventArgs e)
        {
            CustomIconTextEdit.CustomIconTextEdit editor = sender as CustomIconTextEdit.CustomIconTextEdit;
            if (editor != null)
            {
                this.Text = editor.Name + ".Text = " + editor.Text;
            }
        }
    }
}
