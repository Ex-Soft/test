#define CHECK_ID

using System.Diagnostics;
using DevExpress.Utils.Filtering.Internal;

namespace TestOverridedGrid
{
    class CustomFilteringLocalizer : FilteringLocalizer
    {
        public override string GetLocalizedString(FilteringLocalizerStringId id)
        {
            var result = base.GetLocalizedString(id);

            #if CHECK_ID
                Debug.WriteLine($"FilteringLocalizer.{System.Reflection.MethodBase.GetCurrentMethod().Name}.{id}={result}");
            #endif

            return result;
        }
    }
}
