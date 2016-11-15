using System;
using DevExpress.Xpo;
using DevExpress.XtraEditors.DXErrorProvider;

namespace TestDataSetDataStore.Db
{
    [Persistent("TableWithView")]
    class TableWithView : XPCustomObject, IDXDataErrorInfo
    {
        long
            _id;

        string
            _val;

		public TableWithView(Session session) : base(session)
        {
        }

        [Key(true)]
        [Persistent("Id")]
        public long Id
        {
            get { return _id; }
            set { SetPropertyValue("Id", ref _id, value); }
        }

        [Persistent("Val")]
        public string Val
        {
            get { return _val; }
            set { SetPropertyValue("Val", ref _val, value); }
        }

		[Delayed]
		[Persistent("idView")]
		public ViewFake View
		{
			get { return GetDelayedPropertyValue<ViewFake>("View"); }
			set { SetDelayedPropertyValue("View", value); }
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
    }
}
