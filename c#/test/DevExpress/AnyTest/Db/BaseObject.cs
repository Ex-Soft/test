using DevExpress.Xpo;

namespace AnyTest.Db
{
    [NonPersistent]
    [OptimisticLocking(false)]
    public abstract class BaseObject : XPBaseObject
    {
        private long _id;
        private string _name;

        [Key]
        public long Id
        {
            get { return _id; }
            set { SetPropertyValue("Id", ref _id, value); }
        }

        public string Name
        {
            get { return _name; }
            set { SetPropertyValue("Name", ref _name, value); }
        }

        protected BaseObject(Session session) : base(session)
        {}
    }
}
