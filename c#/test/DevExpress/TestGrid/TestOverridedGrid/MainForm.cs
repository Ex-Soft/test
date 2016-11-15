#define USE_DB
//#define USE_SESSION
#define USE_SP
//#define USE_SERVER_COLLECTION

using System;
using System.Data;
using System.Data.SqlClient;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.XtraEditors;
using TestOverridedGrid.Db;

namespace TestOverridedGrid
{
    public partial class MainForm : XtraForm
    {
        #if !USE_DB
            private const int
                FieldsCountMax = 5,
                RowsCountMax = 5;
        #else
            private const string ConnectionString = "Server=.;Database=testdb;User ID=sa;Password=123";
        #endif

        private
        #if !USE_DB
            DataTable
        #else
            #if USE_SERVER_COLLECTION
                XPServerCollectionSource
            #else
                XPCollection
            #endif
        #endif
        _dataSource = null;

        #if USE_DB
            #if USE_SESSION
                private readonly Session _session;
            #else
                private readonly UnitOfWork _unitOfWork;
            #endif
        #endif

        public MainForm()
        {
            InitializeComponent();

            #if USE_DB
                XpoDefault.ConnectionString = MSSqlConnectionProvider.GetConnectionString("i-nozhenko", "sa", "123", "testdb");

                #if USE_SESSION
                    _session = new Session();
                #else
                    _unitOfWork = new UnitOfWork();
                #endif
            #endif

            gridControl.DataSource = DataSource;

            //gridView.OptionsSelection.UseIndicatorForSelection = false;
        }

        public
        #if !USE_DB
            DataTable
        #else
            #if USE_SERVER_COLLECTION
                XPServerCollectionSource
            #else
                XPCollection
            #endif
        #endif
        DataSource
        {
            get
            {
                if (_dataSource == null)
                    _dataSource = CreateDataSource();

                return _dataSource;
            }
        }

        private void BtnModifyDataClick(object sender, EventArgs e)
        {
            #if !USE_DB
                DataSource.Rows[0][0] = (char)(Convert.ToString(DataSource.Rows[0][0])[0] + 1) + Convert.ToString(DataSource.Rows[0][0]);
            #else
                #if !USE_SP
                    TestDE testDE;
                    if ((testDE =
                    #if USE_SESSION
                        _session
                    #else
                        _unitOfWork
                    #endif
                    .GetObjectByKey<TestDE>(1L)) != null)
                    {
                        testDE.f1 = testDE.f1.HasValue ? testDE.f1 + 1 : 1;
                        testDE.Save();
                    }

                    #if !USE_SESSION
                        _unitOfWork.CommitChanges();
                    #endif
                #else
                    ModifyDataBySP();
                #endif
            #endif
        }

        #if !USE_DB
            private static DataTable CreateDataSource()
            {
                var result = new DataTable();

                for (var i = 0; i < FieldsCountMax; ++i)
                    result.Columns.Add(new DataColumn($"Field{i}", typeof (string)));

                for (var i = 0; i < RowsCountMax; ++i)
                {
                    var row = result.NewRow();

                    for (var j = 0; j < FieldsCountMax; ++j)
                        row[j] = $"Cell [{i}, {j}]";

                    result.Rows.Add(row);
                }

                return result;
            }
        #else
            private
            #if USE_SERVER_COLLECTION
                XPServerCollectionSource
            #else
                XPCollection
            #endif
            CreateDataSource()
            {
                return new
                #if USE_SERVER_COLLECTION
                    XPServerCollectionSource
                #else
                    XPCollection
                #endif
                (
                #if USE_SESSION
                    _session
                #else
                    _unitOfWork
                #endif
                , typeof(TestDE));
            }
        #endif

        private void BtnReloadClick(object sender, EventArgs e)
        {
            #if !USE_SESSION
                _unitOfWork.DropIdentityMap();
            #endif
            DataSource.Reload();
        }

        private void BtnRefreshDataClick(object sender, EventArgs e)
        {
            gridView.RefreshData();
        }

        private void BtnRefreshClick(object sender, EventArgs e)
        {
            gridControl.Refresh();
        }

        private void BtnRefreshDataSourceClick(object sender, EventArgs e)
        {
            gridControl.RefreshDataSource();
        }

        #if USE_DB && USE_SP

            private static void ModifyDataBySP()
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "TestDEUpdater";
                        command.ExecuteNonQuery();
                    }
                }
            }

        #endif
    }
}
