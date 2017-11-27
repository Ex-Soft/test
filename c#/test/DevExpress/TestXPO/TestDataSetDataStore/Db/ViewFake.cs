using System;
using DevExpress.Xpo;
using DevExpress.XtraEditors.DXErrorProvider;

namespace TestDataSetDataStore.Db
{
    [Persistent("ViewFake")]
    class ViewFake : XPCustomObject, IDXDataErrorInfo
    {
        long
            _id;

        string
            _val;

        public ViewFake(Session session) : base(session)
        {
        }

        [Key(true)]
        [Persistent("Id")]
        public long Id
        {
            get { return _id; }
            set { SetPropertyValue("Id", ref _id, value); }
        }

        [Persistent("Val")]
        public string Val
        {
            get { return _val; }
            set { SetPropertyValue("Val", ref _val, value); }
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
