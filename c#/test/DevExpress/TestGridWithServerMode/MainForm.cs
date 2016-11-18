// https://documentation.devexpress.com/#WindowsForms/CustomDocument3265
// https://documentation.devexpress.com/#CoreLibraries/clsDevExpressDataLinqEntityServerModeSourcetopic
// https://documentation.devexpress.com/#CoreLibraries/clsDevExpressDataLinqLinqServerModeSourcetopic

#define USE_XPServerCollectionSource
//#define USE_EntityServerModeSource
//#define USE_LinqServerModeSource

using System.Configuration;
using System.Linq;
using DevExpress.Data.Linq;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using TestGridWithServerMode.Models.EF;

namespace TestGridWithServerMode
{
    public partial class MainForm : XtraForm
    {
        const string ConnectionStringKey = "TestDBContext";

        public MainForm()
        {
            InitializeComponent();

            #if USE_XPServerCollectionSource
                XpoDefault.ConnectionString = $"XpoProvider=MSSqlServer;{GetConnectionString()}";

                var session = new Session();
                var classInfo = session.GetClassInfo(typeof(Models.Xpo.TableWithHugeData));
                var xpServerCollectionSource = new XPServerCollectionSource(session, classInfo);
                gridControl.DataSource = xpServerCollectionSource;
            #elif USE_LinqServerModeSource || USE_EntityServerModeSource
                var db = new TestDBContext();
                gridControl.DataSource = new
                    #if USE_LinqServerModeSource
                        LinqServerModeSource
                    #elif USE_EntityServerModeSource
                        EntityServerModeSource
                    #endif
                { KeyExpression = "Id", QueryableSource = db.TableWithHugeData };
            #endif
        }

        #if USE_XPServerCollectionSource
            private static string GetConnectionString()
            {
                var result = string.Empty;

                if (ConfigurationManager.ConnectionStrings.OfType<ConnectionStringSettings>().Any(cs => cs.Name == ConnectionStringKey))
                    result = ConfigurationManager.ConnectionStrings[ConnectionStringKey].ConnectionString;

                return result;
            }
        #endif

        private void btnDoIt_Click(object sender, System.EventArgs e)
        {
            if (sender == null)
                return;
        }
    }
}
