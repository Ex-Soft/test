using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace TestDEControlsII
{
    class CustomGridView : GridView
    {
        protected override object[] GetFilterPopupValuesCore(GridColumn column, bool allowAsync, OperationCompleted asyncCompleted)
        {
            //return OptionsFilter.ColumnFilterPopupMaxRecordsCount == 0 ? null : base.GetFilterPopupValuesCore(column, allowAsync, asyncCompleted);
            return null;
        }
    }
}
