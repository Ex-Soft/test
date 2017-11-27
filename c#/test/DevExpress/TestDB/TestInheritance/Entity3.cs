using DevExpress.Xpo;

namespace TestDB.TestInheritance
{
    [Persistent("Entity3")]
    public class Entity3Base : XPBaseObject
    {
        public Entity3Base(Session session) : base(session)
        {}

        [Key(true)]
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
    }

    [MapInheritance(MapInheritanceType.ParentTable)]
    public class Entity3Derived1 : Entity3Base
    {
        public Entity3Derived1(Session session) : base(session)
        {}
        
        [Persistent("ElementId")]
        [Association("Entity1-Entity3Derived1", typeof(Entity1))/*, NoForeignKey*/]
        public Entity1 Element
        {
            get => GetPropertyValue<Entity1>(nameof(Element));
            set => SetPropertyValue(nameof(Element), value);
        }
    }

    [MapInheritance(MapInheritanceType.ParentTable)]
    public class Entity3Derived2 : Entity3Base
    {
        public Entity3Derived2(Session session) : base(session)
        {}
        
        [Persistent("ElementId")]
        [Association("Entity2-Entity3Derived2", typeof(Entity2))/*, NoForeignKey*/]
        public Entity2 Element
        {
            get => GetPropertyValue<Entity2>(nameof(Element));
            set => SetPropertyValue(nameof(Element), value);
        }
    }
}
