namespace ClassLibrary
{
    public class B
    {
        public string BString1 { get; set; }
        public string BString2 { get; set; }
        public string BString3 { get; set; }

        public B(string pString1 = default, string pString2 = default, string pString3 = default)
        {
            BString1 = pString1;
            BString2 = pString2;
            BString3 = pString3;
        }

        public B(B obj):this(obj.BString1, obj.BString2, obj.BString3)
        {}

        public override string ToString()
        {
            return $"{{BString1:{(BString1 != null ? $"\"{BString1}\"" : "null")}, BString2:{(BString2 != null ? $"\"{BString2}\"" : "null")}, BString3:{(BString3 != null ? $"\"{BString3}\"" : "null")}}}";
        }
    }
}
