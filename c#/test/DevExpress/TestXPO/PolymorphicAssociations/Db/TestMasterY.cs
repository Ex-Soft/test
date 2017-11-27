using DevExpress.Xpo;

namespace PolymorphicAssociations.Db
{
    [Persistent("TestMasterY")]
    public class TestMasterY : XPBaseObject
    {
        int _id;
        string _val;

        [Key(true)]
        [Persistent("Id")]
        public int Id
        {
            get { return _id; }
            set { SetPropertyValue("Id", ref _id, value); }
        }

        [Persistent("Val")]
        public string Val
        {
            get { return _val; }
            set { SetPropertyValue("Val", ref _val, value); }
        }

        public TestMasterY(Session session) : base(session)
        {}
    }
}
