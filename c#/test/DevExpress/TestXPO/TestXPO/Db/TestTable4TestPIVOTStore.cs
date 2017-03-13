using DevExpress.Xpo;

namespace TestXPO.Db
{
    [Persistent("TestTable4TestPIVOTStores")]
    public class TestTable4TestPIVOTStore : XPCustomObject
    {
        private int _id;
        private string _name;

        [Key]
        public int Id
        {
            get { return _id; }
            set
            {
                System.Diagnostics.Debug.WriteLine($"TestTable4TestPIVOTStore.set_Id({value})");
                SetPropertyValue("Id", ref _id, value);
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                System.Diagnostics.Debug.WriteLine($"TestTable4TestPIVOTStore.set_Name({value})");
                SetPropertyValue("Name", ref _name, value);
            }
        }

        public TestTable4TestPIVOTStore(Session session) : base(session)
        {
            System.Diagnostics.Debug.WriteLine("TestTable4TestPIVOTStore.ctor(Session)");
        }

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
