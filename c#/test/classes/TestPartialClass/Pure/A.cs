namespace TestPartialClass
{
    public partial class A
    {
        public string FStringI { get; set; }

        [CustomAttribute(Value = "blah-blah-blah")]
        public string FStringII { get; set; }
    }
}
