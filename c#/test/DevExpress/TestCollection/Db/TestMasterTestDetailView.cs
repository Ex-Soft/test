#if TEST_An_item_with_the_same_key_has_already_been_added

using DevExpress.Xpo;

namespace TestCollection.Db
{
    [Persistent("vTestMasterTestDetail")]
    public class TestMasterTestDetailView : XPLiteObject
    {
        long
            _masterId;

        long?
            _detailId;

        string
            _masterVal,
            _detailVal;

        public TestMasterTestDetailView(Session session) : base(session)
        {
        }

        [Key(false)]
        [Persistent("MasterId"), Delayed]
        public long MasterId
        {
            get { return _masterId; }
            set { SetPropertyValue("MasterId", ref _masterId, value); }
        }

        [Persistent("MasterVal"), Delayed]
        public string MasterVal
        {
            get { return _masterVal; }
            set { SetPropertyValue("MasterVal", ref _masterVal, value); }
        }

        [Persistent("DetailId"), Delayed]
        public long? DetailId
        {
            get { return _detailId; }
            set { SetPropertyValue("DetailId", ref _detailId, value); }
        }

        [Persistent("DetailVal"), Delayed]
        public string DetailVal
        {
            get { return _detailVal; }
            set { SetPropertyValue("DetailVal", ref _detailVal, value); }
        }
    }
}

#endif