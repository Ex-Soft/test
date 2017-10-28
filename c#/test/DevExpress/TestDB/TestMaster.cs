using System;
using DevExpress.Xpo;
using DevExpress.XtraEditors.DXErrorProvider;

namespace TestDB
{
    [Persistent("TestMaster")]
    public class TestMaster : XPCustomObject, IDXDataErrorInfo
    {
        public TestMaster(Session session) : base(session)
        {}

        [Key(true)]
        public long Id
        {
            get { return GetPropertyValue<long>(nameof(Id)); }
            set { SetPropertyValue(nameof(Id), value); }
        }

        public string Val
        {
            get { return GetPropertyValue<string>(nameof(Val)); }
            set { SetPropertyValue(nameof(Val), value); }
        }

        [Association("TestMaster-TestDetail")]
        public XPCollection<TestDetail> Details => GetCollection<TestDetail>(nameof(Details));

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            System.Diagnostics.Debug.WriteLine($"{System.Reflection.MethodBase.GetCurrentMethod().Name}(\"{propertyName}\": \"{oldValue}\" -> \"{newValue}\")");
            base.OnChanged(propertyName, oldValue, newValue);
        }

        public void GetPropertyError(string propertyName, ErrorInfo info)
        {
            if (info != null && !string.IsNullOrWhiteSpace(info.ErrorText))
                throw new NotImplementedException();
        }

        public void GetError(ErrorInfo info)
        {
            if (info != null && !string.IsNullOrWhiteSpace(info.ErrorText))
                throw new NotImplementedException();
        }
    }
}
