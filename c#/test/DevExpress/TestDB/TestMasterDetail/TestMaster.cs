using System;
using System.Linq;
using DevExpress.Xpo;
using DevExpress.XtraEditors.DXErrorProvider;

namespace TestDB.TestMasterDetail
{
    [Persistent("dbo.TestMaster")]
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

        #if TEST_An_item_with_the_same_key_has_already_been_added

        [Persistent("IdForView"), Delayed, NoForeignKey]
        public TestMasterTestDetailView View
        {
            get { return GetDelayedPropertyValue<TestMasterTestDetailView>("View"); }
            set { SetDelayedPropertyValue("View", value); }
        }

        [PersistentAlias("View.DetailVal")]
        public string DetailVal
        {
            get { return (string)EvaluateAlias("DetailVal"); }
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
