using System.Windows.Forms;
using WinFormsApp.Domain;

namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        ISmthEntities _smthEntities;

        public MainForm(ISmthEntities smthEntities)
        {
            _smthEntities = smthEntities;

            InitializeComponent();
        }
    }
}
