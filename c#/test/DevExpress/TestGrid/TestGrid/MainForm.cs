using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
#if TEST_LINQ_IN_PROPERTY
    using TestGrid.Model;
#else
    using TestGrid.Model;
#endif

namespace TestGrid
{
    public partial class MainForm : XtraForm
    {
        public MainForm()
        {
            InitializeComponent();

            XpoDefault.ConnectionString = MSSqlConnectionProvider.GetConnectionString("i-nozhenko", "sa", "123", "testdb");

            var session = new Session();

            SetDataSource(session);

            gridView.OptionsSelection.MultiSelect = true;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
        }

        #if TEST_LINQ_IN_PROPERTY
            void SetDataSource(Session session)
            {
                var classInfo = session.GetClassInfo(typeof(TestMaster));
                var xpServerCollectionSource = new XPServerCollectionSource(session, classInfo);

                gridControl.DataSource = xpServerCollectionSource;
                gridView.OptionsLayout.Columns.AddNewColumns = true;
            }
        #else
            void SetDataSource(Session session)
            {
                var classInfo = session.GetClassInfo(typeof(TestMaster));
                var xpServerCollectionSource = new XPServerCollectionSource(session, classInfo);

                gridControl.DataSource = xpServerCollectionSource;
                gridView.OptionsLayout.Columns.AddNewColumns = true;
            }
        #endif
    }
}
