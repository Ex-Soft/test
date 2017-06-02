using DevExpress.Xpo;

namespace TestInheritance.Db
{
    [Persistent("refGoodsCompetitors")]
    public class StuSKUCompetitorByGood : XPBaseObject
    {
        int _id;
        string _value;

        StuSKU
            _SKU,
            _SKUCompetitor;

        public StuSKUCompetitorByGood(Session session) : base(session)
        {}

        [Key(true)]
        [Persistent("id")]
        public int id
        {
            get { return _id; }
            set { SetPropertyValue("id", ref _id, value); }
        }

        [Persistent("Value")]
        public string Value
        {
            get { return _value; }
            set { SetPropertyValue("Value", ref _value, value); }
        }

        [Persistent("idGoods")]
        [Association("SKU-StuSKUCopetitorByGood", typeof(StuSKU))]
        public StuSKU PersistentSKU
        {
            get { return _SKU ; }
            set { SetPropertyValue("PersistentSKU", ref _SKU, value); }
        }

        [Persistent("idGoodsCompetitor")]
        [Association("SKU-StuSKUCopetitorByCopetitor", typeof(StuSKU))]
        public StuSKU PersistentSKUCompetitor
        {
            get { return _SKUCompetitor; }
            set { SetPropertyValue("PersistentSKUCompetitor", ref _SKUCompetitor, value); }
        }

        [NonPersistent]
        public StuSKU SKU
        {
            get { return PersistentSKU != null ? (!PersistentSKU.IsCompetitor ? PersistentSKU : PersistentSKUCompetitor) : PersistentSKU; }
            set
            {
                if (PersistentSKU != null)
                {
                    if (!PersistentSKU.IsCompetitor)
                        PersistentSKU = value;
                    else
                        PersistentSKUCompetitor = value;
                }
                else
                    PersistentSKU = value;
            }
        }

        [NonPersistent]
        public StuSKU SKUCompetitor
        {
            get { return PersistentSKU != null ? (!PersistentSKU.IsCompetitor ? PersistentSKUCompetitor : PersistentSKU) : PersistentSKUCompetitor; }
            set
            {
                if (PersistentSKU != null)
                {
                    if (!PersistentSKU.IsCompetitor)
                        PersistentSKUCompetitor = value;
                    else
                        PersistentSKU = value;
                }
                else
                    PersistentSKUCompetitor = value;
            }
        }
    }
}
