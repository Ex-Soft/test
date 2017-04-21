using System;
using System.Collections.Generic;

namespace TestJson.Common
{
    enum TestEnum
    {
        Zero,
        First,
        Second,
        Third
    }

    class TestObject
    {
        public bool FBool { get; set; }
        public string FString { get; set; }
        public int FInt { get; set; }
        public float FFloat { get; set; }
        public double FDouble { get; set; }
        public decimal FDecimal { get; set; }
        public DateTime FDateTime { get; set; }
        public object FObject { get; set; }
        public byte[] FArrayBytes { get; set; }
        public int[] FArrayInts { get; set; }
        public List<int> FListInts { get; set; }
        public TestObject[] FArrayTestObjects { get; set; }
        public List<TestObject> FListTestObjects { get; set; }
        public TestEnum FTestEnum { get; set; }
    }
}
