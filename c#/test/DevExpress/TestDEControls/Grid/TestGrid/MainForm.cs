using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using TestDB.TestMasterDetail;

namespace TestGrid
{
    public partial class MainForm : XtraForm
    {
        public MainForm()
        {
            InitializeComponent();

            XpoDefault.ConnectionString = MSSqlConnectionProvider.GetConnectionString(".", "sa", "123", "testdb");

            var session = new Session();

            SetDataSource(session);

            gridView.OptionsSelection.MultiSelect = true;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;

            gridView.OptionsLayout.Columns.AddNewColumns = true;

            gridView.OptionsBehavior.Editable = true;
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
                gridControl.DataSource = new XPServerCollectionSource(session, session.GetClassInfo<TestMaster>());
            }
        #endif

        private void BtnShowForm1Click(object sender, System.EventArgs e)
        {
            using (var modalForm = new Form1())
            {
                modalForm.ShowDialog(this);
            }
        }
    }
}
