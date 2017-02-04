using DevExpress.Xpo;

namespace TestXPO.Db
{
    [Persistent("EntityA")]
    public class EntityA : XPBaseObject
    {
        int _id;
        string _value;
        EntityA _main;

        [Key]
        [Persistent("Id")]
        public int Id
        {
            get { return _id; }
            set { SetPropertyValue("Id", ref _id, value); }
        }

        [Persistent("MainId")]
        public EntityA Main
        {
            get { return _main; }
            set { SetPropertyValue("Main", ref _main, value); }
        }

        [Persistent("Value")]
        public string Value
        {
            get { return _value; }
            set { SetPropertyValue("Value", ref _value, value); }
        }

        [Association("EntityA-EntityC")]
        public XPCollection<EntityC> EntityC => GetCollection<EntityC>("EntityC");

        public EntityA(Session session) : base(session)
        {}
    }
}
