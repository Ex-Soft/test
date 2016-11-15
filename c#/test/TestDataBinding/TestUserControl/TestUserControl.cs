using System.ComponentModel;
using System.Windows.Forms;

namespace TestUserControl
{
    public partial class TestUserControl : UserControl, INotifyPropertyChanged
    {
        string
            _master,
            _slave;

        public string Master
        {
            get { return _master; }
            set
            {
                if (_master == value)
                    return;

                tbMaster.Text = _master = value;
                OnPropertyChanged("Master");
            }
        }

        public string Slave
        {
            get { return _slave; }
            set
            {
                if (_slave == value)
                    return;

                tbSlave.Text = _slave = value;
            }
        }

        public TestUserControl()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
