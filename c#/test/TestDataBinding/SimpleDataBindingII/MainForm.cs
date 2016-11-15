using System.Windows.Forms;

namespace SimpleDataBindingII
{
    public partial class MainForm : Form
    {
        readonly VictimClass _victim;

        public MainForm()
        {
            InitializeComponent();

            _victim = new VictimClass("Victim");
        }

        private void MainFormLoad(object sender, System.EventArgs e)
        {
            textBox.DataBindings.Add("Text", _victim, "VictimProperty", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void ButtonClick(object sender, System.EventArgs e)
        {
            _victim.VictimProperty = "DoIt!";
        }
    }
}
