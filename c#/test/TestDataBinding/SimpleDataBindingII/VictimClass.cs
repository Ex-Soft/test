using System.ComponentModel;
using System.Reflection;

namespace SimpleDataBindingII
{
    class VictimClass : INotifyPropertyChanged
    {
        string
            _victimProperty,
            _formProperty;

        public VictimClass(string victimProperty = "", string formProperty = "")
        {
            System.Diagnostics.Debug.WriteLine($"VictimClass.{MethodBase.GetCurrentMethod().Name}(string victimProperty = \"{victimProperty}\", string formProperty = \"{formProperty}\")");

            _victimProperty = victimProperty;
            _formProperty = formProperty;
        }

        public VictimClass(VictimClass obj) : this(obj.VictimProperty, obj.FormProperty)
        {}

        public string VictimProperty
        {
            get => _victimProperty;
            set
            {
                if (_victimProperty == value)
                    return;
                
                _victimProperty = value;

                System.Diagnostics.Debug.WriteLine($"VictimClass.{MethodBase.GetCurrentMethod().Name} = \"{_victimProperty}\"");

                OnPropertyChanged(nameof(VictimProperty));
            }
        }

        public string FormProperty
        {
            get => _formProperty;
            set
            {
                if (_formProperty == value)
                    return;

                _formProperty = value;

                System.Diagnostics.Debug.WriteLine($"VictimClass.{MethodBase.GetCurrentMethod().Name} = \"{_formProperty}\"");

                OnPropertyChanged(nameof(FormProperty));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
