using DevExpress.Xpo;

namespace TestDB.TestInheritance
{
    [Persistent("TestDETableLeft")]
    class Left : Center
    {
        string
            _valLeft;

        public Left(Session session) : base(session)
        {
        }

        [Persistent("ValLeft")]
        [DisplayName("ValLeft")]
        public string ValLeft
        {
            get { return _valLeft; }
            set { SetPropertyValue("ValLeft", ref _valLeft, value); }
        }
    }
}
