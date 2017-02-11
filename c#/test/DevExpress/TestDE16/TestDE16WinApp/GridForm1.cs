using DevExpress.Utils;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using TestDE16WinApp.Db;

namespace TestDE16WinApp
{
    public partial class GridForm1 : XtraForm
    {
        public GridForm1()
        {
            InitializeComponent();
            //gridControl.DataSource = new XPCollection(typeof(TestDE));
            gridControl.DataSource = new XPServerCollectionSource(unitOfWork, typeof(TestDE));
            gridControl.AllowRestoreSelectionAndFocusedRow = DefaultBoolean.True;
        }
    }
}
