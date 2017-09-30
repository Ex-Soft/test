using DevExpress.Utils.Filtering.Internal;

namespace TestOverridedGrid
{
    class CustomFilterUIElementLocalizer : FilterUIElementLocalizer
    {
        public override string GetLocalizedString(FilterUIElementLocalizerStringId id)
        {
            return base.GetLocalizedString(id);
        }
    }
}
