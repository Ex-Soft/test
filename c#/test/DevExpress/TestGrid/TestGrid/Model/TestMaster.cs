using System;
using System.Linq;
using DevExpress.Xpo;
using DevExpress.XtraEditors.DXErrorProvider;

namespace TestGrid.Model
{
    [Persistent("TestMaster")]
    class TestMaster : XPCustomObject, IDXDataErrorInfo
    {
        long
            _id;

        string
            _val;

        public TestMaster(Session session) : base(session)
        {
        }

        [Key(true)]
        [Persistent("Id")]
        [DisplayName("ID")]
        public long Id
        {
            get { return _id; }
            set { SetPropertyValue("Id", ref _id, value); }
        }

        [Persistent("Val")]
        [DisplayName("Val")]
        public string Name
        {
            get { return _val; }
            set { SetPropertyValue("Val", ref _val, value); }
        }

        [Association("TestMaster-TestDetail")]
        public XPCollection<TestDetail> Details
        {
            get { return GetCollection<TestDetail>("Details"); }
        }

        #if TEST_LINQ_IN_PROPERTY

        [NonPersistent]
        [DisplayName("AggregateNameLength")]
        public int AggregateNameLength
        {
            get
            {
                //throw new NullReferenceException();
                return Details.Select(detail => detail.Name).Aggregate(0, (value, next) => value + next.Length);
            }
        }

        #endif


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
