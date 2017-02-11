using DevExpress.Xpo;

namespace AnyTest.Db
{
    [Persistent("EntityB")]
    public class EntityB : Object
    {
        private string _propertyEntityB;

        public string PropertyEntityB
        {
            get { return _propertyEntityB; }
            set { SetPropertyValue("PropertyEntityB", ref _propertyEntityB, value); }
        }

        public EntityB(Session session) : base(session)
        {}

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);

            switch (propertyName)
            {
                case "PropertyEntityB":
                {
                    SetNotSplitFieldChanged<EntityB>(true);
                    SetNotSplitFieldChanged(GetType(), true);
                    break;
                }
            }
        }
    }
}
