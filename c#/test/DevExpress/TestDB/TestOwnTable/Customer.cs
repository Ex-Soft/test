using DevExpress.Xpo;

namespace TestDB.TestOwnTable
{
    [Persistent("Customer")]
    [MapInheritance(MapInheritanceType.OwnTable)]
    public class Customer : Person
    {
        string _preferences;
        public string Preferences
        {
            get { return _preferences; }
            set { SetPropertyValue("Preferences", ref _preferences, value); }
        }

        public Customer(Session session) : base(session)
        {}
    }
}
