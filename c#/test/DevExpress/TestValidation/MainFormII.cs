using System;
using System.ComponentModel;
using DevExpress.XtraEditors;

namespace TestValidation
{
    public partial class MainFormII : XtraForm, INotifyPropertyChanged
    {
        DateTime _testDateTime;

        public DateTime TestDateTime
        {
            get { return _testDateTime; }
            set
            {
                if (_testDateTime != value)
                {
                    _testDateTime = value;
                }
            }
        }

        public MainFormII()
        {
            InitializeComponent();

            dateEdit.Properties.NullDate = default(DateTime);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
