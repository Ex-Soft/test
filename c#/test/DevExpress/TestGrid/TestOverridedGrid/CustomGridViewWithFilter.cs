using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace TestOverridedGrid
{
    public class CustomGridViewWithFilter : GridView
    {
        protected override object[] GetFilterPopupValuesCore(GridColumn column, bool allowAsync, OperationCompleted asyncCompleted)
        {
            return base.GetFilterPopupValuesCore(column, allowAsync, asyncCompleted);
        }
    }
}
