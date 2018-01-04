using DevExpress.Xpo;

namespace TestDB.TestOwnTable
{
    [Persistent("Customer")]
    [MapInheritance(MapInheritanceType.OwnTable)]
    public class Customer : Person
    {
        public Customer(Session session) : base(session)
        {}

        public string Preferences
        {
            get => GetPropertyValue<string>(nameof(Preferences));
            set => SetPropertyValue(nameof(Preferences), value);
        }
    }
}
