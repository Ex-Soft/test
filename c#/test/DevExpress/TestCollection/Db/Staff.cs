using System;
using DevExpress.Xpo;

namespace TestCollection.Db
{
    [Persistent("Staff")]
    public class Staff : XPCustomObject
    {
        long
            _id;

        int
            _dep;

        string
            _name;

        decimal
            _salary;

        decimal?
            _nullField;

        DateTime
            _birthDate;

        [Persistent("Id"), Key(true)]
        public long Id
        {
            get { return _id; }
            set { SetPropertyValue("Id", ref _id, value); }
        }

        [Persistent("Name")]
        public string Name
        {
            get { return _name; }
            set { SetPropertyValue("Name", ref _name, value); }
        }

        [Persistent("Salary")]
        public decimal Salary
        {
            get { return _salary; }
            set { SetPropertyValue("Salary", ref _salary, value); }
        }

        [Persistent("Dep")]
        [DisplayName("Department")]
        public int Dep
        {
            get { return _dep; }
            set { SetPropertyValue("Dep", ref _dep, value); }
        }

        [Persistent("BirthDate")]
        [DisplayName("Birth Date")]
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { SetPropertyValue("BirthDate", ref _birthDate, value); }
        }

        [Persistent("NullField")]
        [DisplayName("Null Field")]
        public decimal? NullField
        {
            get { return _nullField; }
            set { SetPropertyValue("NullField", ref _nullField, value); }
        }

        public Staff(Session session) : base(session)
        {}
    }
}
