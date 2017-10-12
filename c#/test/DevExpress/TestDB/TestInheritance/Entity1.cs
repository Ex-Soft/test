using DevExpress.Xpo;

namespace TestDB.TestInheritance
{
    [Persistent("Entity1")]
    public class Entity1 : XPBaseObject
    {
        int _id;
        string _value;

        [Key]
        [Persistent("Id")]
        public int Id
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

        [Association("Entity1-Entity3Derived1", typeof(Entity3Derived1))]
        public XPCollection Entity3Derived1 => GetCollection("Entity3Derived1");

        public Entity1(Session session) : base(session)
        {}
    }
}
