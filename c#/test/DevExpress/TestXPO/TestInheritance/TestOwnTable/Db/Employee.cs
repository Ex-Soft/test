using DevExpress.Xpo;

namespace TestOwnTable.Db
{
    [Persistent("Employee")]
    [MapInheritance(MapInheritanceType.OwnTable)]
    public class Employee : Person
    {
        decimal _salary;
        public decimal Salary
        {
            get { return _salary; }
            set { SetPropertyValue("Name", ref _salary, value); }
        }

        public Employee(Session session) : base(session)
        {}
    }
}
