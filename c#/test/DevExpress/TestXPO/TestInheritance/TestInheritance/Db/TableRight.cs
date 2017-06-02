using DevExpress.Xpo;

namespace TestInheritance.Db
{
    [Persistent("TestDETableRight")]
    class Right : Center
    {
        string
            _valRight;

        public Right(Session session) : base(session)
        {
        }

        [Persistent("ValRight")]
        [DisplayName("ValRight")]
        public string ValRight
        {
            get { return _valRight; }
            set { SetPropertyValue("ValRight", ref _valRight, value); }
        }
    }
}
