using DevExpress.Xpo;

namespace TestCollection
{
    public class CustomCollection : XPCollection
    {
    }

    public class CustomCollection<T> : XPCollection<T>
    {
        public CustomCollection(Session session) : base(session)
        {}
    }
}
