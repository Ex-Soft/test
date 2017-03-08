using DevExpress.Xpo;

namespace TestAssociation.Db
{
    [Persistent("TableRight")]
    public class TableRight : XPBaseObject
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

        [Association("TableRight-AssociativeTable")]
        public XPCollection<AssociativeTable> AssociativeTable => GetCollection<AssociativeTable>("AssociativeTable");

        public TableRight(Session session) : base(session)
        {}
    }
}
