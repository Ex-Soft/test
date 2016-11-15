using System.Windows.Forms;

namespace TestUserControl
{
    public partial class MainForm : Form
    {
        VictimClass _victim;

        public MainForm()
        {
            _victim = new VictimClass("Master", "Slave");

            InitializeComponent();

            tbMaster.DataBindings.Add("Text", _victim, "Master", true, DataSourceUpdateMode.OnPropertyChanged);
            tbSlave.DataBindings.Add("Text", _victim, "Slave", true, DataSourceUpdateMode.OnPropertyChanged);

            testUserControl.DataBindings.Add("Master", _victim, "Master", true, DataSourceUpdateMode.OnPropertyChanged);
            testUserControl.DataBindings.Add("Slave", _victim, "Slave", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void BtnSetClick(object sender, System.EventArgs e)
        {
            testUserControl.Master = tbSet.Text;
        }
    }
}
