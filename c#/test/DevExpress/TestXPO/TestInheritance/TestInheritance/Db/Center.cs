using DevExpress.Xpo;

namespace TestInheritance.Db
{
    [NonPersistent]
    class Center : XPBaseObject
    {
        int
            _id;

        string
            _val;

        public Center(Session session) : base(session)
        {
        }

        [Key(true)]
        [Persistent("Id")]
        [DisplayName("ID")]
        public int Id
        {
            get { return _id; }
            set { SetPropertyValue("Id", ref _id, value); }
        }

        [Persistent("Val")]
        [DisplayName("Val")]
        public string Val
        {
            get { return _val; }
            set { SetPropertyValue("Val", ref _val, value); }
        }
    }
}
