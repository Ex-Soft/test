using DevExpress.Xpo;

namespace TestDB.TestXPO
{
    [Persistent("TestTable4TestPIVOTProducts")]
    public class TestTable4TestPIVOTProduct : XPCustomObject
    {
        public TestTable4TestPIVOTProduct(Session session) : base(session)
        {
            System.Diagnostics.Debug.WriteLine("TestTable4TestPIVOTProduct.ctor(Session)");
        }

        [Key]
        public int Id
        {
            get { return GetPropertyValue<int>(nameof(Id)); }
            set
            {
                System.Diagnostics.Debug.WriteLine($"TestTable4TestPIVOTProduct.set_Id({value})");
                SetPropertyValue(nameof(Id), value);
            }
        }

        public string Name
        {
            get { return GetPropertyValue<string>(nameof(Name)); }
            set
            {
                System.Diagnostics.Debug.WriteLine($"TestTable4TestPIVOTProduct.set_Name({value})");
                SetPropertyValue(nameof(Name), value);
            }
        }

        [Association("List-Product", typeof(TestTable4TestPIVOTList))]
        public XPCollection List => GetCollection(nameof(List));

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
