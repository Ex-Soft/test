#define CHECK_ID

using System.Diagnostics;
using DevExpress.XtraGrid.Localization;

namespace TestFilter
{
    class CustomGridLocalizer : GridLocalizer
    {
        public override string GetLocalizedString(GridStringId id)
        {
            var result = base.GetLocalizedString(id);

            #if CHECK_ID
                Debug.WriteLine($"GridLocalizer.{System.Reflection.MethodBase.GetCurrentMethod().Name}.{id}={result}");
            #endif

            return result;
        }
    }
}
