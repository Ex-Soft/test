using DevExpress.Xpo;

namespace TestOverridedGrid.Db
{
    [Persistent("TestMaster")]
    class TestMaster : XPCustomObject
    {
        public TestMaster(Session session) : base(session)
        {}

        [Key(true)]
        public long Id
        {
            get { return GetPropertyValue<long>(nameof(Id)); }
            set { SetPropertyValue(nameof(Id), value); }
        }

        public string Val
        {
            get { return GetPropertyValue<string>(nameof(Val)); }
            set { SetPropertyValue(nameof(Val), value); }
        }

        [Association("TestMaster-TestDetail")]
        public XPCollection<TestDetail> Details => GetCollection<TestDetail>(nameof(Details));
    }
}
