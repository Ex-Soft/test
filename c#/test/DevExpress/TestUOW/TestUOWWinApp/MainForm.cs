using System;
using System.Collections;
using System.Diagnostics;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Helpers;
using DevExpress.XtraEditors;
using TestUOWWinApp.Db;

namespace TestUOWWinApp
{
    public partial class MainForm : XtraForm
    {
        private readonly UnitOfWork _unitOfWork;

        public MainForm()
        {
            InitializeComponent();
            XpoDefault.ConnectionString = MSSqlConnectionProvider.GetConnectionString(".", "sa", "123", "testdb");
            _unitOfWork = new UnitOfWork();
        }

        private void btnCommitTransactionAsync_Click(object sender, System.EventArgs e)
        {
            Modify();

            int
                    param1 = 13,
                    param2 = 14;

            AsyncCommitCallback commitCallback = exception =>
            {
                Debug.WriteLine($"commitCallback({exception?.Message ?? "null"}) {{ param1 = {param1}; param2 = {param2}; }}");
            };

            param2 *= 2;

            _unitOfWork.CommitChangesAsync(commitCallback);

            var collectionOfTestDE = new XPCollection<TestDE>(_unitOfWork);

            collectionOfTestDE.LoadAsync(LoadObjectsCallback);
        }

        private void LoadObjectsCallback(ICollection[] result, Exception exception)
        {
            Debug.WriteLine($"loadObjectsCallback({result.Length}, {exception?.Message ?? "null"})");
        }

        private void btnCommitTransaction_Click(object sender, System.EventArgs e)
        {
            Modify();

            _unitOfWork.CommitChanges();

            var collectionOfTestDE = new XPCollection<TestDE>(_unitOfWork);
            collectionOfTestDE.Load();
            Debug.WriteLine($"collectionOfTestDE.Count={collectionOfTestDE.Count}");
        }

        private void Modify()
        {
            TestDE testDE;
            object tmpObject;

            if ((testDE = _unitOfWork.GetObjectByKey<TestDE>((tmpObject = _unitOfWork.ExecuteScalar("select min(id) from TestDE")) != null && !Convert.IsDBNull(tmpObject) ? Convert.ToInt64(tmpObject) : 1L)) == null)
                return;

            testDE.f1 = testDE.f1 * 2 ?? 1;
            testDE.Save();
        }
    }
}
