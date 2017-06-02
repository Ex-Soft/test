using DevExpress.Xpo;

namespace TestInheritance.Db
{
    [Persistent("TestDEMasterTableWithInheritance")]
    public class TestDEMasterTableWithInheritanceLite : XPBaseObject
    {
        int _id;
        string _valueLite;

        public TestDEMasterTableWithInheritanceLite(Session session) : base(session)
        {}

        [Key(true)]
        [Persistent("id")]
        public int Id
        {
            get { return _id; }
            set { SetPropertyValue("id", ref _id, value); }
        }

        [Persistent("valueLite")]
        public string ValueLite
        {
            get { return _valueLite; }
            set { SetPropertyValue("valueLite", ref _valueLite, value); }
        }

        [Association("TestMaster-TestDetail", typeof(TestDEDetailTableWithInheritanceLite))]
        public XPCollection<TestDEDetailTableWithInheritanceLite> Details
        {
            get { return GetCollection<TestDEDetailTableWithInheritanceLite>("Details"); }
        }
    }
    
    [MapInheritance(MapInheritanceType.ParentTable)]
    public class TestDEMasterTableWithInheritance : TestDEMasterTableWithInheritanceLite
    {
        string _value;

        public TestDEMasterTableWithInheritance(Session session) : base(session)
        {}

        [Persistent("value")]
        public string Value
        {
            get { return _value; }
            set { SetPropertyValue("Value", ref _value, value); }
        }

        [Association("TestMaster-TestDetail", typeof(TestDEDetailTableWithInheritance))]
        public new XPCollection<TestDEDetailTableWithInheritance> Details
        {
            get { return GetCollection<TestDEDetailTableWithInheritance>("Details"); }
        }
    }
}
