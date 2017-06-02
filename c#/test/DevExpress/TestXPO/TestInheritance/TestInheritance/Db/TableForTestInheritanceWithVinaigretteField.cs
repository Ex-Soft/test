#define TEST_AGGREGATED

using DevExpress.Xpo;

namespace TestInheritance.Db
{
    [Persistent("TableForTestInheritanceWithVinaigretteField")]
    public class TableForTestInheritanceWithVinaigretteField : XPBaseObject
    {
        int _id;
        string _value;

        [Key]
        [Persistent("Id")]
        public int Id
        {
            get { return _id; }
            set { SetPropertyValue("Id", ref _id, value); }
        }

        [Persistent("Value")]
        public string Value
        {
            get { return _value; }
            set { SetPropertyValue("Value", ref _value, value); }
        }

        public TableForTestInheritanceWithVinaigretteField(Session session) : base(session)
        {}
    }

    [MapInheritance(MapInheritanceType.ParentTable)]
    public class TableForTestInheritanceWithVinaigretteFieldA : TableForTestInheritanceWithVinaigretteField
    {
        TableForTestInheritanceForVinaigretteFieldA _vinaigretteField;

        #if TEST_AGGREGATED
            [Persistent("VinaigretteField")]
            [Association("A-Vinaigrette")]
            public TableForTestInheritanceForVinaigretteFieldA VinaigretteField
            {
                get { return _vinaigretteField; }
                set { SetPropertyValue("VinaigretteField", ref _vinaigretteField, value); }
            }
        #else
            [Persistent("VinaigretteField")]
            public TableForTestInheritanceForVinaigretteFieldA VinaigretteField
            {
                get { return _vinaigretteField; }
                set
                {
                    if (_vinaigretteField == value)
                        return;

                    var prevValue = _vinaigretteField;
                    _vinaigretteField = value;

                    if (IsLoading)
                        return;

                    if (prevValue != null && prevValue.VinaigretteField == this)
                        prevValue.VinaigretteField = null;

                    if (_vinaigretteField != null)
                        _vinaigretteField.VinaigretteField = this;

                    OnChanged("VinaigretteField");
                }
            }
        #endif

        public TableForTestInheritanceWithVinaigretteFieldA(Session session) : base(session)
        {}
    }

    [MapInheritance(MapInheritanceType.ParentTable)]
    public class TableForTestInheritanceWithVinaigretteFieldB : TableForTestInheritanceWithVinaigretteField
    {
        TableForTestInheritanceForVinaigretteFieldB _vinaigretteField;

        #if TEST_AGGREGATED
            [Persistent("VinaigretteField")]
            [Association("B-Vinaigrette")]
            public TableForTestInheritanceForVinaigretteFieldB VinaigretteField
            {
                get { return _vinaigretteField; }
                set { SetPropertyValue("VinaigretteField", ref _vinaigretteField, value); }
            }
        #else
            [Persistent("VinaigretteField")]
            public TableForTestInheritanceForVinaigretteFieldB VinaigretteField
            {
                get { return _vinaigretteField; }
                set
                {
                    if (_vinaigretteField == value)
                        return;

                    var prevValue = _vinaigretteField;
                    _vinaigretteField = value;

                    if (IsLoading)
                        return;

                    if (prevValue != null && prevValue.VinaigretteField == this)
                        prevValue.VinaigretteField = null;

                    if (_vinaigretteField != null)
                        _vinaigretteField.VinaigretteField = this;

                    OnChanged("VinaigretteField");
                }
            }
        #endif

        public TableForTestInheritanceWithVinaigretteFieldB(Session session) : base(session)
        {}
    }

    [Persistent("TableForTestInheritanceForVinaigretteFieldA")]
    public class TableForTestInheritanceForVinaigretteFieldA : XPBaseObject
    {
        int _id;
        string _value;

        [Key]
        [Persistent("Id")]
        public int Id
        {
            get { return _id; }
            set { SetPropertyValue("Id", ref _id, value); }
        }

        [Persistent("Value")]
        public string Value
        {
            get { return _value; }
            set { SetPropertyValue("Value", ref _value, value); }
        }
        
        #if TEST_AGGREGATED
            [Association("A-Vinaigrette"), Aggregated]
            public XPCollection<TableForTestInheritanceWithVinaigretteFieldA> VinaigretteField => GetCollection<TableForTestInheritanceWithVinaigretteFieldA>("VinaigretteField");
        #else
            TableForTestInheritanceWithVinaigretteFieldA _vinaigretteField;

            [NonPersistent]
            public TableForTestInheritanceWithVinaigretteFieldA VinaigretteField
            {
                get { return _vinaigretteField; }
                set
                {
                    if (_vinaigretteField == value)
                        return;

                    var prevValue = _vinaigretteField;
                    _vinaigretteField = value;

                    if (IsLoading)
                        return;

                    if (prevValue != null && prevValue.VinaigretteField == this)
                        prevValue.VinaigretteField = null;

                    if (_vinaigretteField != null)
                        _vinaigretteField.VinaigretteField = this;

                    OnChanged("VinaigretteField");
                }
            }
        #endif

        public TableForTestInheritanceForVinaigretteFieldA(Session session) : base(session)
        {}
    }

    [Persistent("TableForTestInheritanceForVinaigretteFieldB")]
    public class TableForTestInheritanceForVinaigretteFieldB : XPBaseObject
    {
        int _id;
        string _value;
        
        [Key]
        [Persistent("Id")]
        public int Id
        {
            get { return _id; }
            set { SetPropertyValue("Id", ref _id, value); }
        }

        [Persistent("Value")]
        public string Value
        {
            get { return _value; }
            set { SetPropertyValue("Value", ref _value, value); }
        }

        #if TEST_AGGREGATED
            [Association("B-Vinaigrette"), Aggregated]
            public XPCollection<TableForTestInheritanceWithVinaigretteFieldB> VinaigretteField => GetCollection<TableForTestInheritanceWithVinaigretteFieldB>("VinaigretteField");
        #else
            TableForTestInheritanceWithVinaigretteFieldB _vinaigretteField;

            [NonPersistent]
            public TableForTestInheritanceWithVinaigretteFieldB VinaigretteField
            {
                get { return _vinaigretteField; }
                set
                {
                    if (_vinaigretteField == value)
                        return;

                    var prevValue = _vinaigretteField;
                    _vinaigretteField = value;

                    if (IsLoading)
                        return;

                    if (prevValue != null && prevValue.VinaigretteField == this)
                        prevValue.VinaigretteField = null;

                    if (_vinaigretteField != null)
                        _vinaigretteField.VinaigretteField = this;

                    OnChanged("VinaigretteField");
                }
            }
        #endif

        public TableForTestInheritanceForVinaigretteFieldB(Session session) : base(session)
        {}
    }
}
