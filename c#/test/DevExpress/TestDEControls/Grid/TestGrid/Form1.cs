using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.XtraEditors;

namespace TestGrid
{
    public partial class Form1 : XtraForm
    {
        const int
            MaxMaster = 5,
            MaxDetail = 10;

        readonly Session _session;

        public Form1()
        {
            XpoDefault.DataLayer = new SimpleDataLayer(new InMemoryDataStore());

            InitializeComponent();

            _session = new Session();

            FillInMemoryDataStore(_session);

            gridView.DisableCurrencyManager = true;

            gridControl.DataSource = new XPServerCollectionSource(_session, _session.GetClassInfo<Master>());
        }

        void FillInMemoryDataStore(Session session)
        {
            for (var i = 0; i < MaxMaster; ++i)
            {
                var master = new Master(session);
                master.Id = i;
                master.Name = $"Master# {i}";

                for (var j = 0; j < MaxDetail; ++j)
                {
                    Detail detail;
                    master.Details.Add(detail = new Detail(session));
                    detail.Id = i * MaxMaster * 100 + j;
                    detail.Name = $"Detail# {i}.{j}";
                }

                master.Save();
                session.Save(master);
            }
        }
    }

    [Persistent("Master")]
    class Master : XPCustomObject
    {
        public Master(Session session) : base(session)
        {}

        [Key(false)]
        public int Id
        {
            get => GetPropertyValue<int>(nameof(Id));
            set => SetPropertyValue(nameof(Id), value);
        }

        public string Name
        { 
            get => GetPropertyValue<string>(nameof(Name));
            set => SetPropertyValue(nameof(Name), value);
        }

        public bool PBool
        {
            get => GetPropertyValue<bool>(nameof(PBool));
            set => SetPropertyValue(nameof(PBool), value);
        }

        [Association("Master-Detail")]
        public XPCollection<Detail> Details => GetCollection<Detail>(nameof(Details));
    }

    [Persistent("Detail")]
    class Detail : XPCustomObject
    {
        public Detail(Session session) : base(session)
        {}

        [Key(false)]
        public int Id
        {
            get => GetPropertyValue<int>(nameof(Id));
            set => SetPropertyValue(nameof(Id), value);
        }

        [Persistent("MasterId")]
        [Association("Master-Detail")]
        public Master Master
        {
            get => GetPropertyValue<Master>(nameof(Master));
            set => SetPropertyValue(nameof(Master), value);
        }

        public string Name
        {
            get => GetPropertyValue<string>(nameof(Name));
            set => SetPropertyValue(nameof(Name), value);
        }

        public bool PBool
        {
            get => GetPropertyValue<bool>(nameof(PBool));
            set => SetPropertyValue(nameof(PBool), value);
        }
    }
}
