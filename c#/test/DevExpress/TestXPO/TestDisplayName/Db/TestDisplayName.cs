using DevExpress.Xpo;

namespace TestDisplayName.Db
{
    [Persistent("TestDisplayName")]
    public class TestDisplayName : BaseObjectWithIdentityId
    {
        public TestDisplayName(Session session) : base(session)
        {}

        public TestDisplayName(Session session, int id, string name) : base(session, id, name)
        {}

        [CustomDisplayName("Name (from TestDisplayName")]
        public override string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }
    }
}
