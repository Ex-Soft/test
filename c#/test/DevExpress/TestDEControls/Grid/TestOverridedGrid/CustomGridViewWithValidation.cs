using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace TestOverridedGrid
{
    public class CustomGridViewWithValidation : GridView
    {
        public override string GetColumnError(GridColumn column)
        {
            return base.GetColumnError(column);
        }
    }
}
