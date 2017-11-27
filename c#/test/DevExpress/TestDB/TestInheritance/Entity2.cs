using DevExpress.Xpo;

namespace TestDB.TestInheritance
{
    [Persistent(nameof(Entity2))]
    public class Entity2 : XPBaseObject
    {
        public Entity2(Session session) : base(session)
        {}

        [Key]
        public int Id
        {
            get => GetPropertyValue<int>(nameof(Id));
            set => SetPropertyValue(nameof(Id), value);
        }

        [Persistent("Value")]
        public string Value
        {
            get => GetPropertyValue<string>(nameof(Value));
            set => SetPropertyValue(nameof(Value), value);
        }

        [Association("Entity2-Entity3Derived2", typeof(Entity3Derived2))]
        public XPCollection Entity3Derived2 => GetCollection(nameof(Entity3Derived2));
    }
}
