#define USE_ENTITY_AS_PARENT

using DevExpress.Xpo;

namespace TestDB
{
    [Persistent("TableWithHierarchy")]
    public class TableWithHierarchy : XPCustomObject
    {
        public TableWithHierarchy(Session session) : base(session)
        {}

        [Key(false)]
        public int Id
        {
            get { return GetPropertyValue<int>(nameof(Id)); }
            set { SetPropertyValue(nameof(Id), value); }
        }

        #if USE_ENTITY_AS_PARENT
            [Persistent("ParentId")]
            public TableWithHierarchy Parent
            {
                get { return GetPropertyValue<TableWithHierarchy>(nameof(Parent)); }
                set { SetPropertyValue(nameof(Parent), value); }
            }
        #else
            public int? ParentId
            {
                get { return GetPropertyValue<int?>(nameof(ParentId)); }
                set { SetPropertyValue(nameof(ParentId), value); }
            }
        #endif

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
