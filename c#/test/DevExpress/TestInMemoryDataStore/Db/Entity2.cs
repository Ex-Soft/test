using DevExpress.Xpo;

namespace TestInMemoryDataStore.Db
{
    [Persistent("Entity2")]
    public class Entity2 : XPBaseObject
    {
        long _id;
        string _value;

        [Key]
        [Persistent("Id")]
        public long Id
        {
            get { return _id; }
            set { SetPropertyValue("Id", ref _id, value); }
        }

        [Persistent("Value")]
        public string Value
        {
            get { return _value; }
            set { SetPropertyValue("Value", ref _value, value); }
        }

        [Association("Entity2-Entity3Derived2", typeof(Entity3Derived2))]
        public XPCollection Entity3Derived2 => GetCollection("Entity3Derived2");

        public Entity2(Session session) : base(session)
        {}
    }
}
