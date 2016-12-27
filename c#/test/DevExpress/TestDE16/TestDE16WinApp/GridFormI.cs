using DevExpress.Xpo;
using DevExpress.XtraEditors;
using TestDE16WinApp.Db;

namespace TestDE16WinApp
{
    public partial class GridFormI : XtraForm
    {
        public GridFormI()
        {
            InitializeComponent();
            gridControl.DataSource = new XPCollection(typeof(TestDE));
            //gridControl.DataSource = new XPServerCollectionSource(unitOfWork, typeof(TestDE));
        }
    }
}
