using DevExpress.Xpo;

namespace TestDB.TestOwnTable
{
    [Persistent("Executive")]
    [MapInheritance(MapInheritanceType.OwnTable)]
    public class Executive : Employee
    {
        public Executive(Session session) : base(session)
        {}

        public decimal Bonus
        {
            get => GetPropertyValue<decimal>(nameof(Bonus));
            set => SetPropertyValue(nameof(Bonus), value);
        }
    }
}
