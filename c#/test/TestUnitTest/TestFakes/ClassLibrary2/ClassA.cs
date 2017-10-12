namespace ClassLibrary2
{
    public class ClassA
    {
        public string FString { get; set; }

        public ClassA(string fString = "")
        {
            FString = fString;
        }

        public ClassA(ClassA obj) : this(obj.FString)
        {}
    }
}
