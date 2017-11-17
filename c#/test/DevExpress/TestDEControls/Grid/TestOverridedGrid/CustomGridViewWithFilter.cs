using DevExpress.Xpo;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace TestOverridedGrid
{
    public class CustomGridViewWithFilter : GridView
    {
        protected override void OnPopulateColumns()
        {
            base.OnPopulateColumns();

            var xpCollection = DataSource as XPCollection;
            var session = xpCollection?.Session;

            foreach (GridColumn column in Columns)
            {
                System.Diagnostics.Debug.WriteLine(column.ColumnType);

                if (session != null)
                {
                    var classInfo = session.GetClassInfo(column.ColumnType);
                    if (classInfo != null)
                        column.FilterMode = ColumnFilterMode.DisplayText;
                }
            }
        }

        protected override object[] GetFilterPopupValuesCore(GridColumn column, bool allowAsync, OperationCompleted asyncCompleted)
        {
            return base.GetFilterPopupValuesCore(column, allowAsync, asyncCompleted);
        }
    }
}
