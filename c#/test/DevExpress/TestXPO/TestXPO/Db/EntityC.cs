using DevExpress.Xpo;

namespace TestXPO.Db
{
    [Persistent("EntityC")]
    public class EntityC : XPBaseObject
    {
        int _id;
        string _value;
        EntityA _entityA;
        EntityB _entityB;

        [Key(true)]
        [Persistent("Id")]
        public int Id
        {
            get { return _id; }
            set { SetPropertyValue("Id", ref _id, value); }
        }

        [Association("EntityA-EntityC")]
        [Persistent("EntityAId")]
        public EntityA EntityA
        {
            get { return _entityA; }
            set { SetPropertyValue("EntityA", ref _entityA, value); }
        }

        [Association("EntityB-EntityC")]
        [Persistent("EntityBId")]
        public EntityB EntityB
        {
            get { return _entityB; }
            set { SetPropertyValue("EntityB", ref _entityB, value); }
        }

        [Persistent("Value")]
        public string Value
        {
            get { return _value; }
            set { SetPropertyValue("Value", ref _value, value); }
        }

        public EntityC(Session session) : base(session)
        {}
    }
}
