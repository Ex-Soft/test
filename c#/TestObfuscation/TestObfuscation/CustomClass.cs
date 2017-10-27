using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace TestObfuscation
{
    public class CustomClass: INotifyPropertyChanging, INotifyPropertyChanged
    {
        private string
            _smthValue1,
            _smthValue2;

        [Custom(nameof(SmthValue1))]
        public string SmthValue1
        {
            get { return _smthValue1; }
            set
            {
                if (_smthValue1 == value)
                    return;

                OnPropertyChanging(nameof(SmthValue1));
                _smthValue1 = value;
                OnPropertyChanged();
            }
        }

        [Custom("SmthValue2")]
        public string SmthValue2
        {
            get { return _smthValue2; }
            set
            {
                if (_smthValue2 == value)
                    return;

                OnPropertyChanging("SmthValue2");
                _smthValue2 = value;
                OnPropertyChanged();
            }
        }

        public CustomClass(string smthValue1 = "", string smthValue2 = "")
        {
            _smthValue1 = smthValue1;
            _smthValue2 = smthValue2;
        }

        public event PropertyChangingEventHandler PropertyChanging;
        protected virtual void OnPropertyChanging(string propertyName)
        {
            File.WriteAllText($"{DateTime.Now.Ticks}_OnPropertyChanging.txt", $"{nameof(OnPropertyChanging)}(\"{propertyName}\")");
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            File.WriteAllText($"{DateTime.Now.Ticks}_OnPropertyChanged.txt", $"{nameof(OnPropertyChanged)}(\"{propertyName}\")");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
