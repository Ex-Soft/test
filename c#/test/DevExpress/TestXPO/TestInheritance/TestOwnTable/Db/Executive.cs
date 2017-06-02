using DevExpress.Xpo;

namespace TestOwnTable.Db
{
    [Persistent("Executive")]
    [MapInheritance(MapInheritanceType.OwnTable)]
    public class Executive : Employee
    {
        decimal _bonus;
        public decimal Bonus
        {
            get { return _bonus; }
            set { SetPropertyValue("Bonus", ref _bonus, value); }
        }

        public Executive(Session session) : base(session)
        {}
    }
}
