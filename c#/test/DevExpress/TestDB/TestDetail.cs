using System;
using DevExpress.Xpo;
using DevExpress.XtraEditors.DXErrorProvider;

namespace TestDB
{
    [Persistent("TestDetail")]
    public class TestDetail : XPCustomObject, IDXDataErrorInfo
    {
        public TestDetail(Session session) : base(session)
        {}

        [Key(true)]
        public long Id
        {
            get => GetPropertyValue<long>(nameof(Id));
            set => SetPropertyValue(nameof(Id), value);
        }
        
        [Persistent("IdMaster")]
        [Association("TestMaster-TestDetail")]
        public TestMaster Master
        {
            get => GetPropertyValue<TestMaster>(nameof(Master));
            set => SetPropertyValue(nameof(Master), value);
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

        [PersistentAlias("Master.Val")]
        public string MasterVal => (string)EvaluateAlias(nameof(MasterVal));

        [NonPersistent]
        public string NonPersistentField => Id.ToString();

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
