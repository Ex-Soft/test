using System;
using DevExpress.Xpo;
using DevExpress.XtraEditors.DXErrorProvider;

namespace TestDataSetDataStore.Db
{
    [Persistent("TestDetail")]
    class TestDetail : XPCustomObject, IDXDataErrorInfo
    {
        long
            _id;

        TestMaster
            _master;

        string
            _val;

        public TestDetail(Session session) : base(session)
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
        
        [Persistent("TestMasterId")]
        [Association("TestMaster-TestDetail")]
        [DisplayName("_Master_")]
        public TestMaster Master
        {
            get { return _master; }
            set { SetPropertyValue("Master", ref _master, value); }
        }
        
        [Persistent("Val")]
        [DisplayName("Val")]
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
