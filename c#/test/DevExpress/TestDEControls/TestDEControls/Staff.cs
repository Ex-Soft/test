using System;
using DevExpress.Xpo;
using DevExpress.XtraEditors.DXErrorProvider;

namespace TestDEControls
{
    [Persistent("Staff")]
    public class Staff : XPCustomObject, IDXDataErrorInfo
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

        public Staff(Session session) : base(session)
        {
        }

        [Key(true)]
        [Persistent("ID")]
        [DisplayName("ID")]
        public long id
        {
            get { return _id; }
            set { SetPropertyValue("id", ref _id, value); }
        }

        [Persistent("Name")]
        [DisplayName("Name")]
        public string Name
        {
            get { return _name; }
            set { SetPropertyValue("Name", ref _name, value); }
        }

        [Persistent("Salary")]
        [DisplayName("Salary")]
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

        public void GetPropertyError(string propertyName, ErrorInfo info)
        {
            if (info != null
                && !string.IsNullOrWhiteSpace(info.ErrorText))
                throw new NotImplementedException();
        }

        public void GetError(ErrorInfo info)
        {
            if (info != null
                && !string.IsNullOrWhiteSpace(info.ErrorText))
                throw new NotImplementedException();
        }
    }
}