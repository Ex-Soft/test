using System;
using System.Linq;
using DevExpress.Xpo;
using DevExpress.XtraEditors.DXErrorProvider;

namespace TestDB.TestMasterDetail
{
    [Persistent("TestMaster")]
    public class TestMaster : XPCustomObject, IDXDataErrorInfo
    {
        public TestMaster(Session session) : base(session)
        {}

        [Key(true)]
        public long Id
        {
            get => GetPropertyValue<long>(nameof(Id));
            set => SetPropertyValue(nameof(Id), value);
        }

        public string Val
        {
            get => GetPropertyValue<string>(nameof(Val));
            set => SetPropertyValue(nameof(Val), value);
        }

        public bool? FBit
        {
            get => GetPropertyValue<bool?>(nameof(FBit));
            set => SetPropertyValue(nameof(FBit), value);
        }

        [Association("TestMaster-TestDetail")]
        public XPCollection<TestDetail> Details => GetCollection<TestDetail>(nameof(Details));

        #if TEST_LINQ_IN_PROPERTY

        [NonPersistent]
        [DisplayName("AggregateNameLength")]
        public int AggregateNameLength
        {
            get
            {
                //throw new NullReferenceException();
                return Details.Select(detail => detail.Name).Aggregate(0, (value, next) => value + next.Length);
            }
        }

        #endif

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
