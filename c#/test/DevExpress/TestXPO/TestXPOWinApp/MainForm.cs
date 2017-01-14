using System;
using System.Diagnostics;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.XtraEditors;
using TestXPOWinApp.Db;

namespace TestXPOWinApp
{
    public partial class MainForm : XtraForm
    {
        private readonly Session _session;

        public MainForm()
        {
            InitializeComponent();
            XpoDefault.ConnectionString = MSSqlConnectionProvider.GetConnectionString(".", "sa", "123", "testdb");
            _session = new Session(components);
        }

        private void btnCommitTransaction_Click(object sender, EventArgs e)
        {
            TestDE testDE;

            try
            {
                _session.BeginTransaction();

                if ((testDE = _session.GetObjectByKey<TestDE>(1L)) == null)
                    return;

                testDE.f1 = 0;

                int
                    param1 = 13,
                    param2 = 14;

                AsyncCommitCallback commitCallback = exception =>
                {
                    Debug.WriteLine($"commitCallback({exception?.Message ?? "null"}) {{ param1 = {param1}; param2 = {param2}; }}");
                };

                param2 *= 2;

                _session.CommitTransactionAsync(commitCallback);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.GetType().FullName + Environment.NewLine + "Message: " + exception.Message + Environment.NewLine + (exception.InnerException != null && !string.IsNullOrEmpty(exception.InnerException.Message) ? "InnerException.Message" + exception.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + exception.StackTrace);
            }
            finally
            {
                if (_session.InTransaction)
                    _session.RollbackTransaction();
            }
        }
    }
}
