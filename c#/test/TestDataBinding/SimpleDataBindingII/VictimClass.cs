using System.ComponentModel;

namespace SimpleDataBindingII
{
    class VictimClass : INotifyPropertyChanged
    {
        string _victimProperty;

        public VictimClass(string victimProperty="")
        {
            _victimProperty = victimProperty;
        }

        public VictimClass(VictimClass obj) : this(obj.VictimProperty)
        {}

        public string VictimProperty
        {
            get { return _victimProperty; }
            set
            {
                if (_victimProperty != value)
                {
                    _victimProperty = value;
                    OnPropertyChanged("VictimProperty");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
