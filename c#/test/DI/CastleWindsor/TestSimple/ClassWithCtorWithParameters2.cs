namespace TestSimple
{
    public class ClassWithCtorWithParameters2 : IClassWithCtorWithParameters2
    {
        public int PInt { get; set; }
        public string PString { get; set; }

        public ClassWithCtorWithParameters2(int pInt = 0, string pString = "")
        {
            PInt = pInt;
            PString = pString;
        }

        public override string ToString()
        {
            return $"{{PInt:{PInt}, PString:\"{PString}\"}}";
        }
    }
}
