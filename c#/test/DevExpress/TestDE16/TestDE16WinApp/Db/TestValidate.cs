using DevExpress.Xpo;
using DevExpress.XtraEditors.DXErrorProvider;

namespace TestDE16WinApp.Db
{
    [NonPersistent]
    public class TestValidate : XPBaseObject, IDXDataErrorInfo
    {
        private bool _boolValue;

        private string
            _stringValue1,
            _stringValue2;

        [NonPersistent]
        public bool BoolValue
        {
            get { return _boolValue; }
            set { SetPropertyValue("BoolValue", ref _boolValue, value); }
        }

        [NonPersistent]
        public string StringValue1
        {
            get { return _stringValue1; }
            set { SetPropertyValue("StringValue1", ref _stringValue1, value); }
        }

        [NonPersistent]
        public string StringValue2
        {
            get { return _stringValue2; }
            set { SetPropertyValue("StringValue2", ref _stringValue2, value); }
        }

        public void GetPropertyError(string propertyName, ErrorInfo info)
        {
            info.ErrorType = ErrorType.Information;
            info.ErrorText = $"GetPropertyError({propertyName})";
        }

        public void GetError(ErrorInfo info)
        {
            info.ErrorType = ErrorType.Information;
            info.ErrorText = "GetError()";
        }

        public TestValidate(TestValidate obj) : this(obj.BoolValue, obj.StringValue1, obj.StringValue2)
        {}

        public TestValidate(bool boolValue = false, string stringValue1 = "", string stringValue2 = "")
        {
            _boolValue = boolValue;
            _stringValue1 = stringValue1;
            _stringValue2 = stringValue2;
        }
    }
}
