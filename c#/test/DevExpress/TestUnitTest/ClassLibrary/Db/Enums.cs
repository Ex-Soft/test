using DevExpress.Xpo;

namespace ClassLibrary.Db
{
    [Persistent("Enums")]
    public class Enums : XPBaseObject
    {
        int _id;
        string _codeKey;

        public Enums(Session session) : base(session)
        {}

        [Key(true)]
        [Persistent("Id")]
        public int Id
        {
            get { return _id; }
            set { SetPropertyValue("Id", ref _id, value); }
        }

        [Persistent("CodeKey")]
        [DisplayName("CodeKey")]
        public string CodeKey
        {
            get { return _codeKey; }
            set { SetPropertyValue("CodeKey", ref _codeKey, value); }
        }
    }
}
