using System.Windows.Forms;
using WinFormsApp.Domain;

namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        ISmthEntity _smthEntity;

        public MainForm(ISmthEntity smthEntity)
        {
            _smthEntity = smthEntity;

            InitializeComponent();
        }
    }
}
