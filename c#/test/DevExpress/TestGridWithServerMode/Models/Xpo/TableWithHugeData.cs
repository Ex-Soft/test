using DevExpress.Xpo;

namespace TestGridWithServerMode.Models.Xpo
{
    [Persistent("TableWithHugeData")]
    class TableWithHugeData : XPBaseObject
    {
        private long _id;
        private string _fString;

        public TableWithHugeData(Session session) : base(session)
        {
        }

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
    }
}
