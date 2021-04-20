namespace ClassLibrary
{
    public class Worker
    {
        public string Concat(A a)
        {
            return a != null ? a.AString1 + a.AString2 + a.AString3 : null;
        }

        public string Concat(A a, B b)
        {
            return a != null && b != null ? a.AString1 + b.BString1 + a.AString2 + b.BString2 + a.AString3 + b.BString3 : null;
        }
    }
}
