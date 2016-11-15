using System;
using DevExpress.Xpo;
using DevExpress.XtraEditors.DXErrorProvider;

namespace TestSession.Db
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
