using DevExpress.Xpo;

namespace TestAssociation.Db
{
    [Persistent("TableLeft")]
    public class TableLeft : XPBaseObject
    {
        private int _id;
        private string _val;

        [Key]
        public int Id
        {
            get { return _id; }
            set { SetPropertyValue("Id", ref _id, value); }
        }

        public string Val
        {
            get { return _val; }
            set { SetPropertyValue("Val", ref _val, value); }
        }

        [Association("TableLeft-AssociativeTable")]
        public XPCollection<AssociativeTable> AssociativeTable => GetCollection<AssociativeTable>("AssociativeTable");

        public TableLeft(Session session) : base(session)
        {}
    }
}
