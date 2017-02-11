using System;
using DevExpress.Xpo;

namespace AnyTest.Db
{
    [NonPersistent]
    [OptimisticLocking(true)]
    public abstract class Object : BaseObject
    {
        private bool _handleSplitFieldChanged = true;
        private bool _notSplitFieldChanged;
        private string _propertyObject;

        public string PropertyObject
        {
            get { return _propertyObject; }
            set { SetPropertyValue("PropertyObject", ref _propertyObject, value); }
        }

        [NonPersistent]
        public bool HandleNotSplitFieldChanged
        {
            get { return _handleSplitFieldChanged; }
            set { _handleSplitFieldChanged = value; }
        }

        [NonPersistent]
        public bool NotSplitFieldChanged
        {
            get { return _notSplitFieldChanged; }
            set { _notSplitFieldChanged = value; }
        }

        protected void SetNotSplitFieldChanged<T>(bool value)
        {
            Object entity;
            if (Id > 0 && (entity = Session.GetObjectByKey<T>(Id) as Object) != null && entity.HandleNotSplitFieldChanged)
                entity.NotSplitFieldChanged = value;
        }

        protected void SetNotSplitFieldChanged(Type classType, bool value)
        {
            Object entity;
            if (Id > 0 && (entity = Session.GetObjectByKey(classType, Id) as Object) != null && entity.HandleNotSplitFieldChanged)
                entity.NotSplitFieldChanged = value;
        }

        protected Object(Session session) : base(session)
        {}

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);

            switch (propertyName)
            {
                case "PropertyObject":
                {
                    SetNotSplitFieldChanged(GetType(), true);
                    break;
                }
            }
        }
    }
}
