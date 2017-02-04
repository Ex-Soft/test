using DevExpress.Xpo;

namespace TestXPO.Db
{
    [Persistent("EntityB")]
    public class EntityB : XPBaseObject
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

        [Association("EntityB-EntityC")]
        public XPCollection<EntityC> EntityC => GetCollection<EntityC>("EntityC");

        [Persistent("Value")]
        public string Value
        {
            get { return _value; }
            set { SetPropertyValue("Value", ref _value, value); }
        }

        public EntityB(Session session) : base(session)
        {}
    }
}
