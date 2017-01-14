using System;
using DevExpress.Xpo;
using DevExpress.XtraEditors.DXErrorProvider;

namespace TestXPO.Db
{
    [Persistent("TestMasterWOFK")]
    class TestMasterWOFK : XPCustomObject, IDXDataErrorInfo
    {
        long _id;
        string _val;

        public TestMasterWOFK(Session session) : base(session)
        {
        }

        [Key(false)]
        [Persistent("Id")]
        public long Id
        {
            get { return _id; }
            set { SetPropertyValue("Id", ref _id, value); }
        }

        [Persistent("Val")]
        public string Name
        {
            get { return _val; }
            set { SetPropertyValue("Val", ref _val, value); }
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
