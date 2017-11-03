using DevExpress.Xpo;

namespace TestDB.TestXPO
{
    [Persistent("TestTable4TestPIVOTStores")]
    public class TestTable4TestPIVOTStore : XPCustomObject
    {
        public TestTable4TestPIVOTStore(Session session) : base(session)
        {
            System.Diagnostics.Debug.WriteLine("TestTable4TestPIVOTStore.ctor(Session)");
        }

        [Key]
        public int Id
        {
            get { return GetPropertyValue<int>(nameof(Id)); }
            set
            {
                System.Diagnostics.Debug.WriteLine($"TestTable4TestPIVOTStore.set_Id({value})");
                SetPropertyValue(nameof(Id), value);
            }
        }

        public string Name
        {
            get { return GetPropertyValue<string>(nameof(Name)); }
            set
            {
                System.Diagnostics.Debug.WriteLine($"TestTable4TestPIVOTStore.set_Name({value})");
                SetPropertyValue(nameof(Name), value);
            }
        }

        [Association("List-Store", typeof(TestTable4TestPIVOTList))]
        public XPCollection List => GetCollection(nameof(List));

        protected override void OnLoading()
        {
            System.Diagnostics.Debug.WriteLine("TestTable4TestPIVOTStore.OnLoading()");
            base.OnLoading();
        }

        protected override void OnLoaded()
        {
            System.Diagnostics.Debug.WriteLine("TestTable4TestPIVOTStore.OnLoaded()");
            base.OnLoaded();
        }
    }
}
