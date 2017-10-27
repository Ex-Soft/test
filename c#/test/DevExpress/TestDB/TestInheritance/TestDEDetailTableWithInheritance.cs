//#define TRY_VIRTUAL

using DevExpress.Xpo;

namespace TestDB.TestInheritance
{
    [Persistent("TestDEDetailTableWithInheritance")]
    public class TestDEDetailTableWithInheritanceLite : XPBaseObject
    {
        int _id;
        string _valueLite;
        protected TestDEMasterTableWithInheritanceLite _master;

        public TestDEDetailTableWithInheritanceLite(Session session) : base(session)
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

        [Persistent("idMaster")]
        [Association("TestMasterTableWithInheritanceLite-TestDetailTableWithInheritanceLite")]
        public TestDEMasterTableWithInheritanceLite Master
        {
            get { return _master; }
            set
            {
                #if TRY_VIRTUAL
                    SetMaster(value);
                #else
                    SetPropertyValue("Master", ref _master, value);
                #endif
            }
        }

        #if TRY_VIRTUAL
            protected virtual bool SetMaster(TestDEMasterTableWithInheritanceLite value)
            {
                return SetPropertyValue("Master", ref _master, value);
            }
        #endif
    }

    [MapInheritance(MapInheritanceType.ParentTable)]
    public class TestDEDetailTableWithInheritance : TestDEDetailTableWithInheritanceLite
    {
        string _value;

        public TestDEDetailTableWithInheritance(Session session) : base(session)
        {}

        [Persistent("value")]
        public string Value
        {
            get { return _value; }
            set { SetPropertyValue("Value", ref _value, value); }
        }

        // [Persistent("idMaster")] // not needed - inherited
        // [Association("TestMasterTableWithInheritanceLite-TestDetailTableWithInheritanceLite")] // not needed - inherited
        public new TestDEMasterTableWithInheritance Master
        {
            get { return _master as TestDEMasterTableWithInheritance; }
            set
            {
                #if TRY_VIRTUAL
                    SetMaster(value);
                #else
                    SetPropertyValue("Master", ref _master, value);
                #endif
            }
        }

        #if TRY_VIRTUAL
            protected override bool SetMaster(TestDEMasterTableWithInheritanceLite value)
            {
                return SetPropertyValue("Master", ref _master, value as TestDEMasterTableWithInheritanceLite);
            }
        #endif
    }
}
