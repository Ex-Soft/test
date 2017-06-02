using DevExpress.Xpo;

namespace TestDEControlsII.Db
{
    [Persistent("TestMaster")]
    class TestMaster : XPCustomObject
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
        public long Id
        {
            get { return _id; }
            set { SetPropertyValue("Id", ref _id, value); }
        }

        [Persistent("Val")]
        [DisplayName("Val")]
        public string Val
        {
            get { return _val; }
            set { SetPropertyValue("Val", ref _val, value); }
        }

        [Association("TestMaster-TestDetail")]
        public XPCollection<TestDetail> Details
        {
            get { return GetCollection<TestDetail>("Details"); }
        }
    }
}
