using DevExpress.Xpo;

namespace PolymorphicAssociations.Db
{
    [Persistent("TestMasterX")]
    public class TestMasterX : XPBaseObject
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

        [Association("TestMasterX-TestDetailWithPolymorphicAssociations", typeof(TestDetailWithPolymorphicAssociations))]
        public XPCollection TestDetailWithPolymorphicAssociations => GetCollection("TestDetailWithPolymorphicAssociations");

        public TestMasterX(Session session) : base(session)
        {}
    }
}
