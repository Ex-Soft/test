using DevExpress.Xpo;

namespace TestDB.TestOwnTable
{
    [NonPersistent]
    public abstract class BaseObjectWithId : XPBaseObject
    {
        protected BaseObjectWithId(Session session) : base(session)
        {}

        [Key(false)]
        public int Id
        {
            get => GetPropertyValue<int>(nameof(Id));
            set => SetPropertyValue(nameof(Id), value);
        }
    }
}
