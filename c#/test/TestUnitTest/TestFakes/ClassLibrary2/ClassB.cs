namespace ClassLibrary2
{
    public class ClassB
    {
        public string FString { get; set; }

        public ClassB(string fString = "")
        {
            FString = fString;
        }

        public ClassB(ClassB obj) : this(obj.FString)
        {}
    }
}
