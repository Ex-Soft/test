using DevExpress.Xpo;

namespace TestDB.TestInheritance
{
    [Persistent("Entity3")]
    public class Entity3Base : XPBaseObject
    {
        int _id;
        string _value;

        [Key(true)]
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

        public Entity3Base(Session session) : base(session)
        {}
    }

    [MapInheritance(MapInheritanceType.ParentTable)]
    public class Entity3Derived1 : Entity3Base
    {
        private Entity1 _element;

        [Persistent("ElementId")]
        [Association("Entity1-Entity3Derived1", typeof(Entity1))/*, NoForeignKey*/]
        public Entity1 Element
        {
            get { return _element; }
            set { SetPropertyValue("Element", ref _element, value); }
        }

        public Entity3Derived1(Session session) : base(session)
        {}
    }

    [MapInheritance(MapInheritanceType.ParentTable)]
    public class Entity3Derived2 : Entity3Base
    {
        private Entity2 _element;

        [Persistent("ElementId")]
        [Association("Entity2-Entity3Derived2", typeof(Entity2))/*, NoForeignKey*/]
        public Entity2 Element
        {
            get { return _element; }
            set { SetPropertyValue("Element", ref _element, value); }
        }

        public Entity3Derived2(Session session) : base(session)
        {}
    }
}
