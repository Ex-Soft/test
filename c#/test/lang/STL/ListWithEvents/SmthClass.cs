namespace ListWithEvents
{
    public class SmthClass
    {
        public string PString { get; set; }

        public SmthClass(string pString = "")
        {
            PString = pString;
        }

        public SmthClass(SmthClass obj) : this(obj.PString)
        { }

        public override string ToString()
        {
            return $"{{PString:\"{PString}\"}}";
        }
    }
}
