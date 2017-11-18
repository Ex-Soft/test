#define CHECK_ID

using System.Diagnostics;
using DevExpress.Utils.Filtering.Internal;

namespace TestFilter
{
    class CustomFilterUIElementLocalizer : FilterUIElementLocalizer
    {
        public override string GetLocalizedString(FilterUIElementLocalizerStringId id)
        {
            var result = base.GetLocalizedString(id);

            #if CHECK_ID
                Debug.WriteLine($"FilterUIElementLocalizer.{System.Reflection.MethodBase.GetCurrentMethod().Name}.{id}={result}");
            #endif

            return result;
        }
    }
}
