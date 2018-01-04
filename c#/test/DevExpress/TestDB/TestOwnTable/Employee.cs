using DevExpress.Xpo;

namespace TestDB.TestOwnTable
{
    [Persistent("Employee")]
    [MapInheritance(MapInheritanceType.OwnTable)]
    public class Employee : Person
    {
        public Employee(Session session) : base(session)
        {}

        public decimal Salary
        {
            get => GetPropertyValue<decimal>(nameof(Salary));
            set => SetPropertyValue(nameof(Salary), value);
        }
    }
}
