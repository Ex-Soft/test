namespace ClassLibrary
{
    public class A
    {
        public string AString1 { get; set; }
        public string AString2 { get; set; }
        public string AString3 { get; set; }

        public A(string pString1 = default, string pString2 = default, string pString3 = default)
        {
            AString1 = pString1;
            AString2 = pString2;
            AString3 = pString3;
        }

        public A(A obj):this(obj.AString1, obj.AString2, obj.AString3)
        {}

        public override string ToString()
        {
            return $"{{AString1:{(AString1 != null ? $"\"{AString1}\"" : "null")}, AString2:{(AString2 != null ? $"\"{AString2}\"" : "null")}, AString3:{(AString3 != null ? $"\"{AString3}\"" : "null")}}}";
        }
    }
}
