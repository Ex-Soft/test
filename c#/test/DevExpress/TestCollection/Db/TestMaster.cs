using System;
using DevExpress.Xpo;
using DevExpress.XtraEditors.DXErrorProvider;

namespace TestCollection.Db
{
    [Persistent("TestMaster")]
    class TestMaster : XPCustomObject, IDXDataErrorInfo
    {
        long
            _id;

        string
            _val;

        public TestMaster(Session session) : base(session)
        {
        }

        [Key(true)]
        [Persistent("Id")]
        [DisplayName("ID")]
        public long Id
        {
            get { return _id; }
            set { SetPropertyValue("Id", ref _id, value); }
        }

        [Persistent("Val")]
        [DisplayName("Val")]
        public string Name
        {
            get { return _val; }
            set { SetPropertyValue("Val", ref _val, value); }
        }

        [Association("TestMaster-TestDetail")]
        public XPCollection<TestDetail> Details
        {
            get { return GetCollection<TestDetail>("Details"); }
        }

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

        public void GetPropertyError(string propertyName, ErrorInfo info)
        {
            if (info != null
                && !string.IsNullOrWhiteSpace(info.ErrorText))
                throw new NotImplementedException();
        }

        public void GetError(ErrorInfo info)
        {
            if (info != null
                && !string.IsNullOrWhiteSpace(info.ErrorText))
                throw new NotImplementedException();
        }
    }
}
