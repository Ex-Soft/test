﻿using System;
using DevExpress.Xpo;
using DevExpress.XtraEditors.DXErrorProvider;

namespace TestUOWWinApp.Db
{
    [Persistent("TestDE")]
    class TestDE : XPBaseObject, IDXDataErrorInfo
    {
        long
            _id;

        int?
            _f1,
            _f2,
            _f3;

        public TestDE(Session session) : base(session)
        {
        }

        public TestDE(Session session, int? f1=null, int? f2=null, int? f3=null) : base(session)
        {
            this.f1 = f1;
            this.f2 = f2;
            this.f3 = f3;
        }

        [Key(true)]
        [Persistent("id")]
        [DisplayName("id")]
        public long id
        {
            get { return _id; }
            set { SetPropertyValue("id", ref _id, value); }
        }

        [Persistent("f1")]
        [DisplayName("f1")]
        public int? f1
        {
            get { return _f1; }
            set { SetPropertyValue("f1", ref _f1, value); }
        }

        [Persistent("f2")]
        [DisplayName("f2")]
        public int? f2
        {
            get { return _f2; }
            set { SetPropertyValue("f2", ref _f2, value); }
        }

        [Persistent("f3")]
        [DisplayName("f3")]
        public int? f3
        {
            get { return _f3; }
            set { SetPropertyValue("f3", ref _f3, value); }
        }

        public void GetPropertyError(string propertyName, ErrorInfo info)
        {
            if (info != null && !string.IsNullOrWhiteSpace(info.ErrorText))
                throw new NotImplementedException();
        }

        public void GetError(ErrorInfo info)
        {
            if (info != null && !string.IsNullOrWhiteSpace(info.ErrorText))
                throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{{ id: {id}, f1: {f1?.ToString() ?? "NULL"}, f2: {f2?.ToString() ?? "NULL"}, f3: {f3?.ToString() ?? "NULL"} }}";
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            System.Diagnostics.Debug.WriteLine($"XPBaseObject: OnChanged(\"{propertyName}\", {oldValue}, {newValue}) (IsLoading={IsLoading})");
            base.OnChanged(propertyName, oldValue, newValue);
        }

        protected override void OnSaving()
	    {
			System.Diagnostics.Debug.WriteLine("XPBaseObject: OnSaving");
		    base.OnSaving();
	    }

	    protected override void OnSaved()
	    {
			System.Diagnostics.Debug.WriteLine("XPBaseObject: OnSaved");
		    base.OnSaved();
	    }
    }
}
