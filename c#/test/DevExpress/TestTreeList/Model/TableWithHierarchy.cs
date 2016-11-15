#define USE_ENTITY_AS_PARENT

using DevExpress.Xpo;

namespace TestTreeList.Model
{
    [Persistent("TableWithHierarchy")]
    public class TableWithHierarchy : XPCustomObject
    {
        int _id;

        #if USE_ENTITY_AS_PARENT
            TableWithHierarchy _parent;
        #else
            int? _parentId;
        #endif

        string
            _val,
            _materializedPath;

        bool
            _selected;

        public TableWithHierarchy(Session session) : base(session)
        {
        }

        [Key(false)]
        public int Id
        {
            get { return _id; }
            set { SetPropertyValue("Id", ref _id, value); }
        }

        #if USE_ENTITY_AS_PARENT
            [Persistent("ParentId")]
            public TableWithHierarchy Parent
            {
                get { return _parent; }
                set { SetPropertyValue("Parent", ref _parent, value); }
            }
        #else
            public int? ParentId
            {
                get { return _parentId; }
                set { SetPropertyValue("ParentId", ref _parentId, value); }
            }
        #endif

        public string Val
        {
            get { return _val; }
            set { SetPropertyValue("Val", ref _val, value); }
        }

        public string MaterializedPath
        {
            get { return _materializedPath; }
            set { SetPropertyValue("MaterializedPath", ref _materializedPath, value); }
        }

        public bool Selected
        {
            get { return _selected; }
            set { SetPropertyValue("Selected", ref _selected, value); }
        }
    }
}
