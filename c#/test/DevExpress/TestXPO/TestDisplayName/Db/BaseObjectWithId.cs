using DevExpress.Xpo;

namespace TestDisplayName.Db
{
    [NonPersistent]
    public abstract class BaseObjectWithIdentityId : XPBaseObject
    {
        private int _id;
        private string _name;

        [Key(true)]

        public int Id
        {
            get { return _id;  }
            set { SetPropertyValue("Id", ref _id, value); }
        }

        [CustomDisplayName("Name (from BaseObjectWithId)")]
        public virtual string Name
        {
            get { return _name; }
            set { SetPropertyValue("Name", ref _name, value); }
        }

        public BaseObjectWithIdentityId(Session session) : base(session)
        {}

        public BaseObjectWithIdentityId(Session session, int id, string name) : base(session)
        {
            Id = id;
            Name = name;
        }
    }
}
