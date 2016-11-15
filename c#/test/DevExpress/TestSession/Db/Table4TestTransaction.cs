#define TEST_EXCEPTION_IN_ONSAVING

using System;
using DevExpress.Xpo;

namespace TestSession.Db
{
    [Persistent("Table4TestTransaction")]
    public class Table4TestTransaction : XPCustomObject
    {
        long
            _id;

        string
            _value;

        public Table4TestTransaction(Session session) : base(session)
        {
        }

        [Key(true)]
        [Persistent("id")]
        public long id
        {
            get { return _id; }
            set { SetPropertyValue("id", ref _id, value); }
        }

        [Persistent("value")]
        public string Value
        {
            get { return _value; }
            set { SetPropertyValue("value", ref _value, value); }
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
