using System;
using System.Diagnostics;
using System.Reflection;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Localization;
using DevExpress.Utils.Filtering.Internal;
using DevExpress.XtraGrid.Views.Grid;
using TestFilter.Db;

namespace TestFilter
{
    public partial class MainForm : XtraForm
    {
        const int MaxRecordCount = 10;

        readonly Session _session;

        public MainForm()
        {
            InitializeComponent();

            _session = new Session();

            FillInMemoryDataStore(_session);

            //gridControlCommon.DataSource = new XPCollection<TestTable4Types>(_session);
            gridControlCommon.DataSource = new XPServerCollectionSource(_session, _session.GetClassInfo<TestTable4Types>());
            gridControlMaster.DataSource = new XPCollection<TestMaster>(_session);
            gridControlDetail.DataSource = new XPCollection<TestDetail>(_session);
            treeList.DataSource = new XPCollection<TableWithHierarchy>(_session);
            gridControlWithCustomFilter.DataSource = new XPCollection<TestTable4Types>(_session);

            // Turn off FilterPopupMode.Excel
            // https://www.devexpress.com/Support/Center/Question/Details/T576583/gridview-handlers-showfilterpopupcheckedlistbox-showfilterpopuplistbox
            //gridViewCommon.CustomDrawColumnHeader += GridViewCustomDrawColumnHeader;

            gridViewWithCustomFilter.ShowFilterPopupExcel += GridViewShowFilterPopupExcel;
        }

        private void GridViewShowFilterPopupExcel(object sender, FilterPopupExcelEventArgs e)
        {
            Debug.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        private void GridViewCustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            GridView gridView;
            if ((gridView = sender as GridView) == null
                || e.Column == null
                || e.Column.FieldName != nameof(TestTable4Types.NonPersistentFString))
                return;

            System.Diagnostics.Debug.WriteLine(e.Column.FieldName);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Localize();
        }

        private static void Localize()
        {
            Localizer.Active = new CustomLocalizer();
            GridLocalizer.Active = new CustomGridLocalizer();
            FilteringLocalizer.Active = new CustomFilteringLocalizer();
            FilterUIElementLocalizer.Active = new CustomFilterUIElementLocalizer();
        }

        void FillInMemoryDataStore(Session session)
        {
            AddCommon(session);
            AddMaster(session);
            AddTree(session);
        }

        void AddCommon(Session session)
        {
            for (var i = 1; i <= MaxRecordCount; ++i)
            {
                var tmpTestTable4Types = new TestTable4Types(session);

                tmpTestTable4Types.FBool = i % 2 == 0;
                tmpTestTable4Types.FInt = i;
                tmpTestTable4Types.FLong = i;
                tmpTestTable4Types.FDouble = i + i / 10;
                tmpTestTable4Types.FDecimal = i + i / 10;
                tmpTestTable4Types.FDateTime = DateTime.Now.AddDays(i * 30);
                tmpTestTable4Types.FTimeSpan = DateTime.Now.TimeOfDay.Add(new TimeSpan(i, i, i, i, i));

                if (i % 2 == 0)
                {
                    tmpTestTable4Types.FBoolNullable = i % 4 == 0;
                    tmpTestTable4Types.FString = $"FString# {i}";
                    tmpTestTable4Types.FIntNullable = i;
                    tmpTestTable4Types.FLongNullable = i;
                    tmpTestTable4Types.FDateTimeNullable = DateTime.Now.AddDays(i * 30);
                    tmpTestTable4Types.FDoubleNullable = i + i / 10;
                    tmpTestTable4Types.FDecimalNullable = i + i / 10;
                    tmpTestTable4Types.FTimeSpanNullable = DateTime.Now.TimeOfDay.Add(new TimeSpan(i, i, i, i, i));
                }

                tmpTestTable4Types.Save();
            }

            XPBaseCollection dataSource;
            if ((dataSource = gridControlCommon.DataSource as XPBaseCollection) != null)
                dataSource.Reload();
        }

        void AddMaster(Session session)
        {
            for (var i = 1; i <= MaxRecordCount; ++i)
            {
                var tmpTestMaster = new TestMaster(session);
                tmpTestMaster.Val = $"Master# {i}";
                for (var j = 1; j <= MaxRecordCount; ++j)
                {
                    var tmpTestDetail = new TestDetail(session);
                    tmpTestDetail.Val = $"Detail# [{i}.{j}]";
                    tmpTestDetail.Master = tmpTestMaster;
                    tmpTestDetail.Save();
                }
                tmpTestMaster.Save();
            }

            XPBaseCollection dataSource;
            if ((dataSource = gridControlMaster.DataSource as XPBaseCollection) != null)
                dataSource.Reload();
            if ((dataSource = gridControlDetail.DataSource as XPBaseCollection) != null)
                dataSource.Reload();
        }

        void AddTree(Session session)
        {
            var parent = new TableWithHierarchy(session);

            parent.Val = "Root";
            parent.Save();

            for (var i = 1; i <= MaxRecordCount; ++i)
            {
                var child = new TableWithHierarchy(session);

                child.Parent = parent;
                child.Val = $"{i}";
                child.MaterializedPath = $"/{i}";
                child.Save();

                for (var j = 1; j <= MaxRecordCount; ++j)
                {
                    var childChild = new TableWithHierarchy(session);

                    childChild.Parent = child;
                    childChild.Val = $"{i}.{j}";
                    childChild.MaterializedPath = $"/{i}/{j}";
                    childChild.Save();
                }
            }
        }

        void BtnAddClick(object sender, EventArgs e)
        {
            SimpleButton button;
            if ((button = sender as SimpleButton) == null)
                return;

            Action<Session> action = null;

            switch (button.Tag.ToString())
            {
                case "Common":
                {
                    action = AddCommon;
                    break;
                }
                case "Master":
                {
                    action = AddMaster;
                    break;
                }
            }

            action?.Invoke(_session);
        }

        private void CheckEditHandlerCheckedChanged(object sender, EventArgs e)
        {
            if (checkEditHandler.Checked)
                gridViewCommon.ShowFilterPopupListBox += GridViewShowFilterPopupListBox;
            else
                gridViewCommon.ShowFilterPopupListBox -= GridViewShowFilterPopupListBox;
        }

        private void GridViewShowFilterPopupListBox(object sender, FilterPopupListBoxEventArgs e)
        {}
    }
}
