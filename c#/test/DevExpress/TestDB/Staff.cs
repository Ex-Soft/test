using System;
using DevExpress.Xpo;

namespace TestDB
{
    [Persistent("Staff")]
    public class Staff : XPCustomObject
    {
        public Staff(Session session) : base(session)
        {}

        [Persistent("ID"), Key(true)]
        public long Id
        {
            get => GetPropertyValue<long>(nameof(Id));
            set => SetPropertyValue(nameof(Id), value);
        }

        public string Name
        {
            get => GetPropertyValue<string>(nameof(Name));
            set => SetPropertyValue(nameof(Name), value);
        }

        public decimal Salary
        {
            get => GetPropertyValue<decimal>(nameof(Salary));
            set => SetPropertyValue(nameof(Salary), value);
        }

        [DisplayName("Department")]
        public int Dep
        {
            get => GetPropertyValue<int>(nameof(Dep));
            set => SetPropertyValue(nameof(Dep), value);
        }

        [DisplayName("Birth Date")]
        public DateTime BirthDate
        {
            get => GetPropertyValue<DateTime>(nameof(BirthDate));
            set => SetPropertyValue(nameof(BirthDate), value);
        }

        [DisplayName("Null Field")]
        public decimal? NullField
        {
            get => GetPropertyValue<decimal?>(nameof(NullField));
            set => SetPropertyValue(nameof(NullField), value);
        }
    }
}