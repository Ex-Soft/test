using System.Collections.Generic;
using System.Data;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using TestDEControlsII.Db;
using ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode;

namespace TestDEControlsII
{
    public partial class GridForm3 : XtraForm
    {
        public GridForm3()
        {
            InitializeComponent();

            gridControl.DataSource = CreateData();
            //gridControl.DataSource = CreateDataTable();
            //gridControl.DataSource = new XPServerCollectionSource(unitOfWork, unitOfWork.GetClassInfo<TableWithHugeData>());
            //gridControl.DataSource = new XPCollection(unitOfWork, unitOfWork.GetClassInfo<TableWithHugeData>());
            //gridControl.DataSource = new XPCollection(unitOfWork, unitOfWork.GetClassInfo<TableWithHierarchy>());
            //gridControl.DataSource = new XPCollection<TableWithHierarchy>(unitOfWork);

            //gridView.OptionsFilter.ColumnFilterPopupMaxRecordsCount = 10;
            gridView.OptionsFilter.ColumnFilterPopupMode = ColumnFilterPopupMode.Classic;
            //gridView.OptionsCustomization.AllowFilter = false;

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

            var tmpDataColumn = result.Columns.Add("Id", typeof(int));
            tmpDataColumn.AllowDBNull = false;
            tmpDataColumn.Unique = true;

            result.Columns.Add("Val", typeof(string));

            for (var i = 0; i < 26; ++i)
            {
                var dataRow = result.NewRow();
                dataRow["Id"] = i;
                dataRow["Val"] = new string((char)(i + 0x41), 1);
                result.Rows.Add(dataRow);
            }

            return result;
        }
    }
}
