using DevExpress.Xpo;

namespace TestAssociation.Db
{
    [NonPersistent]
    public class NonPersistentMaster : XPBaseObject
    {
        private long _id;
        private string _val;

        public NonPersistentMaster(Session session) : base(session)
        {
        }

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
        public XPCollection<NonPersistentDetail> Details
        {
            get { return GetCollection<NonPersistentDetail>("Details"); }
        }
    }
}
