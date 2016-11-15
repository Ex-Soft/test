using DevExpress.Xpo;

namespace TestInheritance.Db
{
    [Persistent("refGoods")]
    public class StuSKU : XPBaseObject
    {
        int _id;
        string _fullName;
        bool _isCompetitor;

        public StuSKU(Session session) : base(session)
        {}

        [Key(true)]
        [Persistent("id")]
        public int id
        {
            get { return _id; }
            set { SetPropertyValue("Id", ref _id, value); }
        }

        [Persistent("FullName")]
        public string FullName
        {
            get { return _fullName; }
            set { SetPropertyValue("FullName", ref _fullName, value); }
        }

        [Persistent("IsCompetitor")]
        public bool IsCompetitor
        {
            get { return _isCompetitor; }
            set { SetPropertyValue("IsCompetitor", ref _isCompetitor, value); }
        }

        [Association("SKU-StuSKUCopetitorByGood", typeof(StuSKUCompetitorByGood))]
        public XPCollection StuSKUCopetitorByGood
        {
            get
            {
                XPCollection result;

                //if (!IsBackward)
                    result = GetCollection("StuSKUCopetitorByGood");
                //else
                //    result = GetCollection("ForTestInheritanceDetailRight");

                return result;
            }
        }

        [Association("SKU-StuSKUCopetitorByCopetitor", typeof(StuSKUCompetitorByGood))]
        public XPCollection StuSKUCopetitorByCopetitor
        {
            get
            {
                XPCollection result;

                //if (!IsBackward)
                    result = GetCollection("StuSKUCopetitorByCopetitor");
                //else
                //    result = GetCollection("ForTestInheritanceDetailLeft");

                return result;
            }
        }
    }
}
