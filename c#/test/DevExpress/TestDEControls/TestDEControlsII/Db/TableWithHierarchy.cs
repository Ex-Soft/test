using System;
using DevExpress.Xpo;
using DevExpress.Utils.Filtering;

namespace TestDEControlsII.Db
{
    [Persistent("TableWithHierarchy")]
    public class TableWithHierarchy : XPCustomObject
    {
        int
            _id;

        TableWithHierarchy
            _parent;

        string
            _val,
            _materializedPath;

        bool
            _selected;

        public TableWithHierarchy(Session session) : base(session)
        {}

        [Key(false)]
        public int Id
        {
            get { return _id; }
            set { SetPropertyValue("Id", ref _id, value); }
        }


        [Persistent("ParentId")]
        //[FilterLookup]
        //[DisplayName("ParentId")]
        public TableWithHierarchy Parent
        {
            get { return _parent; }
            set { SetPropertyValue("Parent", ref _parent, value); }
        }

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
