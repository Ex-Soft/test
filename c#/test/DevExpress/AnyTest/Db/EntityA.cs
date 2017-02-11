using DevExpress.Xpo;

namespace AnyTest.Db
{
    [Persistent("EntityA")]
    public class EntityA : Object
    {
        private string _propertyEntityA;

        public string PropertyEntityA
        {
            get { return _propertyEntityA; }
            set { SetPropertyValue("PropertyEntityA", ref _propertyEntityA, value); }
        }

        public EntityA(Session session) : base(session)
        {}

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);

            switch (propertyName)
            {
                case "PropertyEntityA":
                {
                    SetNotSplitFieldChanged<EntityA>(true);
                    SetNotSplitFieldChanged(GetType(), true);
                    break;
                }
            }
        }
    }
}
