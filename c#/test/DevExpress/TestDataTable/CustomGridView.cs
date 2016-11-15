using System;
using System.Threading;
using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Views.Grid;

namespace TestDataTable
{
    class CustomGridView : GridView
    {
        protected override CriteriaOperator ConvertGridFilterToDataFilter(CriteriaOperator criteria)
        {
            var res = base.ConvertGridFilterToDataFilter(criteria);
            var c = Thread.CurrentThread.CurrentCulture;

            try
            {
                object value = "22.04";
                var ic = value as IConvertible;
                var cc = Thread.CurrentThread.CurrentCulture;
                var dt = Convert.ChangeType(value, typeof (DateTime), cc);
            }
            catch (Exception eException)
            {
            }
            return res;
        }
    }
}
