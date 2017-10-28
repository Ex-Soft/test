using DevExpress.Xpo;

namespace TestDB.TestXPO
{
    [Persistent("TestTable4TestPIVOTList")]
    public class TestTable4TestPIVOTList : XPCustomObject
    {
        private int
            _id,
            _cnt;

        [Key]
        public int Id
        {
            get { return _id; }
            set
            {
                System.Diagnostics.Debug.WriteLine($"TestTable4TestPIVOTList.set_Id({value})");
                SetPropertyValue("Id", ref _id, value);
            }
        }

        [Persistent("IdProduct")]
        [Delayed]
        public TestTable4TestPIVOTProduct Product
        {
            get { return GetDelayedPropertyValue<TestTable4TestPIVOTProduct>("Product"); }
            set
            {
                System.Diagnostics.Debug.WriteLine($"TestTable4TestPIVOTList.set_Product({value})");
                SetDelayedPropertyValue("Product", value);
            }
        }

        [Persistent("IdStore")]
        [Delayed]
        public TestTable4TestPIVOTStore Store
        {
            get { return GetDelayedPropertyValue<TestTable4TestPIVOTStore>("Store"); }
            set
            {
                System.Diagnostics.Debug.WriteLine($"TestTable4TestPIVOTList.set_Store({value})");
                SetDelayedPropertyValue("Store", value);
            }
        }

        public int Cnt
        {
            get { return _cnt; }
            set
            {
                System.Diagnostics.Debug.WriteLine($"TestTable4TestPIVOTList.set_Cnt({value})");
                SetPropertyValue("Cnt", ref _cnt, value);
            }
        }

        public TestTable4TestPIVOTList(Session session) : base(session)
        {
            System.Diagnostics.Debug.WriteLine("TestTable4TestPIVOTList.ctor(Session)");
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
