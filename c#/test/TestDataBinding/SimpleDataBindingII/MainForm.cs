using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace SimpleDataBindingII
{
    public partial class MainForm : Form, INotifyPropertyChanged
    {
        readonly VictimClass _victim;

        public MainForm()
        {
            InitializeComponent();

            _victim = new VictimClass("Victim", "Form");
        }

        private void MainFormLoad(object sender, System.EventArgs e)
        {
            textBox1.DataBindings.Add(nameof(TextBox.Text), _victim, nameof(VictimClass.VictimProperty), false, DataSourceUpdateMode.OnPropertyChanged);

            Binding binding = new Binding(nameof(FormProperty), _victim, nameof(VictimClass.FormProperty), true, DataSourceUpdateMode.OnPropertyChanged);
            binding.BindingComplete += BindingBindingComplete;
            binding.Format += BindingFormat;
            binding.Parse += BindingParse;
            DataBindings.Add(binding);
        }

        private void BindingParse(object sender, ConvertEventArgs e)
        {
            
        }

        private void BindingFormat(object sender, ConvertEventArgs e)
        {
            
        }

        private void BindingBindingComplete(object sender, BindingCompleteEventArgs e)
        {
            
        }

        private void BtnSetPropertyClick(object sender, System.EventArgs e)
        {
            _victim.VictimProperty = "SetProperty (VictimProperty)";
            FormProperty = "SetProperty (FormProperty)";
        }

        private void BtnSetControlClick(object sender, System.EventArgs e)
        {
            textBox1.Text = "SetControl";
        }

        string _formProperty;

        public string FormProperty
        {
            get => _formProperty;
            set
            {
                if (_formProperty == value)
                    return;

                _formProperty = value;

                System.Diagnostics.Debug.WriteLine($"MainForm.{MethodBase.GetCurrentMethod().Name} = \"{_formProperty}\"");

                OnPropertyChanged(nameof(FormProperty));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
