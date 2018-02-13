using DevExpress.Xpo;

namespace TestDB
{
    [Persistent("Victim")]
    public class Victim : XPCustomObject
    {
        public Victim(Session session) : base(session)
        {}

        [Persistent("id"), Key(true)]
        public long Id
        {
            get => GetPropertyValue<long>(nameof(Id));
            set => SetPropertyValue(nameof(Id), value);
        }

        [Persistent("f_int")]
        public int? FInt
        {
            get => GetPropertyValue<int?>(nameof(FInt));
            set => SetPropertyValue(nameof(FInt), value);
        }

        [Persistent("f_bit")]
        public bool? FBit
        {
            get => GetPropertyValue<bool?>(nameof(FBit));
            set => SetPropertyValue(nameof(FBit), value);
        }
    }
}
