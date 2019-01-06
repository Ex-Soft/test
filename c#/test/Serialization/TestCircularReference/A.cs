using System.Runtime.Serialization;

namespace TestCircularReference
{
    [DataContract(IsReference = true)]
    public class A
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public B PB { get; set; }
        [DataMember]
        public C PC { get; set; }
    }
}
