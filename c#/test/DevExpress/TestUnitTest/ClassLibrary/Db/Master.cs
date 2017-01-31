using DevExpress.Xpo;

namespace ClassLibrary.Db
{
    [Persistent("Master")]
    public class Master : XPBaseObject
    {
        private int _id;
        private string _name;

        [Key(true)]
        [Persistent("Id")]
        public int Id
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

        public Master(Session session) : base(session)
        {}
    }
}
