#define CHECK_ID

using System.Diagnostics;
using DevExpress.XtraEditors.Controls;

namespace TestFilter
{
    class CustomLocalizer : Localizer
    {
        public override string GetLocalizedString(StringId id)
        {
            var result = base.GetLocalizedString(id);

            #if CHECK_ID
                Debug.WriteLine($"Localizer.{System.Reflection.MethodBase.GetCurrentMethod().Name}.{id}={result}");
            #endif

            return result;
        }
    }
}
