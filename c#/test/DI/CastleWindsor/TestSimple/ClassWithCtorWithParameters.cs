﻿namespace TestSimple
{
    public class ClassWithCtorWithParameters : IClassWithCtorWithParameters
    {
        public int PInt { get; set; }
        public string PString { get; set; }

        public ClassWithCtorWithParameters(int pInt = 0, string pString = "")
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
