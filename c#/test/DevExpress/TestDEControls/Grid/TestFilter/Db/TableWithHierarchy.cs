using DevExpress.Xpo;

namespace TestFilter.Db
{
    [Persistent("TableWithHierarchy")]
    public class TableWithHierarchy : XPCustomObject
    {
        public TableWithHierarchy(Session session) : base(session)
        {}

        [Key(true)]
        public int ID
        {
            get { return GetPropertyValue<int>(nameof(ID)); }
            set { SetPropertyValue(nameof(ID), value); }
        }

        public TableWithHierarchy Parent
        {
            get { return GetPropertyValue<TableWithHierarchy>(nameof(Parent)); }
            set { SetPropertyValue(nameof(Parent), value); }
        }

        public string Val
        {
            get { return GetPropertyValue<string>(nameof(Val)); }
            set { SetPropertyValue(nameof(Val), value); }
        }

        public string MaterializedPath
        {
            get { return GetPropertyValue<string>(nameof(MaterializedPath)); }
            set { SetPropertyValue(nameof(MaterializedPath), value); }
        }

        public bool Selected
        {
            get { return GetPropertyValue<bool>(nameof(Selected)); }
            set { SetPropertyValue(nameof(Selected), value); }
        }
    }
}
