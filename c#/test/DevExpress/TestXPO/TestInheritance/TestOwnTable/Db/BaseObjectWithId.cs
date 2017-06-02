using DevExpress.Xpo;

namespace TestOwnTable.Db
{
    [NonPersistent]
    public abstract class BaseObjectWithId : XPBaseObject
    {
        int _id;

        [Key(false)]
        public int Id
        {
            get { return _id; }
            set { SetPropertyValue("Id", ref _id, value); }
        }

        protected BaseObjectWithId(Session session) : base(session)
        {}
    }
}
