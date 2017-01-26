using DevExpress.Xpo;

namespace TestDE16WinApp.Db
{
    [Persistent("TestDetail")]
    class TestDetail : XPCustomObject
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
        public long Id
        {
            get { return _id; }
            set { SetPropertyValue("Id", ref _id, value); }
        }
        
        [Persistent("IdMaster")]
        [Association("TestMaster-TestDetail")]
        public TestMaster Master
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
    }
}
