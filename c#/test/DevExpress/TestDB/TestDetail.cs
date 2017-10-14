using DevExpress.Xpo;

namespace TestDB
{
    [Persistent("TestDetail")]
    public class TestDetail : XPCustomObject
    {
        public TestDetail(Session session) : base(session)
        {}

        [Key(true)]
        public long Id
        {
            get { return GetPropertyValue<long>(nameof(Id)); }
            set { SetPropertyValue(nameof(Id), value); }
        }
        
        [Persistent("IdMaster")]
        [Association("TestMaster-TestDetail")]
        public TestMaster Master
        {
            get { return GetPropertyValue<TestMaster>(nameof(Master)); }
            set { SetPropertyValue(nameof(Master), value); }
        }
        
        public string Val
        {
            get { return GetPropertyValue<string>(nameof(Val)); }
            set { SetPropertyValue(nameof(Val), value); }
        }

        [PersistentAlias("Master.Val")]
        public string MasterVal => (string)EvaluateAlias(nameof(MasterVal));

        [NonPersistent]
        public string NonPersistentField => Id.ToString();
    }
}
