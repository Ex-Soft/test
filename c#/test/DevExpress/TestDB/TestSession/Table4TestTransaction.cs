//#define TEST_EXCEPTION_IN_ONSAVING

using System;
using DevExpress.Xpo;

namespace TestDB.TestSession
{
    [Persistent("Table4TestTransaction")]
    public class Table4TestTransaction : XPCustomObject
    {
        public Table4TestTransaction(Session session) : base(session)
        {}

        [Key(true)]
        public long id
        {
            get { return GetPropertyValue<long>(nameof(id)); }
            set { SetPropertyValue(nameof(id), value); }
        }

        [Persistent("value")]
        public string Value
        {
            get { return GetPropertyValue<string>(nameof(Value)); }
            set { SetPropertyValue(nameof(Value), value); }
        }

        #if TEST_EXCEPTION_IN_ONSAVING

            protected override void OnSaving()
            {
                //base.OnSaving();
                throw new Exception("from OnSaving()");
            }
        
        #endif
    }
}
