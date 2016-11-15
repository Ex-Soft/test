namespace TestDEControls
{
    public class StubWithIdBool
    {
        public bool Id { get; set; }
        public string Name { get; set; }

        public StubWithIdBool(StubWithIdBool obj) : this(obj.Id, obj.Name)
        {}

        public StubWithIdBool(bool id=false, string name="")
        {
            Id = id;
            Name = name;
        }
    }

    public class StubWithIdNullableBool
    {
        public bool? Id { get; set; }
        public string Name { get; set; }

        public StubWithIdNullableBool(StubWithIdNullableBool obj) : this(obj.Id, obj.Name)
        {}

        public StubWithIdNullableBool(bool? id = null, string name = "")
        {
            Id = id;
            Name = name;
        }
    }

    public class StubWithIdDevExpressDefaultBoolean
    {
        public DevExpress.Utils.DefaultBoolean Id { get; set; }
        public string Name { get; set; }

        public StubWithIdDevExpressDefaultBoolean(StubWithIdDevExpressDefaultBoolean obj) : this(obj.Id, obj.Name)
        {}

        public StubWithIdDevExpressDefaultBoolean(DevExpress.Utils.DefaultBoolean id = DevExpress.Utils.DefaultBoolean.Default, string name = "")
        {
            Id = id;
            Name = name;
        }
    }

    public class StubWithIdInt
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public StubWithIdInt(StubWithIdInt obj) : this(obj.Id, obj.Name)
        {}

        public StubWithIdInt(int id=0, string name="")
        {
            Id = id;
            Name = name;
        }
    }
}
