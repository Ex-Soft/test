using DevExpress.Xpo;

namespace TestDisplayName
{
    public class CustomDisplayNameAttribute : DisplayNameAttribute
    {
        public CustomDisplayNameAttribute(string displayName) : base(displayName)
        {}

        public override string DisplayName
        {
            get { return base.DisplayName; }
        }
    }
}
