using DevExpress.Xpo;

namespace PolymorphicAssociations.Db
{
    [Persistent("TestDetailWithPolymorphicAssociations")]
    public class TestDetailWithPolymorphicAssociations : XPBaseObject
    {
        int _id;

        string
            _masterType,
            _val;

        TestMasterX _testMasterX;

        [Key(true)]
        [Persistent("Id")]
        public int Id
        {
            get { return _id; }
            set { SetPropertyValue("Id", ref _id, value); }
        }

        [Persistent("MasterType")]
        public string MasterType
        {
            get { return _masterType; }
            set { SetPropertyValue("MasterType", ref _masterType, value); }
        }

        [Persistent("MasterId")]
        [Association("TestMasterX-TestDetailWithPolymorphicAssociations", typeof(TestMasterX)), NoForeignKey]
        public TestMasterX TestMasterX
        {
            get { return _testMasterX; }
            set { SetPropertyValue("TestMasterX", ref _testMasterX, value); }
        } 

        [Persistent("Val")]
        public string Val
        {
            get { return _val; }
            set { SetPropertyValue("Val", ref _val, value); }
        }

        public TestDetailWithPolymorphicAssociations(Session session) : base(session)
        {}
    }
}
