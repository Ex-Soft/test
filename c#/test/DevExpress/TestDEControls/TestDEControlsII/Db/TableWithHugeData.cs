using DevExpress.Xpo;

namespace TestDEControlsII.Db
{
    [Persistent("TableWithHugeData")]
    public class TableWithHugeData : XPBaseObject
    {
        long
            _id;

        string
            _fString;

        [Key(true)]
        public long Id
        {
            get { return _id; }
            set { SetPropertyValue("Id", ref _id, value); }
        }

        public string FString
        {
            get { return _fString; }
            set { SetPropertyValue("FString", ref _fString, value); }
        }
        public TableWithHugeData(Session session) : base(session)
        {}
    }
}
