using DevExpress.Xpo;

namespace TestAssociation.Db
{
    [Persistent("AssociativeTable")]
    public class AssociativeTable : XPBaseObject
    {
        private int _id;
        private TableLeft _left;
        private TableRight _right;

        [Key(true)]
        public int Id
        {
            get { return _id; }
            set { SetPropertyValue("Id", ref _id, value); }
        }

        [Persistent("LeftId")]
        [Association("TableLeft-AssociativeTable")]
        public TableLeft Left
        {
            get { return _left; }
            set { SetPropertyValue("Left", ref _left, value); }
        }

        [Persistent("RightId")]
        [Association("TableRight-AssociativeTable")]
        public TableRight Right
        {
            get { return _right; }
            set { SetPropertyValue("Right", ref _right, value); }
        }

        public AssociativeTable(Session session) : base(session)
        {}
    }
}
