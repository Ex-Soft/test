using DevExpress.Xpo;

namespace TestDB.TestXPO
{
    [Persistent("TestTable4TestPIVOTList")]
    public class TestTable4TestPIVOTList : XPCustomObject
    {
        public TestTable4TestPIVOTList(Session session) : base(session)
        {
            System.Diagnostics.Debug.WriteLine("TestTable4TestPIVOTList.ctor(Session)");
        }

        [Key]
        public int Id
        {
            get { return GetPropertyValue<int>(nameof(Id)); }
            set
            {
                System.Diagnostics.Debug.WriteLine($"TestTable4TestPIVOTList.set_Id({value})");
                SetPropertyValue(nameof(Id), value);
            }
        }

        [Persistent("IdProduct")]
        [Association("List-Product", typeof(TestTable4TestPIVOTProduct))]
        [Delayed]
        public TestTable4TestPIVOTProduct Product
        {
            get { return GetDelayedPropertyValue<TestTable4TestPIVOTProduct>(nameof(Product)); }
            set
            {
                System.Diagnostics.Debug.WriteLine($"TestTable4TestPIVOTList.set_Product({value})");
                SetDelayedPropertyValue(nameof(Product), value);
            }
        }

        [Persistent("IdStore")]
        [Association("List-Store", typeof(TestTable4TestPIVOTStore))]
        [Delayed]
        public TestTable4TestPIVOTStore Store
        {
            get { return GetDelayedPropertyValue<TestTable4TestPIVOTStore>(nameof(Store)); }
            set
            {
                System.Diagnostics.Debug.WriteLine($"TestTable4TestPIVOTList.set_Store({value})");
                SetDelayedPropertyValue(nameof(Store), value);
            }
        }

        public int Cnt
        {
            get { return GetPropertyValue<int>(nameof(Cnt)); }
            set
            {
                System.Diagnostics.Debug.WriteLine($"TestTable4TestPIVOTList.set_Cnt({value})");
                SetPropertyValue(nameof(Cnt), value);
            }
        }

        protected override void OnLoading()
        {
            System.Diagnostics.Debug.WriteLine("TestTable4TestPIVOTList.OnLoading()");
            base.OnLoading();
        }

        protected override void OnLoaded()
        {
            System.Diagnostics.Debug.WriteLine("TestTable4TestPIVOTList.OnLoaded()");
            base.OnLoaded();
        }
    }
}
