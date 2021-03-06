﻿using DevExpress.Xpo;

namespace ClassLibrary.Db
{
    [Persistent("Enums")]
    public class Enums : XPBaseObject
    {
        private int _id;
        private string _codeKey;

        [Key(true)]
        [Persistent("Id")]
        public int Id
        {
            get { return _id; }
            set { SetPropertyValue("Id", ref _id, value); }
        }

        [Persistent("CodeKey")]
        public string CodeKey
        {
            get { return _codeKey; }
            set { SetPropertyValue("CodeKey", ref _codeKey, value); }
        }

        public Enums(Session session) : base(session)
        {}
    }
}
