using DevExpress.Xpo;

namespace TestDB.TestOwnTable
{
    [Persistent("Person")]
    public class Person : BaseObjectWithId
    {
        string _name;
        public string Name
        {
            get { return _name; }
            set { SetPropertyValue("Name", ref _name, value); }
        }

        public Person(Session session) : base(session)
        {}
    }
}
