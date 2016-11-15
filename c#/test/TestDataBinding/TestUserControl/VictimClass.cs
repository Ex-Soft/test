using System.ComponentModel;

namespace TestUserControl
{
    public class VictimClass : INotifyPropertyChanged, INotifyPropertyChanging
    {
        string
            _master,
            _slave;

        public VictimClass(string master = null, string slave = null)
        {
            _master = master;
            _slave = slave;
        }

        public VictimClass(VictimClass obj) : this(obj.Master, obj.Slave)
        {}

        public string Master
        {
            get { return _master; }
            set
            {
                if (_master == value)
                    return;

                OnPropertyChanging("Master");
                _master = value;
                OnPropertyChanged("Master");
            }
        }

        public string Slave
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_master))
                    _slave = _master + _master;

                return _slave;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangingEventHandler PropertyChanging;

        protected virtual void OnPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
        }
    }
}
