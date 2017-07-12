//#define INVALID_CAST_EXCEPTION
#define PREVENT_INVALID_CAST_EXCEPTION

using System.Collections.Generic;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;

namespace TestDEControlsII
{
    public partial class CustomGridForm1 : XtraForm
    {
        const string
            ValueMemberFieldName = "Id",
            DisplayMemberFieldName = "Val";

        public CustomGridForm1()
        {
            InitializeComponent();

            #if INVALID_CAST_EXCEPTION
                gridControl.DataSource = CreateDataTable();
            #else
                gridControl.DataSource = CreateData();                
            #endif

            GridColumn gridColumn;
            if ((gridColumn = gridView.Columns.ColumnByFieldName(ValueMemberFieldName)) != null)
            {
                RepositoryItemLookUpEdit repositoryItemLookUpEdit;
                gridColumn.ColumnEdit = repositoryItemLookUpEdit = new RepositoryItemLookUpEdit
                {
                    ShowHeader = false,
                    ShowFooter = false,
                    ValueMember = ValueMemberFieldName,
                    DisplayMember = DisplayMemberFieldName,
                    #if INVALID_CAST_EXCEPTION && PREVENT_INVALID_CAST_EXCEPTION
                        DataSource = CreateData()
                    #else
                        DataSource = gridControl.DataSource
                    #endif
                };

                repositoryItemLookUpEdit.Columns.Clear();
                repositoryItemLookUpEdit.Columns.Add(new LookUpColumnInfo(DisplayMemberFieldName));

                gridColumn.FilterMode = ColumnFilterMode.DisplayText;
            }
        }

        private static IEnumerable<Data> CreateData()
        {
            var result = new List<Data>();

            for (var i = 0; i < 26; ++i)
                result.Add(new Data(i, new string((char)(i + 0x41), 1)));

            return result;
        }

        private static DataTable CreateDataTable()
        {
            var result = new DataTable();

            var tmpDataColumn = result.Columns.Add(ValueMemberFieldName, typeof(int));
            tmpDataColumn.AllowDBNull = false;
            tmpDataColumn.Unique = true;

            result.Columns.Add(DisplayMemberFieldName, typeof(string));

            for (var i = 0; i < 26; ++i)
            {
                var dataRow = result.NewRow();
                dataRow[ValueMemberFieldName] = i;
                dataRow[DisplayMemberFieldName] = new string((char)(i + 0x41), 1);
                result.Rows.Add(dataRow);
            }

            return result;
        }
    }

    class Data
    {
        public int Id { get; set; }
        public string Val { get; set; }

        public Data(int id = 0, string val = "")
        {
            Id = id;
            Val = val;
        }

        public override string ToString()
        {
            return Val;
        }
    }
}
