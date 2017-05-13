using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.XtraEditors;

namespace TestDisplayName
{
    public partial class MainForm : XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
            XpoDefault.ConnectionString = MSSqlConnectionProvider.GetConnectionString(".", "sa", "123", "testdb");
            gridControl1.DataSource = new XPCollection<Db.TestDisplayName>();
        }
    }
}
