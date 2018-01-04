using DevExpress.Xpo;

namespace TestDB.TestOwnTable
{
    [Persistent("Person")]
    public class Person : BaseObjectWithId
    {
        public Person(Session session) : base(session)
        {}

        public string Name
        {
            get => GetPropertyValue<string>(nameof(Name));
            set => SetPropertyValue(nameof(Name), value);
        }
    }
}
