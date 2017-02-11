using DevExpress.Xpo;

namespace TestCollection.Db
{
    [Persistent("Victim")]
    public class Victim : XPCustomObject
    {
        private long _id;
        private int? _fInt;
        private bool? _fBit;

        [Persistent("id"), Key(true)]
        public long Id
        {
            get { return _id; }
            set { SetPropertyValue("Id", ref _id, value); }
        }

        [Persistent("f_int")]
        public int? FInt
        {
            get { return _fInt; }
            set { SetPropertyValue("FInt", ref _fInt, value); }
        }

        [Persistent("f_bit")]
        public bool? FBit
        {
            get { return _fBit; }
            set { SetPropertyValue("FBit", ref _fBit, value); }
        }

        public Victim(Session session) : base(session)
        {}
    }
}
