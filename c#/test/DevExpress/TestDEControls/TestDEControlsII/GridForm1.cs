using DevExpress.Utils;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using TestDEControlsII.Db;

namespace TestDEControlsII
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
