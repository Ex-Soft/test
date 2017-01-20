using DevExpress.Xpo;

namespace TestAssociation.Db
{
    [NonPersistent]
    public class NonPersistentDetail : XPBaseObject
    {
        private long _id;
        private NonPersistentMaster _master;
        private string _val;

        public NonPersistentDetail(Session session) : base(session)
        {}

        [Key(true)]
        public long Id
        {
            get { return _id; }
            set { SetPropertyValue("Id", ref _id, value); }
        }

        public string Val
        {
            get { return _val; }
            set { SetPropertyValue("Val", ref _val, value); }
        }

        [Association("NonPersistentMaster-NonPersistentDetail")]
        public NonPersistentMaster Master
        {
            get { return _master; }
            set { SetPropertyValue("Master", ref _master, value); }
        }
    }
}
