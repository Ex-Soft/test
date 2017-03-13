using DevExpress.Xpo;

namespace TestXPO.Db
{
    [Persistent("TestTable4TestPIVOTProducts")]
    public class TestTable4TestPIVOTProduct : XPCustomObject
    {
        private int _id;
        private string _name;

        [Key]
        public int Id
        {
            get { return _id; }
            set
            {
                System.Diagnostics.Debug.WriteLine($"TestTable4TestPIVOTProduct.set_Id({value})");
                SetPropertyValue("Id", ref _id, value);
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                System.Diagnostics.Debug.WriteLine($"TestTable4TestPIVOTProduct.set_Name({value})");
                SetPropertyValue("Name", ref _name, value);
            }
        }

        public TestTable4TestPIVOTProduct(Session session) : base(session)
        {
            System.Diagnostics.Debug.WriteLine("TestTable4TestPIVOTProduct.ctor(Session)");
        }

        protected override void OnLoading()
        {
            System.Diagnostics.Debug.WriteLine("TestTable4TestPIVOTProduct.OnLoading()");
            base.OnLoading();
        }

        protected override void OnLoaded()
        {
            System.Diagnostics.Debug.WriteLine("TestTable4TestPIVOTProduct.OnLoaded()");
            base.OnLoaded();
        }
    }
}
