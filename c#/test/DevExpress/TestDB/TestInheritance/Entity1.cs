using DevExpress.Xpo;

namespace TestDB.TestInheritance
{
    [Persistent(nameof(Entity1))]
    public class Entity1 : XPBaseObject
    {
        public Entity1(Session session) : base(session)
        {}

        [Key]
        public int Id
        {
            get => GetPropertyValue<int>(nameof(Id));
            set => SetPropertyValue(nameof(Id), value);
        }

        public string Value
        {
            get => GetPropertyValue<string>(nameof(Value));
            set => SetPropertyValue(nameof(Value), value);
        }

        [Association("Entity1-Entity3Derived1", typeof(Entity3Derived1))]
        public XPCollection Entity3Derived1 => GetCollection(nameof(Entity3Derived1));
    }
}
