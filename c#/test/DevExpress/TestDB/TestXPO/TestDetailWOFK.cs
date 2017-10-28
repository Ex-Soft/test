using System;
using DevExpress.Xpo;
using DevExpress.XtraEditors.DXErrorProvider;

namespace TestDB.TestXPO
{
    class TestDetailWOFK : XPCustomObject, IDXDataErrorInfo
    {
        long _id;
        TestMasterWOFK _master;
        string _val;

        public TestDetailWOFK(Session session) : base(session)
        {
        }

        [Key(false)]
        [Persistent("Id")]
        public long Id
        {
            get { return _id; }
            set { SetPropertyValue("Id", ref _id, value); }
        }
        
        [Persistent("IdMaster")]
        public TestMasterWOFK Master
        {
            get { return _master; }
            set { SetPropertyValue("Master", ref _master, value); }
        }
        
        [Persistent("Val")]
        public string Val
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
