using System;
using DevExpress.Xpo;
using DevExpress.XtraEditors.DXErrorProvider;

namespace TestDB.TestMasterDetail
{
    [Persistent("TestDetailWithNullableIdMaster")]
    public class TestDetailWithNullableIdMaster : XPCustomObject, IDXDataErrorInfo
    {
        public TestDetailWithNullableIdMaster(Session session) : base(session)
        {}

        [Key(true)]
        public long Id
        {
            get => GetPropertyValue<long>(nameof(Id));
            set => SetPropertyValue(nameof(Id), value);
        }
        
        public long IdMaster
        {
            get => GetPropertyValue<long>(nameof(IdMaster));
            set => SetPropertyValue(nameof(IdMaster), value);
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
