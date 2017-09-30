using System.Collections.Generic;
using System.Data;
using DevExpress.Utils.Menu;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using TestDEControlsII.Db;

namespace TestDEControlsII
{
    public partial class GridForm3 : XtraForm
    {
        public GridForm3()
        {
            InitializeComponent();

            gridControl.DataSource = CreateData();
            //gridControl.DataSource = CreateDataTable();
            //gridControl.DataSource = CustomGridForm1.CreateData();
            //gridControl.DataSource = new XPServerCollectionSource(unitOfWork, unitOfWork.GetClassInfo<TableWithHugeData>());
            //gridControl.DataSource = new XPCollection(unitOfWork, unitOfWork.GetClassInfo<TableWithHugeData>());
            //gridControl.DataSource = new XPCollection(unitOfWork, unitOfWork.GetClassInfo<TableWithHierarchy>());
            //gridControl.DataSource = new XPCollection<TableWithHierarchy>(unitOfWork);

            //gridView.OptionsFilter.ColumnFilterPopupMaxRecordsCount = 10;
            //gridView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Classic;
            //gridView.OptionsCustomization.AllowFilter = false;

            // https://www.devexpress.com/Support/Center/Question/Details/Q422943/xtragrid-remove-grouping-tab-disable-editing-row-multi-select
            gridView.OptionsCustomization.AllowGroup = false;
            gridView.OptionsView.ShowGroupPanel = false;
            //gridView.OptionsMenu.EnableGroupPanelMenu = false;

            // https://www.devexpress.com/Support/Center/Question/Details/A47/how-to-disable-particular-menu-items-in-the-default-grid-menus
            gridView.PopupMenuShowing += GridViewPopupMenuShowing;

            //gridView.PopulateColumns();

            string
                //valueMemberFieldName = "Parent!",
                valueMemberFieldName = "Id",
                displayMemberFieldName = "Val";

            GridColumn gridColumn;
            if ((gridColumn = gridView.Columns.ColumnByFieldName(valueMemberFieldName)) != null)
            {
                RepositoryItemLookUpEdit repositoryItemLookUpEdit;
                gridColumn.ColumnEdit = repositoryItemLookUpEdit = new RepositoryItemLookUpEdit
                {
                    ShowHeader = false,
                    ShowFooter = false,
                    ValueMember = valueMemberFieldName,
                    DisplayMember = displayMemberFieldName,
                    DataSource = gridControl.DataSource
                };

                repositoryItemLookUpEdit.Columns.Clear();
                repositoryItemLookUpEdit.Columns.Add(new LookUpColumnInfo(displayMemberFieldName));
                //repositoryItemLookUpEdit.KeyMember = "Parent!";

                gridColumn.FilterMode = ColumnFilterMode.DisplayText;
            }
        }

        // https://www.devexpress.com/Support/Center/Question/Details/A47/how-to-disable-particular-menu-items-in-the-default-grid-menus
        private void GridViewPopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            GridView gridView;
            GridViewColumnMenu menu;

            if ((gridView = sender as GridView) == null
                || !e.HitInfo.InColumn
                || e.MenuType != GridMenuType.Column
                || (menu = e.Menu as GridViewColumnMenu) == null) 
                return;

            DXMenuItem
                menuColumnGroup,
                menuColumnGroupBox;

            if ((menuColumnGroup = GetItemByStringId(menu, GridStringId.MenuColumnGroup)) != null) // "Group By This Column"
                menuColumnGroup.Enabled = false;
            if ((menuColumnGroupBox = GetItemByStringId(menu, GridStringId.MenuGroupPanelShow)) != null) // "Show Group By Box"
                menuColumnGroupBox.Enabled = false;
        }

        // https://www.devexpress.com/Support/Center/Question/Details/A47/how-to-disable-particular-menu-items-in-the-default-grid-menus
        private DXMenuItem GetItemByStringId(DXPopupMenu menu, GridStringId id)
        {
            foreach (DXMenuItem item in menu.Items)
                if (item.Caption == GridLocalizer.Active.GetLocalizedString(id))
                    return item;

            return null;
        }

        private static IEnumerable<string> CreateData()
        {
            var result = new List<string>();

            for (var i = 0; i < 26; ++i)
            {
                var str = string.Empty;

                for (var j = 0; j < 5; ++j)
                {
                    if (!string.IsNullOrWhiteSpace(str))
                        str += " ";

                    str += new string((char)(i + 0x41), 1);
                }

                result.Add(str);
            }

            return result;
        }

        private static DataTable CreateDataTable()
        {
            var result = new DataTable();

            var tmpDataColumn = result.Columns.Add("Id", typeof(long));
            tmpDataColumn.AllowDBNull = false;
            tmpDataColumn.Unique = true;

            result.Columns.Add("Val", typeof(string));

            DataRow dataRow;

            for (var i = 0; i < 26; ++i)
            {
                dataRow = result.NewRow();
                dataRow["Id"] = i;
                dataRow["Val"] = new string((char)(i + 0x41), 1);
                result.Rows.Add(dataRow);
            }

            dataRow = result.NewRow();
            dataRow["Id"] = 201707245844801;
            dataRow["Val"] = "Infinity";
            result.Rows.Add(dataRow);
            
            return result;
        }
    }
}
