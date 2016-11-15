using System.ComponentModel.DataAnnotations;

namespace TestPartialClass
{
    // https://msdn.microsoft.com/en-us/library/ee256141%28v=vs.100%29.aspx
    [MetadataType(typeof(AExtension))]
    public partial class A
    {
        private class AExtension
        {
            [CustomAttribute(Value = "blah-blah-blah")]
            public string FStringI { get; set; }

            [Required(ErrorMessage = "Error message for FStringII")]
            public string FStringII { get; set; }
        }
    }
}
