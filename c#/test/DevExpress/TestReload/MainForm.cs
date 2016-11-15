using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Internal;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;

namespace TestReload
{
    public partial class MainForm : Form
    {
        Session _session;

        public MainForm()
        {
            InitializeComponent();

            XpoDefault.ConnectionString = MSSqlConnectionProvider.GetConnectionString("i-nozhenko", "sa", "123", "testdb");

            _session = new Session();
            gridControl.DataSource = new XPServerCollectionSource(_session, _session.GetClassInfo(typeof(TestDE)));
            //((XPServerCollectionSource)gridControl.DataSource).TrackChanges = true;
        }

        private void BtnEditInAnotherSessionClick(object sender, System.EventArgs e)
        {
            Session session = new Session();

            TestDE testDE = session.GetObjectByKey<TestDE>(5L);

            testDE.f3++;
            testDE.Save();
            session.Save(testDE);

            testDE = _session.GetObjectByKey<TestDE>(5L);
            testDE.Reload();

            //gridView.RefreshRow(4); // works
            //gridView.RefreshData(); // works
            gridView.LayoutChanged(); // works

            //gridControl.RefreshDataSource(); // works
            //gridControl.Invalidate(); // doesn't work

            //gridView.Invalidate(); // doesn't work
            //gridView.InvalidateRow(4); // doesn't work
            //gridView.InvalidateRows();  // doesn't work

            //((XPServerCollectionSource)gridControl.DataSource).Reload(); // works
        }

        private void BtnEditItInGridSessionClick(object sender, System.EventArgs e)
        {
            TestDE testDE = _session.GetObjectByKey<TestDE>(5L);

            testDE.f3++;
            testDE.Save();

            _session.Save(testDE);

            gridView.RefreshRow(4);
            //gridView.RefreshData(); // works
            //gridView.LayoutChanged(); // works

            //gridControl.RefreshDataSource(); // works
        }
    }
}
